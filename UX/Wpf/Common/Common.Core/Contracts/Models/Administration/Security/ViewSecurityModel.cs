using Common.Core.Contracts.Interfaces.Administration.Security;
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    [NotMapped]
    public class ViewSecurityModel : BaseModel<Guid>, ISecurityModel
    {
        private int _displayId;
        [DataMember]
        public int DisplayId
        {
            get => _displayId;
            set => SetProperty(ref _displayId, value);
        }

        private string _displayLabel;
        [DataMember]
        public string DisplayLabel
        {
            get => _displayLabel;
            set => SetProperty(ref _displayLabel, value);
        }

        private int _parentDisplayId;
        [DataMember]
        public int ParentDisplayId
        {
            get => _parentDisplayId;
            set => SetProperty(ref _parentDisplayId, value);
        }

        private int _grandParentDisplayId;
        [DataMember]
        public int GrandParentDisplayId
        {
            get => _grandParentDisplayId;
            set => SetProperty(ref _grandParentDisplayId, value);
        }

        private string _displayName;

        [DataMember]
        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        private string _labelKey;
        [DataMember]
        public string LabelKey
        {
            get => _labelKey;
            set => SetProperty(ref _labelKey, value);
        }

        private string _parentModuleLabelKey;
        [DataMember]
        public string ParentModuleLabelKey
        {
            get => _parentModuleLabelKey;
            set => SetProperty(ref _parentModuleLabelKey, value);
        }

        private string _parentFunctiontLabelKey;
        [DataMember]
        public string ParentFunctionLabelKey
        {
            get => _parentFunctiontLabelKey;
            set => SetProperty(ref _parentFunctiontLabelKey, value);
        }

        private string _imageSource;

        [DataMember]
        public string ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        private string _viewName;
        [DataMember]
        public string ViewName
        {
            get => _viewName;
            set => SetProperty(ref _viewName, value);
        }

        private string _activeDirectoryGroup;

        [DataMember]
        public string ActiveDirectoryGroup
        {
            get => _activeDirectoryGroup;
            set => SetProperty(ref _activeDirectoryGroup, value);
        }

        private ObservableCollection<FieldSecurityModel> _fields;

        [DataMember]
        public ObservableCollection<FieldSecurityModel> Fields
        {
            get => _fields;
            set => SetProperty(ref _fields, value);
        }

        private bool? _isSelected = false;
        public bool? IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

    }
}
