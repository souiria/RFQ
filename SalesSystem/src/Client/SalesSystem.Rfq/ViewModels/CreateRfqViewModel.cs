namespace SalesSystem.Rfq.ViewModels
{
    public partial class CreateRfqViewModel : ObservableObject, IAsyncInitializable, IDisposable
    {
        public const string DefaultDragClass = "relative rounded-lg border-2 border-dashed pa-4 mt-4 mud-width-full mud-height-full";

        readonly RfqUxClientService _RfqUxClientService;
        readonly ILogger<CreateRfqViewModel> _Logger;
        readonly ISnackbar _Snackbar;
        readonly IDialogService _DialogService;
        readonly NavigationManager _Navigation;
        readonly List<FileObjectUxModel> _FileObjects = new();
        bool _Disposed;

        public CreateRfqViewModel(
            RfqUxClientService rfqUxClientService,
            ILogger<CreateRfqViewModel> logger,
            ISnackbar snackbar,
            IDialogService dialogService,
            NavigationManager navigation)
        {
            _RfqUxClientService = rfqUxClientService;
            _Logger = logger;
            _Snackbar = snackbar;
            _DialogService = dialogService;
            _Navigation = navigation;
        }

        [ObservableProperty]
        GlobalValue? _GlobalValue;

        [ObservableProperty]
        string? _CustomerValue;

        [ObservableProperty]
        string? _CustomerProjectValue; // Kept for backward compatibility with validation

        [ObservableProperty]
        RfqCustomerProjectAssociationUxModel? _SelectedProject;

        [ObservableProperty]
        string? _ReasonValue;

        [ObservableProperty]
        string? _QuotationValue;

        [ObservableProperty]
        int _VehicleVolume;

        [ObservableProperty]
        DateTime? _Date = DateTime.Today;

        [ObservableProperty]
        bool _UploadedSuccessfully;

        [ObservableProperty]
        string _DragClass = DefaultDragClass;

        public ReadOnlyCollection<FileObjectUxModel> FileObjects => _FileObjects.AsReadOnly();
        public int CreatedProjectId { get; private set; }

        // Allows the component to reset the FileManager's underlying InputFile when a file is removed.
        public Func<Task>? ResetInputFileRequested { get; set; }

        public IReadOnlyCollection<CustomerUxModel?> Customers => _RfqUxClientService.Customers;
        public IReadOnlyCollection<RfqReasonGrpc> Reasons => _RfqUxClientService.Reasons;
        public IReadOnlyCollection<string> QuotationNumbers => _RfqUxClientService.QuotationNumbers;

        public bool ProcessDataDisabled =>
            string.IsNullOrWhiteSpace(CustomerValue)
            || SelectedProject == null
            || string.IsNullOrWhiteSpace(ReasonValue)
            || string.IsNullOrWhiteSpace(QuotationValue)
            || VehicleVolume <= 0
            || !Date.HasValue
            || FileObjects.Count <= 0
            || !FileObjects.Any(f => f.Status != UxObjectStatus.Deleted && f.IsFileValid);

        public async Task InitializeAsync()
        {
            if (GlobalValue?.UserId == null || GlobalValue.UserId == Guid.Empty)
            {
                _Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                _Snackbar.Add("Not an authenticated user", Severity.Error);
                LogMissingUserId();
                return;
            }

            if (_RfqUxClientService.Customers.Count == 0)
            {
                Func<Guid, Task<int>> guidAsyncService = _RfqUxClientService.GetCustomersByUserIdAsync;
                (long timing, int count) = await guidAsyncService.TimeAsyncGuidIntService((Guid)GlobalValue.UserId);
                LogLoadedCustomers(count, GlobalValue?.UserId, timing);
            }

            if (_RfqUxClientService.Reasons.Count == 0)
            {
                Func<Task<int>> guidAsyncService = _RfqUxClientService.GetRfqReasonsAsync;
                (long timing, int count) = await guidAsyncService.TimeAsyncVoidIntService();
                LogLoadedReasons(count, timing);
            }
        }

        #region Customer
        public async Task OnCustomerValueChangedAsync(string value)
        {
            CustomerValue = value;
            CustomerUxModel? customer = _RfqUxClientService.Customers.FirstOrDefault(c => c?.CustomerBusinessGroupName == value);
            LogCustomerChanged(customer?.Id, customer?.CustomerBusinessGroupName);

            // Clear selected project when customer changes
            SelectedProject = null;
            CustomerProjectValue = null;

#pragma warning disable CA1031 // Intentional top-level catch at the UI error boundary; failure is surfaced via logging.
            try
            {
                await GetProjectAssociationsByCustomerNameAsync(value);
            }
            catch (OperationCanceledException ex)
            {
                LogCustomerProjectsCanceled(ex, CustomerValue);
                throw;
            }
            catch (ArgumentException ex)
            {
                LogCustomerProjectsArgumentError(ex, CustomerValue);
            }
            catch (InvalidOperationException ex)
            {
                LogCustomerProjectsInvalidOperation(ex, CustomerValue);
            }
#pragma warning restore CA1031
        }

        async Task GetProjectAssociationsByCustomerNameAsync(string customerName)
        {
            if (string.IsNullOrWhiteSpace(CustomerValue))
            {
                return;
            }

            CustomerUxModel? customer = _RfqUxClientService.Customers.FirstOrDefault(c => c?.CustomerBusinessGroupName == customerName);

            if (customer != null && Guid.TryParse(customer.Id, out Guid customerId))
            {
                await _RfqUxClientService.GetProjectAssociationsByCustomerIdAsync(customerId.ToString());
                OnPropertyChanged(nameof(CustomerProjectAssociations));
            }
            else
            {
                LogCustomerNotFound(customerName);
            }
        }

        public IReadOnlyCollection<RfqCustomerProjectAssociationUxModel> CustomerProjectAssociations => _RfqUxClientService.CustomerProjectAssociations;
        #endregion

        #region Reason
        public async Task OnReasonValueChangedAsync(string value)
        {
            ReasonValue = value;

            RfqReasonGrpc? reason = await _RfqUxClientService.Reasons
                .ToAsyncEnumerable()
                .FirstOrDefaultAsync(r => r.RfqReasonTitle == value);
            LogReasonChanged(reason?.RowId, reason?.RfqReasonTitle);
        }
        #endregion

        #region Project Autocomplete
        public async Task<IEnumerable<RfqCustomerProjectAssociationUxModel>> SearchProjectsAsync(string searchText, CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken); // Keep async signature and respect cancellation

            if (string.IsNullOrWhiteSpace(searchText))
            {
                return _RfqUxClientService.CustomerProjectAssociations
                    .OrderBy(p => p.ProjectCode)
                    .ThenBy(p => p.CustomerName);
            }

            return _RfqUxClientService.CustomerProjectAssociations
                .Where(p =>
                    (p.ProjectCode?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (p.CustomerName?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false))
                .OrderBy(p => p.ProjectCode)
                .ThenBy(p => p.CustomerName);
        }
        #endregion

        #region Quotation
        public void HandleQuotationValueChanged(string value)
        {
            QuotationValue = value;

            RfqReasonGrpc? quotation = _RfqUxClientService.Reasons.FirstOrDefault(r => r.RfqReasonTitle == value);
            LogQuotationChanged(quotation?.RowId, value);
        }
        #endregion

        #region Drag/Drop
        public void SetDragClass() => DragClass = $"{DefaultDragClass} mud-border-primary";

        public void ClearDragClass() => DragClass = DefaultDragClass;
        #endregion

        #region Files
        public async Task AddFilesAsync(Collection<FileObjectUxModel> newFiles)
        {
            if (newFiles is null || newFiles.Count == 0)
            {
                return;
            }

            foreach (FileObjectUxModel file in newFiles)
            {
                _FileObjects.Add(file);
            }

            OnPropertyChanged(nameof(FileObjects));
            await Task.CompletedTask;
        }

        public async Task ClearFilesAsync()
        {
            _FileObjects.Clear();

            if (ResetInputFileRequested != null)
            {
                await ResetInputFileRequested.Invoke();
            }

            OnPropertyChanged(nameof(FileObjects));
        }

        public async Task RestoreFileAsync(FileObjectUxModel fileObject)
        {
            if (fileObject != null && fileObject.Status == UxObjectStatus.Deleted)
            {
                fileObject.Status = UxObjectStatus.Created;
                LogRemovedFile(fileObject.DisplayName); // consider adding a dedicated LogRestoredFile source-generated message
                OnPropertyChanged(nameof(FileObjects));
            }

            await Task.CompletedTask;
        }

#pragma warning disable CA1031 // Intentional top-level catch at the UI error boundary; failure is surfaced via snackbar.
        public async Task HandleFileRemovalAsync(FileObjectUxModel fileObject)
        {
            try
            {
                // Ensure the ID is passed as a string so the source generator can format it
                LogRemovingFile(fileObject.DisplayName, fileObject.Id?.ToString());

                if (fileObject.CanBeRemovedSafely)
                {
                    bool removed = _FileObjects.Remove(fileObject);

                    if (removed)
                    {
                        if (ResetInputFileRequested != null)
                        {
                            await ResetInputFileRequested.Invoke();
                        }

                        LogRemovedFile(fileObject.DisplayName);
                        _Snackbar.Add($"File '{fileObject.DisplayName}' removed successfully", Severity.Success);
                    }
                    else
                    {
                        LogFileNotFound(fileObject.DisplayName);
                    }
                }
                else
                {
                    fileObject.Status = UxObjectStatus.Deleted;
                    LogMarkedFileDeleted(fileObject.DisplayName);
                    _Snackbar.Add($"File '{fileObject.DisplayName}' marked as deleted", Severity.Info);
                }

                OnPropertyChanged(nameof(FileObjects));
            }
            catch (Exception ex)
            {
                LogFileRemovalError(ex, fileObject.DisplayName);
                _Snackbar.Add($"Error removing file: {ex.Message}", Severity.Error);
                throw;
            }
        }
#pragma warning restore CA1031
        #endregion

        #region Submission
#pragma warning disable CA1031 // Intentional top-level catch at the UI error boundary; failure is surfaced via the progress dialog.
        public async Task ProcessDataAsync()
        {
            SubmissionProgressState progressState = new SubmissionProgressState();

            progressState.OnSuccessCallback = () =>
            {
                try
                {
                    if (CreatedProjectId > 0)
                    {
                        LogNavigatingToEditRfq();
                        _Navigation.NavigateTo($"/editRfq/{CreatedProjectId}");
                    }
                    else
                    {
                        LogNavigatingToDashboard();
                        _Navigation.NavigateTo("/");
                    }
                }
                catch (OperationCanceledException ex)
                {
                    LogNavigationCanceled(ex);
                    _Snackbar.Add("Navigation was canceled. Please manually navigate to the dashboard.", Severity.Warning);
                }
                catch (ArgumentException ex)
                {
                    LogNavigationArgumentError(ex);
                    _Snackbar.Add("Navigation error occurred. Please manually navigate to the dashboard.", Severity.Warning);
                }
                catch (InvalidOperationException ex)
                {
                    LogNavigationInvalidOperation(ex);
                    _Snackbar.Add("Navigation error occurred. Please manually navigate to the dashboard.", Severity.Warning);
                }
                catch (Exception ex)
                {
                    LogNavigationError(ex);
                    _Snackbar.Add("Navigation error occurred. Please manually navigate to the dashboard.", Severity.Warning);
                    throw;
                }
            };

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

            IDialogReference dialog = await _DialogService.ShowAsync<SubmissionProgressDialog>("Processing RFQ", parameters, options);

            try
            {
                // Checkpoint 1: Validation
                progressState.UpdateProgress("Validating form data...", 0);
                progressState.SetCheckpointActive(0);

                await Task.Delay(500); // Small delay for UX

                if (string.IsNullOrWhiteSpace(CustomerValue)
                || SelectedProject == null
                || string.IsNullOrWhiteSpace(ReasonValue)
                || string.IsNullOrWhiteSpace(QuotationValue)
                || VehicleVolume <= 0 || !Date.HasValue)
                {
                    progressState.SetError("Validation failed: Missing required fields", "Please fill in all required fields.");
                    LogValidationFailedMissingFields();
                    return;
                }

                CustomerUxModel? customer = _RfqUxClientService.Customers.FirstOrDefault(c => c?.CustomerBusinessGroupName == CustomerValue);
                if (customer is null)
                {
                    progressState.SetError("Validation failed: Customer not found", "Selected customer not found.");
                    LogValidationFailedCustomerNotFound();
                    return;
                }

                RfqCustomerProjectAssociationUxModel customerProject = SelectedProject;

                RfqReasonGrpc? reason = _RfqUxClientService.Reasons.FirstOrDefault(r => r.RfqReasonTitle == ReasonValue);
                if (reason is null)
                {
                    progressState.SetError("Validation failed: Reason not found", "Selected reason not found.");
                    LogValidationFailedReasonNotFound();
                    return;
                }

                if (FileObjects.Count <= 0 || !FileObjects.Any(f => f.Status != UxObjectStatus.Deleted && f.IsFileValid))
                {
                    progressState.SetError("Validation failed: No valid files", "Please upload at least one valid file.");
                    LogValidationFailedNoFiles();
                    return;
                }

                progressState.SetCheckpointCompleted(0, "All validations passed");
                LogValidationsOk();

                // Checkpoint 2: Create RFQ ProjectName
                progressState.UpdateProgress("Creating RFQ project...", 1);
                progressState.SetCheckpointActive(1);

                RfqProject requestProject = new RfqProject();
                requestProject.CustomerBusinessUnitGuid = customer.Id;
                requestProject.CustomerLocationGuid = customerProject.CustomerId;
                requestProject.ProjectGuid = customerProject.ProjectId;
                requestProject.RfqReasonId = reason.RowId ?? 0;
                requestProject.VehicleVolume = VehicleVolume;
                requestProject.RfqResponseDeadline = Timestamp.FromDateTime(Date.Value.ToUniversalTime());
                requestProject.IsActive = true;

                CreateRfqProjectGrpcResponse response = await _RfqUxClientService.CreateRfqProjectAsync(requestProject);

                if (response == null)
                {
                    progressState.SetError("Failed to create project", $"Failed to create project:{Environment.NewLine}Response is null.");
                    LogCreateProjectNullResponse();
                    return;
                }
                else if (response.Success == false)
                {
                    progressState.SetError("Failed to create project", $"Failed to create project:{Environment.NewLine}{response.Message}");
                    LogCreateProjectFailed(response.Message);
                    return;
                }

                progressState.SetCheckpointCompleted(1, $"ProjectName created:{Environment.NewLine}{response.CreatedProjectId}");
                LogProjectCreated(response.CreatedProjectId);
                CreatedProjectId = Convert.ToInt32(response.CreatedProjectId, CultureInfo.InvariantCulture);

                // Checkpoint 3: Files
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
                            LogSkippingInvalidFile(fileObject.DisplayName);
                            continue;
                        }

                        fileCount++;
                        progressState.UpdateProgress($"Uploading file {fileCount} of {totalFiles}: {fileObject.File.Name}", 2);

                        UploadPartsRequestGrpcResponse uploadFileResponse = await _RfqUxClientService.UploadBomFileAsync(response.CreatedProjectId, fileObject.File, GlobalValue?.UserId, 16_000_000);
                        fileObject.UploadStatus = new FileObjectUploadStatus(uploadFileResponse);
                        allOk = allOk && uploadFileResponse.Success == true;

                        if (uploadFileResponse.Success == true)
                        {
                            LogFileUploaded(fileObject.File.Name, fileObject.File.Size, fileObject.UploadStatus.Status, fileObject.UploadStatus.Message);
                        }
                        else
                        {
                            LogFileUploadFailed(fileObject.File.Name, fileObject.File.Size, fileObject.UploadStatus.Status, fileObject.UploadStatus.Message);
                        }
                    }
                    catch (Exception fileEx)
                    {
                        LogFileUploadError(fileEx, fileObject.DisplayName);
                        fileObject.UploadStatus = new FileObjectUploadStatus
                        {
                            Status = FileUploadStatus.Failed,
                            Message = $"Upload error: {fileEx.Message}"
                        };
                        allOk = false;
                        throw;
                    }
                }

                string uploadSummary = skippedCount > 0
                    ? $"{Environment.NewLine}Uploaded {fileCount} files, skipped {skippedCount} invalid files"
                    : $"{Environment.NewLine}Uploaded {fileCount} files";

                progressState.SetCheckpointCompleted(2, uploadSummary);
                LogUploadSummary(uploadSummary);

                // Checkpoint 4: Finalize
                progressState.UpdateProgress($"{Environment.NewLine}Finalizing submission...", 3);
                progressState.SetCheckpointActive(3);

                await Task.Delay(500); // Small delay for UX

                UploadedSuccessfully = allOk;
                progressState.SetCheckpointCompleted(3, "Submission completed");
                LogSubmissionFinalized(allOk);

                progressState.SetCompleted(allOk ? "RFQ submission completed successfully!" : "RFQ submission completed with some errors", !allOk);

                if (allOk)
                {
                    _Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                    _Snackbar.Add("RFQ submitted successfully!", Severity.Success);
                }
                else
                {
                    _Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                    _Snackbar.Add("RFQ submitted with some file upload errors. Please check the file status.", Severity.Warning);
                }
            }
            catch (OperationCanceledException ex)
            {
                LogSubmissionCanceled(ex);
                progressState.SetError("Submission canceled", $"Operation was canceled: {ex.Message}", isCompleted: true);
                throw;
            }
            catch (ArgumentException ex)
            {
                LogSubmissionArgumentError(ex);
                progressState.SetError("Argument error occurred", $"Error: {ex.Message}", isCompleted: true);
                throw;
            }
            catch (InvalidOperationException ex)
            {
                LogSubmissionInvalidOperation(ex);
                progressState.SetError("Invalid operation occurred", $"Error: {ex.Message}", isCompleted: true);
                throw;
            }
            catch (Exception ex)
            {
                LogSubmissionUnexpectedError(ex);
                progressState.SetError("An unexpected error occurred", $"Error: {ex.Message}", isCompleted: true);
                // Do NOT rethrow here — the dialog already reflects the error state,
                // and rethrowing crashes the render pipeline before the user can click Close.
            }
        }
#pragma warning restore CA1031
        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed)
            {
                return;
            }

            if (disposing)
            {
                // dispose managed resources here if any are added in the future
            }

            _Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "CreateRfq.InitializeAsync - UserId is missing in the URL")]
        partial void LogMissingUserId();

        [LoggerMessage(EventId = 2, Level = LogLevel.Information, Message = "CreateRfq.InitializeAsync - Loaded {Count} customers for UserId {UserId} in {Timing}ms")]
        partial void LogLoadedCustomers(int count, Guid? userId, long timing);

        [LoggerMessage(EventId = 3, Level = LogLevel.Information, Message = "CreateRfq.InitializeAsync - Loaded {Count} reasons in {Timing}ms")]
        partial void LogLoadedReasons(int count, long timing);

        [LoggerMessage(EventId = 4, Level = LogLevel.Information, Message = "CreateRfq.OnCustomerValueChanged - Customer changed to {CustomerId} - {CustomerName}")]
        partial void LogCustomerChanged(string? customerId, string? customerName);

        [LoggerMessage(EventId = 5, Level = LogLevel.Error, Message = "CreateRfq.OnCustomerValueChanged - Operation canceled while loading customer projects for customer '{CustomerValue}'")]
        partial void LogCustomerProjectsCanceled(Exception ex, string? customerValue);

        [LoggerMessage(EventId = 6, Level = LogLevel.Error, Message = "CreateRfq.OnCustomerValueChanged - Argument error while loading customer projects for customer '{CustomerValue}'")]
        partial void LogCustomerProjectsArgumentError(Exception ex, string? customerValue);

        [LoggerMessage(EventId = 7, Level = LogLevel.Error, Message = "CreateRfq.OnCustomerValueChanged - Invalid operation while loading customer projects for customer '{CustomerValue}'")]
        partial void LogCustomerProjectsInvalidOperation(Exception ex, string? customerValue);

        [LoggerMessage(EventId = 8, Level = LogLevel.Information, Message = "CreateRfq.GetProjectAssociationsByCustomerName - Customer not found or invalid ID for '{CustomerName}'")]
        partial void LogCustomerNotFound(string customerName);

        [LoggerMessage(EventId = 9, Level = LogLevel.Information, Message = "CreateRfq.OnReasonValueChanged - Reason changed to {RowId} - {Title}")]
        partial void LogReasonChanged(long? rowId, string? title);

        [LoggerMessage(EventId = 10, Level = LogLevel.Information, Message = "Quotation changed to {RowId} - {Value}")]
        partial void LogQuotationChanged(long? rowId, string value);
        [LoggerMessage(EventId = 11, Level = LogLevel.Information, Message = "CreateRfq.HandleFileRemoval - Starting removal for file: {DisplayName} (ID: {Id})")]
        partial void LogRemovingFile(string displayName, string? id);

        [LoggerMessage(EventId = 12, Level = LogLevel.Information, Message = "CreateRfq.HandleFileRemoval - Completely removed file: {DisplayName}")]
        partial void LogRemovedFile(string displayName);

        [LoggerMessage(EventId = 13, Level = LogLevel.Information, Message = "CreateRfq.HandleFileRemoval - File not found in collection: {DisplayName}")]
        partial void LogFileNotFound(string displayName);

        [LoggerMessage(EventId = 14, Level = LogLevel.Information, Message = "CreateRfq.HandleFileRemoval - Marked uploaded file as deleted: {DisplayName}")]
        partial void LogMarkedFileDeleted(string displayName);

        [LoggerMessage(EventId = 15, Level = LogLevel.Error, Message = "CreateRfq.HandleFileRemoval - Error removing file: {DisplayName}")]
        partial void LogFileRemovalError(Exception ex, string displayName);

        [LoggerMessage(EventId = 16, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Navigating to EditRfq after successful RFQ submission")]
        partial void LogNavigatingToEditRfq();

        [LoggerMessage(EventId = 17, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Navigating to dashboard after successful RFQ submission")]
        partial void LogNavigatingToDashboard();

        [LoggerMessage(EventId = 18, Level = LogLevel.Error, Message = "CreateRfq.ProcessDataAsync - Navigation canceled")]
        partial void LogNavigationCanceled(Exception ex);

        [LoggerMessage(EventId = 19, Level = LogLevel.Error, Message = "CreateRfq.ProcessDataAsync - Invalid argument during navigation")]
        partial void LogNavigationArgumentError(Exception ex);

        [LoggerMessage(EventId = 20, Level = LogLevel.Error, Message = "CreateRfq.ProcessDataAsync - Invalid operation during navigation")]
        partial void LogNavigationInvalidOperation(Exception ex);

        [LoggerMessage(EventId = 21, Level = LogLevel.Error, Message = "CreateRfq.ProcessDataAsync - Error navigating to dashboard")]
        partial void LogNavigationError(Exception ex);

        [LoggerMessage(EventId = 22, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Validation failed: Missing required fields")]
        partial void LogValidationFailedMissingFields();

        [LoggerMessage(EventId = 23, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Validation failed: Customer not found")]
        partial void LogValidationFailedCustomerNotFound();

        [LoggerMessage(EventId = 24, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Validation failed: Reason not found")]
        partial void LogValidationFailedReasonNotFound();

        [LoggerMessage(EventId = 25, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Validation failed: No valid files")]
        partial void LogValidationFailedNoFiles();

        [LoggerMessage(EventId = 26, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Checkpoint: Validations OK")]
        partial void LogValidationsOk();

        [LoggerMessage(EventId = 27, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Failed to create project. Response is null.")]
        partial void LogCreateProjectNullResponse();

        [LoggerMessage(EventId = 28, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Failed to create project. {Message}")]
        partial void LogCreateProjectFailed(string message);

        [LoggerMessage(EventId = 29, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Checkpoint: RFQ created with ID {CreatedProjectId}")]
        partial void LogProjectCreated(string createdProjectId);

        [LoggerMessage(EventId = 30, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Skipping invalid file: {DisplayName}")]
        partial void LogSkippingInvalidFile(string displayName);

        [LoggerMessage(EventId = 31, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Uploaded file {FileName}/{Size}, {Status}/{Message}")]
        partial void LogFileUploaded(string fileName, long size, FileUploadStatus status, string message);

        [LoggerMessage(EventId = 32, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Upload failed for file {FileName}/{Size}, {Status}/{Message}")]
        partial void LogFileUploadFailed(string fileName, long size, FileUploadStatus status, string message);

        [LoggerMessage(EventId = 33, Level = LogLevel.Error, Message = "CreateRfq.ProcessDataAsync - Error uploading file {DisplayName}")]
        partial void LogFileUploadError(Exception ex, string displayName);

        [LoggerMessage(EventId = 34, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Checkpoint: {Summary}")]
        partial void LogUploadSummary(string summary);

        [LoggerMessage(EventId = 35, Level = LogLevel.Information, Message = "CreateRfq.ProcessDataAsync - Checkpoint: Submission finalized, success: {Success}")]
        partial void LogSubmissionFinalized(bool success);

        [LoggerMessage(EventId = 36, Level = LogLevel.Error, Message = "CreateRfq.ProcessDataAsync - Operation canceled during submission")]
        partial void LogSubmissionCanceled(Exception ex);

        [LoggerMessage(EventId = 37, Level = LogLevel.Error, Message = "CreateRfq.ProcessDataAsync - Argument error during submission")]
        partial void LogSubmissionArgumentError(Exception ex);

        [LoggerMessage(EventId = 38, Level = LogLevel.Error, Message = "CreateRfq.ProcessDataAsync - Invalid operation during submission")]
        partial void LogSubmissionInvalidOperation(Exception ex);

        [LoggerMessage(EventId = 39, Level = LogLevel.Error, Message = "CreateRfq.ProcessDataAsync - Unexpected error during submission")]
        partial void LogSubmissionUnexpectedError(Exception ex);
    }
}