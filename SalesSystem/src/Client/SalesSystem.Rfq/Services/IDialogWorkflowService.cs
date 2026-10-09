namespace SalesSystem.Rfq.Services
{
    /// <summary>
    ///     Provides a reusable pattern for running an async action while showing a
    ///     modal loading dialog, so pages don't need to know about DialogOptions,
    ///     DialogParameters, or the loading-dialog lifecycle.
    /// </summary>
    public interface IDialogWorkflowService
    {
        /// <summary>
        ///     Shows a modal loading dialog with <paramref name="message" /> while
        ///     <paramref name="action" /> runs, closing it once the action completes.
        /// </summary>
        Task<T> RunWithLoadingAsync<T>(string message, Func<Task<T>> action);

        /// <summary>
        ///     Shows a modal loading dialog with <paramref name="message" /> while
        ///     <paramref name="action" /> runs, closing it once the action completes.
        /// </summary>
        Task RunWithLoadingAsync(string message, Func<Task> action);
    }
}
