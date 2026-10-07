namespace SalesSystem.Rfq.Services
{
#pragma warning disable CA1002 // Do not expose generic lists
    /// <summary>
    ///     Plan describing which in-progress parts will become new NPR requests
    ///     and which ones match pre-existing NPR requests from other RFQ projects.
    /// </summary>
    public class NprRequestWorkflowPlan
    {
        public List<RfqDrawingPartNumberUxModel> NewParts { get; } = new List<RfqDrawingPartNumberUxModel>();
        public List<RfqNprRequestUxModel> PreExistingNprRequests { get; } = new List<RfqNprRequestUxModel>();

        /// <summary>
        ///     True when there are already NPR requests tracked globally, meaning the
        ///     user should be asked to confirm taking over/updating pre-existing ones.
        /// </summary>
        public bool HasExistingGlobalNprRequests { get; set; }
    }

    /// <summary>
    ///     Result of committing a <see cref="NprRequestWorkflowPlan" />.
    /// </summary>
    public class NprRequestCommitResult
    {
        public int NewCreatedCount { get; set; }
        public int PreExistingUpdatedCount { get; set; }
    }

    /// <summary>
    ///     Result of submitting NPR requests to the NPR API.
    /// </summary>
    public class NprSubmissionResult
    {
        public bool Success { get; set; }
        public string StatusMessage { get; set; } = string.Empty;
        public string? NprRequestNumber { get; set; }
    }

    /// <summary>
    ///     Encapsulates the NPR request creation/update/submission workflow that used
    ///     to live directly in the EditRfq component.
    /// </summary>
    public class NprRequestWorkflowService
    {
        readonly RfqUxClientService _RfqUxClientService;
        readonly ILogger<NprRequestWorkflowService> _Logger;
        readonly ISnackbar _Snackbar;
        readonly IDialogService _DialogService;
        readonly IDialogWorkflowService _DialogWorkflowService;

        public NprRequestWorkflowService(
            RfqUxClientService rfqUxClientService,
            ILogger<NprRequestWorkflowService> logger,
            ISnackbar snackbar,
            IDialogService dialogService,
            IDialogWorkflowService dialogWorkflowService)
        {
            _RfqUxClientService = rfqUxClientService;
            _Logger = logger;
            _Snackbar = snackbar;
            _DialogService = dialogService;
            _DialogWorkflowService = dialogWorkflowService;
        }

        public RfqNprRequestUxModel? GetRfqNprRequestByCustomerNumber(RfqProjectUxModel rfqProject, RfqDrawingPartNumberUxModel part)
        {
            return rfqProject?.NprRequests.FirstOrDefault(x => x.CustomerPartNumber?.Trim().ToUpperInvariant() == part.CustomerPartNumber?.Trim().ToUpperInvariant());
        }

        /// <summary>
        ///     Computes which in-progress parts will result in new NPR requests and
        ///     which already have a pre-existing NPR request under another RFQ.
        /// </summary>
        public async Task<NprRequestWorkflowPlan> PrepareNprAllAsync(RfqProjectUxModel rfqProject, IEnumerable<RfqDrawingPartNumberUxModel?> inProgressParts)
        {
            ArgumentNullException.ThrowIfNull(rfqProject);

            NprRequestWorkflowPlan plan = new NprRequestWorkflowPlan();

            int count = await _RfqUxClientService.GetAllNprRequestsAsync();
            plan.HasExistingGlobalNprRequests = count > 0;

            foreach (RfqDrawingPartNumberUxModel? r in inProgressParts)
            {
                if (r is null)
                {
                    continue;
                }

                RfqNprRequestUxModel? found = count > 0
                    ? _RfqUxClientService.NprRequests.FirstOrDefault(x => r.CustomerPartNumber == x?.CustomerPartNumber && x?.CustomerRfqNo != rfqProject.RfqNumber)
                    : null;

                if (found != null)
                {
                    plan.PreExistingNprRequests.Add(found);
                }
                else
                {
                    plan.NewParts.Add(r);
                }
            }

            return plan;
        }

        /// <summary>
        ///     Persists the NPR requests described by <paramref name="plan" />: creates new
        ///     ones for unmatched parts and updates pre-existing ones taken over from other RFQs.
        /// </summary>
        public async Task<NprRequestCommitResult> CommitNprAllAsync(RfqProjectUxModel rfqProject, NprRequestWorkflowPlan plan, GlobalValue? globalValue)
        {
            ArgumentNullException.ThrowIfNull(rfqProject);
            ArgumentNullException.ThrowIfNull(plan);

            NprRequestCommitResult result = new NprRequestCommitResult();
            DateTime now = DateTime.UtcNow;

            if (plan.NewParts.Count > 0)
            {
                List<RfqNprRequestUxModel> nprRequests = new List<RfqNprRequestUxModel>();

                foreach (RfqDrawingPartNumberUxModel part in plan.NewParts)
                {
                    RfqNprRequestUxModel? nprRequest = GetRfqNprRequestByCustomerNumber(rfqProject, part);
                    if (nprRequest == null)
                    {
                        nprRequest = part.ToNprRequest(rfqProject);
                        nprRequest.CustomerRfqNo = rfqProject.RfqNumber;
                        nprRequest.Created = now;
                        nprRequest.Updated = now;
                        nprRequest.UxStatus = UxObjectStatus.Created;
                        nprRequests.Add(nprRequest);
                    }
                }

                if (globalValue != null)
                {
                    foreach (RfqNprRequestUxModel nprRequest in nprRequests)
                    {
                        nprRequest.Update(rfqProject, globalValue);
                    }
                }

                rfqProject.NprRequests.Clear();
                List<RfqNprRequestUxModel> response = await _RfqUxClientService.CreateNprRequestsAsync(nprRequests);
                rfqProject.NprRequests.AddRange(response);
                result.NewCreatedCount = plan.NewParts.Count;
            }

            if (plan.PreExistingNprRequests.Count > 0)
            {
                foreach (RfqNprRequestUxModel r in plan.PreExistingNprRequests)
                {
                    r.CustomerRfqNo = rfqProject.RfqNumber;
                    r.Updated = DateTime.UtcNow;
                    r.UxStatus = UxObjectStatus.Updated;
                }

                List<RfqNprRequestUxModel> response = await _RfqUxClientService.UpdateNprRequestsAsync(plan.PreExistingNprRequests);
                rfqProject.NprRequests.AddRange(response);
                result.PreExistingUpdatedCount = plan.PreExistingNprRequests.Count;
            }

            return result;
        }

        /// <summary>
        ///     Submits the given NPR requests to the NPR API and refreshes NPR status descriptions.
        /// </summary>
        public async Task<NprSubmissionResult> SubmitAsync(List<RfqNprRequestUxModel> toSubmit)
        {
            ArgumentNullException.ThrowIfNull(toSubmit);

            CreateNprGrpcResponse response = await _RfqUxClientService.CreateNprGrpcAsync(toSubmit);

            _Logger.GenericLogInformation(
                $"NprRequestWorkflowService.SubmitAsync - Response: HttpStatusCode='{response.HttpStatusCode}', " +
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

            return new NprSubmissionResult
            {
                Success = ok,
                StatusMessage = statusMessage,
                NprRequestNumber = nprRequestNumber
            };
        }

        /// <summary>
        ///     Full orchestration for the "NPR All" action: confirms with the user,
        ///     persists pending edits, computes the plan, confirms take-over of
        ///     pre-existing requests if needed, and commits the result.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public async Task<bool> NprAllInProgressPartsAsync(
            RfqProjectUxModel? rfqProject,
            IReadOnlyList<RfqDrawingPartNumberUxModel> inProgressParts,
            GlobalValue? globalValue,
            Func<Task> saveDataAsync)
        {
            ArgumentNullException.ThrowIfNull(inProgressParts);
            ArgumentNullException.ThrowIfNull(saveDataAsync);

            if (rfqProject == null)
            {
                _Snackbar.Add("No Rfq ProjectName to process for NPR", Severity.Error);
                return false;
            }

            if (inProgressParts.Count == 0)
            {
                _Snackbar.Add("No unmatched parts to process for NPR", Severity.Info);
                return false;
            }

            try
            {
                bool? confirm = await _DialogService.ShowMessageBoxAsync(
                    "Confirm NPR All",
                    $"Are you sure you want to create NPR requests for all {inProgressParts.Count} unmatched part(s)? This will UPDATE CHANGES.",
                    yesText: "Create NPR for All",
                    cancelText: "Cancel"
                );

                if (confirm != true)
                {
                    return false;
                }

                _Logger.GenericLogInformation($"NprRequestWorkflowService.NprAllInProgressPartsAsync - Creating NPR for {inProgressParts.Count} unmatched parts");

                await saveDataAsync();

                NprRequestWorkflowPlan plan = await PrepareNprAllAsync(rfqProject, inProgressParts);

                if (plan.HasExistingGlobalNprRequests)
                {
                    confirm = await _DialogService.ShowMessageBoxAsync(
                        "Commit NPR Requests",
                        $"Are you sure you want to create {plan.NewParts.Count} NPR requests and take over {plan.PreExistingNprRequests.Count} older NPR requests? This will UPDATE CHANGES.",
                        yesText: $"Commit {plan.NewParts.Count + plan.PreExistingNprRequests.Count} NPR requests",
                        cancelText: "Cancel"
                    );

                    if (confirm != true)
                    {
                        return false;
                    }
                }

                NprRequestCommitResult result = await CommitNprAllAsync(rfqProject, plan, globalValue);

                bool changed = false;

                if (result.NewCreatedCount > 0)
                {
                    _Snackbar.Add($"Successfully created new NPR request set for {result.NewCreatedCount} part(s)", Severity.Success);
                    changed = true;
                }

                if (result.PreExistingUpdatedCount > 0)
                {
                    _Snackbar.Add($"Successfully updated pre-existing {result.PreExistingUpdatedCount} NPR request(s)", Severity.Success);
                    changed = true;
                }

                return changed;
            }
            catch (InvalidOperationException ex)
            {
                _Logger.GenericLogError("NprRequestWorkflowService.NprAllInProgressPartsAsync - Invalid operation error creating NPR for parts", ex);
                _Snackbar.Add($"Error creating NPR requests: {ex.Message}", Severity.Error);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                _Logger.GenericLogError("NprRequestWorkflowService.NprAllInProgressPartsAsync - Argument null error creating NPR for parts", ex);
                _Snackbar.Add($"Error creating NPR requests: {ex.Message}", Severity.Error);
                throw;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("NprRequestWorkflowService.NprAllInProgressPartsAsync - Unexpected error creating NPR for parts", ex);
                _Snackbar.Add($"Error creating NPR requests: {ex.Message}", Severity.Error);
                throw;
            }
        }

        /// <summary>
        ///     Full orchestration for submitting all active NPR requests to the NPR API:
        ///     confirms with the user, persists any pending editor changes, runs the
        ///     submission behind a loading dialog, and shows the result/error dialog.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public async Task<bool> SubmitAllNprRequestsAsync(
            RfqProjectUxModel? rfqProject,
            Func<bool> hasPendingEditorChanges,
            Func<Task> saveEditorChangesAsync,
            Func<Task> reloadNprRequestsAsync,
            Action? notifyEditorStateChanged)
        {
            ArgumentNullException.ThrowIfNull(hasPendingEditorChanges);
            ArgumentNullException.ThrowIfNull(saveEditorChangesAsync);
            ArgumentNullException.ThrowIfNull(reloadNprRequestsAsync);

            if (rfqProject?.NprRequests == null || rfqProject.NprRequests.Count == 0)
            {
                _Snackbar.Add("No NPR requests to submit", Severity.Info);
                return false;
            }

            // Only submit requests that are not soft-deleted.
            List<RfqNprRequestUxModel> toSubmit = rfqProject.NprRequests
                .Where(r => r.UxStatus != UxObjectStatus.Deleted)
                .ToList();

            if (toSubmit.Count == 0)
            {
                _Snackbar.Add("No active NPR requests to submit", Severity.Info);
                return false;
            }

            bool? confirm = await _DialogService.ShowMessageBoxAsync(
                "Submit NPR Requests",
                $"Submit {toSubmit.Count} NPR request(s) to the NPR API?",
                yesText: $"Submit {toSubmit.Count}",
                cancelText: "Cancel"
            );

            if (confirm != true)
            {
                return false;
            }

            try
            {
                // Persist any pending NPR edits BEFORE submitting so the API sees the latest data.
                if (hasPendingEditorChanges())
                {
                    await saveEditorChangesAsync();
                }

                _Logger.GenericLogInformation(
                    $"NprRequestWorkflowService.SubmitAllNprRequestsAsync - Submitting {toSubmit.Count} NPR request(s) for RFQ {rfqProject.RfqNumber}");

                NprSubmissionResult submissionResult = await _DialogWorkflowService.RunWithLoadingAsync(
                    "Sending Npr Request to Engineering endpoint, please wait!",
                    () => SubmitAsync(toSubmit));

                bool ok = submissionResult.Success;

                DialogParameters submitStatusParameters = new DialogParameters
                {
                    { nameof(NprSubmissionStatusDialog.IsSuccess), ok },
                    { nameof(NprSubmissionStatusDialog.RfqNumber), rfqProject.RfqNumber },
                    { nameof(NprSubmissionStatusDialog.NprRequestNumber), submissionResult.NprRequestNumber },
                    { nameof(NprSubmissionStatusDialog.StatusMessage), submissionResult.StatusMessage }
                };

                DialogOptions submitStatusOptions = new DialogOptions
                {
                    MaxWidth = MaxWidth.Medium,
                    FullWidth = true,
                    CloseButton = true,
                    CloseOnEscapeKey = true
                };

                await _DialogService.ShowAsync<NprSubmissionStatusDialog>(
                    ok ? "NPR Submission Successful" : "NPR Submission Warning",
                    submitStatusParameters,
                    submitStatusOptions);

                // Refresh from DB so any RequestID assignments / status changes are picked up.
                await reloadNprRequestsAsync();
                notifyEditorStateChanged?.Invoke();

                return true;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("NprRequestWorkflowService.SubmitAllNprRequestsAsync - Error submitting NPR requests", ex);

                DialogParameters submitErrorParameters = new DialogParameters
                {
                    { nameof(NprSubmissionStatusDialog.IsSuccess), false },
                    { nameof(NprSubmissionStatusDialog.RfqNumber), rfqProject?.RfqNumber ?? string.Empty },
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

                await _DialogService.ShowAsync<NprSubmissionStatusDialog>(
                    "NPR Submission Error",
                    submitErrorParameters,
                    submitErrorOptions);

                return false;
            }
        }
    }
#pragma warning restore CA1002
}
