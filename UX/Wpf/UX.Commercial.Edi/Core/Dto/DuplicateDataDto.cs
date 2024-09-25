using System;
using Prism.Mvvm;

namespace UX.Commercial.Edi.Core.Dto
{
    public class DuplicateDataDto : BindableBase
    {
        private bool _isMarkedForDeletion;
        private bool _isMarkedForReprocessing;
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string DispatchNumber { get; set; }

        public bool IsMarkedForDeletion
        {
            get => _isMarkedForDeletion;
            set
            {
                SetProperty(ref _isMarkedForDeletion, value);
                if (value)
                    IsMarkedForReprocessing = !value;
            }
        }

        public bool IsMarkedForReprocessing
        {
            get => _isMarkedForReprocessing;
            set
            {
                SetProperty(ref _isMarkedForReprocessing, value);
                if (value)
                    IsMarkedForDeletion = !value;
            }
        }
    }
}
