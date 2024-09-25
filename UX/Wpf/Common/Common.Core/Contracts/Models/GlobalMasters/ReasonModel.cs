using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class ReasonModel : BaseModel<Guid>
    {
        private string _reasonCode;
        [DataMember]
        [Required]
        [StringLength(10)]
        public string ReasonCode
        {
            get => _reasonCode;
            set => SetProperty(ref _reasonCode, value);
        }

        private string _reasonDescription;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string ReasonDescription
        {
            get => _reasonDescription;
            set => SetProperty(ref _reasonDescription, value);
        }
    }
}
