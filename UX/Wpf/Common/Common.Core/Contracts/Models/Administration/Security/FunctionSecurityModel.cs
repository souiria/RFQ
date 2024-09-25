using Common.Core.Contracts.Interfaces.Administration.Security;
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class FunctionSecurityModel :  BaseModel<Guid>, ISecurityModel
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

        private string _displayLabel;
        public string DisplayLabel
        {
            get => _displayLabel;
            set => SetProperty(ref _displayLabel, value);
        }

        private int _displayId;

        [DataMember]
        public int DisplayId
        {
            get => _displayId;
            set => SetProperty(ref _displayId, value);
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

        private ObservableCollection<ModuleSecurityModel> _modules;

        [DataMember]
        public ObservableCollection<ModuleSecurityModel> Modules
        {
            get => _modules;
            set => SetProperty(ref _modules, value);
        }
    }
}
