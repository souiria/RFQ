using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class GIStoreModel : BaseModel<Guid>
    {
        private string _giStoreCode;
        [DataMember]
        [Required]
        [StringLength(10)]
        public string GIStoreCode
        {
            get => _giStoreCode;
            set => SetProperty(ref _giStoreCode, value);
        }

        private string _giStoreName;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string GIStoreName
        {
            get => _giStoreName;
            set => SetProperty(ref _giStoreName, value);
        }

        private string _giStoreManager;
        [DataMember]
        [StringLength(8)]
        public string GIStoreManager
        {
            get => _giStoreManager;
            set => SetProperty(ref _giStoreManager, value);
        }

        private string _streetNumber;
        [DataMember]
        [StringLength(50)]
        public string StreetNumber
        {
            get => _streetNumber;
            set => SetProperty(ref _streetNumber, value);
        }

        private string _streetName;
        [DataMember]
        [StringLength(50)]
        public string StreetName
        {
            get => _streetName;
            set => SetProperty(ref _streetName, value);
        }

        private string _city;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private string _region;
        [DataMember]
        [StringLength(50)]
        public string Region
        {
            get => _region;
            set => SetProperty(ref _region, value);
        }

        private string _zipCode;
        [DataMember]
        [StringLength(20)]
        public string ZipCode
        {
            get => _zipCode;
            set => SetProperty(ref _zipCode, value);
        }

        private Guid _countryGuid;
        [DataMember]
        [Required]      
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => SetProperty(ref _countryGuid, value);
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
