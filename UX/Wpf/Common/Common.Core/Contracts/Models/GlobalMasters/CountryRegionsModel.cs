using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class CountryRegionsModel : BaseModel<Guid>
    {
        private string _regionName;
        [DataMember]
        [StringLength(50)]
        [Required]
        public string RegionName
        {
            get => _regionName;
            set => SetProperty(ref _regionName, value);
        }

        private string _subRegionName;
        [DataMember]
        [StringLength(50)]
        public string SubRegionName
        {
            get => _subRegionName;
            set => SetProperty(ref _subRegionName, value);
        }

        private string _regionCode;
        [DataMember]
        [StringLength(3)]
        [Required]
        public string RegionCode
        {
            get => _regionCode;
            set => SetProperty(ref _regionCode, value);
        }

        private string _subRegionCode;
        [DataMember]
        [StringLength(3)]
        public string SubRegionCode
        {
            get => _subRegionCode;
            set => SetProperty(ref _subRegionCode, value);
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
