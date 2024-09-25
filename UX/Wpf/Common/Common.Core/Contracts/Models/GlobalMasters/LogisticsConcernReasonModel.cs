using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class LogisticsConcernReasonModel : BaseModel<Guid>
    {
        private string _reasonCode;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string ReasonCode
        {
            get => _reasonCode;
            set => SetProperty(ref _reasonCode, value);
        }

        private string _reasonDescription;
        [DataMember] 
        [StringLength(500)]
        public string ReasonDescription
        {
            get => _reasonDescription;
            set => SetProperty(ref _reasonDescription, value);
        }
    }
}
