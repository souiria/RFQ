using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Core.Security
{
    public class MenuItem : BaseModel<Guid>
    {
        private string _labelKey;
        [DataMember, StringLength(25)]
        public string LabelKey
        {
            get => _labelKey;
            set => SetProperty(ref _labelKey, value);
        }

        private string _activeDirectoryGroup;
        [DataMember, StringLength(250)]
        public string ActiveDirectoryGroup
        {
            get => _activeDirectoryGroup;
            set => SetProperty(ref _activeDirectoryGroup, value);
        }

        private string _displayName;
        [DataMember,StringLength(250)]
        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        private string _parentAdGroup;
        [DataMember, StringLength(250)]
        public string ParentAdGroup
        {
            get => _parentAdGroup;
            set => SetProperty(ref _parentAdGroup, value);
        }

        private string _viewName;
        [DataMember, StringLength(250)]
        public string ViewName
        {
            get => _viewName;
            set => SetProperty(ref _viewName, value);
        }

        private int _displayId;
        [DataMember]
        public int DisplayId
        {
            get => _displayId;
            set => SetProperty(ref _displayId, value);
        }

        private string _imageSource;
        [DataMember]
        public string ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }
    }
}
