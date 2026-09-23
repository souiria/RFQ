namespace SalesSystem.Rfq.Components.Pages
{
    public partial class EditRfq : IDisposable
    {
        #region Attribs
        //[Parameter]
        //public IReadOnlySet<long> PreselectedDerivativeIds { get; set; } = new HashSet<long>();
        Composites? _CompositesRef;
        // Store the current selection from the CompositeCards checkboxes
        IEnumerable<DsiComponentUxModel> _SelectedComponents = new List<DsiComponentUxModel>();
        // Reference to the Harnesses
        readonly List<DsiHarnessUxModel> _Composites;
        HashSet<long> _PreselectedDerivativeIds = new HashSet<long>();
        NprRequestsEditor? _ComponentNprEditor;

        // Search All state tracking
        bool _IsSearchingAll;
        CancellationTokenSource? _SearchCancellationTokenSource;

        // Reference to autocomplete for reset
        //MudAutocomplete<RfqCustomerProjectAssociationUxModel>? _ProjectAutocomplete;

        // Helper property for total parts count
        int TotalParts => _CompletedParts.Count + _InProgressParts.Count;

        // Form related
        bool IsLoading
        { get; set; }
        // this is set in the OnInitialAsync based on the RfqProjectId parameter
        RfqProjectUxModel? RfqProject 
        { get; set; }

        // Simplified project selection (like CreateRfq)
        RfqCustomerProjectAssociationUxModel? SelectedProject
        { get; set; }

        // Track previous selected project to detect changes
        RfqCustomerProjectAssociationUxModel? _PreviousSelectedProject;

        // Part numbers data - changed to List for mutability
        List<RfqDrawingPartNumberUxModel> _CompletedParts = new List<RfqDrawingPartNumberUxModel>();
        List<RfqDrawingPartNumberUxModel> _InProgressParts = new List<RfqDrawingPartNumberUxModel>();

        // Submit NPRs state tracking
        bool _IsSubmittingNprs;

        // Active tab index for programmatic tab switching
        int _ActiveTabIndex;
        #endregion

        public EditRfq()
        {
            _IsSearchingAll = false;
            IsLoading = true;
            // FileObjects = new List<FileObjectUxModel>();
            _Composites = new();
        }

        #region Parameters

        //[Parameter] public Guid? UserId { get; set; }
        [Parameter] public long RfqProjectId { get; set; }
        [CascadingParameter(Name = "GlobalValue")]
        public GlobalValue? GlobalValue { get; set; }
        #endregion

        #region Events
        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            if (GlobalValue?.UserId == null || GlobalValue.UserId == Guid.Empty)
            {
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                Snackbar.Add("Not an authenticated user", Severity.Error);
                Logger.GenericLogInformation("EditRfq.OnInitializedAsync - UserId is missing in the URL");
                IsLoading = false;
                NavigationManager.NavigateTo("/");
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
                    _ActiveTabIndex = 1; // Switch to "Parts Lists" tab 
                }
            }
            catch (InvalidOperationException ex)
            {
                Logger.GenericLogError("EditRfq.OnInitializedAsync - Invalid operation error loading RFQ project", ex);
                Snackbar.Add("Error loading RFQ project", Severity.Error);
                NavigationManager.NavigateTo("/");
                throw;
            }
            catch (ArgumentNullException ex)
            {
                Logger.GenericLogError("EditRfq.OnInitializedAsync - Argument null error loading RFQ project", ex);
                Snackbar.Add("Error loading RFQ project", Severity.Error);
                NavigationManager.NavigateTo("/");
                throw;
            }
            catch (Exception ex)
            {
                Logger.GenericLogError("EditRfq.OnInitializedAsync - Error loading RFQ project", ex);
                Snackbar.Add("Error loading RFQ project", Severity.Error);
                NavigationManager.NavigateTo("/");
                throw;
            }
            finally
            {
                IsLoading = false;
                StateHasChanged();
            }
        }

        // Watch for project selection changes
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (!firstRender)
            {
                // Update RfqProject.ProjectId when SelectedProject changes
                if (SelectedProject != _PreviousSelectedProject)
                {
                    if (SelectedProject != null)
                    {
                        RfqProject!.ProjectId = SelectedProject.ProjectId!;
                        Logger.GenericLogInformation($"EditRfq.OnAfterRender - ProjectName changed to {SelectedProject.Id} - {SelectedProject.ProjectCode}");
                    }
                    else
                    {
                        RfqProject!.ProjectId = "";
                        Logger.GenericLogInformation($"EditRfq.OnAfterRender - ProjectName cleared");
                    }

                    _PreviousSelectedProject = SelectedProject;
                }
            }
        }
        #endregion

        #region Load rfq data
        async Task<bool> LoadDataAsync()
        {
            if(GlobalValue?.UserId == null || GlobalValue.UserId == Guid.Empty)
            {
                Logger.GenericLogInformation($"EditRfq.LoadDataAsync - UserId is missing, cannot load data");
                return false;
            }

            if (RfqUxClientService.Customers.Count == 0)
            {
                Func<Guid, Task<int>> guidAsyncService = RfqUxClientService.GetCustomersByUserIdAsync;
                (long timing, int count) = await guidAsyncService.TimeAsyncGuidIntService((Guid)GlobalValue.UserId);
                Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Loaded {count} customers for UserId {GlobalValue?.UserId} in {timing}ms");
            }

            if (RfqUxClientService.Reasons.Count == 0)
            {
                Func<Task<int>> guidAsyncService = RfqUxClientService.GetRfqReasonsAsync;
                (long timing, int count) = await guidAsyncService.TimeAsyncVoidIntService();
                Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Loaded {count} reasons in {timing}ms");
            }

            // load the RfqProject and part numbers
            return await LoadRfqAndPartNumbersAsync();
        }

        async Task<bool> LoadRfqAndPartNumbersAsync()
        {
            bool success = false;
            // get the project
            RfqProject? rfqProject = await RfqUxClientService.GetRfqProjectByIdAsync(RfqProjectId);
            if (rfqProject == null)
            {
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                Snackbar.Add($"RFQ ProjectName with Id {RfqProjectId} not found", Severity.Error);
                Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - RFQ ProjectName with Id {RfqProjectId} not found");
                NavigationManager.NavigateTo("/");
                return success;
            }
            else
            {
                Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Retrieved RFQ ProjectName with Id {rfqProject.RowId} - {rfqProject.RfqNumber} - Customer {rfqProject.CustomerBusinessUnitGuid} / {rfqProject.CustomerBusinessGroupCode} - ProjectName {rfqProject.ProjectGuid} / {rfqProject.ProjectName}");
            }

            if (RfqUxClientService.CustomerProjectAssociations.Count == 0)
            {
                Func<string, Task<int>> stringAsyncService = RfqUxClientService.GetProjectAssociationsByCustomerIdAsync;
                (long timing, int count) = await stringAsyncService.TimeAsyncStringIntService(rfqProject.CustomerBusinessUnitGuid);
                Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Loaded {count} customerProjectAssociations for CustomerBusinessUnitGuid {rfqProject.CustomerBusinessUnitGuid} in {timing}ms");
            }

            RfqProject = rfqProject.ToUx();
            if (RfqProject == null)
            {
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                Snackbar.Add($"Error mapping RFQ ProjectName with Id {RfqProjectId}", Severity.Error);
                Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Error mapping RFQ ProjectName with Id {RfqProjectId}");
                NavigationManager.NavigateTo("/");
                return success;
            }
            else
            {
                // Set the selected project from the loaded RfqProject
                SelectedProject = RfqUxClientService.CustomerProjectAssociations
                    .FirstOrDefault(p => p.ProjectId == RfqProject.ProjectId);
                if (SelectedProject != null)
                {
                    RfqProject.ProjectName = SelectedProject.ProjectCode;
                    RfqProject.ProjectName = SelectedProject.ProjectName;
                    RfqProject.CustomerCode = SelectedProject.CustomerCode ?? string.Empty;
                }

                RfqProject.RfqReasonName = RfqUxClientService.Reasons.FirstOrDefault(r => r.RowId == RfqProject.RfqReasonId)?.RfqReasonTitle ?? string.Empty;

                _PreviousSelectedProject = SelectedProject;
                IsLoading = false;
                success = true;
                Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Loaded RFQ ProjectName with Id {RfqProject.RowId} - {RfqProject.RfqNumber} {RfqProject.ProjectId}");
            }

            // get the part numbers
            int partNumbersCount = await RfqUxClientService.GetRfqDrawingPartNumbersByRfqIdAsync(RfqProjectId);
            if (partNumbersCount > 0)
            {
                _CompletedParts = RfqUxClientService.RfqDrawingPartNumbers.Where(x => x?.IsCompleted == true).Cast<RfqDrawingPartNumberUxModel>().ToList();
                _InProgressParts = RfqUxClientService.RfqDrawingPartNumbers.Where(x => x?.IsCompleted == false).Cast<RfqDrawingPartNumberUxModel>().ToList();
            }

            return success;
        }

        async Task LoadNprRequests()
        {
            await Task.Delay(1);
            List<RfqNprRequestUxModel>? nprRequests = await RfqUxClientService.GetNprRequestsByRfqNumberAsync(RfqProject?.RfqNumber);
            if (nprRequests != null)
            {
                RfqProject!.NprRequests = nprRequests;
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
                Logger.GenericLogError(
                    "Error parsing JsonData for SelectionLogData",
                    ex);

                return;
            }

            if (selectionLog == null)
            {
                Logger.GenericLogInformation(
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
                        Logger.GenericLogInformation(
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
                    Logger.GenericLogInformation(
                        $"Invalid HarnessId format: {selectionLog.HarnessId}");
                }
            }

            if (harnessIds.Count == 0)
            {
                Logger.GenericLogInformation(
                    "No valid HarnessIds found in JsonData");

                return;
            }

            await DsiUxClientService.GetAllHarnessAsync();

            IEnumerable<DsiHarnessUxModel> linkedHarnesses =
                DsiUxClientService.Harnesses
                    .Where(
                        harness =>
                            harnessIds.Contains(harness.Id))
                    .GroupBy(harness => harness.Id)
                    .Select(group => group.First());

            _Composites.AddRange(linkedHarnesses);

            Logger.GenericLogInformation(
                $"LoadCompositesAsync - Found {_Composites.Count} " +
                $"linked harnesses from {harnessIds.Count} stored HarnessIds");

            _PreselectedDerivativeIds.Clear();

            if (selectionLog.Selections != null
                && selectionLog.Selections.Any())
            {
                foreach (SelectedCompositeData selection
                         in selectionLog.Selections)
                {
                    _PreselectedDerivativeIds.Add(
                        selection.Id);
                }
            }
        }

        public bool IsCreateNprRequestsPermitted
        {
            get
            {
                int nprRequestAlreadyExists = 0;

                foreach (RfqDrawingPartNumberUxModel? drawingPartNumber in _InProgressParts)
                {
                    if (RfqProject?.NprRequests.Any(x => x.CustomerPartNumber == drawingPartNumber?.CustomerPartNumber) == true)
                    {
                        nprRequestAlreadyExists++;
                    }
                }

                return _InProgressParts.Count <= nprRequestAlreadyExists;
            }
        }

        // it should be in the ux service
        RfqNprRequestUxModel? GetRfqNprRequestByCustomerNumber(RfqDrawingPartNumberUxModel part)
        {
            return RfqProject?.NprRequests.FirstOrDefault(x => x.CustomerPartNumber?.Trim().ToUpperInvariant() == part.CustomerPartNumber?.Trim().ToUpperInvariant());
        }
        // NprAllInProgressPartsAsync - creates flat list of requests
        async Task NprAllInProgressPartsAsync()
        {
            if (RfqProject == null)
            {
                Snackbar.Add("No Rfq ProjectName to process for NPR", Severity.Error);
                return;
            }

            if (_InProgressParts.Count == 0)
            {
                Snackbar.Add("No unmatched parts to process for NPR", Severity.Info);
                return;
            }

            try
            {
                bool? confirm = await DialogService.ShowMessageBoxAsync(
                    "Confirm NPR All",
                    $"Are you sure you want to create NPR requests for all {_InProgressParts.Count} unmatched part(s)? This will UPDATE CHANGES.",
                    yesText: "Create NPR for All",
                    cancelText: "Cancel"
                );

                if (confirm != true)
                {
                    return;
                }

                Logger.GenericLogInformation($"EditRfq.NprAllInProgressPartsAsync - Creating NPR for {_InProgressParts.Count} unmatched parts");

                await SaveDataAsync();

                List<RfqNprRequestUxModel> nprRequests = new List<RfqNprRequestUxModel>();
                DateTime now = DateTime.UtcNow;

                // check against all npr requests for duplicates
                int count = await RfqUxClientService.GetAllNprRequestsAsync();
                if (count > 0)
                {
                    // some records already there
                    List<RfqNprRequestUxModel> preExistingNprRequests = new();
                    List<RfqDrawingPartNumberUxModel> toNewNprRequests = new();

                    // look for same customer part and different rfq project
                    foreach (RfqDrawingPartNumberUxModel? r in _InProgressParts)
                    {
                        if (r is null)
                        {
                            continue;
                        }

                        RfqNprRequestUxModel? found = RfqUxClientService.NprRequests.FirstOrDefault(x => (r?.CustomerPartNumber == x?.CustomerPartNumber && x?.CustomerRfqNo != RfqProject.RfqNumber));
                        if (found != null)
                        {
                            preExistingNprRequests.Add(found);
                        }
                        else
                        {
                            toNewNprRequests.Add(r);
                        }
                    }

                    confirm = await DialogService.ShowMessageBoxAsync(
                        "Commit NPR Requests",
                        $"Are you sure you want to create {toNewNprRequests.Count} NPR requests and take over {preExistingNprRequests.Count} older NPR requests? This will UPDATE CHANGES.",
                        yesText: $"Commit {toNewNprRequests.Count + preExistingNprRequests.Count} NPR requests",
                        cancelText: "Cancel"
                    );

                    if (confirm != true)
                    {
                        return;
                    }

                    // act if ok
                    if (0 < toNewNprRequests.Count)
                    {
                        // new ones
                        foreach (RfqDrawingPartNumberUxModel? part in toNewNprRequests)
                        {
                            if (part != null)
                            {
                                //check if the part does not already has a npr request created in another project
                                RfqNprRequestUxModel? nprRequest = GetRfqNprRequestByCustomerNumber(part);
                                if (nprRequest == null)
                                {
                                    nprRequest = part.ToNprRequest(RfqProject);
                                    nprRequest.CustomerRfqNo = RfqProject.RfqNumber;
                                    nprRequest.Created = now;
                                    nprRequest.Updated = now;
                                    nprRequest.UxStatus = UxObjectStatus.Created;
                                    nprRequests.Add(nprRequest);
                                }
                            }
                        }

                        // update all relevant attributes
                        if(GlobalValue != null)
                        {
                            foreach (RfqNprRequestUxModel nprRequest in nprRequests)
                            {

                                nprRequest.Update(RfqProject, GlobalValue);
                            }
                        }

                        // persist
                        RfqProject.NprRequests.Clear();
                        List<RfqNprRequestUxModel> response = await RfqUxClientService.CreateNprRequestsAsync(nprRequests);
                        RfqProject.NprRequests.AddRange(response);

                        Snackbar.Add($"Successfully created new NPR request set for {toNewNprRequests.Count} part(s)", Severity.Success);
                        StateHasChanged();
                    }

                    if (0 < preExistingNprRequests.Count)
                    {
                        // update pre-existing ones
                        foreach (RfqNprRequestUxModel r in preExistingNprRequests)
                        {
                            r.CustomerRfqNo = RfqProject.RfqNumber;
                            r.Updated = DateTime.UtcNow;
                            r.UxStatus = UxObjectStatus.Updated;
                        }

                        // persist
                        List<RfqNprRequestUxModel> response = await RfqUxClientService.UpdateNprRequestsAsync(preExistingNprRequests);
                        RfqProject.NprRequests.AddRange(response);

                        Snackbar.Add($"Successfully updated pre-existing {preExistingNprRequests.Count} NPR request(s)", Severity.Success);
                        StateHasChanged();
                    }
                }
                else
                {
                    // no npr requests yet
                    foreach (RfqDrawingPartNumberUxModel? part in _InProgressParts.ToList())
                    {
                        if (part != null)
                        {
                            //check if the part does not already has a npr request created in another project
                            RfqNprRequestUxModel? nprRequest = GetRfqNprRequestByCustomerNumber(part);
                            if (nprRequest == null)
                            {
                                nprRequest = part.ToNprRequest(RfqProject);
                                nprRequest.CustomerRfqNo = RfqProject.RfqNumber;
                                nprRequest.Created = now;
                                nprRequest.Updated = now;
                                nprRequest.UxStatus = UxObjectStatus.Created;
                                nprRequests.Add(nprRequest);
                            }
                        }
                    }

                    List<RfqNprRequestUxModel> response = await RfqUxClientService.CreateNprRequestsAsync(nprRequests);
                    RfqProject.NprRequests = response;

                    Snackbar.Add($"Successfully created NPR request set for {_InProgressParts.Count} part(s)", Severity.Success);
                    StateHasChanged();
                }
            }
            catch (InvalidOperationException ex)
            {
                Logger.GenericLogError("EditRfq.NprAllInProgressPartsAsync - Invalid operation error creating NPR for parts", ex);
                Snackbar.Add($"Error creating NPR requests: {ex.Message}", Severity.Error);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                Logger.GenericLogError("EditRfq.NprAllInProgressPartsAsync - Argument null error creating NPR for parts", ex);
                Snackbar.Add($"Error creating NPR requests: {ex.Message}", Severity.Error);
                throw;
            }
            catch (Exception ex)
            {
                Logger.GenericLogError("EditRfq.NprAllInProgressPartsAsync - Unexpected error creating NPR for parts", ex);
                Snackbar.Add($"Error creating NPR requests: {ex.Message}", Severity.Error);
                throw;
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        async Task SubmitNprRequestsAsync()
        {
            if (RfqProject?.NprRequests == null || RfqProject.NprRequests.Count == 0)
            {
                Snackbar.Add("No NPR requests to submit", Severity.Info);
                return;
            }

            // Only submit requests that are not soft-deleted.
            List<RfqNprRequestUxModel> toSubmit = RfqProject.NprRequests
                .Where(r => r.UxStatus != UxObjectStatus.Deleted)
                .ToList();

            if (toSubmit.Count == 0)
            {
                Snackbar.Add("No active NPR requests to submit", Severity.Info);
                return;
            }

            bool? confirm = await DialogService.ShowMessageBoxAsync(
                "Submit NPR Requests",
                $"Submit {toSubmit.Count} NPR request(s) to the NPR API?",
                yesText: $"Submit {toSubmit.Count}",
                cancelText: "Cancel"
            );

            if (confirm != true)
            {
                return;
            }

            _IsSubmittingNprs = true;
            StateHasChanged();

            try
            {
                // Persist any pending NPR edits BEFORE submitting so the API sees the latest data.
                if (_ComponentNprEditor != null && _ComponentNprEditor.HasPendingChanges)
                {
                    await _ComponentNprEditor.SaveNprRequestsAsync();
                }

                Logger.GenericLogInformation(
                    $"EditRfq.SubmitNprRequestsAsync - Submitting {toSubmit.Count} NPR request(s) for RFQ {RfqProject.RfqNumber}");
                // display wait dialog
                DialogParameters loadingParameters = new DialogParameters
                {
                    { nameof(LoadingDialog.Message), "Sending Npr Request to Engineering endpoint, please wait!" }
                };

                DialogOptions loadingOptions = new DialogOptions
                {
                    MaxWidth = MaxWidth.Small,
                    FullWidth = false,
                    CloseButton = false,
                    CloseOnEscapeKey = false,
                    BackdropClick = false,
                    NoHeader = true
                };

                IDialogReference loadingDialog = await DialogService.ShowAsync<LoadingDialog>(
                    string.Empty,
                    loadingParameters,
                    loadingOptions);

                CreateNprGrpcResponse response;
                try
                {
                    response = await RfqUxClientService.CreateNprGrpcAsync(toSubmit);
                }
                finally
                {
                    loadingDialog.Close();
                }

                Logger.GenericLogInformation(
                    $"EditRfq.SubmitNprRequestsAsync - Response: HttpStatusCode='{response.HttpStatusCode}', " +
                    $"Message='{response.Message}', returned {response.NprApiData.Count} entry(ies)");

                bool ok = string.Equals(response.HttpStatusCode, "OK", StringComparison.OrdinalIgnoreCase);

                string? nprRequestNumber = response.NprApiData
                    .Select(d => d.NprId)
                    .FirstOrDefault(id => !string.IsNullOrWhiteSpace(id));

                string statusMessage = ok
                    ? $"Submitted {response.NprApiData.Count} NPR request(s) successfully.{Environment.NewLine}{Environment.NewLine}" +
                      $"HTTP Status: {response.HttpStatusCode}{Environment.NewLine}" +
                      $"API Message: {response.Message}"
                    : $"NPR submission did not complete successfully.{Environment.NewLine}{Environment.NewLine}" +
                      $"HTTP Status: {response.HttpStatusCode}{Environment.NewLine}" +
                      $"API Message: {response.Message}";

                DialogParameters submitStatusParameters = new DialogParameters
                {
                    { nameof(NprSubmissionStatusDialog.IsSuccess), ok },
                    { nameof(NprSubmissionStatusDialog.RfqNumber), RfqProject.RfqNumber },
                    { nameof(NprSubmissionStatusDialog.NprRequestNumber), nprRequestNumber },
                    { nameof(NprSubmissionStatusDialog.StatusMessage), statusMessage }
                };

                DialogOptions submitStatusOptions = new DialogOptions
                {
                    MaxWidth = MaxWidth.Medium,
                    FullWidth = true,
                    CloseButton = true,
                    CloseOnEscapeKey = true
                };

                await DialogService.ShowAsync<NprSubmissionStatusDialog>(
                    ok ? "NPR Submission Successful" : "NPR Submission Warning",
                    submitStatusParameters,
                    submitStatusOptions);

                // Refresh from DB so any RequestID assignments / status changes are picked up.
                await LoadNprRequests();
                if (_ComponentNprEditor != null)
                {
                    _ComponentNprEditor.NotifyStateChanged();
                }
            }
            catch (Exception ex)
            {
                Logger.GenericLogError("EditRfq.SubmitNprRequestsAsync - Error submitting NPR requests", ex);

                DialogParameters submitErrorParameters = new DialogParameters
                {
                    { nameof(NprSubmissionStatusDialog.IsSuccess), false },
                    { nameof(NprSubmissionStatusDialog.RfqNumber), RfqProject?.RfqNumber ?? string.Empty },
                    { nameof(NprSubmissionStatusDialog.NprRequestNumber), null },
                    { nameof(NprSubmissionStatusDialog.StatusMessage), $"Error submitting NPR requests:{Environment.NewLine}{Environment.NewLine}{ex.Message}" }
                };

                DialogOptions submitErrorOptions = new DialogOptions
                {
                    MaxWidth = MaxWidth.Medium,
                    FullWidth = true,
                    CloseButton = true,
                    CloseOnEscapeKey = true
                };

                await DialogService.ShowAsync<NprSubmissionStatusDialog>(
                    "NPR Submission Error",
                    submitErrorParameters,
                    submitErrorOptions);
            }
            finally
            {
                _IsSubmittingNprs = false;
            }

            StateHasChanged();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        async Task ShowDatasetStatusAsync()
        {
            DialogParameters parameters = new DialogParameters
            {
                { nameof(DatasetStatusDialog.MatchedParts), _CompletedParts },
                { nameof(DatasetStatusDialog.UnmatchedParts), _InProgressParts },
                { nameof(DatasetStatusDialog.RfqNumber), RfqProject?.RfqNumber ?? string.Empty }
            };

            DialogOptions options = new DialogOptions
            {
                MaxWidth = MaxWidth.Large,
                FullWidth = true,
                CloseButton = true,
                CloseOnEscapeKey = true
            };

            IDialogReference dialog = await DialogService.ShowAsync<DatasetStatusDialog>(
                $"Dataset Status – {RfqProject?.RfqNumber}",
                parameters,
                options
            );

            await dialog.Result;
        }
        async Task HandlePartNumberDeleted(RfqDrawingPartNumberUxModel deletedItem)
        {
            try
            {
                if (deletedItem.IsCompleted)
                {
                    _CompletedParts.Remove(deletedItem);
                    Logger.GenericLogInformation($"EditRfq.HandlePartNumberDeleted - Removed matched part: {deletedItem.CustomerPartNumber}");
                }
                else
                {
                    _InProgressParts.Remove(deletedItem);
                    Logger.GenericLogInformation($"EditRfq.HandlePartNumberDeleted - Removed unmatched part: {deletedItem.CustomerPartNumber}");
                }

                StateHasChanged();
            }
            catch (InvalidOperationException ex)
            {
                Logger.GenericLogError($"EditRfq.HandlePartNumberDeleted - Invalid operation error handling deletion of part: {deletedItem.CustomerPartNumber}", ex);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                Logger.GenericLogError($"EditRfq.HandlePartNumberDeleted - Argument null error handling deletion of part: {deletedItem.CustomerPartNumber}", ex);
                throw;
            }

            await Task.CompletedTask;
        }
        async Task HandlePartNumberUpdated(RfqDrawingPartNumberUxModel updatedItem)
        {
            try
            {
                RfqDrawingPartNumberUxModel? matchedItem = _CompletedParts.FirstOrDefault(p => p?.RowId == updatedItem.RowId);
                RfqDrawingPartNumberUxModel? unmatchedItem = _InProgressParts.FirstOrDefault(p => p?.RowId == updatedItem.RowId);

                bool isInCompletedList = matchedItem != null;
                bool isInInProgressList = unmatchedItem != null;

                if (updatedItem.IsCompleted && isInInProgressList && unmatchedItem is not null)
                {
                    _InProgressParts.Remove(unmatchedItem);
                    _CompletedParts.Add(updatedItem);
                    Logger.GenericLogInformation($"EditRfq.HandlePartNumberUpdated - Moved part to matched: {updatedItem.CustomerPartNumber}");
                }
                else if (!updatedItem.IsCompleted && isInCompletedList && matchedItem is not null)
                {
                    _CompletedParts.Remove(matchedItem);
                    _InProgressParts.Add(updatedItem);
                    Logger.GenericLogInformation($"EditRfq.HandlePartNumberUpdated - Moved part to unmatched: {updatedItem.CustomerPartNumber}");
                }
                else if (isInCompletedList && matchedItem is not null)
                {
                    int index = _CompletedParts.IndexOf(matchedItem);
                    if (index >= 0)
                    {
                        _CompletedParts[index] = updatedItem;
                    }

                    Logger.GenericLogInformation($"EditRfq.HandlePartNumberUpdated - Updated matched part: {updatedItem.CustomerPartNumber}");
                }
                else if (isInInProgressList && unmatchedItem is not null)
                {
                    int index = _InProgressParts.IndexOf(unmatchedItem);
                    if (index >= 0)
                    {
                        _InProgressParts[index] = updatedItem;
                    }

                    Logger.GenericLogInformation($"EditRfq.HandlePartNumberUpdated - Updated unmatched part: {updatedItem.CustomerPartNumber}");
                }

                StateHasChanged();
            }
            catch (InvalidOperationException ex)
            {
                Logger.GenericLogError($"EditRfq.HandlePartNumberUpdated - Invalid operation error handling update of part: {updatedItem.CustomerPartNumber}", ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.GenericLogError($"EditRfq.HandlePartNumberUpdated - Argument null error handling update of part: {updatedItem.CustomerPartNumber}", ex);
            }

            await Task.CompletedTask;
        }
        #endregion

        #region Customer
        //async Task OnCustomerValueChanged(string value)
        //{
        //    RfqProject!.CustomerBusinessUnitId = value;

        //    CustomerUxModel? customer = RfqUxClientService.Customers.FirstOrDefault(c => c?.Id == value);
        //    if (customer == null)
        //    {
        //        Logger.GenericLogInformation($"EditRfq.OnCustomerValueChanged - Customer with ID '{value}' not found");
        //        return;
        //    }

        //    Logger.GenericLogInformation($"EditRfq.OnCustomerValueChanged - Customer changed to {customer.Id} - {customer.CustomerBusinessGroupName}");

        //    // Clear selected project when customer changes (like CreateRfq)
        //    SelectedProject = null;
        //    _PreviousSelectedProject = null;
        //    RfqProject.ProjectId = "";

        //    // Reset the autocomplete component
        //    if (_ProjectAutocomplete != null)
        //    {
        //        await _ProjectAutocomplete.ClearAsync();
        //    }

        //    try
        //    {
        //        await GetProjectAssociationsByCustomerName(customer.CustomerBusinessGroupName);
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        Logger.GenericLogError($"EditRfq.OnCustomerValueChanged - ArgumentNullException loading customer projects for customer '{customer.CustomerBusinessGroupName}'", ex);
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        Logger.GenericLogError($"EditRfq.OnCustomerValueChanged - InvalidOperationException loading customer projects for customer '{customer.CustomerBusinessGroupName}'", ex);
        //    }

        //    StateHasChanged();
        //}

        //async Task GetProjectAssociationsByCustomerName(string? customerBusinessGroupName)
        //{
        //    if (!string.IsNullOrWhiteSpace(RfqProject!.CustomerBusinessUnitId))
        //    {
        //        CustomerUxModel? customer = RfqUxClientService.Customers.FirstOrDefault(c => c?.CustomerBusinessGroupName == customerBusinessGroupName);

        //        if (customer != null && Guid.TryParse(customer.Id, out Guid customerId))
        //        {
        //            await RfqUxClientService.GetProjectAssociationsByCustomerIdAsync(customerId.ToString());
        //            StateHasChanged();
        //        }
        //        else
        //        {
        //            Logger.GenericLogInformation($"EditRfq.GetProjectAssociationsByCustomerName - Customer not found or invalid ID for '{customerBusinessGroupName}'");
        //        }
        //    }
        //}
        #endregion

        #region Project Autocomplete
        // Search function for MudAutocomplete (same as CreateRfq)
        //async Task<IEnumerable<RfqCustomerProjectAssociationUxModel>> SearchProjects(string searchText, CancellationToken cancellationToken)
        //{
        //    await Task.Delay(0, cancellationToken);

        //    // If no search text, return all projects (sorted)
        //    if (string.IsNullOrWhiteSpace(searchText))
        //    {
        //        return RfqUxClientService.CustomerProjectAssociations
        //            .OrderBy(p => p.ProjectCode)
        //            .ThenBy(p => p.CustomerName);
        //    }

        //    // Search across project name and customer name
        //    return RfqUxClientService.CustomerProjectAssociations
        //        .Where(p =>
        //            (p.ProjectCode?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false) ||
        //            (p.CustomerName?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false))
        //        .OrderBy(p => p.ProjectCode?.StartsWith(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
        //        .ThenBy(p => p.ProjectCode)
        //        .ThenBy(p => p.CustomerName);
        //}
        #endregion

        #region Reason
        async Task OnReasonValueChanged(int? value)
        {
            RfqProject!.RfqReasonId = value ?? 0;

            await Task.Delay(0);

            RfqReasonGrpc? reason = RfqUxClientService.Reasons.FirstOrDefault(r => r.RowId == (value ?? 0));

            Logger.GenericLogInformation($"EditRfq.OnReasonValueChanged - Reason changed to {reason?.RowId} - {reason?.RfqReasonTitle}");

            StateHasChanged();
        }
        #endregion

        #region Part Number

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        //async Task UploadFilesAsync()
        //{
        //    if (FileObjects.Count == 0)
        //    {
        //        Snackbar.Add("No files to upload", Severity.Info);
        //        Logger.GenericLogInformation("EditRfq.UploadFilesAsync - No files available");
        //        return;
        //    }

        //    // Create a progress state object that will be shared with the dialog
        //    SubmissionProgressState progressState = new SubmissionProgressState();

        //    // Initialize progress dialog
        //    DialogParameters parameters = new DialogParameters<SubmissionProgressDialog>
        //    {
        //        { x => x.ProgressState, progressState }
        //    };

        //    DialogOptions options = new DialogOptions()
        //    {
        //        CloseButton = false,
        //        BackdropClick = false,
        //        MaxWidth = MaxWidth.Medium,
        //        FullWidth = true
        //    };

        //    IDialogReference dialog = await DialogService.ShowAsync<SubmissionProgressDialog>("Uploading Files", parameters, options);

        //    try
        //    {
        //        // Checkpoint 1: Validation
        //        progressState.UpdateProgress("Validating files...", 0);
        //        progressState.SetCheckpointActive(0);

        //        await Task.Delay(500); // Small delay for UX

        //        List<FileObjectUxModel> validFiles = FileObjects.Where(f => f.Status != UxObjectStatus.Deleted && f.IsFileValid).ToList();

        //        if (validFiles.Count == 0)
        //        {
        //            progressState.SetError("Validation failed: No valid files", "Please upload at least one valid file.");
        //            Logger.GenericLogInformation("EditRfq.UploadFilesAsync - Validation failed: No valid files");
        //            return;
        //        }

        //        progressState.SetCheckpointCompleted(0, $"{validFiles.Count} valid file(s) ready for upload");
        //        Logger.GenericLogInformation($"EditRfq.UploadFilesAsync - Checkpoint: Validation OK - {validFiles.Count} valid files");

        //        // Checkpoint 2: Upload Files
        //        progressState.UpdateProgress("Uploading files...", 1);
        //        progressState.SetCheckpointActive(1);

        //        bool allOk = true;
        //        int fileCount = 0;
        //        int skippedCount = 0;
        //        int totalFiles = validFiles.Count;

        //        foreach (FileObjectUxModel fileObject in validFiles)
        //        {
        //            try
        //            {
        //                if (fileObject.File == null || !fileObject.IsFileValid)
        //                {
        //                    skippedCount++;
        //                    Logger.GenericLogInformation($"EditRfq.UploadFilesAsync - Skipping invalid file: {fileObject.DisplayName}");
        //                    continue;
        //                }

        //                fileCount++;
        //                progressState.UpdateProgress($"Uploading file {fileCount} of {totalFiles}: {fileObject.File.Name}", 1);

                        //UploadPartsRequestGrpcResponse uploadFileResponse = await RfqUxClientService.UploadBomFileAsync(RfqProjectId.ToString(CultureInfo.InvariantCulture), fileObject.File, GlobalValue?.UserId, 16_000_000);
                        //fileObject.UploadStatus = new FileObjectUploadStatus(uploadFileResponse);
                        //allOk = allOk && uploadFileResponse.Success;

        //                Logger.GenericLogInformation($"EditRfq.UploadFilesAsync - Uploaded file {fileObject.File.Name}/{fileObject.File.Size}, {fileObject.UploadStatus.Status}/{fileObject.UploadStatus.Message}");
        //            }
        //            catch (Exception fileEx)
        //            {
        //                Logger.GenericLogError($"EditRfq.UploadFilesAsync - Error uploading file {fileObject.DisplayName}", fileEx);
        //                fileObject.UploadStatus = new FileObjectUploadStatus
        //                {
        //                    Status = FileUploadStatus.Failed,
        //                    Message = $"Upload error: {fileEx.Message}"
        //                };
        //                allOk = false;
        //            }
        //        }

        //        string uploadSummary = skippedCount > 0
        //            ? $"Uploaded {fileCount} file(s), skipped {skippedCount} invalid file(s)"
        //            : $"Uploaded {fileCount} file(s)";

        //        progressState.SetCheckpointCompleted(1, uploadSummary);
        //        Logger.GenericLogInformation($"EditRfq.UploadFilesAsync - Checkpoint: {uploadSummary}");

        //        // Checkpoint 3: Reload Data
        //        progressState.UpdateProgress("Reloading part numbers...", 2);
        //        progressState.SetCheckpointActive(2);

        //        await Task.Delay(500); // Small delay for UX

        //        // Reload the part numbers to get the newly uploaded data
        //        await LoadRfqAndPartNumbersAsync();

        //        progressState.SetCheckpointCompleted(2, "Data reloaded successfully");
        //        Logger.GenericLogInformation("EditRfq.UploadFilesAsync - Checkpoint: Data reloaded");

        //        // Checkpoint 4: Finalize
        //        progressState.UpdateProgress("Finalizing upload...", 3);
        //        progressState.SetCheckpointActive(3);

        //        await Task.Delay(500); // Small delay for UX

        //        progressState.SetCheckpointCompleted(3, "Upload completed");
        //        Logger.GenericLogInformation($"EditRfq.UploadFilesAsync - Checkpoint: Upload finalized, success: {allOk}");

        //        // Final update
        //        progressState.SetCompleted(allOk ? "File upload completed successfully!" : "File upload completed with some errors", !allOk);

        //        StateHasChanged();

        //        if (allOk)
        //        {
        //            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
        //            Snackbar.Add("Files uploaded successfully!", Severity.Success);
        //        }
        //        else
        //        {
        //            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
        //            Snackbar.Add("Files uploaded with some errors. Please check the file status.", Severity.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.GenericLogError("EditRfq.UploadFilesAsync - Unexpected error during file upload", ex);
        //        progressState.SetError("An unexpected error occurred", $"Error: {ex.Message}", isCompleted: true);
        //        Snackbar.Add($"Error uploading files: {ex.Message}", Severity.Error);
        //    }
        //}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        async Task ReloadDataAsync()
        {
            try
            {
                await LoadRfqAndPartNumbersAsync();

                // Reload NPR requests into RfqProject so the tab stays enabled
                await LoadNprRequests();

                // If the editor component is still alive, refresh its view too
                if (_ComponentNprEditor != null)
                {
                    await _ComponentNprEditor.RefreshNprRequestsAsync();
                }

                StateHasChanged();
            }
            catch (Exception ex)
            {
                Logger.GenericLogError($"EditRfq.ReloadDataAsync - Unexpected error during data reload {ex.Message}", ex);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        async Task SaveDataAsync()
        {
            List<RfqDrawingPartNumberUxModel> allParts = new();
            allParts.AddRange(_CompletedParts.Where(p => p != null).Select(p => p!));
            allParts.AddRange(_InProgressParts.Where(p => p != null).Select(p => p!));
            if(allParts.Count == 0)
            {
                Snackbar.Add("No parts to save", Severity.Info);
                Logger.GenericLogInformation("EditRfq.SaveDataAsync - No parts available to save");
                return;
            }

            try
            {
                // Save pending NPR changes BEFORE reloading (otherwise the editor gets destroyed)
                if (_ComponentNprEditor != null && _ComponentNprEditor.HasPendingChanges)
                {
                    await _ComponentNprEditor.SaveNprRequestsAsync();
                }

                // Update selection (save JSON Data)
                await UpdateSelectionAsync();

                // Save the RfqProject FIRST so its RowId exists before parts reference it
                UpdateRfqProjectGrpcResponse rfqUpdateResult = await RfqUxClientService.UpdateRfqProjectAsync(RfqProject!);
                RfqCrudResponse partsUpdateResult = await RfqUxClientService.UpdateRfqDrawingPartNumbersAsync(allParts);

                if (partsUpdateResult.SaveSuccess && rfqUpdateResult.Success)
                {
                    Snackbar.Add("Data saved successfully", Severity.Success);
                    Logger.GenericLogInformation("EditRfq.SaveDataAsync - Data saved successfully");

                    // Reload part numbers
                    await LoadRfqAndPartNumbersAsync();

                    // Reload NPR requests so the tab remains enabled and data is fresh
                    await LoadNprRequests();

                    // Notify the NPR editor to re-render with the fresh data
                    // (the parent replaced RfqProject.NprRequests but Blazor won't
                    //  detect the change since the RfqProject reference is the same)
                    if (_ComponentNprEditor != null)
                    {
                        // await _ComponentNprEditor.RefreshNprRequestsAsync();
                        _ComponentNprEditor.NotifyStateChanged();
                    }
                }
                else
                {
                    Snackbar.Add("Error saving data", Severity.Error);
                    Logger.GenericLogInformation("EditRfq.SaveDataAsync - Error saving data");
                }

                StateHasChanged();
            }
            catch (Exception ex)
            {
                Logger.GenericLogError($"EditRfq.SaveDataAsync - Unexpected error during data save {ex.Message}", ex);
            }
        }
        #endregion

        #region Search All

        // Snapshot of the BOM size taken at the start of a search run.
        // Used to assert the invariant: _CompletedParts.Count + _InProgressParts.Count <= initialTotalParts.
        int _SearchInitialTotalParts;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        async Task SearchAllPartNumbersAsync()
        {
            if (_InProgressParts == null || !_InProgressParts.Any())
            {
                Snackbar.Add(
                    "No in-progress parts to search",
                    Severity.Info);

                return;
            }

            bool? confirm = await DialogService.ShowMessageBoxAsync(
                "Confirm Search All",
                $"Search EMACS for all {_InProgressParts.Count} in-progress part(s)? " +
                "Auto-matched parts will be moved to Completed.",
                yesText: "Search All",
                cancelText: "Cancel");

            if (confirm != true)
            {
                return;
            }

            _IsSearchingAll = true;

            _SearchCancellationTokenSource?.Dispose();
            _SearchCancellationTokenSource = new CancellationTokenSource();

            CancellationToken cancellationToken =
                _SearchCancellationTokenSource.Token;

            _SearchInitialTotalParts = TotalParts;

            // Create a snapshot so the original lists can be modified safely.
            List<RfqDrawingPartNumberUxModel> partsSnapshot =
                _InProgressParts
                    .Where(part => part != null)
                    .ToList();

            if (partsSnapshot.Count == 0)
            {
                Snackbar.Add(
                    "No in-progress parts to search",
                    Severity.Info);

                _IsSearchingAll = false;
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
                await DialogService.ShowAsync<SearchProgressDialog>(
                    "Search All Part Numbers",
                    parameters,
                    options);

            int processed = 0;
            int movedExact = 0;
            int movedContains = 0;
            int unmatched = 0;

            try
            {
                StateHasChanged();

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
                        Logger.GenericLogInformation(
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
                        Logger.GenericLogInformation(
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
                            await RfqUxClientService
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

                            Logger.GenericLogInformation(
                                $"EditRfq.SearchAllPartNumbersAsync - " +
                                $"InputPart={searchedPartNumber}, " +
                                $"ExactMatch={isExactMatch}, " +
                                $"Candidates=" +
                                $"{priceResponse.PriceInformation.Count}");
                        }

                        Logger.GenericLogInformation(
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
                                await RfqUxClientService
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

                                Logger.GenericLogInformation(
                                    $"EditRfq.SearchAllPartNumbersAsync - " +
                                    $"Auto-matched ({item.Status}): " +
                                    $"Input={matchedInputPartNumber}, " +
                                    $"Drawing={item.DrawingPartNumber}, " +
                                    $"Price={item.DrawingPartNumberPrice}");
                            }
                            else
                            {
                                Logger.GenericLogInformation(
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

                            Logger.GenericLogInformation(
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
                        Logger.GenericLogError(
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
                    StateHasChanged();
                    await Task.Yield();
                }

                /*
                 * Move successfully matched rows from In Progress
                 * to Completed.
                 */
                List<RfqDrawingPartNumberUxModel> toMove =
                    _InProgressParts
                        .Where(part =>
                            part.Status ==
                                RfqDrawingPartNumberStatus.ExactMatch ||
                            part.Status ==
                                RfqDrawingPartNumberStatus.ContainsMatch)
                        .ToList();

                foreach (RfqDrawingPartNumberUxModel part in toMove)
                {
                    _InProgressParts.Remove(part);

                    if (!_CompletedParts.Contains(part))
                    {
                        _CompletedParts.Add(part);
                    }
                }

                Debug.Assert(
                    _CompletedParts.Count + _InProgressParts.Count ==
                    _SearchInitialTotalParts,
                    "SearchAllPartNumbersAsync changed total BOM size");

                string summary =
                    $"Processed {processed}, " +
                    $"exact-matched {movedExact}, " +
                    $"contains-matched {movedContains}, " +
                    $"unmatched {unmatched}";

                progressState.SetCompleted(summary);

                Snackbar.Add(
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

                Snackbar.Add(
                    "Search All cancelled",
                    Severity.Warning);

                Logger.GenericLogInformation(
                    "EditRfq.SearchAllPartNumbersAsync - " +
                    "Cancelled by user");
            }
            catch (Exception ex)
            {
                progressState.SetError(
                    "Search failed",
                    ex.Message,
                    isCompleted: true);

                Logger.GenericLogError(
                    "EditRfq.SearchAllPartNumbersAsync - " +
                    "Unexpected error during Search All",
                    ex);

                Snackbar.Add(
                    $"Search All failed: {ex.Message}",
                    Severity.Error);
            }
            finally
            {
                _IsSearchingAll = false;
                progressState.OnCancelRequested = null;

                StateHasChanged();

                _ = await dialog.Result;
            }
        }
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

        async Task HandleComponentsSelectedAsync(IEnumerable<DsiComponentUxModel> components)
        {
            // Save the selection from the composite cards
            _SelectedComponents = components;
            // Delete and clear the existing parts lists before adding new ones
            if (_InProgressParts != null && _InProgressParts.Any())
            {
                bool result = await RfqUxClientService.DeleteRfqDrawingPartNumbers(_InProgressParts!);
            }
            else
            {
                _CompletedParts = new List<RfqDrawingPartNumberUxModel>();
            }

            if (_CompletedParts != null && _CompletedParts.Any())
            {
                bool result = await RfqUxClientService.DeleteRfqDrawingPartNumbers(_CompletedParts!);
            }
            else
            {
                _InProgressParts = new List<RfqDrawingPartNumberUxModel>();
            }

            _CompletedParts!.Clear();
            _InProgressParts!.Clear();

            if(RfqProject == null)
            {
                Logger.GenericLogInformation("EEE - EditRfq.HandleComponentsSelectedAsync - RfqProject is null");
                return;
            }

            foreach (DsiComponentUxModel component in components)
            {
                if (string.IsNullOrWhiteSpace(component.PartNumber1))
                {
                    continue;
                }

                _InProgressParts.Add(component.ToUx(RfqProject.RowId));
            }

            _ActiveTabIndex = 1; // Switch to "Parts Lists" tab
            StateHasChanged();
            await Task.CompletedTask;
        }
             
         async Task UpdateSelectionAsync()
        {
            HashSet<DsiCompositeDetailUxModel>? currentSelections = _CompositesRef?.SelectedItems;

            //if (currentSelections == null || !currentSelections.Any())
            //{
            //    Snackbar.Add("No components selected to update.", Severity.Warning);
            //    return;
            //}

            string? harnessId = _Composites.FirstOrDefault()?.Id.ToString();
            SelectionLogData selectionLog = new SelectionLogData
            {
                HarnessId = harnessId,
                RfqId = RfqProjectId
            };

            if (currentSelections != null && currentSelections.Any())
            {
                selectionLog.Selections = currentSelections.Select(x => new SelectedCompositeData
                {
                    Id = x.Id,
                    HarnessName1 = x.HarnessName1,
                    HarnessName2 = x.HarnessName2,
                    Customer = x.Customer
                }).ToList();
            }
            else
            {
                selectionLog.Selections = new List<SelectedCompositeData>();
            }

            // Explicit string declaration
            string jsonOutput = JsonSerializer.Serialize(selectionLog, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            Logger.GenericLogInformation($">>> Serializing derivatives selection JSON data: {jsonOutput}");

            RfqProject!.JsonData = jsonOutput;

            //try
            //{
            //    UpdateRfqProjectGrpcResponse result =
            //        await RfqUxClientService.UpdateRfqProjectAsync(RfqProject);

            //    if (result.Success)
            //    {
            //        Snackbar.Add(" JSON data saved to RFQ successfully", Severity.Success);
            //    }
            //    else
            //    {
            //        Snackbar.Add("Failed to save JSON data", Severity.Error);
            //    }
            //}
            //catch (InvalidOperationException ex)
            //{
            //    Snackbar.Add($"Invalid operation: {ex.Message}", Severity.Error);
            //}
            //catch (ArgumentNullException ex)
            //{
            //    Snackbar.Add($"Missing data: {ex.Message}", Severity.Error);
            //}
            //catch (HttpRequestException ex)
            //{
            //    Snackbar.Add($"Network error: {ex.Message}", Severity.Error);
            //}

            //Snackbar.Add($"{currentSelections?.Count} components selected", Severity.Success);

            await Task.CompletedTask;
       }

        // update npr requests
        async Task UpdateRfqNprRequestsAsync()
        {
            Logger.GenericLogInformation("updating RfqNprRequests...");
            Stopwatch sw = Stopwatch.StartNew();

            bool status = await RfqUxClientService.UpdateRfqNprRequestStatusAsync();

            sw.Stop();
            Logger.GenericLogInformation($"updating RfqNprRequests - Updated NPR requests in {sw.ElapsedMilliseconds}ms");
            if(status)
            {
                Logger.GenericLogInformation("updating RfqNprRequests - NPR requests updated successfully");
            }
            else
            {
                Logger.GenericLogInformation("updating RfqNprRequests - NPR requests update failed");
            }
        }
    }

     public class SelectionLogData
    {
        public string? HarnessId { get; set; }
        [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
        public Collection<string> HarnessIds { get; } = new();
        public long RfqId { get; set; }
        public IEnumerable<SelectedCompositeData>? Selections { get; set; }
    }
    public class SelectedCompositeData
    {
        public long Id { get; set; }
        public string? HarnessName1 { get; set; }
        public string? HarnessName2 { get; set; }
        public string? Customer { get; set; }
    }
    //public class CompositeData
    //{
    //    public string? HarnessId { get; set; }
    //    public IEnumerable<SelectedCompositeData>? Selections { get; set; }
    //}
}