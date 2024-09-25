using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Data Contract to map Facility Group with Facility
    /// </summary>
    [DataContract, Serializable]
    public class PurchasingFacilityGroupModel : BaseModel<Guid>
    {
        private Guid _purchasingFacilityGuid;
        [DataMember]
        [Required]
        public Guid PurchasingFacilityGuid
        {
            get => _purchasingFacilityGuid;
            set => SetProperty(ref _purchasingFacilityGuid, value);
        }

        private string _facilityGroupCode;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string FacilityGroupCode
        {
            get => _facilityGroupCode;
            set => SetProperty(ref _facilityGroupCode, value);
        }
    }
}
