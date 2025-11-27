namespace SalesSystem.Rfq.Models
{
    public class SearchProgressStateChangedEventArgs : EventArgs
    {
        // Add properties if you want to pass additional info with the event
    }

    public class SearchProgressState
    {
        public event EventHandler<SearchProgressStateChangedEventArgs>? StateChanged;

        public int TotalCount 
        { get; private set; }
        public int ProcessedCount 
        { get; private set; }
        public int TotalSearched 
        { get; private set; }
        public int TotalMatched 
        { get; private set; }
        public int TotalUnmatched 
        { get; private set; }
        public int MultiMatchCount 
        { get; private set; }
        public string CurrentPartNumber 
        { get; private set; } = string.Empty;
        public bool IsComplete 
        { get; private set; }
        public bool CanCancel 
        { get; private set; } = true;

        CancellationTokenSource? _CancellationTokenSource;

        public SearchProgressState(CancellationTokenSource? cancellationTokenSource)
        {
            _CancellationTokenSource = cancellationTokenSource;
        }

        public SearchProgressState(int totalCount, CancellationTokenSource cancellationTokenSource)
        {
            TotalCount = totalCount;
            _CancellationTokenSource = cancellationTokenSource;
        }

        public void UpdateProgress(
            int processedCount,
            int totalSearched,
            int totalMatched,
            int totalUnmatched,
            int multiMatchCount,
            string currentPartNumber)
        {
            ProcessedCount = processedCount;
            TotalSearched = totalSearched;
            TotalMatched = totalMatched;
            TotalUnmatched = totalUnmatched;
            MultiMatchCount = multiMatchCount;
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
            SearchProgressStateChangedEventArgs state = new SearchProgressStateChangedEventArgs();
            StateChanged?.Invoke(this, state);
        }
    }
}