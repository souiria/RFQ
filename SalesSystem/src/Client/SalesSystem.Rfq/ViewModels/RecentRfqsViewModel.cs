namespace SalesSystem.Rfq.ViewModels
{
    public partial class RecentRfqsViewModel : ObservableObject, IAsyncInitializable, IDisposable
    {
        readonly RfqUxClientService _RfqUxClientService;
        readonly ILogger<RecentRfqsViewModel> _Logger;
        readonly ISnackbar _Snackbar;
        readonly NavigationManager _Navigation;
        readonly IDialogService _DialogService;

        bool _Disposed;

        public RecentRfqsViewModel(
            RfqUxClientService rfqUxClientService,
            ILogger<RecentRfqsViewModel> logger,
            ISnackbar snackbar,
            NavigationManager navigation,
            IDialogService dialogService)
        {
            _RfqUxClientService = rfqUxClientService;
            _Logger = logger;
            _Snackbar = snackbar;
            _Navigation = navigation;
            _DialogService = dialogService;
        }

        [ObservableProperty]
        bool _IsLoading = true;

        [ObservableProperty]
        bool _ShowActionsColumn = true;

        [ObservableProperty]
        string _QuickSearch = string.Empty;

        [ObservableProperty]
        GlobalValue? _GlobalValue;

        public IReadOnlyCollection<RfqProjectUxModel> RecentRfqs => _RfqUxClientService.RfqProjectUxs;

        public async Task InitializeAsync()
        {
            await RefreshAsync();
            IsLoading = false;
        }

        public async Task RefreshAsync()
        {
#pragma warning disable CA1031 // Intentional top-level catch at the UI error boundary; failure is surfaced to the user via snackbar.
            try
            {
                QuickSearch = string.Empty;
                LogLoadingProjects();
                int count = await _RfqUxClientService.GetAllRfqProjectAsync();

                if (count <= 0)
                {
                    _Snackbar.Add("No RFQ projects found.", Severity.Info);
                }

                LogLoadedProjects(_RfqUxClientService.RfqProjectUxs.Count);

                // Collection reference changes, so notify bound UI explicitly.
                OnPropertyChanged(nameof(RecentRfqs));
            }
            catch (Exception ex)
            {
                LogRefreshFailed(ex);
                _Snackbar.Add("Failed to load RFQ projects.", Severity.Error);
            }
#pragma warning restore CA1031
        }

        public void NavigateToEdit(RfqProjectUxModel project)
        {
            if (GlobalValue?.UserId != null && GlobalValue.UserId != Guid.Empty)
            {
                _Navigation.NavigateTo($"/editRfq/{project.RowId}");
            }
            else
            {
                _Snackbar.Add("User ID is required to edit RFQ.", Severity.Warning);
            }
        }

        public async Task DeleteAsync(RfqProjectUxModel project)
        {
            bool? result = await _DialogService.ShowMessageBoxAsync(
                "Delete RFQ Project",
                $"Are you sure you want to delete RFQ #{project.RfqNumber}? This action cannot be undone.",
                yesText: "Delete",
                cancelText: "Cancel",
                options: new DialogOptions() { MaxWidth = MaxWidth.Small });

            if (result != true)
            {
                return;
            }

#pragma warning disable CA1031 // Intentional top-level catch at the UI error boundary; failure is surfaced to the user via snackbar.
            try
            {
                LogDeleting(project.RowId);
                RfqCrudResponse response = await _RfqUxClientService.DeleteRfqProjectByRowIdAsync(project.RowId);

                if (response.SaveSuccess)
                {
                    _Snackbar.Add($"RFQ #{project.RfqNumber} deleted successfully.", Severity.Success);
                    LogDeleted(project.RfqNumber);

                    // Refresh the list
                    await RefreshAsync();
                }
                else
                {
                    _Snackbar.Add($"Failed to delete RFQ: {response.Message}", Severity.Error);
                    LogDeleteFailed(project.RfqNumber, response.Message);
                }
            }
            catch (Exception ex)
            {
                LogDeleteError(ex, project.RowId);
                _Snackbar.Add($"An error occurred while deleting RFQ #{project.RfqNumber}.", Severity.Error);
            }
#pragma warning restore CA1031
        }

        // quick filter - filter globally across multiple columns with the same input
        public Func<RfqProjectUxModel, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(QuickSearch))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(x.CarModel) && x.CarModel.Contains(QuickSearch, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(x.CustomerBusinessUnit) && x.CustomerBusinessUnit.Contains(QuickSearch, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(x.RfqNumber) && x.RfqNumber.Contains(QuickSearch, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        };

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

        [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Loading RFQ projects...")]
        partial void LogLoadingProjects();

        [LoggerMessage(EventId = 2, Level = LogLevel.Information, Message = "Loaded {Count} RFQ projects")]
        partial void LogLoadedProjects(int count);

        [LoggerMessage(EventId = 3, Level = LogLevel.Error, Message = "Failed to load RFQ projects")]
        partial void LogRefreshFailed(Exception ex);

        [LoggerMessage(EventId = 4, Level = LogLevel.Information, Message = "Deleting RFQ project with RowId: {RowId}")]
        partial void LogDeleting(long rowId);

        [LoggerMessage(EventId = 5, Level = LogLevel.Information, Message = "Successfully deleted RFQ project: {RfqNumber}")]
        partial void LogDeleted(string rfqNumber);

        [LoggerMessage(EventId = 6, Level = LogLevel.Warning, Message = "Delete failed for RFQ {RfqNumber}: {ResponseMessage}")]
        partial void LogDeleteFailed(string rfqNumber, string responseMessage);

        [LoggerMessage(EventId = 7, Level = LogLevel.Error, Message = "Error deleting RFQ project with RowId: {RowId}")]
        partial void LogDeleteError(Exception ex, long rowId);
    }
}