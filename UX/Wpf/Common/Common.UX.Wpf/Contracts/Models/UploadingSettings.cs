using System;
using Prism.Mvvm;

namespace Common.UX.Wpf.Contracts.Models
{
    public class UploadingSettings : BindableBase
    {
        public UploadingSettings()
        {
            IsBusy = false;
            IsIndeterminate = true;
            LoadingText = "Uploading";
            Progress = 0.0D;
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private string _loadingText = "Loading";
        public string LoadingText
        {
            get => _loadingText;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    SetProperty(ref _loadingText, "Loading");
                else

                    SetProperty(ref _loadingText, value);
            }
        }

        private double _progress;
        public double Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }
        private bool _isIndeterminate;
        public bool IsIndeterminate
        {
            get => _isIndeterminate;
            set => SetProperty(ref _isIndeterminate, value);
        }

        private TimeSpan? _tooLongTime;
        public TimeSpan? TooLongTime
        {
            get => _tooLongTime;
            set
            {
                if (value == null)
                    SetProperty(ref _tooLongTime, TimeSpan.FromSeconds(30));
                else
                    SetProperty(ref _tooLongTime, value);
            }
        }
    }
}
