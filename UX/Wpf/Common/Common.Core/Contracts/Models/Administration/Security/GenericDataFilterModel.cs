using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class GenericDataFilterModel : BaseModel<Guid>
    {
        private Guid _modelGuid;
        [DataMember]
        public Guid ModelGuid
        {
            get => _modelGuid;
            set => SetProperty(ref _modelGuid, value);
        }

        private string _displayName;
        [DataMember]
        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        private bool? _isSelected = false;
        public bool? IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
