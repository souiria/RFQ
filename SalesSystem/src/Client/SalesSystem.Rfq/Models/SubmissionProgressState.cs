namespace SalesSystem.Rfq.Models
{
    public class SubmissionProgressState : INotifyPropertyChanged
    {
        string _CurrentMessage;
        bool _IsCompleted;
        bool _HasError;
        string _ErrorMessage;
        ObservableCollection<CheckpointProgress> _Checkpoints;

        public SubmissionProgressState()
        {
            _CurrentMessage = "Initializing...";
            _IsCompleted = false;
            _HasError = false;
            _ErrorMessage = string.Empty;
            _Checkpoints = new ObservableCollection<CheckpointProgress>
            {
                new("Validating form data"),
                new("Creating RFQ project"),
                new("Uploading files"),
                new("Finalizing submission")
            };
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
        /// Callback action to be executed when the user clicks Done after successful completion
        /// </summary>
        public Action? OnSuccessCallback
        { get; set; }

        public void UpdateProgress(string message, int activeCheckpointIndex)
        {
            CurrentMessage = message;
            
            // Reset all checkpoints to inactive
            foreach (CheckpointProgress checkpoint in Checkpoints)
            {
                checkpoint.SetInactive();
            }
            
            // Set the current checkpoint as active
            if (0 <= activeCheckpointIndex && activeCheckpointIndex < Checkpoints.Count)
            {
                Checkpoints[activeCheckpointIndex].SetActive();
            }
            
            OnPropertyChanged(nameof(Checkpoints));
        }

        public void SetCheckpointActive(int index)
        {
            if (0 <= index && index < Checkpoints.Count)
            {
                Checkpoints[index].SetActive();
                OnPropertyChanged(nameof(Checkpoints));
            }
        }

        public void SetCheckpointCompleted(int index, string? details = null)
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