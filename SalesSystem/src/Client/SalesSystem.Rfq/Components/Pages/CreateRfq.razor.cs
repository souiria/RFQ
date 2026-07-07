using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace SalesSystem.Rfq.Components.Pages
{
    public partial class CreateRfq
    {
        // Reference to the FileManager component
        FileManager? _ComponentFileManager;
        FileCards? _ComponentFileCards;
        List<FileObjectUxModel> FileObjects 
        { get; set; }
        bool _UploadedSuccessfully;
        DateTime? _Date;
        const string DefaultDragClass = "relative rounded-lg border-2 border-dashed pa-4 mt-4 mud-width-full mud-height-full";
        string _DragClass;
        bool _IsQuotationOpen;
        public CreateRfq()
        {
            _UploadedSuccessfully = false;
            _Date = DateTime.Today;
            _DragClass = DefaultDragClass;
            FileObjects = new List<FileObjectUxModel>();
        }
        // Form values
        string? CustomerValue
        { get; set; }
        string? CustomerProjectValue
        { get; set; }  // Keep for backward compatibility with validation
        RqfCustomerProjectAssociationUxModel? SelectedProject 
        { get; set; }  // Holds the selected project object
        string? ReasonValue 
        { get; set; }
        string? ProjectValue 
        { get; set; }
        string? QuotationValue 
        { get; set; }
        int VehicleVolume 
        { get; set; }

        //[Parameter] public Guid? UserId { get; set; }
        [CascadingParameter(Name = "GlobalValue")]
        public GlobalValue? GlobalValue { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (GlobalValue?.UserId == null || GlobalValue.UserId == Guid.Empty)
            {
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                Snackbar.Add("Not an authenticated user", Severity.Error);
                Logger.GenericLogInformation("CreateRfq.OnInitializedAsync - UserId is missing in the URL");
                return;
            }

            if (RfqUxClientService.Customers.Count == 0)
            {
                Func<Guid, Task<int>> guidAsyncService = RfqUxClientService.GetCustomersByUserIdAsync;
                (long timing, int count) = await guidAsyncService.TimeAsyncGuidIntService((Guid)GlobalValue.UserId);
                Logger.GenericLogInformation($"CreateRfq.OnInitializedAsync - Loaded {count} customers for UserId {GlobalValue?.UserId} in {timing}ms");
            }

            if (RfqUxClientService.Reasons.Count == 0)
            {
                Func<Task<int>> guidAsyncService = RfqUxClientService.GetRfqReasonsAsync;
                (long timing, int count) = await guidAsyncService.TimeAsyncVoidIntService();
                Logger.GenericLogInformation($"CreateRfq.OnInitializedAsync - Loaded {count} reasons in {timing}ms");
            }
        }

        // Control generated events - only call StateHasChanged() from events (i.e. methods starting with On....)
        #region Customer
        async Task OnCustomerValueChanged(string value)
        {
            CustomerValue = value;
            CustomerUxModel? customer = RfqUxClientService.Customers.FirstOrDefault(c => c?.CustomerBusinessGroupName == value);
            Logger.GenericLogInformation($"CreateRfq.OnCustomerValueChanged - Customer changed to {customer?.Id} - {customer?.CustomerBusinessGroupName}");

            // Clear selected project when customer changes
            SelectedProject = null;
            CustomerProjectValue = null;

            try
            {
                await GetProjectAssociationsByCustomerName(value);
            }
            catch (OperationCanceledException ex)
            {
                Logger.GenericLogError($"CreateRfq.OnCustomerValueChanged - Operation canceled while loading customer projects for customer '{CustomerValue}'", ex);
                throw;
            }
            catch (ArgumentException ex)
            {
                Logger.GenericLogError($"CreateRfq.OnCustomerValueChanged - Argument error while loading customer projects for customer '{CustomerValue}'", ex);
                // Optionally rethrow or handle as needed
            }
            catch (InvalidOperationException ex)
            {
                Logger.GenericLogError($"CreateRfq.OnCustomerValueChanged - Invalid operation while loading customer projects for customer '{CustomerValue}'", ex);
                // Optionally rethrow or handle as needed
            }

            StateHasChanged();
        }

        async Task GetProjectAssociationsByCustomerName(string customerName)
        {
            if (!string.IsNullOrWhiteSpace(CustomerValue))
            {
                CustomerUxModel? customer = RfqUxClientService.Customers.FirstOrDefault(c => c?.CustomerBusinessGroupName == customerName);

                if (customer != null && Guid.TryParse(customer.Id, out Guid customerId))
                {
                    await RfqUxClientService.GetProjectAssociationsByCustomerIdAsync(customerId.ToString());
                    StateHasChanged();
                }
                else
                {
                    Logger.GenericLogInformation($"CreateRfq.GetProjectAssociationsByCustomerName - Customer not found or invalid ID for '{customerName}'");
                }
            }
        }
        #endregion

        #region Reason
        async Task OnReasonValueChanged(string value)
        {
            ReasonValue = value;
            await Task.Delay(0);

            RfqReasonGrpc? reason = RfqUxClientService.Reasons.FirstOrDefault(r => r.RfqReasonTitle == value);
            Logger.GenericLogInformation($"CreateRfq.OnReasonValueChanged - Reason changed to {reason?.RowId} - {reason?.RfqReasonTitle}");

            StateHasChanged();
        }
        #endregion

        #region Project Autocomplete

        // Add CancellationToken parameter to match MudAutocomplete's delegate signature
        async Task<IEnumerable<RqfCustomerProjectAssociationUxModel>> SearchProjects(string searchText, CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken); // Keep async signature and respect cancellation

            // If no search text, return all projects
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return RfqUxClientService.CustomerProjectAssociations;
            }

            // Search across project name, customer name, and location name
            return RfqUxClientService.CustomerProjectAssociations
                .Where(p =>
                    (p.ProjectCode?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (p.CustomerName?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false))
                .OrderBy(p => p.ProjectCode)
                .ThenBy(p => p.CustomerName);
        }

        #endregion

        bool ProcessDataDisabled
        {
            get
            {
                return        
                    string.IsNullOrWhiteSpace(CustomerValue)
                    || SelectedProject == null
                    || string.IsNullOrWhiteSpace(ReasonValue)
                    || string.IsNullOrWhiteSpace(QuotationValue)
                    || VehicleVolume <= 0
                    || !_Date.HasValue
                    || FileObjects.Count <= 0
                    || !FileObjects.Any(f => f.Status != UxObjectStatus.Deleted && f.IsFileValid);
            }
        }

        public int CreatedProjectId { get; private set; }

        async Task ProcessDataAsync()
        {
            // Create a progress state object that will be shared with the dialog
            SubmissionProgressState progressState = new SubmissionProgressState();

            // Set up navigation callback for successful completion
            progressState.OnSuccessCallback = () =>
            {
                try

                {
                    if(CreatedProjectId > 0)
                    {
                        Logger.GenericLogInformation("CreateRfq.ProcessDataAsync - Navigating to EditRfq after successful RFQ submission");
                        NavigationManager.NavigateTo($"/editRfq/{CreatedProjectId}");
                    }
                    else
                    {
                        Logger.GenericLogInformation("CreateRfq.ProcessDataAsync - Navigating to dashboard after successful RFQ submission");
                        NavigationManager.NavigateTo("/");
                    }
                }
                catch (OperationCanceledException ex)
                {
                    Logger.GenericLogError("CreateRfq.ProcessDataAsync - Navigation canceled", ex);
                    Snackbar.Add("Navigation was canceled. Please manually navigate to the dashboard.", Severity.Warning);
                }
                catch (ArgumentException ex)
                {
                    Logger.GenericLogError("CreateRfq.ProcessDataAsync - Invalid argument during navigation", ex);
                    Snackbar.Add("Navigation error occurred. Please manually navigate to the dashboard.", Severity.Warning);
                }
                catch (InvalidOperationException ex)
                {
                    Logger.GenericLogError("CreateRfq.ProcessDataAsync - Invalid operation during navigation", ex);
                    Snackbar.Add("Navigation error occurred. Please manually navigate to the dashboard.", Severity.Warning);
                }
                catch (Exception ex)
                {  
                    Logger.GenericLogError("CreateRfq.ProcessDataAsync - Error navigating to dashboard", ex);
                    Snackbar.Add("Navigation error occurred. Please manually navigate to the dashboard.", Severity.Warning);
                    throw; // Rethrow to comply with CA1031 since we're only catching Exception to log and show a message
                }
            };

            // Initialize progress dialog
            DialogParameters<SubmissionProgressDialog> parameters = new DialogParameters<SubmissionProgressDialog>
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

            IDialogReference dialog = await DialogService.ShowAsync<SubmissionProgressDialog>("Processing RFQ", parameters, options);

            try
            {
                // Checkpoint 1: Validation
                progressState.UpdateProgress("Validating form data...", 0);
                progressState.SetCheckpointActive(0);

                await Task.Delay(500); // Small delay for UX

                // Use selectedProject instead of customerProjectValue for validation
                if (string.IsNullOrWhiteSpace(CustomerValue)
                || SelectedProject == null  // Changed validation
                || string.IsNullOrWhiteSpace(ReasonValue)
                || string.IsNullOrWhiteSpace(QuotationValue)
                || VehicleVolume <= 0 || !_Date.HasValue)
                {
                    progressState.SetError("Validation failed: Missing required fields", "Please fill in all required fields.");
                    Logger.GenericLogInformation("CreateRfq.ProcessDataAsync - Validation failed: Missing required fields");
                    return;
                }

                CustomerUxModel? customer = RfqUxClientService.Customers.FirstOrDefault(c => c?.CustomerBusinessGroupName == CustomerValue);
                if (customer is null)
                {
                    progressState.SetError("Validation failed: Customer not found", "Selected customer not found.");
                    Logger.GenericLogInformation("CreateRfq.ProcessDataAsync - Validation failed: Customer not found");
                    return;
                }

                // Use selectedProject directly (already validated above)
                RqfCustomerProjectAssociationUxModel customerProject = SelectedProject;

                RfqReasonGrpc? reason = RfqUxClientService.Reasons.FirstOrDefault(r => r.RfqReasonTitle == ReasonValue);
                if (reason is null)
                {
                    progressState.SetError("Validation failed: Reason not found", "Selected reason not found.");
                    Logger.GenericLogInformation("CreateRfq.ProcessDataAsync - Validation failed: Reason not found");
                    return;
                }

                if (FileObjects.Count <= 0 || !FileObjects.Any(f => f.Status != UxObjectStatus.Deleted && f.IsFileValid))
                {
                    progressState.SetError("Validation failed: No valid files", "Please upload at least one valid file.");
                    Logger.GenericLogInformation("CreateRfq.ProcessDataAsync - Validation failed: No valid files");
                    return;
                }

                progressState.SetCheckpointCompleted(0, "All validations passed");
                Logger.GenericLogInformation($"CreateRfq.ProcessDataAsync - Checkpoint: Validations OK");

                // Checkpoint 2: Create RFQ Project
                progressState.UpdateProgress("Creating RFQ project...", 1);
                progressState.SetCheckpointActive(1);

                RfqProject requestProject = new RfqProject();
                requestProject.CustomerBusinessUnitGuid = customer.Id;
                requestProject.CustomerLocationGuid = customerProject.CustomerId;
                requestProject.ProjectGuid = customerProject.ProjectId;
                requestProject.RfqReasonId = reason.RowId ?? 0;
                requestProject.VehicleVolume = VehicleVolume;
                requestProject.RfqResponseDeadline = Timestamp.FromDateTime(_Date.Value.ToUniversalTime());
                requestProject.IsActive = true;

                CreateRfqProjectGrpcResponse response = await RfqUxClientService.CreateRfqProjectAsync(requestProject);

                if (response == null)
                {
                    progressState.SetError("Failed to create project", "Failed to create project. Response is null.");
                    Logger.GenericLogInformation("CreateRfq.ProcessDataAsync - Failed to create project. Response is null.");
                    return;
                }
                else if (response.Success == false)
                {
                    progressState.SetError("Failed to create project", $"Failed to create project. {response.Message}");
                    Logger.GenericLogInformation($"CreateRfq.ProcessDataAsync - Failed to create project. {response.Message}");
                    return;
                }

                progressState.SetCheckpointCompleted(1, $"Project created: {response.CreatedProjectId}");
                Logger.GenericLogInformation($"CreateRfq.ProcessDataAsync - Checkpoint: RFQ created with ID {response.CreatedProjectId}");
                CreatedProjectId = Convert.ToInt32(response.CreatedProjectId, CultureInfo.InvariantCulture);

                // Checkpoint 3:
                // Files
                progressState.UpdateProgress("Uploading files...", 2);
                progressState.SetCheckpointActive(2);

                bool allOk = true;
                int fileCount = 0;
                int skippedCount = 0;
                List<FileObjectUxModel> validFiles = FileObjects.Where(f => f.Status != UxObjectStatus.Deleted && f.IsFileValid).ToList();
                int totalFiles = validFiles.Count;

                foreach (FileObjectUxModel fileObject in validFiles)
                {
                    try
                    {
                        if (fileObject.File == null || !fileObject.IsFileValid)
                        {
                            skippedCount++;
                            Logger.GenericLogInformation($"CreateRfq.ProcessDataAsync - Skipping invalid file: {fileObject.DisplayName}");
                            continue;
                        }

                        fileCount++;
                        progressState.UpdateProgress($"CreateRfq.ProcessDataAsync - Uploading file {fileCount} of {totalFiles}: {fileObject.File.Name}", 2);

                        UploadPartsRequestGrpcResponse uploadFileResponse = await RfqUxClientService.UploadPartsAsync(response.CreatedProjectId, fileObject.File, GlobalValue?.UserId, 16_000_000);
                        fileObject.UploadStatus = new FileObjectUploadStatus(uploadFileResponse);
                        allOk = allOk && uploadFileResponse.Success == true;

                        if (uploadFileResponse.Success == true)
                        {
                            Logger.GenericLogInformation($"III CreateRfq.ProcessDataAsync - Uploaded file {fileObject.File.Name}/{fileObject.File.Size}, {fileObject.UploadStatus.Status}/{fileObject.UploadStatus.Message}");
                        }
                        else
                        {
                            Logger.GenericLogInformation($"FFF CreateRfq.ProcessDataAsync - Uploaded file {fileObject.File.Name}/{fileObject.File.Size}, {fileObject.UploadStatus.Status}/{fileObject.UploadStatus.Message}");
                        }
                    }
                    catch (Exception fileEx)
                    {
                        Logger.GenericLogError($"EEE CreateRfq.ProcessDataAsync - Error uploading file {fileObject.DisplayName}", fileEx);
                        fileObject.UploadStatus = new FileObjectUploadStatus
                        {
                            Status = FileUploadStatus.Failed,
                            Message = $"Upload error: {fileEx.Message}"
                        };
                        allOk = false;
                        throw; // Rethrow to ensure the error is logged by the outer catch and to comply with CA1031 since we're only catching Exception to log and update status
                    }
                }

                string uploadSummary = skippedCount > 0
                    ? $"Uploaded {fileCount} files, skipped {skippedCount} invalid files"
                    : $"Uploaded {fileCount} files";

                progressState.SetCheckpointCompleted(2, uploadSummary);
                Logger.GenericLogInformation($"CreateRfq.ProcessDataAsync - Checkpoint: {uploadSummary}");

                // Checkpoint 4: Finalize
                progressState.UpdateProgress("Finalizing submission...", 3);
                progressState.SetCheckpointActive(3);

                await Task.Delay(500); // Small delay for UX

                _UploadedSuccessfully = allOk;
                progressState.SetCheckpointCompleted(3, "Submission completed");
                Logger.GenericLogInformation($"CreateRfq.ProcessDataAsync - Checkpoint: Submission finalized, success: {allOk}");

                // Final update
                progressState.SetCompleted(allOk ? "RFQ submission completed successfully!" : "RFQ submission completed with some errors", !allOk);

                StateHasChanged();

                if (allOk)
                {
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                    Snackbar.Add("RFQ submitted successfully!", Severity.Success);
                }
                else
                {
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                    Snackbar.Add("RFQ submitted with some file upload errors. Please check the file status.", Severity.Warning);
                }
            }
            catch (OperationCanceledException ex)
            {
                Logger.GenericLogError("CreateRfq.ProcessDataAsync - Operation canceled during submission", ex);
                progressState.SetError("Submission canceled", $"Operation was canceled: {ex.Message}", isCompleted: true);
                throw;
            }
            catch (ArgumentException ex)
            {
                Logger.GenericLogError("CreateRfq.ProcessDataAsync - Argument error during submission", ex);
                progressState.SetError("Argument error occurred", $"Error: {ex.Message}", isCompleted: true);
                throw;
            }
            catch (InvalidOperationException ex)
            {
                Logger.GenericLogError("CreateRfq.ProcessDataAsync - Invalid operation during submission", ex);
                progressState.SetError("Invalid operation occurred", $"Error: {ex.Message}", isCompleted: true);
                throw;
            }
            // Only catch Exception if you rethrow, to comply with CA1031
            catch (Exception ex)
            {
                Logger.GenericLogError("CreateRfq.ProcessDataAsync - Unexpected error during submission", ex);
                progressState.SetError("An unexpected error occurred", $"Error: {ex.Message}", isCompleted: true);
                throw;
            }
        }

        void SetDragClass()
            => _DragClass = $"{DefaultDragClass} mud-border-primary";

        void ClearDragClass()
            => _DragClass = DefaultDragClass;

        void OnQuotationValueChanged(string value)
        {
            QuotationValue = value;

            RfqReasonGrpc? quotation = RfqUxClientService.Reasons.FirstOrDefault(r => r.RfqReasonTitle == value);
            Logger.GenericLogInformation($"Quotation changed to {quotation?.RowId} - {value}");

            StateHasChanged();
        }

        // REMOVED: OnCustomerProjectValueChanged is no longer needed
        // The selectedProject binding handles this automatically

        void OnFilesChanged()
        {
            StateHasChanged();
        }

        async Task HandleFileRemoval(FileObjectUxModel fileObject)
        {
            try
            {
                Logger.GenericLogInformation($"CreateRfq.HandleFileRemoval - Starting removal for file: {fileObject.DisplayName} (ID: {fileObject.Id})");

                // Check if file can be safely removed
                if (fileObject.CanBeRemovedSafely)
                {
                    // Remove completely from collection to prevent InputFile issues
                    bool removed = FileObjects.Remove(fileObject);

                    if (removed)
                    {
                        // Reset the FileManager's InputFile component to clear internal state
                        if (_ComponentFileManager != null)
                        {
                            await _ComponentFileManager.ResetInputFileAsync();
                        }

                        Logger.GenericLogInformation($"CreateRfq.HandleFileRemoval - Completely removed file: {fileObject.DisplayName}");
                        Snackbar.Add($"File '{fileObject.DisplayName}' removed successfully", Severity.Success);
                    }
                    else
                    {
                        Logger.GenericLogInformation($"CreateRfq.HandleFileRemoval - File not found in collection: {fileObject.DisplayName}");
                    }
                }
                else
                {
                    // Keep in collection but mark as deleted for uploaded files
                    fileObject.Status = UxObjectStatus.Deleted;
                    Logger.GenericLogInformation($"CreateRfq.HandleFileRemoval - Marked uploaded file as deleted: {fileObject.DisplayName}");
                    Snackbar.Add($"File '{fileObject.DisplayName}' marked as deleted", Severity.Info);
                }

                StateHasChanged();
            }
            catch (InvalidOperationException ex)
            {
                Logger.GenericLogError($"CreateRfq.HandleFileRemoval - Invalid operation removing file: {fileObject.DisplayName}", ex);
                Snackbar.Add($"Error removing file: {ex.Message}", Severity.Error);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                Logger.GenericLogError($"CreateRfq.HandleFileRemoval - Argument null removing file: {fileObject.DisplayName}", ex);
                Snackbar.Add($"Error removing file: {ex.Message}", Severity.Error);
                throw;
            }
            catch (ArgumentException ex)
            {
                Logger.GenericLogError($"CreateRfq.HandleFileRemoval - Argument error removing file: {fileObject.DisplayName}", ex);
                Snackbar.Add($"Error removing file: {ex.Message}", Severity.Error);
                throw;
            }
            catch (Exception ex)
            {
                Logger.GenericLogError($"CreateRfq.HandleFileRemoval - Unexpected error removing file: {fileObject.DisplayName}", ex);
                Snackbar.Add($"Error removing file: {ex.Message}", Severity.Error);
                throw;
            }
        }
    }
}