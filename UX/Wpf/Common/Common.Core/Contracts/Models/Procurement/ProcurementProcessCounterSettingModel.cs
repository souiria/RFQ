using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Procurement
{
    [DataContract, Serializable]
    public class ProcurementProcessCounterSettingModel : BaseModel<Guid>
    {
        private string _counterKey;
        [DataMember]
        [Required]
        [StringLength(5)]
        public string CounterKey
        {
            get => _counterKey;
            set => SetProperty(ref _counterKey, value);
        }

        private string _counterKeyName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string CounterKeyName
        {
            get => _counterKeyName;
            set => SetProperty(ref _counterKeyName, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
