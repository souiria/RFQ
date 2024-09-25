using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// To manage Facility details for Purchasing
    /// </summary>
    public class PurchasingFacilityModel : BaseModel<Guid>
    {
        private string _purchasingFacilityCode;
        [DataMember]
        [StringLength(50)]
        [Required]
        public string PurchasingFacilityCode
        {
            get => _purchasingFacilityCode;
            set => SetProperty(ref _purchasingFacilityCode, value);
        }

        private string _purchasingFacilityName;
        [DataMember]
        [StringLength(50)]
        [Required]
        public string PurchasingFacilityName
        {
            get => _purchasingFacilityName;
            set => SetProperty(ref _purchasingFacilityName, value);
        }

    }
}
