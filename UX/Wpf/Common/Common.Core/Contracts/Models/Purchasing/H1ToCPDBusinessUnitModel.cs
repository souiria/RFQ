using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDBusinessUnitModel
    {
        private Guid _businessUnitGuid;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => _businessUnitGuid = value;
        }

        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }

        private string _businessUnitName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string BusinessUnitName
        {
            get => _businessUnitName;
            set => _businessUnitName = value;
        }

        private string _streetNumber;
        [DataMember]
        [StringLength(50)]
        public string StreetNumber
        {
            get => _streetNumber;
            set => _streetNumber = value;
        }

        private string _streetName;
        [DataMember]
        [StringLength(50)]
        public string StreetName
        {
            get => _streetName;
            set => _streetName = value;
        }

        private string _city;
        [DataMember]
        public string City
        {
            get => _city;
            set => _city = value;
        }

        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }

        private Guid _countryGuid;
        [DataMember]
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => _countryGuid = value;
        }

        private bool _isActive;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
    }

    [DataContract, Serializable]
    public class H1ToCPDBusinessUnitDataSyncModel : H1ToCPDBusinessUnitModel
    {

        
             private Guid _procurementUnitGuid;
        [DataMember]
        [Required]
        public Guid ProcurementUnitGuid
        {
            get => _procurementUnitGuid;
            set => _procurementUnitGuid = value;
        }

        private string _countryName;
        [DataMember]
        public string CountryName
        {
            get => _countryName;
            set => _countryName = value;
        }

        private string _shortPrefixCode;
        [DataMember]
        public string ShortPrefixCode
        {
            get => _shortPrefixCode;
            set => _shortPrefixCode = value;
        }

        private string _baseCurrencyCode;
        [DataMember]
        public string BaseCurrencyCode
        {
            get => _baseCurrencyCode;
            set => _baseCurrencyCode = value;
        }

        private string _error;
        [DataMember]
        public string Error
        {
            get => _error;
            set => _error = value;
        }
        private string _zipCode;
        [DataMember]
       
        public string ZipCode
        {
            get => _zipCode;
            set =>  _zipCode= value;
        }
    }

    [DataContract, Serializable]
    public class H1ToCPDProcurementUnitBusinessUnitAssociationModel
    {
        private Guid _businessUnitGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => _businessUnitGuid = value;
        }

        private string _businessUnitShortCode;
        [DataMember]
        [Required]
        [StringLength(1)]
        public string BusinessUnitShortCode
        {
            get => _businessUnitShortCode;
            set => _businessUnitShortCode = value;
        }

        private Guid _baseCurrencyGuid;
        [DataMember]
        [Required]
        public Guid BaseCurrencyGuid
        {
            get => _baseCurrencyGuid;
            set => _baseCurrencyGuid = value;
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }
    }
}