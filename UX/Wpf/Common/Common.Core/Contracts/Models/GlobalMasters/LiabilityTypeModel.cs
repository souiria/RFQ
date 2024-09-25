using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class LiabilityTypeModel : BaseModel<Guid>
    {
       
        private string _liabilityTypeCode;
        [DataMember]
        [Required]
        [StringLength(40)]
        public string LiabilityTypeCode
        {
            get => _liabilityTypeCode;
            set => SetProperty(ref _liabilityTypeCode, value);
        }

        private string _LiabilityTypeDescription = null;
        [DataMember]
        [StringLength(50)]
        public string LiabilityTypeDescription
        {
            get => _LiabilityTypeDescription;
            set => SetProperty(ref _LiabilityTypeDescription, value);
        }
    }
}
