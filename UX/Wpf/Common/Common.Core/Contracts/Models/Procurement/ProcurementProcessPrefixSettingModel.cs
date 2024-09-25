using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Procurement
{
    [DataContract, Serializable]
    public class ProcurementProcessPrefixSettingModel : BaseModel<Guid>
    {
        private string _prefixCode;
        [DataMember]
        [Required]
        [StringLength(1)]
        public string PrefixCode
        {
            get => _prefixCode;
            set => SetProperty(ref _prefixCode, value);
        }

        private string _prefixDescription;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string PrefixDescription
        {
            get => _prefixDescription;
            set => SetProperty(ref _prefixDescription, value);
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
