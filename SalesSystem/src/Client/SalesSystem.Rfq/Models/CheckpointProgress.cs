namespace SalesSystem.Rfq.Models
{
    public class CheckpointProgress : INotifyPropertyChanged
    {
        string _Message;
        bool _IsCompleted;
        bool _IsActive;
        string _Details;
        DateTime? _CompletedAt;

        public CheckpointProgress(string message)
        {
            _Message = message;
            _IsCompleted = false;
            _IsActive = false;
            _Details = string.Empty;
            _CompletedAt = null;
        }

        public string Message
        {
            get => _Message;
            set
            {
                _Message = value;
                OnPropertyChanged(nameof(Message));
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

        public bool IsActive
        {
            get => _IsActive;
            private set
            {
                _IsActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        public string Details
        {
            get => _Details;
            private set
            {
                _Details = value;
                OnPropertyChanged(nameof(Details));
            }
        }

        public DateTime? CompletedAt
        {
            get => _CompletedAt;
            private set
            {
                _CompletedAt = value;
                OnPropertyChanged(nameof(CompletedAt));
            }
        }

        public void SetActive()
        {
            IsActive = true;
            IsCompleted = false;
        }

        public void SetCompleted(string? details = null)
        {
            IsActive = false;
            IsCompleted = true;
            CompletedAt = DateTime.Now;
            if (!string.IsNullOrEmpty(details))
            {
                Details = details;
            }
        }

        public void SetInactive()
        {
            IsActive = false;
            //IsCompleted = false;
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