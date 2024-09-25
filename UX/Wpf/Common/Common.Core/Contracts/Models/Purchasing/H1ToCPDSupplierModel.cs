using System.Runtime.Serialization;
using System;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDSupplierModel
    {
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => _supplierGuid = value;
        }
        private string _supplierCode;
        [DataMember]

        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }

        private string _supplierName;
        [DataMember]
        public string SupplierName
        {
            get => _supplierName;
            set => _supplierName = value;
        }
        private string _address1;
        [DataMember]

        public string Address1
        {
            get => _address1;
            set => _address1 = value;
        }
        private string _address2;
        [DataMember]
        public string Address2
        {
            get => _address2;
            set => _address2 = value;
        }
        private string _address3;
        [DataMember]
        public string Address3
        {
            get => _address3;
            set => _address3 = value;
        }

        private string _city;
        [DataMember]
        public string City
        {
            get => _city;
            set => _city = value;
        }

        private Guid _countryGuid;
        [DataMember]
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => _countryGuid = value;
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
    [DataContract, Serializable]
    public class H1ToCPDPurchasingSupplierModel
    {
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => _supplierGuid = value;
        }
        private Guid _supplierAssociationGuid;
        [DataMember]
        public Guid SupplierAssociationGuid
        {
            get => _supplierAssociationGuid;
            set => _supplierAssociationGuid = value;
        }
        private string _paymentTerms;
        [DataMember]
        public string PaymentTerms
        {
            get => _paymentTerms;
            set => _paymentTerms = value;
        }

        private Guid _epoCommodityGroupGuid;
        [DataMember]
        public Guid EPOCommodityGroupGuid
        {
            get => _epoCommodityGroupGuid;
            set => _epoCommodityGroupGuid = value;
        }

        private string _CollectionAddress;
        [DataMember]
        public string CollectionAddress
        {
            get => _CollectionAddress;
            set => _CollectionAddress = value;
        }
        private Guid _pOPriceEffectiveDateTypeGuid;
        [DataMember]
        public Guid POPriceEffectiveDateTypeGuid
        {
            get => _pOPriceEffectiveDateTypeGuid;
            set => _pOPriceEffectiveDateTypeGuid = value;
        }

        private Guid _tariffContentEmailGuid;
        [DataMember]
        public Guid TariffContentEmailGuid
        {
            get => _tariffContentEmailGuid;
            set => _tariffContentEmailGuid = value;
        }

        private bool _tariffNotification;
        [DataMember]
        public bool TariffNotification
        {
            get => _tariffNotification;
            set => _tariffNotification = value;
        }

        private int _transporterVolume;
        [DataMember]
        public int TransporterVolume
        {
            get => _transporterVolume;
            set => _transporterVolume = value;
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
    [DataContract, Serializable]
    public class H1ToCPDSupplierDataSyncModel
    {
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => _supplierGuid = value;
        }
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }

        private string _supplierName;
        [DataMember]
        public string SupplierName
        {
            get => _supplierName;
            set => _supplierName = value;
        }
        private string _address1;
        [DataMember]
        public string Address1
        {
            get => _address1;
            set => _address1 = value;
        }
        private string _address2;
        [DataMember]
        public string Address2
        {
            get => _address2;
            set => _address2 = value;
        }

        private string _address3;
        [DataMember]

        public string Address3
        {
            get => _address3;
            set => _address3 = value;
        }

        private string _currencyCode;
        [DataMember]

        public string CurrencyCode
        {
            get => _currencyCode;
            set => _currencyCode = value;
        }
        private string _incotermCode;
        [DataMember]
        public string IncotermCode
        {
            get => _incotermCode;
            set => _incotermCode = value;
        }

        private string _transporterCurrencyCode;
        [DataMember]
        public string TransporterCurrencyCode
        {
            get => _transporterCurrencyCode;
            set => _transporterCurrencyCode = value;
        }
        private string _supplierGroupCode;
        [DataMember]
        public string SupplierGroupCode
        {
            get => _supplierGroupCode;
            set => _supplierGroupCode = value;
        }

        private string _sDECode;
        [DataMember]
        public string SDECode
        {
            get => _sDECode;
            set => _sDECode = value;
        }

        private string _emailId;
        [DataMember]
        public string EmailId
        {
            get => _emailId;
            set => _emailId = value;
        }

        private string _paymentTerms;
        [DataMember]
        public string PaymentTerms
        {
            get => _paymentTerms;
            set => _paymentTerms = value;
        }
        private int _transporterVolume;
        [DataMember]
        public int TransporterVolume
        {
            get => _transporterVolume;
            set => _transporterVolume = value;
        }
        private string _ePOCommodityGroupCode;
        [DataMember]
        public string EPOCommodityGroupCode
        {
            get => _ePOCommodityGroupCode;
            set => _ePOCommodityGroupCode = value;
        }

        private string _collectionAddress;
        [DataMember]
        public string CollectionAddress
        {
            get => _collectionAddress;
            set => _collectionAddress = value;
        }

        private string _tariffContactId;
        [DataMember]
        public string TariffContactId
        {
            get => _tariffContactId;
            set => _tariffContactId = value;
        }

        private bool _tariffNotification;
        [DataMember]
        public bool TariffNotification
        {
            get => _tariffNotification;
            set => _tariffNotification = value;
        }

        private string _pOPriceEffectiveDateType;
        [DataMember]
        public string POPriceEffectiveDateType

        {
            get => _pOPriceEffectiveDateType;
            set => _pOPriceEffectiveDateType = value;
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        private string _error;
        [DataMember]
        public string Error
        {
            get => _error;
            set => _error = value;
        }
        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }

        private string _city;
        [DataMember]
        public string City
        {
            get => _city;
            set => _city = value;
        }

        private string _country;
        [DataMember]
        public string Country
        {
            get => _country;
            set => _country = value;
        }
    }

}
