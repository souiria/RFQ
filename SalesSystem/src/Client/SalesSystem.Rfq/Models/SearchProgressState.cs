namespace SalesSystem.Rfq.Models
{
    public class SearchProgressState : INotifyPropertyChanged
    {
        string _CurrentMessage;
        bool _IsCompleted;
        bool _HasError;
        string _ErrorMessage;
        int _ProcessedCount;
        int _ExactMatchCount;
        int _ContainsMatchCount;
        int _UnmatchedCount;
        ObservableCollection<CheckpointProgress> _Checkpoints;

        public SearchProgressState()
        {
            _CurrentMessage = "Initializing search...";
            _IsCompleted = false;
            _HasError = false;
            _ErrorMessage = string.Empty;
            _ProcessedCount = 0;
            _ExactMatchCount = 0;
            _ContainsMatchCount = 0;
            _UnmatchedCount = 0;
            _Checkpoints = new ObservableCollection<CheckpointProgress>();
        }

        /// <summary>
        /// Builds one checkpoint per part to be searched.
        /// </summary>
        public void Initialize(IEnumerable<string> partLabels)
        {
            if (partLabels == null)
            {
                throw new ArgumentNullException(nameof(partLabels));
            }

            ObservableCollection<CheckpointProgress> next = new ObservableCollection<CheckpointProgress>();
            foreach (string label in partLabels)
            {
                next.Add(new CheckpointProgress(label));
            }

            Checkpoints = next;
            TotalCount = next.Count;
            ProcessedCount = 0;
            ExactMatchCount = 0;
            ContainsMatchCount = 0;
            UnmatchedCount = 0;
            CurrentMessage = $"Ready to search {TotalCount} part(s)...";
        }

        public string CurrentMessage
        {
            get => _CurrentMessage;
            private set
            {
                _CurrentMessage = value;
                OnPropertyChanged(nameof(CurrentMessage));
            }
        }

        public ObservableCollection<CheckpointProgress> Checkpoints
        {
            get => _Checkpoints;
            private set
            {
                _Checkpoints = value;
                OnPropertyChanged(nameof(Checkpoints));
            }
        }

        public int TotalCount
        { get; private set; }

        public int ProcessedCount
        {
            get => _ProcessedCount;
            private set
            {
                _ProcessedCount = value;
                OnPropertyChanged(nameof(ProcessedCount));
                OnPropertyChanged(nameof(ProgressFraction));
            }
        }

        public int ExactMatchCount
        {
            get => _ExactMatchCount;
            private set
            {
                _ExactMatchCount = value;
                OnPropertyChanged(nameof(ExactMatchCount));
            }
        }

        public int ContainsMatchCount
        {
            get => _ContainsMatchCount;
            private set
            {
                _ContainsMatchCount = value;
                OnPropertyChanged(nameof(ContainsMatchCount));
            }
        }

        public int UnmatchedCount
        {
            get => _UnmatchedCount;
            private set
            {
                _UnmatchedCount = value;
                OnPropertyChanged(nameof(UnmatchedCount));
            }
        }

        public double ProgressFraction => TotalCount == 0 ? 0d : (double)ProcessedCount / TotalCount;

        public bool IsCompleted
        {
            get => _IsCompleted;
            private set
            {
                _IsCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

        public bool HasError
        {
            get => _HasError;
            private set
            {
                _HasError = value;
                OnPropertyChanged(nameof(HasError));
            }
        }

        public string ErrorMessage
        {
            get => _ErrorMessage;
            private set
            {
                _ErrorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        /// <summary>
        /// Invoked by the dialog when the user clicks Cancel while the search is running.
        /// </summary>
        public Action? OnCancelRequested
        { get; set; }

        public void RequestCancel()
        {
            OnCancelRequested?.Invoke();
            CurrentMessage = "Cancellation requested...";
        }

        public void StartPart(int index, string message)
        {
            if (0 <= index && index < Checkpoints.Count)
            {
                Checkpoints[index].SetActive();
                CurrentMessage = message;
                OnPropertyChanged(nameof(Checkpoints));
            }
        }

        public void CompletePartAsExactMatch(int index, string details)
        {
            CompletePart(index, details);
            ExactMatchCount++;
            ProcessedCount++;
        }

        public void CompletePartAsContainsMatch(int index, string details)
        {
            CompletePart(index, details);
            ContainsMatchCount++;
            ProcessedCount++;
        }

        public void CompletePartAsUnmatched(int index, string details)
        {
            CompletePart(index, details);
            UnmatchedCount++;
            ProcessedCount++;
        }

        void CompletePart(int index, string? details)
        {
            if (0 <= index && index < Checkpoints.Count)
            {
                Checkpoints[index].SetCompleted(details);
                OnPropertyChanged(nameof(Checkpoints));
            }
        }

        public void SetError(string message, string errorMessage, bool isCompleted = false)
        {
            CurrentMessage = message;
            ErrorMessage = errorMessage;
            HasError = true;
            IsCompleted = isCompleted;
        }

        public void SetCompleted(string message, bool hasError = false)
        {
            CurrentMessage = message;
            IsCompleted = true;
            HasError = hasError;
        }

        public void UpdateMessage(string message)
        {
            CurrentMessage = message;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                handler.Invoke(this, args);
            }
        }
    }
}