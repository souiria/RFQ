using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class GenericServiceDataFilterModel : BaseModel<Guid>
    {
        private IEnumerable<Guid> _modelGuids;
        [DataMember]
        public IEnumerable<Guid> ModelGuids
        {
            get => _modelGuids;
            set => SetProperty(ref _modelGuids, value);
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
