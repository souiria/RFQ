using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class FacilityModel : BaseModel<Guid>
    {
        private string _facilityName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string FacilityName
        {
            get => _facilityName;
            set => SetProperty(ref _facilityName, value);
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
