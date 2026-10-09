namespace SalesSystem.Rfq.Services
{
    /// <inheritdoc cref="IDialogWorkflowService" />
    public class DialogWorkflowService : IDialogWorkflowService
    {
        readonly IDialogService _DialogService;

        public DialogWorkflowService(IDialogService dialogService)
        {
            _DialogService = dialogService;
        }

        public async Task<T> RunWithLoadingAsync<T>(string message, Func<Task<T>> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            DialogParameters loadingParameters = new DialogParameters
            {
                { nameof(LoadingDialog.Message), message }
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

            IDialogReference loadingDialog = await _DialogService.ShowAsync<LoadingDialog>(
                string.Empty,
                loadingParameters,
                loadingOptions);

            try
            {
                return await action();
            }
            finally
            {
                loadingDialog.Close();
            }
        }

        public async Task RunWithLoadingAsync(string message, Func<Task> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            await RunWithLoadingAsync(
                message,
                async () =>
                {
                    await action();
                    return true;
                });
        }
    }
}
