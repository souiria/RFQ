namespace SalesSystem.Rfq.Models
{
    public class DeleteProgressStateChangedEventArgs : EventArgs
    {
        // Add properties if you want to pass additional info with the event
    }

    public class DeleteProgressState
    {
        public event EventHandler<DeleteProgressStateChangedEventArgs>? StateChanged;

        public int TotalCount 
        { get; private set; }
        public int ProcessedCount 
        { get; private set; }
        public int SuccessCount 
        { get; private set; }
        public int FailedCount 
        { get; private set; }
        public string CurrentPartNumber 
        { get; private set; } = string.Empty;
        public bool IsComplete 
        { get; private set; }
        public bool CanCancel 
        { get; private set; } = true;

        CancellationTokenSource? _CancellationTokenSource;

        public DeleteProgressState(CancellationTokenSource? cancellationTokenSource)
        {
            _CancellationTokenSource = cancellationTokenSource;
        }

        public DeleteProgressState(int totalCount, CancellationTokenSource cancellationTokenSource)
        {
            TotalCount = totalCount;
            _CancellationTokenSource = cancellationTokenSource;
        }

        public void UpdateProgress(
            int processedCount,
            int successCount,
            int failedCount,
            string currentPartNumber)
        {
            ProcessedCount = processedCount;
            SuccessCount = successCount;
            FailedCount = failedCount;
            CurrentPartNumber = currentPartNumber;

            NotifyStateChanged();
        }

        public void Complete()
        {
            IsComplete = true;
            NotifyStateChanged();
        }

        public void Cancel()
        {
            _CancellationTokenSource?.Cancel();
        }

        void NotifyStateChanged()
        {
            DeleteProgressStateChangedEventArgs state = new DeleteProgressStateChangedEventArgs();
            StateChanged?.Invoke(this, state);
        }
    }
}
