using Azure.Core;

namespace SalesSystem.Rfq.Components.Pages
{
    public partial class EditRfq : IDisposable
    {
        #region Attribs
        // Reference to the FileManager component
        FileManager? _ComponentFileManager;
        FileCards? _ComponentFileCards;
        NprRequestsEditor? _ComponentNprEditor;
        List<FileObjectUxModel> FileObjects
        { get; set; }

        // Search All state tracking
        bool _IsSearchingAll;
        CancellationTokenSource? _SearchCancellationTokenSource;

        // Reference to autocomplete for reset
        MudAutocomplete<RqfCustomerProjectAssociationUxModel>? _ProjectAutocomplete;

        // Helper property for total parts count
        int TotalParts => _CompletedParts.Count + _InProgressParts.Count;

        // Form related
        bool IsLoading
        { get; set; }
        RqfProjectUxModel? RfqProject { get; set; }

        // Simplified project selection (like CreateRfq)
        RqfCustomerProjectAssociationUxModel? SelectedProject
        { get; set; }

        // Track previous selected project to detect changes
        RqfCustomerProjectAssociationUxModel? _PreviousSelectedProject;

        // Part numbers data - changed to List for mutability
        List<RfqDrawingPartNumberUxModel?> _CompletedParts = new List<RfqDrawingPartNumberUxModel?>();
        List<RfqDrawingPartNumberUxModel?> _InProgressParts = new List<RfqDrawingPartNumberUxModel?>();

        // Submit NPRs state tracking
        bool _IsSubmittingNprs;
        #endregion

        public EditRfq()
        {
            _IsSearchingAll = false;
            IsLoading = true;
            FileObjects = new List<FileObjectUxModel>();
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
            if (GlobalValue?.UserId == null || GlobalValue.UserId == Guid.Empty)
            {
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                Snackbar.Add("Not an authenticated user", Severity.Error);
                Logger.GenericLogInformation("EditRfq.OnInitializedAsync - UserId is missing in the URL");
                IsLoading = false;
                NavigationManager.NavigateTo("/");
            }

            try
            {
                if (await LoadDataAsync())
                {
                    await LoadNprRequests();
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
        }
        void OnFilesChanged()
        {
            StateHasChanged();
        }
        async Task HandleFileRemoval(FileObjectUxModel fileObject)
        {
            try
            {
                Logger.GenericLogInformation($"EditRfq.HandleFileRemoval - Starting removal for file: {fileObject.DisplayName} (ID: {fileObject.Id})");

                if (fileObject.CanBeRemovedSafely)
                {
                    bool removed = FileObjects.Remove(fileObject);

                    if (removed)
                    {
                        if (_ComponentFileManager != null)
                        {
                            await _ComponentFileManager.ResetInputFileAsync();
                        }

                        Logger.GenericLogInformation($"EditRfq.HandleFileRemoval - Completely removed file: {fileObject.DisplayName}");
                        Snackbar.Add($"File '{fileObject.DisplayName}' removed successfully", Severity.Success);
                    }
                    else
                    {
                        Logger.GenericLogInformation($"EditRfq.HandleFileRemoval - File not found in collection: {fileObject.DisplayName}");
                    }
                }
                else
                {
                    fileObject.Status = UxObjectStatus.Deleted;
                    Logger.GenericLogInformation($"EditRfq.HandleFileRemoval - Marked uploaded file as deleted: {fileObject.DisplayName}");
                    Snackbar.Add($"File '{fileObject.DisplayName}' marked as deleted", Severity.Info);
                }

                StateHasChanged();
            }
            catch (InvalidOperationException ex)
            {
                Logger.GenericLogError($"EditRfq.HandleFileRemoval - Invalid operation error removing file: {fileObject.DisplayName}", ex);
                Snackbar.Add($"Error removing file: {ex.Message}", Severity.Error);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                Logger.GenericLogError($"EditRfq.HandleFileRemoval - Argument null error removing file: {fileObject.DisplayName}", ex);
                Snackbar.Add($"Error removing file: {ex.Message}", Severity.Error);
                throw;
            }
            catch (Exception ex)
            {
                Logger.GenericLogError($"EditRfq.HandleFileRemoval - Error removing file: {fileObject.DisplayName}", ex);
                Snackbar.Add($"Error removing file: {ex.Message}", Severity.Error);
                throw;
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
                        Logger.GenericLogInformation($"EditRfq.OnAfterRender - Project changed to {SelectedProject.Id} - {SelectedProject.ProjectName}");
                    }
                    else
                    {
                        RfqProject!.ProjectId = "";
                        Logger.GenericLogInformation($"EditRfq.OnAfterRender - Project cleared");
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
                Snackbar.Add($"RFQ Project with Id {RfqProjectId} not found", Severity.Error);
                Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - RFQ Project with Id {RfqProjectId} not found");
                NavigationManager.NavigateTo("/");
                return success;
            }
            else
            {
                Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Retrieved RFQ Project with Id {rfqProject.RowId} - {rfqProject.RfqNumber} - Customer {rfqProject.CustomerBusinessUnitGuid} / {rfqProject.CustomerBusinessGroupCode} - Project {rfqProject.ProjectGuid} / {rfqProject.ProjectName}");
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
                Snackbar.Add($"Error mapping RFQ Project with Id {RfqProjectId}", Severity.Error);
                Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Error mapping RFQ Project with Id {RfqProjectId}");
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
                    RfqProject.CustomerCode = SelectedProject.CustomerCode ?? string.Empty;
                }

                _PreviousSelectedProject = SelectedProject;
                IsLoading = false;
                success = true;
                Logger.GenericLogInformation($"EditRfq.OnInitializedAsync - Loaded RFQ Project with Id {RfqProject.RowId} - {RfqProject.RfqNumber} {RfqProject.ProjectId}");
            }

            // get the part numbers
            int partNumbersCount = await RfqUxClientService.GetRfqDrawingPartNumbersByRfqIdAsync(RfqProjectId);
            if (partNumbersCount > 0)
            {
                _CompletedParts = RfqUxClientService.RfqDrawingPartNumbers.Where(x => x?.IsCompleted == true).ToList();
                _InProgressParts = RfqUxClientService.RfqDrawingPartNumbers.Where(x => x?.IsCompleted == false).ToList();
            }

            return success;
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

        async Task LoadNprRequests()
        {
            await Task.Delay(1);
            List<RfqNprRequestUxModel>? nprRequests = await RfqUxClientService.GetNprRequestsByRfqNumberAsync(RfqProject?.RfqNumber);
            if (nprRequests != null)
            {
                RfqProject!.NprRequests = nprRequests;
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
                Snackbar.Add("No Rfq Project to process for NPR", Severity.Error);
                return;
            }

            if (_InProgressParts.Count == 0)
            {
                Snackbar.Add("No unmatched parts to process for NPR", Severity.Info);
                return;
            }

            try
            {
                bool? confirm = await DialogService.ShowMessageBox(
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

                    confirm = await DialogService.ShowMessageBox(
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
                                if(SelectedProject == null)
                                {
                                    Logger.GenericLogInformation($"EditRfq.NprAllInProgressPartsAsync - SelectedProject is null, cannot update NPR request for part {nprRequest.CustomerPartNumber}");
                                    continue;
                                }

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

            bool? confirm = await DialogService.ShowMessageBox(
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

                CreateNprGrpcResponse response = await RfqUxClientService.CreateNprGrpcAsync(toSubmit);

                Logger.GenericLogInformation(
                    $"EditRfq.SubmitNprRequestsAsync - Response: HttpStatusCode='{response.HttpStatusCode}', " +
                    $"Message='{response.Message}', returned {response.NprApiData.Count} entry(ies)");

                bool ok = string.Equals(response.HttpStatusCode, "OK", StringComparison.OrdinalIgnoreCase);

                Snackbar.Add(
                    ok
                        ? $"Submitted {response.NprApiData.Count} NPR request(s) successfully. {response.Message}"
                        : $"NPR submission returned {response.HttpStatusCode}: {response.Message}",
                    ok ? Severity.Success : Severity.Warning);

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
                Snackbar.Add($"Error submitting NPR requests: {ex.Message}", Severity.Error);
            }
            finally
            {
                _IsSubmittingNprs = false;
                StateHasChanged();
            }
        }
        async Task ShowDatasetStatusAsync()
        {
            await Task.Delay(1);
            // TODO: Implement the logic to show dataset status.
            // For now, just show a snackbar as a placeholder.
            Snackbar.Add("Dataset status feature is not yet implemented.", Severity.Info);
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

                if (updatedItem.IsCompleted && isInInProgressList)
                {
                    _InProgressParts.Remove(unmatchedItem);
                    _CompletedParts.Add(updatedItem);
                    Logger.GenericLogInformation($"EditRfq.HandlePartNumberUpdated - Moved part to matched: {updatedItem.CustomerPartNumber}");
                }
                else if (!updatedItem.IsCompleted && isInCompletedList)
                {
                    _CompletedParts.Remove(matchedItem);
                    _InProgressParts.Add(updatedItem);
                    Logger.GenericLogInformation($"EditRfq.HandlePartNumberUpdated - Moved part to unmatched: {updatedItem.CustomerPartNumber}");
                }
                else if (isInCompletedList)
                {
                    int index = _CompletedParts.IndexOf(matchedItem);
                    if (index >= 0)
                    {
                        _CompletedParts[index] = updatedItem;
                    }

                    Logger.GenericLogInformation($"EditRfq.HandlePartNumberUpdated - Updated matched part: {updatedItem.CustomerPartNumber}");
                }
                else if (isInInProgressList)
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
        async Task OnCustomerValueChanged(string value)
        {
            RfqProject!.CustomerBusinessUnitId = value;

            CustomerUxModel? customer = RfqUxClientService.Customers.FirstOrDefault(c => c?.Id == value);
            if (customer == null)
            {
                Logger.GenericLogInformation($"EditRfq.OnCustomerValueChanged - Customer with ID '{value}' not found");
                return;
            }

            Logger.GenericLogInformation($"EditRfq.OnCustomerValueChanged - Customer changed to {customer.Id} - {customer.CustomerBusinessGroupName}");

            // Clear selected project when customer changes (like CreateRfq)
            SelectedProject = null;
            _PreviousSelectedProject = null;
            RfqProject.ProjectId = "";

            // Reset the autocomplete component
            if (_ProjectAutocomplete != null)
            {
                await _ProjectAutocomplete.ClearAsync();
            }

            try
            {
                await GetProjectAssociationsByCustomerName(customer.CustomerBusinessGroupName);
            }
            catch (ArgumentNullException ex)
            {
                Logger.GenericLogError($"EditRfq.OnCustomerValueChanged - ArgumentNullException loading customer projects for customer '{customer.CustomerBusinessGroupName}'", ex);
            }
            catch (InvalidOperationException ex)
            {
                Logger.GenericLogError($"EditRfq.OnCustomerValueChanged - InvalidOperationException loading customer projects for customer '{customer.CustomerBusinessGroupName}'", ex);
            }

            StateHasChanged();
        }

        async Task GetProjectAssociationsByCustomerName(string? customerBusinessGroupName)
        {
            if (!string.IsNullOrWhiteSpace(RfqProject!.CustomerBusinessUnitId))
            {
                CustomerUxModel? customer = RfqUxClientService.Customers.FirstOrDefault(c => c?.CustomerBusinessGroupName == customerBusinessGroupName);

                if (customer != null && Guid.TryParse(customer.Id, out Guid customerId))
                {
                    await RfqUxClientService.GetProjectAssociationsByCustomerIdAsync(customerId.ToString());
                    StateHasChanged();
                }
                else
                {
                    Logger.GenericLogInformation($"EditRfq.GetProjectAssociationsByCustomerName - Customer not found or invalid ID for '{customerBusinessGroupName}'");
                }
            }
        }
        #endregion

        #region Project Autocomplete
        // Search function for MudAutocomplete (same as CreateRfq)
        async Task<IEnumerable<RqfCustomerProjectAssociationUxModel>> SearchProjects(string searchText, CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);

            // If no search text, return all projects (sorted)
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return RfqUxClientService.CustomerProjectAssociations
                    .OrderBy(p => p.ProjectName)
                    .ThenBy(p => p.CustomerName);
            }

            // Search across project name and customer name
            return RfqUxClientService.CustomerProjectAssociations
                .Where(p =>
                    (p.ProjectName?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (p.CustomerName?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false))
                .OrderBy(p => p.ProjectName?.StartsWith(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                .ThenBy(p => p.ProjectName)
                .ThenBy(p => p.CustomerName);
        }
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
        async Task UploadFilesAsync()
        {
            if (FileObjects.Count == 0)
            {
                Snackbar.Add("No files to upload", Severity.Info);
                Logger.GenericLogInformation("EditRfq.UploadFilesAsync - No files available");
                return;
            }

            // Create a progress state object that will be shared with the dialog
            SubmissionProgressState progressState = new SubmissionProgressState();

            // Initialize progress dialog
            DialogParameters parameters = new DialogParameters<SubmissionProgressDialog>
            {
                { x => x.ProgressState, progressState }
            };

            DialogOptions options = new DialogOptions()
            {
                CloseButton = false,
                BackdropClick = false,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            IDialogReference dialog = await DialogService.ShowAsync<SubmissionProgressDialog>("Uploading Files", parameters, options);

            try
            {
                // Checkpoint 1: Validation
                progressState.UpdateProgress("Validating files...", 0);
                progressState.SetCheckpointActive(0);

                await Task.Delay(500); // Small delay for UX

                List<FileObjectUxModel> validFiles = FileObjects.Where(f => f.Status != UxObjectStatus.Deleted && f.IsFileValid).ToList();

                if (validFiles.Count == 0)
                {
                    progressState.SetError("Validation failed: No valid files", "Please upload at least one valid file.");
                    Logger.GenericLogInformation("EditRfq.UploadFilesAsync - Validation failed: No valid files");
                    return;
                }

                progressState.SetCheckpointCompleted(0, $"{validFiles.Count} valid file(s) ready for upload");
                Logger.GenericLogInformation($"EditRfq.UploadFilesAsync - Checkpoint: Validation OK - {validFiles.Count} valid files");

                // Checkpoint 2: Upload Files
                progressState.UpdateProgress("Uploading files...", 1);
                progressState.SetCheckpointActive(1);

                bool allOk = true;
                int fileCount = 0;
                int skippedCount = 0;
                int totalFiles = validFiles.Count;

                foreach (FileObjectUxModel fileObject in validFiles)
                {
                    try
                    {
                        if (fileObject.File == null || !fileObject.IsFileValid)
                        {
                            skippedCount++;
                            Logger.GenericLogInformation($"EditRfq.UploadFilesAsync - Skipping invalid file: {fileObject.DisplayName}");
                            continue;
                        }

                        fileCount++;
                        progressState.UpdateProgress($"Uploading file {fileCount} of {totalFiles}: {fileObject.File.Name}", 1);

                        UploadPartsRequestGrpcResponse uploadFileResponse = await RfqUxClientService.UploadPartsAsync(RfqProjectId.ToString(CultureInfo.InvariantCulture), fileObject.File, 16_000_000);
                        fileObject.UploadStatus = new FileObjectUploadStatus(uploadFileResponse);
                        allOk = allOk && uploadFileResponse.Success;

                        Logger.GenericLogInformation($"EditRfq.UploadFilesAsync - Uploaded file {fileObject.File.Name}/{fileObject.File.Size}, {fileObject.UploadStatus.Status}/{fileObject.UploadStatus.Message}");
                    }
                    catch (Exception fileEx)
                    {
                        Logger.GenericLogError($"EditRfq.UploadFilesAsync - Error uploading file {fileObject.DisplayName}", fileEx);
                        fileObject.UploadStatus = new FileObjectUploadStatus
                        {
                            Status = FileUploadStatus.Failed,
                            Message = $"Upload error: {fileEx.Message}"
                        };
                        allOk = false;
                    }
                }

                string uploadSummary = skippedCount > 0
                    ? $"Uploaded {fileCount} file(s), skipped {skippedCount} invalid file(s)"
                    : $"Uploaded {fileCount} file(s)";

                progressState.SetCheckpointCompleted(1, uploadSummary);
                Logger.GenericLogInformation($"EditRfq.UploadFilesAsync - Checkpoint: {uploadSummary}");

                // Checkpoint 3: Reload Data
                progressState.UpdateProgress("Reloading part numbers...", 2);
                progressState.SetCheckpointActive(2);

                await Task.Delay(500); // Small delay for UX

                // Reload the part numbers to get the newly uploaded data
                await LoadRfqAndPartNumbersAsync();

                progressState.SetCheckpointCompleted(2, "Data reloaded successfully");
                Logger.GenericLogInformation("EditRfq.UploadFilesAsync - Checkpoint: Data reloaded");

                // Checkpoint 4: Finalize
                progressState.UpdateProgress("Finalizing upload...", 3);
                progressState.SetCheckpointActive(3);

                await Task.Delay(500); // Small delay for UX

                progressState.SetCheckpointCompleted(3, "Upload completed");
                Logger.GenericLogInformation($"EditRfq.UploadFilesAsync - Checkpoint: Upload finalized, success: {allOk}");

                // Final update
                progressState.SetCompleted(allOk ? "File upload completed successfully!" : "File upload completed with some errors", !allOk);

                StateHasChanged();

                if (allOk)
                {
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                    Snackbar.Add("Files uploaded successfully!", Severity.Success);
                }
                else
                {
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                    Snackbar.Add("Files uploaded with some errors. Please check the file status.", Severity.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.GenericLogError("EditRfq.UploadFilesAsync - Unexpected error during file upload", ex);
                progressState.SetError("An unexpected error occurred", $"Error: {ex.Message}", isCompleted: true);
                Snackbar.Add($"Error uploading files: {ex.Message}", Severity.Error);
            }
        }

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
            List<RfqDrawingPartNumberUxModel?> allParts = new();
            allParts.AddRange(_CompletedParts);
            allParts.AddRange(_InProgressParts);

            try
            {
                // Save pending NPR changes BEFORE reloading (otherwise the editor gets destroyed)
                if (_ComponentNprEditor != null && _ComponentNprEditor.HasPendingChanges)
                {
                    await _ComponentNprEditor.SaveNprRequestsAsync();
                }

                UpdateRfqDrawingPartNumbersGrpcResponse partsUpdateResult = await RfqUxClientService.UpdateRfqDrawingPartNumbersAsync(allParts);
                UpdateRfqProjectGrpcResponse rfqUpdateResult = await RfqUxClientService.UpdateRfqProjectAsync(RfqProject!);

                if (partsUpdateResult.Success && rfqUpdateResult.Success)
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
            if (_InProgressParts.Count == 0)
            {
                Snackbar.Add("No in-progress parts to search", Severity.Info);
                return;
            }

            bool? confirm = await DialogService.ShowMessageBox(
                "Confirm Search All",
                $"Search EMACS for all {_InProgressParts.Count} in-progress part(s)? Auto-matched parts will be moved to Completed.",
                yesText: "Search All",
                cancelText: "Cancel"
            );

            if (confirm != true)
            {
                return;
            }

            _IsSearchingAll = true;
            _SearchCancellationTokenSource?.Dispose();
            _SearchCancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = _SearchCancellationTokenSource.Token;
            _SearchInitialTotalParts = TotalParts;

            // Snapshot so we can mutate _InProgressParts safely while iterating.
            List<RfqDrawingPartNumberUxModel?> partsSnapshot = _InProgressParts.ToList();

            // Build per-part progress state and open the dialog.
            SearchProgressState progressState = new SearchProgressState();
            progressState.Initialize(partsSnapshot.Select(p => p?.CustomerPartNumber ?? "(unknown)"));
            progressState.OnCancelRequested = () =>
            {
                try
                {
                    _SearchCancellationTokenSource?.Cancel();
                }
                catch (ObjectDisposedException)
                {
                    // Already disposed — nothing to do.
                }
            };

            DialogParameters parameters = new DialogParameters<SearchProgressDialog>
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

            IDialogReference dialog = await DialogService.ShowAsync<SearchProgressDialog>(
                "Search All Part Numbers", parameters, options);

            int processed = 0;
            int movedExact = 0;
            int movedContains = 0;
            int unmatched = 0;

            try
            {
                StateHasChanged();

                // ----------------------------------------------------------------
                // Search each part successively so the dialog updates after every
                // individual gRPC call rather than waiting for a full batch.
                // ----------------------------------------------------------------
                for (int partIndex = 0; partIndex < partsSnapshot.Count; partIndex++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    RfqDrawingPartNumberUxModel? item = partsSnapshot[partIndex];
                    if (item == null)
                    {
                        progressState.CompletePartAsUnmatched(partIndex, "skipped (null)");
                        unmatched++;
                        continue;
                    }

                    // Mark this checkpoint active in the dialog immediately.
                    progressState.StartPart(
                        partIndex,
                        $"Searching {partIndex + 1} of {partsSnapshot.Count}: {item.CustomerPartNumber}");

                    processed++;

                    // Reset previous search state on the part (mirrors PartNumbersEditGrid.OnSearch).
                    // `item` is the SAME reference held by _InProgressParts — mutations persist on the
                    // in-progress object.
                    item.SearchResultPartNumbers.Clear();
                    item.Comments = string.Empty;

                    if (string.IsNullOrEmpty(item.CustomerPartNumber))
                    {
                        Logger.GenericLogInformation(
                            $"EditRfq.SearchAllPartNumbersAsync - No valid part number for Row ID: {item.RowId}");
                        progressState.CompletePartAsUnmatched(partIndex, "invalid part number");
                        unmatched++;
                        continue;
                    }

                    try
                    {
                        // One gRPC call per part — response arrives and the dialog checkpoint
                        // is completed before we move on to the next part.
                        SearchPartPricesGrpcResponse response = await RfqUxClientService.SearchPartPricesAsync(
                            new List<string> { item.CustomerPartNumber },
                            cancellationToken);

                        // The service returns one PriceResponse per input part number.
                        PriceResponse? priceResponse = response.PriceResponse
                            .FirstOrDefault(pr =>
                                string.Equals(
                                    pr.CustomerPartNumber,
                                    item.CustomerPartNumber,
                                    StringComparison.OrdinalIgnoreCase));

                        if (priceResponse != null)
                        {
                            bool isExactMatch = priceResponse.ExactMatch ?? false;
                            int candidateIndex = 0;

                            // -------------------------------------------------------
                            // Save ALL returned price lines onto the in-progress part's
                            // SearchResultPartNumbers list for later manual review.
                            // -------------------------------------------------------
                            foreach (PriceInformation priceInfo in priceResponse.PriceInformation)
                            {
                                RfqDrawingPartNumberUxModel candidate = new RfqDrawingPartNumberUxModel();
                                candidate.IsExactMatch = isExactMatch;
                                candidate.Index = candidateIndex++;
                                candidate.DrawingPartNumber = priceInfo.SumitomoNumber ?? string.Empty;
                                candidate.DrawingPartNumberPrice = priceInfo.Price is double d
                                    ? Convert.ToDecimal(d, CultureInfo.InvariantCulture)
                                    : 0m;
                                candidate.PriceSource = priceInfo.PriceSource ?? string.Empty;
                                item.SearchResultPartNumbers.Add(candidate);
                            }

                            Logger.GenericLogInformation(
                                $"EditRfq.SearchAllPartNumbersAsync - {item.CustomerPartNumber}: " +
                                $"exactMatch={isExactMatch}, candidates={item.SearchResultPartNumbers.Count}");
                        }

                        // Pick the best priced candidate from the (now populated) list.
                        RfqDrawingPartNumberUxModel? bestExact = item.SearchResultPartNumbers
                            .FirstOrDefault(x => x.IsExactMatch && x.DrawingPartNumberPrice > 0m);

                        RfqDrawingPartNumberUxModel? bestContains = bestExact == null
                            ? item.SearchResultPartNumbers
                                .FirstOrDefault(x => !x.IsExactMatch && x.DrawingPartNumberPrice > 0m)
                            : null;

                        RfqDrawingPartNumberUxModel? bestMatch = bestExact ?? bestContains;

                        if (bestMatch != null)
                        {
                            // Auto-match: swap the matched part number / price into the part's fields.
                            // SearchResultPartNumbers is intentionally NOT cleared so all candidates
                            // remain visible on the completed row.
                            item.DrawingPartNumber = bestMatch.DrawingPartNumber;
                            item.DrawingPartNumberPrice = bestMatch.DrawingPartNumberPrice;
                            item.IsExactMatch = bestExact != null;
                            item.IsSwapped = false;
                            item.PriceSource = bestMatch.PriceSource;
                            item.Status = bestExact != null
                                ? RfqDrawingPartNumberStatus.ExactMatch
                                : RfqDrawingPartNumberStatus.ContainsMatch;

                            bool ok = await RfqUxClientService.UpdateRfqDrawingPartNumber(item);
                            if (ok)
                            {
                                if (bestExact != null)
                                {
                                    movedExact++;
                                    progressState.CompletePartAsExactMatch(
                                        partIndex,
                                        $"exact: {item.DrawingPartNumber} @ {item.DrawingPartNumberPrice:0.##### €}");
                                }
                                else
                                {
                                    movedContains++;
                                    progressState.CompletePartAsContainsMatch(
                                        partIndex,
                                        $"contains: {item.DrawingPartNumber} @ {item.DrawingPartNumberPrice:0.##### €}");
                                }

                                Logger.GenericLogInformation(
                                    $"EditRfq.SearchAllPartNumbersAsync - Auto-matched ({item.Status}): " +
                                    $"{item.CustomerPartNumber} -> {item.DrawingPartNumber} @ {item.DrawingPartNumberPrice}");
                            }
                            else
                            {
                                Logger.GenericLogInformation(
                                    $"EditRfq.SearchAllPartNumbersAsync - Failed to persist auto-match for {item.CustomerPartNumber}");
                                progressState.CompletePartAsUnmatched(partIndex, "persist failed");
                                unmatched++;
                            }
                        }
                        else
                        {
                            // No priced hit — keep in In-Progress; candidate list preserved for manual review.
                            unmatched++;
                            int candidateCount = item.SearchResultPartNumbers.Count;
                            progressState.CompletePartAsUnmatched(
                                partIndex,
                                candidateCount == 0
                                    ? "no matches"
                                    : $"{candidateCount} candidate(s) saved, no price");

                            Logger.GenericLogInformation(
                                $"EditRfq.SearchAllPartNumbersAsync - No priced match for {item.CustomerPartNumber}; " +
                                $"saved {candidateCount} candidate(s) on the in-progress part for review");
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        Logger.GenericLogError(
                            $"EditRfq.SearchAllPartNumbersAsync - Error processing {item.CustomerPartNumber}", ex);
                        progressState.CompletePartAsUnmatched(partIndex, $"error: {ex.Message}");
                        unmatched++;
                    }

                    // Yield to the Blazor renderer so the dialog re-renders with this
                    // part's completed checkpoint before starting the next search call.
                    StateHasChanged();
                    await Task.Yield();
                }

                // Move every auto-matched part from In-Progress to Completed.
                List<RfqDrawingPartNumberUxModel?> toMove = _InProgressParts
                    .Where(p => p != null
                        && (p.Status == RfqDrawingPartNumberStatus.ExactMatch
                            || p.Status == RfqDrawingPartNumberStatus.ContainsMatch))
                    .ToList();

                foreach (RfqDrawingPartNumberUxModel? p in toMove)
                {
                    _InProgressParts.Remove(p);
                    _CompletedParts.Add(p);
                }

                // Invariant: total BOM size must not change across a Search All run.
                Debug.Assert(
                    _CompletedParts.Count + _InProgressParts.Count == _SearchInitialTotalParts,
                    "SearchAllPartNumbersAsync changed total BOM size");

                string summary = $"Processed {processed}, exact-matched {movedExact}, " +
                                 $"contains-matched {movedContains}, unmatched {unmatched}";
                progressState.SetCompleted(summary);

                Snackbar.Add(
                    $"Search All complete: {summary}",
                    unmatched == 0 && (movedExact + movedContains) > 0 ? Severity.Success : Severity.Info);
            }
            catch (OperationCanceledException)
            {
                progressState.SetError("Search cancelled", "Cancellation was requested by the user.", isCompleted: true);
                Snackbar.Add("Search All cancelled", Severity.Warning);
                Logger.GenericLogInformation("EditRfq.SearchAllPartNumbersAsync - Cancelled by user");
            }
            catch (Exception ex)
            {
                progressState.SetError("Search failed", ex.Message, isCompleted: true);
                Logger.GenericLogError("EditRfq.SearchAllPartNumbersAsync - Unexpected error during Search All", ex);
                Snackbar.Add($"Search All failed: {ex.Message}", Severity.Error);
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

    }
}