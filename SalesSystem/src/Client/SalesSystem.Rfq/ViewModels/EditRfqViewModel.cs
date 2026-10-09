namespace SalesSystem.Rfq.ViewModels
{
    public partial class EditRfqViewModel : ObservableObject, IAsyncInitializable, IDisposable
    {
        readonly RfqUxClientService _RfqUxClientService;
        readonly DsiUxClientService _DsiUxClientService;
        readonly NprRequestWorkflowService _NprRequestWorkflowService;
        readonly ILogger<EditRfqViewModel> _Logger;
        readonly ISnackbar _Snackbar;
        readonly IDialogService _DialogService;
        readonly NavigationManager _Navigation;

        #region Attribs
        //[Parameter]
        //public IReadOnlySet<long> PreselectedDerivativeIds { get; set; } = new HashSet<long>();
        // Reference to the Composites component, wired up by the EditRfq component.
        public Composites? CompositesRef { get; set; }
        // Store the current selection from the CompositeCards checkboxes
        IEnumerable<DsiComponentUxModel> _SelectedComponents = new List<DsiComponentUxModel>();
        // Reference to the Harnesses
        readonly List<DsiHarnessUxModel> _Composites = new();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Consumed by Composites component which requires List<T>")]
        public List<DsiHarnessUxModel> Composites => _Composites;
        public HashSet<long> PreselectedDerivativeIds { get; } = new HashSet<long>();
        // Reference to the NprRequestsEditor component, wired up by the EditRfq component.
        public NprRequestsEditor? ComponentNprEditor { get; set; }

        // Search All state tracking
        [ObservableProperty]
        bool _IsSearchingAll;
        CancellationTokenSource? _SearchCancellationTokenSource;

        // Helper property for total parts count
        public int TotalParts => CompletedParts.Count + InProgressParts.Count;

        // Form related
        [ObservableProperty]
        bool _IsLoading = true;

        // this is set in InitializeAsync based on the RfqProjectId parameter
        [ObservableProperty]
        RfqProjectUxModel? _RfqProject;

        // Simplified project selection (like CreateRfq)
        [ObservableProperty]
        RfqCustomerProjectAssociationUxModel? _SelectedProject;

        // Part numbers data - changed to List for mutability
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalParts))]
        List<RfqDrawingPartNumberUxModel> _CompletedParts = new List<RfqDrawingPartNumberUxModel>();
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalParts))]
        List<RfqDrawingPartNumberUxModel> _InProgressParts = new List<RfqDrawingPartNumberUxModel>();

        // Submit NPRs state tracking
        [ObservableProperty]
        bool _IsSubmittingNprs;

        // Active tab index for programmatic tab switching
        [ObservableProperty]
        int _ActiveTabIndex;
        #endregion

        public EditRfqViewModel(
            RfqUxClientService rfqUxClientService,
            DsiUxClientService dsiUxClientService,
            NprRequestWorkflowService nprRequestWorkflowService,
            ILogger<EditRfqViewModel> logger,
            ISnackbar snackbar,
            IDialogService dialogService,
            NavigationManager navigation)
        {
            _RfqUxClientService = rfqUxClientService;
            _DsiUxClientService = dsiUxClientService;
            _NprRequestWorkflowService = nprRequestWorkflowService;
            _Logger = logger;
            _Snackbar = snackbar;
            _DialogService = dialogService;
            _Navigation = navigation;
            IsSearchingAll = false;
        }

        #region Parameters

        public long RfqProjectId { get; set; }
        [ObservableProperty]
        GlobalValue? _GlobalValue;
        #endregion

        public IReadOnlyCollection<RfqReasonGrpc> Reasons => _RfqUxClientService.Reasons;

        void NotifyStateChanged()
        {
            OnPropertyChanged(string.Empty);
        }

        // Reacts to project selection changes (replaces the old OnAfterRender diffing logic).
        partial void OnSelectedProjectChanged(RfqCustomerProjectAssociationUxModel? value)
        {
            if (RfqProject == null)
            {
                return;
            }

            if (value != null)
            {
                RfqProject.ProjectId = value.ProjectId!;
                _Logger.GenericLogInformation($"EditRfq.OnSelectedProjectChanged - ProjectName changed to {value.Id} - {value.ProjectCode}");
            }
            else
            {
                RfqProject.ProjectId = "";
                _Logger.GenericLogInformation("EditRfq.OnSelectedProjectChanged - ProjectName cleared");
            }
        }

        #region Events
        public async Task InitializeAsync()
        {
            IsLoading = true;
            if (GlobalValue?.UserId == null || GlobalValue.UserId == Guid.Empty)
            {
                _Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                _Snackbar.Add("Not an authenticated user", Severity.Error);
                _Logger.GenericLogInformation("EditRfq.OnInitializedAsync - UserId is missing in the URL");
                IsLoading = false;
                _Navigation.NavigateTo("/");
            }

            _ = UpdateRfqNprRequestsAsync();
            try
            {
                if (await LoadDataAsync())
                {

                    // load the composites
                    await LoadCompositesAsync();
                    // load Npr requests for the RFQ project
                    await LoadNprRequests();
                }

                if(_Composites.Count == 0)
                {
                    // no derivatives loaded, so switch to the parts tab
                    ActiveTabIndex = 1; // Switch to "Parts Lists" tab 
                }
            }
            catch (InvalidOperationException ex)
            {
                _Logger.GenericLogError("EditRfq.OnInitializedAsync - Invalid operation error loading RFQ project", ex);
                _Snackbar.Add("Error loading RFQ project", Severity.Error);
                _Navigation.NavigateTo("/");
                throw;
            }
            catch (ArgumentNullException ex)
            {
                _Logger.GenericLogError("EditRfq.OnInitializedAsync - Argument null error loading RFQ project", ex);
                _Snackbar.Add("Error loading RFQ project", Severity.Error);
                _Navigation.NavigateTo("/");
                throw;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("EditRfq.OnInitializedAsync - Error loading RFQ project", ex);
                _Snackbar.Add("Error loading RFQ project", Severity.Error);
                _Navigation.NavigateTo("/");
                throw;
            }
            finally
            {
                IsLoading = false;
                NotifyStateChanged();
            }
        }

        #endregion

        #region Load rfq data
        async Task<bool> LoadDataAsync()
        {
            if(GlobalValue?.UserId == null || GlobalValue.UserId == Guid.Empty)
            {
                _Logger.GenericLogInformation($"EditRfq.LoadDataAsync - UserId is missing, cannot load data");
                return false;
            }

            if (_RfqUxClientService.Customers.Count == 0)
            {
                Func<Guid, Task<int>> guidAsyncService = _RfqUxClientService.GetCustomersByUserIdAsync;
                (long timing, int count) = await guidAsyncService.TimeAsyncGuidIntService((Guid)GlobalValue.UserId);
                _Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Loaded {count} customers for UserId {GlobalValue?.UserId} in {timing}ms");
            }

            if (_RfqUxClientService.Reasons.Count == 0)
            {
                Func<Task<int>> guidAsyncService = _RfqUxClientService.GetRfqReasonsAsync;
                (long timing, int count) = await guidAsyncService.TimeAsyncVoidIntService();
                _Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Loaded {count} reasons in {timing}ms");
            }

            // load the RfqProject and part numbers
            return await LoadRfqAndPartNumbersAsync();
        }

        async Task<bool> LoadRfqAndPartNumbersAsync()
        {
            bool success = false;
            // get the project
            RfqProject? rfqProject = await _RfqUxClientService.GetRfqProjectByIdAsync(RfqProjectId);
            if (rfqProject == null)
            {
                _Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                _Snackbar.Add($"RFQ ProjectName with Id {RfqProjectId} not found", Severity.Error);
                _Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - RFQ ProjectName with Id {RfqProjectId} not found");
                _Navigation.NavigateTo("/");
                return success;
            }
            else
            {
                _Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Retrieved RFQ ProjectName with Id {rfqProject.RowId} - {rfqProject.RfqNumber} - Customer {rfqProject.CustomerBusinessUnitGuid} / {rfqProject.CustomerBusinessGroupCode} - ProjectName {rfqProject.ProjectGuid} / {rfqProject.ProjectName}");
            }

            if (_RfqUxClientService.CustomerProjectAssociations.Count == 0)
            {
                Func<string, Task<int>> stringAsyncService = _RfqUxClientService.GetProjectAssociationsByCustomerIdAsync;
                (long timing, int count) = await stringAsyncService.TimeAsyncStringIntService(rfqProject.CustomerBusinessUnitGuid);
                _Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Loaded {count} customerProjectAssociations for CustomerBusinessUnitGuid {rfqProject.CustomerBusinessUnitGuid} in {timing}ms");
            }

            RfqProject = rfqProject.ToUx();
            if (RfqProject == null)
            {
                _Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                _Snackbar.Add($"Error mapping RFQ ProjectName with Id {RfqProjectId}", Severity.Error);
                _Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Error mapping RFQ ProjectName with Id {RfqProjectId}");
                _Navigation.NavigateTo("/");
                return success;
            }
            else
            {
                // Set the selected project from the loaded RfqProject
                SelectedProject = _RfqUxClientService.CustomerProjectAssociations
                    .FirstOrDefault(p => p.ProjectId == RfqProject.ProjectId);
                if (SelectedProject != null)
                {
                    RfqProject.ProjectName = SelectedProject.ProjectCode;
                    RfqProject.ProjectName = SelectedProject.ProjectName;
                    RfqProject.CustomerCode = SelectedProject.CustomerCode ?? string.Empty;
                }

                RfqProject.RfqReasonName = _RfqUxClientService.Reasons.FirstOrDefault(r => r.RowId == RfqProject.RfqReasonId)?.RfqReasonTitle ?? string.Empty;

                IsLoading = false;
                success = true;
                _Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Loaded RFQ ProjectName with Id {RfqProject.RowId} - {RfqProject.RfqNumber} {RfqProject.ProjectId}");
            }

            // get the part numbers
            int partNumbersCount = await _RfqUxClientService.GetRfqDrawingPartNumbersByRfqIdAsync(RfqProjectId);
            if (partNumbersCount > 0)
            {
                CompletedParts = _RfqUxClientService.RfqDrawingPartNumbers.Where(x => x?.IsCompleted == true).Cast<RfqDrawingPartNumberUxModel>().ToList();
                InProgressParts = _RfqUxClientService.RfqDrawingPartNumbers.Where(x => x?.IsCompleted == false).Cast<RfqDrawingPartNumberUxModel>().ToList();
            }

            return success;
        }

        async Task LoadNprRequests()
        {
            await Task.Delay(1);
            List<RfqNprRequestUxModel>? nprRequests = await _RfqUxClientService.GetNprRequestsByRfqNumberAsync(RfqProject?.RfqNumber);
            if (nprRequests != null)
            {
                RfqProject!.NprRequests = nprRequests;
            }
            // update the npr status names
            List<RFQStatusGrpc> rfqStatuses = _RfqUxClientService.RFQStatuses.ToList();
            foreach (RfqNprRequestUxModel? nprRequest in RfqProject?.NprRequests ?? Enumerable.Empty<RfqNprRequestUxModel>())
            {
                if (nprRequest != null)
                {
                    nprRequest.StatusName = rfqStatuses.FirstOrDefault(s => s.NPRStage == nprRequest.Status.ToString(CultureInfo.InvariantCulture))?.RFQStatusDescription ?? string.Empty;
                }
            }
        }

        async Task LoadCompositesAsync()
        {
            _Composites.Clear();

            if (RfqProject == null
                || string.IsNullOrWhiteSpace(RfqProject.JsonData))
            {
                return;
            }

            // Composite data is stored in the JsonData field of the RfqProject,
            // so we need to deserialize it.
            SelectionLogData? selectionLog = null;

            try
            {
                JsonSerializerOptions serializerOptions =
                    new JsonSerializerOptions();

                serializerOptions.PropertyNameCaseInsensitive = true;
                serializerOptions.PreferredObjectCreationHandling =
                    JsonObjectCreationHandling.Populate;

                selectionLog =
                    JsonSerializer.Deserialize<SelectionLogData>(
                        RfqProject.JsonData,
                        serializerOptions);
            }
            catch (JsonException ex)
            {
                _Logger.GenericLogError(
                    "Error parsing JsonData for SelectionLogData",
                    ex);

                return;
            }

            if (selectionLog == null)
            {
                _Logger.GenericLogInformation(
                    "SelectionLogData is null");

                return;
            }

            HashSet<Guid> harnessIds = new HashSet<Guid>();

            // New format: multiple harnesses.
            if (selectionLog.HarnessIds.Count > 0)
            {
                foreach (string harnessId in selectionLog.HarnessIds)
                {
                    if (Guid.TryParse(
                            harnessId,
                            out Guid parsedId))
                    {
                        harnessIds.Add(parsedId);
                    }
                    else
                    {
                        _Logger.GenericLogInformation(
                            $"Invalid HarnessId format: {harnessId}");
                    }
                }
            }
            // Backward compatibility: single harness.
            else if (!string.IsNullOrWhiteSpace(selectionLog.HarnessId))
            {
                if (Guid.TryParse(
                        selectionLog.HarnessId,
                        out Guid parsedId))
                {
                    harnessIds.Add(parsedId);
                }
                else
                {
                    _Logger.GenericLogInformation(
                        $"Invalid HarnessId format: {selectionLog.HarnessId}");
                }
            }

            if (harnessIds.Count == 0)
            {
                _Logger.GenericLogInformation(
                    "No valid HarnessIds found in JsonData");

                return;
            }

            await _DsiUxClientService.GetAllHarnessAsync();

            IEnumerable<DsiHarnessUxModel> linkedHarnesses =
                _DsiUxClientService.Harnesses
                    .Where(
                        harness =>
                        {
                            return harnessIds.Contains(harness.Id);
                        })
                    .GroupBy(harness => harness.Id)
                    .Select(group => group.First());

            _Composites.AddRange(linkedHarnesses);

            _Logger.GenericLogInformation(
                $"LoadCompositesAsync - Found {_Composites.Count} " +
                $"linked harnesses from {harnessIds.Count} stored HarnessIds");

            PreselectedDerivativeIds.Clear();

            if (selectionLog.Selections != null
                && selectionLog.Selections.Any())
            {
                foreach (SelectedCompositeData selection
                         in selectionLog.Selections)
                {
                    PreselectedDerivativeIds.Add(
                        selection.Id);
                }
            }
        }

        public bool IsCreateNprRequestsPermitted
        {
            get
            {
                int nprRequestAlreadyExists = 0;

                foreach (RfqDrawingPartNumberUxModel? drawingPartNumber in InProgressParts)
                {
                    if (RfqProject?.NprRequests.Any(x => x.CustomerPartNumber == drawingPartNumber?.CustomerPartNumber) == true)
                    {
                        nprRequestAlreadyExists++;
                    }
                }

                return InProgressParts.Count <= nprRequestAlreadyExists;
            }
        }

        // NprAllInProgressPartsAsync - delegates orchestration to _NprRequestWorkflowService
        public async Task NprAllInProgressPartsAsync()
        {
            bool changed = await _NprRequestWorkflowService.NprAllInProgressPartsAsync(
                RfqProject,
                InProgressParts,
                GlobalValue,
                SaveDataAsync);

            NotifyStateChanged();
        }

        public async Task SubmitNprRequestsAsync()
        {
            IsSubmittingNprs = true;
            NotifyStateChanged();

            try
            {
                await _NprRequestWorkflowService.SubmitAllNprRequestsAsync(
                    RfqProject,
                    HasPendingNprEditorChanges,
                    SaveNprEditorPendingChangesIfAnyAsync,
                    LoadNprRequests,
                    NotifyNprEditorStateChanged);
            }
            finally
            {
                IsSubmittingNprs = false;
            }

            NotifyStateChanged();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public async Task ShowDatasetStatusAsync()
        {
            DialogParameters parameters = new DialogParameters
            {
                { nameof(DatasetStatusDialog.MatchedParts), CompletedParts },
                { nameof(DatasetStatusDialog.UnmatchedParts), InProgressParts },
                { nameof(DatasetStatusDialog.RfqNumber), RfqProject?.RfqNumber ?? string.Empty }
            };

            DialogOptions options = new DialogOptions
            {
                MaxWidth = MaxWidth.Large,
                FullWidth = true,
                CloseButton = true,
                CloseOnEscapeKey = true
            };

            IDialogReference dialog = await _DialogService.ShowAsync<DatasetStatusDialog>(
                $"Dataset Status – {RfqProject?.RfqNumber}",
                parameters,
                options
            );

            await dialog.Result;
        }

        #endregion

        #region Reason
        public async Task OnReasonValueChanged(int? value)
        {
            RfqProject!.RfqReasonId = value ?? 0;

            await Task.Delay(0);

            RfqReasonGrpc? reason = _RfqUxClientService.Reasons.FirstOrDefault(r => r.RowId == (value ?? 0));

            _Logger.GenericLogInformation($"EditRfq.OnReasonValueChanged - Reason changed to {reason?.RowId} - {reason?.RfqReasonTitle}");

            NotifyStateChanged();
        }
        #endregion

        #region Part Number

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public async Task ReloadDataAsync()
        {
            try
            {
                await LoadRfqAndPartNumbersAsync();

                // Reload NPR requests into RfqProject so the tab stays enabled
                await LoadNprRequests();

                // If the editor component is still alive, refresh its view too
                await RefreshNprEditorAsync();

                NotifyStateChanged();
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"EditRfq.ReloadDataAsync - Unexpected error during data reload {ex.Message}", ex);
            }
        }

        #region Npr Editor Coordination
        // Small coordination helpers so other methods (SubmitNprRequestsAsync,
        // ReloadDataAsync, SaveDataAsync) don't each need to null-check and
        // re-implement the same interaction with the NprRequestsEditor child component.
        bool HasPendingNprEditorChanges()
        {
            return ComponentNprEditor != null && ComponentNprEditor.HasPendingChanges;
        }

        Task SaveNprEditorPendingChangesIfAnyAsync()
        {
            return HasPendingNprEditorChanges()
                ? ComponentNprEditor!.SaveNprRequestsAsync()
                : Task.CompletedTask;
        }

        Task RefreshNprEditorAsync()
        {
            return ComponentNprEditor != null
                ? ComponentNprEditor.RefreshNprRequestsAsync()
                : Task.CompletedTask;
        }

        void NotifyNprEditorStateChanged()
        {
            ComponentNprEditor?.NotifyStateChanged();
        }
        #endregion

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public async Task SaveDataAsync()
        {
            if (RfqProject == null)
            {
                _Snackbar.Add(
                    "RFQ project is not available",
                    Severity.Error);

                _Logger.GenericLogInformation(
                    "EditRfq.SaveDataAsync - RfqProject is null");

                return;
            }

            List<RfqDrawingPartNumberUxModel> allParts =
                new List<RfqDrawingPartNumberUxModel>();

            allParts.AddRange(
                CompletedParts
                    .Where(part => part != null));

            allParts.AddRange(
                InProgressParts
                    .Where(part => part != null));

            try
            {
                // Save pending NPR changes before reloading the project.
                await SaveNprEditorPendingChangesIfAnyAsync();

                // Always save the BOM selection and HarnessIds,
                // even when the Parts Lists are empty.
                await UpdateSelectionAsync();

                // Persist the RFQ project, including JsonData.
                UpdateRfqProjectGrpcResponse rfqUpdateResult =
                    await _RfqUxClientService.UpdateRfqProjectAsync(
                        RfqProject);

                bool partsSaveSuccess = true;

                // Only call the parts update endpoint when parts exist.
                if (allParts.Count > 0)
                {
                    RfqCrudResponse partsUpdateResult =
                        await _RfqUxClientService
                            .UpdateRfqDrawingPartNumbersAsync(
                                allParts);

                    partsSaveSuccess =
                        partsUpdateResult.SaveSuccess;
                }
                else
                {
                    _Logger.GenericLogInformation(
                        "EditRfq.SaveDataAsync - " +
                        "No parts available. RFQ and BOM selection " +
                        "will still be saved.");
                }

                if (rfqUpdateResult.Success
                    && partsSaveSuccess)
                {
                    if (allParts.Count > 0)
                    {
                        _Snackbar.Add(
                            "Data saved successfully",
                            Severity.Success);
                    }
                    else
                    {
                        _Snackbar.Add(
                            "BOM selection saved successfully",
                            Severity.Success);
                    }

                    _Logger.GenericLogInformation(
                        "EditRfq.SaveDataAsync - " +
                        $"RFQ saved successfully. " +
                        $"Parts={allParts.Count}, " +
                        $"Harnesses={_Composites.Count}, " +
                        $"Selections=" +
                        $"{CompositesRef?.SelectedItems.Count ?? 0}");

                    // Reload RFQ and part-number data.
                    await LoadRfqAndPartNumbersAsync();

                    // Important: reload HarnessIds and selected derivative IDs
                    // from the newly saved JsonData.
                    await LoadCompositesAsync();

                    // Reload NPR requests so the tab remains enabled.
                    await LoadNprRequests();

                    NotifyNprEditorStateChanged();
                }
                else
                {
                    _Snackbar.Add(
                        "Error saving data",
                        Severity.Error);

                    _Logger.GenericLogInformation(
                        "EditRfq.SaveDataAsync - " +
                        $"Error saving data. " +
                        $"RfqSuccess={rfqUpdateResult.Success}, " +
                        $"PartsSuccess={partsSaveSuccess}");
                }

                NotifyStateChanged();
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError(
                    "EditRfq.SaveDataAsync - " +
                    $"Unexpected error during data save: {ex.Message}",
                    ex);

                _Snackbar.Add(
                    $"Error saving data: {ex.Message}",
                    Severity.Error);
            }
        }
        #endregion

        #region Search All

        // Snapshot of the BOM size taken at the start of a search run.
        // Used to assert the invariant: CompletedParts.Count + InProgressParts.Count <= initialTotalParts.
        int _SearchInitialTotalParts;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public async Task SearchAllPartNumbersAsync()
        {
            if (InProgressParts == null || !InProgressParts.Any())
            {
                _Snackbar.Add(
                    "No in-progress parts to search",
                    Severity.Info);

                return;
            }

            bool? confirm = await _DialogService.ShowMessageBoxAsync(
                "Confirm Search All",
                $"Search EMACS for all {InProgressParts.Count} in-progress part(s)? " +
                "Auto-matched parts will be moved to Completed.",
                yesText: "Search All",
                cancelText: "Cancel");

            if (confirm != true)
            {
                return;
            }

            IsSearchingAll = true;

            _SearchCancellationTokenSource?.Dispose();
            _SearchCancellationTokenSource = new CancellationTokenSource();

            CancellationToken cancellationToken =
                _SearchCancellationTokenSource.Token;

            _SearchInitialTotalParts = TotalParts;

            // Create a snapshot so the original lists can be modified safely.
            List<RfqDrawingPartNumberUxModel> partsSnapshot =
                InProgressParts
                    .Where(part => part != null)
                    .ToList();

            if (partsSnapshot.Count == 0)
            {
                _Snackbar.Add(
                    "No in-progress parts to search",
                    Severity.Info);

                IsSearchingAll = false;
                return;
            }

            // Build the progress-dialog labels.
            SearchProgressState progressState = new SearchProgressState();

            progressState.Initialize(
                partsSnapshot.Select(part =>
                {
                    List<string> displayPartNumbers = new List<string>();

                    if (!string.IsNullOrWhiteSpace(part.PartNumber1))
                    {
                        displayPartNumbers.Add(part.PartNumber1.Trim());
                    }
                    else if (!string.IsNullOrWhiteSpace(part.CustomerPartNumber))
                    {
                        displayPartNumbers.Add(
                            part.CustomerPartNumber.Trim());
                    }

                    if (!string.IsNullOrWhiteSpace(part.PartNumber2))
                    {
                        displayPartNumbers.Add(part.PartNumber2.Trim());
                    }

                    if (!string.IsNullOrWhiteSpace(part.PartNumber3))
                    {
                        displayPartNumbers.Add(part.PartNumber3.Trim());
                    }

                    displayPartNumbers = displayPartNumbers
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .ToList();

                    return displayPartNumbers.Count > 0
                        ? string.Join(" / ", displayPartNumbers)
                        : "(unknown)";
                }));

            progressState.OnCancelRequested = () =>
            {
                try
                {
                    _SearchCancellationTokenSource?.Cancel();
                }
                catch (ObjectDisposedException)
                {
                    // The cancellation token source was already disposed.
                }
            };

            DialogParameters parameters =
                new DialogParameters<SearchProgressDialog>
                {
            { x => x.ProgressState, progressState }
                };

            DialogOptions options = new DialogOptions
            {
                CloseButton = false,
                BackdropClick = false,
                CloseOnEscapeKey = false,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            IDialogReference dialog =
                await _DialogService.ShowAsync<SearchProgressDialog>(
                    "Search All Part Numbers",
                    parameters,
                    options);

            int processed = 0;
            int movedExact = 0;
            int movedContains = 0;
            int unmatched = 0;

            try
            {
                NotifyStateChanged();

                for (int partIndex = 0;
                     partIndex < partsSnapshot.Count;
                     partIndex++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    RfqDrawingPartNumberUxModel item =
                        partsSnapshot[partIndex];

                    /*
                     * Create one search list for this grid row.
                     *
                     * The list can contain:
                     * - PartNumber1
                     * - PartNumber2
                     * - PartNumber3
                     *
                     * CustomerPartNumber is used as a fallback for older records
                     * where PartNumber1 was not stored separately.
                     */
                    List<string> partNumbersToSearch =
                        new List<string>();

                    if (!string.IsNullOrWhiteSpace(item.PartNumber1))
                    {
                        partNumbersToSearch.Add(
                            item.PartNumber1.Trim());
                    }
                    else if (!string.IsNullOrWhiteSpace(
                                 item.CustomerPartNumber))
                    {
                        partNumbersToSearch.Add(
                            item.CustomerPartNumber.Trim());
                    }

                    if (!string.IsNullOrWhiteSpace(item.PartNumber2))
                    {
                        partNumbersToSearch.Add(
                            item.PartNumber2.Trim());
                    }

                    if (!string.IsNullOrWhiteSpace(item.PartNumber3))
                    {
                        partNumbersToSearch.Add(
                            item.PartNumber3.Trim());
                    }

                    // Remove duplicate and empty values.
                    partNumbersToSearch = partNumbersToSearch
                        .Where(partNumber =>
                            !string.IsNullOrWhiteSpace(partNumber))
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .ToList();

                    string progressPartNumbers =
                        partNumbersToSearch.Count > 0
                            ? string.Join(" / ", partNumbersToSearch)
                            : "(unknown)";

                    progressState.StartPart(
                        partIndex,
                        $"Searching {partIndex + 1} of " +
                        $"{partsSnapshot.Count}: " +
                        progressPartNumbers);

                    processed++;

                    // Clear previous search results before running this search.
                    item.SearchResultPartNumbers.Clear();
                    item.Comments = string.Empty;

                    if (partNumbersToSearch.Count == 0)
                    {
                        _Logger.GenericLogInformation(
                            $"EditRfq.SearchAllPartNumbersAsync - " +
                            $"No valid part numbers for RowId={item.RowId}");

                        progressState.CompletePartAsUnmatched(
                            partIndex,
                            "invalid part numbers");

                        unmatched++;
                        continue;
                    }

                    try
                    {
                        _Logger.GenericLogInformation(
                            $"EditRfq.SearchAllPartNumbersAsync - " +
                            $"Searching RowId={item.RowId}, " +
                            $"PartNumbers=[" +
                            $"{string.Join(", ", partNumbersToSearch)}]");

                        /*
                         * One gRPC call for this grid row.
                         *
                         * Example request:
                         * ["PART-1", "PART-2", "PART-3"]
                         */
                        SearchPartPricesGrpcResponse response =
                            await _RfqUxClientService
                                .SearchPartPricesAsync(
                                    partNumbersToSearch,
                                    cancellationToken);

                        int candidateIndex = 0;

                        /*
                         * The service should return one PriceResponse for each
                         * input part number. Process all returned responses.
                         */
                        foreach (PriceResponse priceResponse
                                 in response.PriceResponse)
                        {
                            string searchedPartNumber =
                                priceResponse.CustomerPartNumber?.Trim()
                                ?? string.Empty;

                            bool isExactMatch =
                                priceResponse.ExactMatch ?? false;

                            foreach (PriceInformation priceInfo
                                     in priceResponse.PriceInformation)
                            {
                                decimal candidatePrice =
                                    priceInfo.Price is double price
                                        ? Convert.ToDecimal(
                                            price,
                                            CultureInfo.InvariantCulture)
                                        : 0m;

                                RfqDrawingPartNumberUxModel candidate =
                                    new RfqDrawingPartNumberUxModel
                                    {
                                        Index = candidateIndex++,

                                        /*
                                         * Store the input part number that produced
                                         * this candidate.
                                         */
                                        CustomerPartNumber =
                                            searchedPartNumber,

                                        PartNumber1 =
                                            searchedPartNumber,

                                        DrawingPartNumber =
                                            priceInfo.SumitomoNumber
                                            ?? string.Empty,

                                        DrawingPartNumberPrice =
                                            candidatePrice,

                                        PriceSource =
                                            priceInfo.PriceSource
                                            ?? string.Empty,

                                        IsExactMatch =
                                            isExactMatch,

                                        IsSwapped =
                                            false
                                    };

                                item.SearchResultPartNumbers.Add(
                                    candidate);
                            }

                            _Logger.GenericLogInformation(
                                $"EditRfq.SearchAllPartNumbersAsync - " +
                                $"InputPart={searchedPartNumber}, " +
                                $"ExactMatch={isExactMatch}, " +
                                $"Candidates=" +
                                $"{priceResponse.PriceInformation.Count}");
                        }

                        _Logger.GenericLogInformation(
                            $"EditRfq.SearchAllPartNumbersAsync - " +
                            $"RowId={item.RowId}, " +
                            $"Searched=[" +
                            $"{string.Join(", ", partNumbersToSearch)}], " +
                            $"TotalCandidates=" +
                            $"{item.SearchResultPartNumbers.Count}");

                        /*
                         * First preference:
                         * Any exact match with a price.
                         */
                        RfqDrawingPartNumberUxModel? bestExact =
                            item.SearchResultPartNumbers
                                .FirstOrDefault(candidate =>
                                    candidate.IsExactMatch &&
                                    candidate.DrawingPartNumberPrice > 0m);

                        /*
                         * Second preference:
                         * A contains match with a price.
                         */
                        RfqDrawingPartNumberUxModel? bestContains =
                            bestExact == null
                                ? item.SearchResultPartNumbers
                                    .FirstOrDefault(candidate =>
                                        !candidate.IsExactMatch &&
                                        candidate.DrawingPartNumberPrice > 0m)
                                : null;

                        RfqDrawingPartNumberUxModel? bestMatch =
                            bestExact ?? bestContains;

                        if (bestMatch != null)
                        {
                            string matchedInputPartNumber =
                                bestMatch.CustomerPartNumber;

                            item.DrawingPartNumber =
                                bestMatch.DrawingPartNumber;

                            item.DrawingPartNumberPrice =
                                bestMatch.DrawingPartNumberPrice;

                            item.IsExactMatch =
                                bestExact != null;

                            item.IsSwapped =
                                false;

                            item.PriceSource =
                                bestMatch.PriceSource;

                            item.Status = bestExact != null
                                ? RfqDrawingPartNumberStatus.ExactMatch
                                : RfqDrawingPartNumberStatus.ContainsMatch;

                            bool updateSucceeded =
                                await _RfqUxClientService
                                    .UpdateRfqDrawingPartNumber(item);

                            if (updateSucceeded)
                            {
                                string matchDescription =
                                    $"{matchedInputPartNumber} -> " +
                                    $"{item.DrawingPartNumber} @ " +
                                    $"{item.DrawingPartNumberPrice:0.#####} €";

                                if (bestExact != null)
                                {
                                    movedExact++;

                                    progressState.CompletePartAsExactMatch(
                                        partIndex,
                                        $"exact: {matchDescription}");
                                }
                                else
                                {
                                    movedContains++;

                                    progressState
                                        .CompletePartAsContainsMatch(
                                            partIndex,
                                            $"contains: {matchDescription}");
                                }

                                _Logger.GenericLogInformation(
                                    $"EditRfq.SearchAllPartNumbersAsync - " +
                                    $"Auto-matched ({item.Status}): " +
                                    $"Input={matchedInputPartNumber}, " +
                                    $"Drawing={item.DrawingPartNumber}, " +
                                    $"Price={item.DrawingPartNumberPrice}");
                            }
                            else
                            {
                                _Logger.GenericLogInformation(
                                    $"EditRfq.SearchAllPartNumbersAsync - " +
                                    $"Failed to persist auto-match for " +
                                    $"RowId={item.RowId}");

                                progressState.CompletePartAsUnmatched(
                                    partIndex,
                                    "persist failed");

                                unmatched++;
                            }
                        }
                        else
                        {
                            unmatched++;

                            int candidateCount =
                                item.SearchResultPartNumbers.Count;

                            progressState.CompletePartAsUnmatched(
                                partIndex,
                                candidateCount == 0
                                    ? "no matches"
                                    : $"{candidateCount} candidate(s) " +
                                      "saved, no price");

                            _Logger.GenericLogInformation(
                                $"EditRfq.SearchAllPartNumbersAsync - " +
                                $"No priced match for [" +
                                $"{string.Join(", ", partNumbersToSearch)}]; " +
                                $"saved {candidateCount} candidate(s)");
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        _Logger.GenericLogError(
                            $"EditRfq.SearchAllPartNumbersAsync - " +
                            $"Error processing RowId={item.RowId}, " +
                            $"PartNumbers=[" +
                            $"{string.Join(", ", partNumbersToSearch)}]",
                            ex);

                        progressState.CompletePartAsError(
                            partIndex,
                            "Search failed!");

                        unmatched++;
                    }

                    // Allow the progress dialog to update after each grid row.
                    NotifyStateChanged();
                    await Task.Yield();
                }

                /*
                 * Move successfully matched rows from In Progress
                 * to Completed.
                 */
                List<RfqDrawingPartNumberUxModel> toMove =
                    InProgressParts
                        .Where(part =>
                            part.Status ==
                                RfqDrawingPartNumberStatus.ExactMatch ||
                            part.Status ==
                                RfqDrawingPartNumberStatus.ContainsMatch)
                        .ToList();

                foreach (RfqDrawingPartNumberUxModel part in toMove)
                {
                    InProgressParts.Remove(part);

                    if (!CompletedParts.Contains(part))
                    {
                        CompletedParts.Add(part);
                    }
                }

                Debug.Assert(
                    CompletedParts.Count + InProgressParts.Count ==
                    _SearchInitialTotalParts,
                    "SearchAllPartNumbersAsync changed total BOM size");

                string summary =
                    $"Processed {processed}, " +
                    $"exact-matched {movedExact}, " +
                    $"contains-matched {movedContains}, " +
                    $"unmatched {unmatched}";

                progressState.SetCompleted(summary);

                _Snackbar.Add(
                    $"Search All complete: {summary}",
                    unmatched == 0 &&
                    movedExact + movedContains > 0
                        ? Severity.Success
                        : Severity.Info);
            }
            catch (OperationCanceledException)
            {
                progressState.SetError(
                    "Search cancelled",
                    "Cancellation was requested by the user.",
                    isCompleted: true);

                _Snackbar.Add(
                    "Search All cancelled",
                    Severity.Warning);

                _Logger.GenericLogInformation(
                    "EditRfq.SearchAllPartNumbersAsync - " +
                    "Cancelled by user");
            }
            catch (Exception ex)
            {
                progressState.SetError(
                    "Search failed",
                    ex.Message,
                    isCompleted: true);

                _Logger.GenericLogError(
                    "EditRfq.SearchAllPartNumbersAsync - " +
                    "Unexpected error during Search All",
                    ex);

                _Snackbar.Add(
                    $"Search All failed: {ex.Message}",
                    Severity.Error);
            }
            finally
            {
                IsSearchingAll = false;
                progressState.OnCancelRequested = null;

                NotifyStateChanged();

                _ = await dialog.Result;
            }
        }
        #endregion

        public async Task HandleComponentsSelectedAsync(IEnumerable<DsiComponentUxModel> components)
        {
            // Save the selection from the composite cards
            _SelectedComponents = components;
            // Delete and clear the existing parts lists before adding new ones
            if (InProgressParts != null && InProgressParts.Any())
            {
                bool result = await _RfqUxClientService.DeleteRfqDrawingPartNumbers(InProgressParts!);
            }
            else
            {
                CompletedParts = new List<RfqDrawingPartNumberUxModel>();
            }

            if (CompletedParts != null && CompletedParts.Any())
            {
                bool result = await _RfqUxClientService.DeleteRfqDrawingPartNumbers(CompletedParts!);
            }
            else
            {
                InProgressParts = new List<RfqDrawingPartNumberUxModel>();
            }

            CompletedParts!.Clear();
            InProgressParts!.Clear();

            if(RfqProject == null)
            {
                _Logger.GenericLogInformation("EEE - EditRfq.HandleComponentsSelectedAsync - RfqProject is null");
                return;
            }

            foreach (DsiComponentUxModel component in components)
            {
                if (string.IsNullOrWhiteSpace(component.PartNumber1?.Trim()) 
                    || (string.IsNullOrWhiteSpace(component.PartNumber1?.Trim()) 
                        && string.IsNullOrWhiteSpace(component.PartNumber2?.Trim()) 
                        && string.IsNullOrWhiteSpace(component.PartNumber3?.Trim())))
                {
                    continue;
                }

                InProgressParts.Add(component.ToUx(RfqProject.RowId));
            }

            // Deduplicate entries by (PartNumber1, PartNumber2, PartNumber3), trimmed
            InProgressParts = DeduplicateByPartNumbers(InProgressParts!);

            ActiveTabIndex = 1; // Switch to "Parts Lists" tab
            NotifyStateChanged();
            await Task.CompletedTask;
        }
        static List<RfqDrawingPartNumberUxModel> DeduplicateByPartNumbers(IEnumerable<RfqDrawingPartNumberUxModel> parts)
        {
            HashSet<(string? PartNumber1, string? PartNumber2, string? PartNumber3)> seenKeys = new();
            List<RfqDrawingPartNumberUxModel> uniqueParts = new();

            foreach (RfqDrawingPartNumberUxModel part in parts)
            {
                (string? PartNumber1, string? PartNumber2, string? PartNumber3) key =
                    (part.PartNumber1?.Trim(), part.PartNumber2?.Trim(), part.PartNumber3?.Trim());

                if (seenKeys.Add(key))
                {
                    uniqueParts.Add(part);
                }
            }

            return uniqueParts;
        }

        async Task UpdateSelectionAsync()
        {
            HashSet<DsiCompositeDetailUxModel>? currentSelections =
                CompositesRef?.SelectedItems;

            SelectionLogData selectionLog =
                new SelectionLogData();

            selectionLog.RfqId = RfqProjectId;

            foreach (DsiHarnessUxModel composite in _Composites)
            {
                string harnessId = composite.Id.ToString();

                if (!selectionLog.HarnessIds.Contains(harnessId))
                {
                    selectionLog.HarnessIds.Add(harnessId);
                }
            }

            // Keep the old single HarnessId property for backward compatibility.
            DsiHarnessUxModel? firstComposite =
                _Composites.FirstOrDefault();

            if (firstComposite != null)
            {
                selectionLog.HarnessId =
                    firstComposite.Id.ToString();
            }

            if (currentSelections != null
                && currentSelections.Count > 0)
            {
                List<SelectedCompositeData> selections =
                    new List<SelectedCompositeData>();

                foreach (DsiCompositeDetailUxModel selection
                         in currentSelections)
                {
                    SelectedCompositeData selectedComposite =
                        new SelectedCompositeData();

                    selectedComposite.Id = selection.Id;
                    selectedComposite.HarnessName1 =
                        selection.HarnessName1;
                    selectedComposite.HarnessName2 =
                        selection.HarnessName2;
                    selectedComposite.Customer =
                        selection.Customer;

                    selections.Add(selectedComposite);
                }

                selectionLog.Selections = selections;
            }
            else
            {
                selectionLog.Selections =
                    new List<SelectedCompositeData>();
            }

            JsonSerializerOptions serializerOptions =
                new JsonSerializerOptions();

            serializerOptions.WriteIndented = true;

            string jsonOutput =
                JsonSerializer.Serialize(
                    selectionLog,
                    serializerOptions);

            _Logger.GenericLogInformation(
                $">>> Serializing derivatives selection JSON data: " +
                $"{jsonOutput}");

            if (RfqProject != null)
            {
                RfqProject.JsonData = jsonOutput;
            }

            await Task.CompletedTask;
        }

        // update npr requests
        async Task UpdateRfqNprRequestsAsync()
        {
            _Logger.GenericLogInformation("updating RfqNprRequests...");
            Stopwatch sw = Stopwatch.StartNew();

            bool status = await _RfqUxClientService.UpdateRfqNprRequestStatusAsync();

            sw.Stop();
            _Logger.GenericLogInformation($"updating RfqNprRequests - Updated NPR requests in {sw.ElapsedMilliseconds}ms");
            if(status)
            {
                _Logger.GenericLogInformation("updating RfqNprRequests - NPR requests updated successfully");
            }
            else
            {
                _Logger.GenericLogInformation("updating RfqNprRequests - NPR requests update failed");
            }
        }

        #region Disposal
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _SearchCancellationTokenSource?.Dispose();
            }
        }
        #endregion

    }
}
