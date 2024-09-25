using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    //Class may be Obsolete
    [DataContract, NotMapped]
    public class FieldSecurityModel : BaseModel<Guid>
    {
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

        private string _variableName;

        [DataMember]
        public string VariableName
        {
            get => _variableName;
            set => SetProperty(ref _variableName, value);
        }

        private Guid _parentViewId;

        [DataMember]
        public Guid ParentViewId
        {
            get => _parentViewId;
            set => SetProperty(ref _parentViewId, value);
        }

        private bool? _isSelected = false;
        public bool? IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
