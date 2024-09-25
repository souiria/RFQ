using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Core.Settings
{
    [DataContract, Serializable]
    public class ServiceValidationModel : BaseModel<Guid>
    {
        private bool? _isServiceValidationEnabled = true;
        [DataMember]
        public bool? IsServiceValidationEnabled
        {
            get => _isServiceValidationEnabled;
            set => SetProperty(ref _isServiceValidationEnabled, value);
        }

        [DataMember]
        public List<Guid> H1ConfigurationSettingItems { get; set; }

    }
}