using Common.Core.Contracts.Interfaces.Administration.Security;
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class ModuleSecurityModel : BaseModel<Guid>, ISecurityModel
    {
        private string _activeDirectoryGroup;

        [DataMember]
        public string ActiveDirectoryGroup
        {
            get => _activeDirectoryGroup;
            set => SetProperty(ref _activeDirectoryGroup, value);
        }

        private string _labelKey;

        [DataMember]
        public string LabelKey
        {
            get => _labelKey;
            set => SetProperty(ref _labelKey, value);
        }

        private int _displayId;
        [DataMember]
        public int DisplayId
        {
            get => _displayId;
            set => SetProperty(ref _displayId, value);
        }

        private int _parentDisplayId;
        [DataMember]
        public int ParentDisplayId
        {
            get => _parentDisplayId;
            set => SetProperty(ref _parentDisplayId, value);
        }

        private string _displayLabel;
        [DataMember]
        public string DisplayLabel
        {
            get => _displayLabel;
            set => SetProperty(ref _displayLabel, value);
        }

        private string _displayName;

        [DataMember]
        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        private string _imageSource;

        [DataMember]
        public string ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        private bool _isExpanded = true;
        public bool IsExpanded
        {
            get => _isExpanded;
            set => SetProperty(ref _isExpanded, value);
        }

        private bool? _isSelected = false;
        public bool? IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        private ObservableCollection<ViewSecurityModel> _views;

        [DataMember]
        public ObservableCollection<ViewSecurityModel> Views
        {
            get => _views;
            set => SetProperty(ref _views, value);
        }
    }
}
