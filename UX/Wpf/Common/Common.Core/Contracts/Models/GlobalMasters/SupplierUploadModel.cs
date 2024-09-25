using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class SupplierUploadModel: BaseModel<Guid>
    {
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }

        private string _supplierName;
        [DataMember]
        public string SupplierName
        {
            get => _supplierName;
            set => SetProperty(ref _supplierName, value);
        }
        private string _address1;
        [DataMember]

        public string Address1
        {
            get => _address1;
            set => SetProperty(ref _address1, value);
        }
        private string _address2;
        [DataMember]
        public string Address2
        {
            get => _address2;
            set => SetProperty(ref _address2, value);
        }
        private string _address3;
        [DataMember]
        public string Address3
        {
            get => _address3;
            set => SetProperty(ref _address3, value);
        }

        private string _city;
        [DataMember]
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }
        private string _region;
        [DataMember]
        public string Region
        {
            get => _region;
            set => SetProperty(ref _region, value);
        }
        private string _zipCode;
        [DataMember]
        public string ZipCode
        {
            get => _zipCode;
            set => SetProperty(ref _zipCode, value);
        }
        private Guid _countryGuid;
        [DataMember]
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

        private string _countryName;
        [DataMember]
        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }

        private Guid _distributionCountryOfOriginGuid;
        [DataMember]
        public Guid DistributionCountryOfOriginGuid
        {
            get => _distributionCountryOfOriginGuid;
            set => SetProperty(ref _distributionCountryOfOriginGuid, value);
        }

        private string _distributionCountryName;
        [DataMember]
        public string DistributionCountryName
        {
            get { return _distributionCountryName; }
            set { SetProperty(ref _distributionCountryName, value); }
        }

        #region Association
        private Guid _supplierAssociationGuid;
        [DataMember]
        public Guid SupplierAssociationGuid
        {
            get { return _supplierAssociationGuid; }
            set { SetProperty(ref _supplierAssociationGuid, value); }
        }

        private string _supplierType;
        [DataMember]
        public string SupplierType
        {
            get { return _supplierType; }
            set { SetProperty(ref _supplierType, value); }
        }

        private Guid _supplierTypeGuid;
        [DataMember]
        public Guid SupplierTypeGuid
        {
            get => _supplierTypeGuid;
            set => SetProperty(ref _supplierTypeGuid, value);
        }

        private string _supplierGroup;
        [DataMember]
        public string SupplierGroup
        {
            get { return _supplierGroup; }
            set { SetProperty(ref _supplierGroup, value); }
        }

        private Guid _supplierGroupGuid;
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => SetProperty(ref _supplierGroupGuid, value);
        }

        private string _supplierIncoTerms;
        [DataMember]
        public string SupplierIncoTerms
        {
            get { return _supplierIncoTerms; }
            set { SetProperty(ref _supplierIncoTerms, value); }
        }

        private Guid _supplierIncoTermsGuid;
        [DataMember]
        public Guid SupplierIncoTermsGuid
        {
            get => _supplierIncoTermsGuid;
            set => SetProperty(ref _supplierIncoTermsGuid, value);
        }

        private string _supplierCurrency;
        [DataMember]
        public string SupplierCurrency
        {
            get { return _supplierCurrency; }
            set { SetProperty(ref _supplierCurrency, value); }
        }

        private Guid _supplierCurrencyGuid;
        [DataMember]
        public Guid SupplierCurrencyGuid
        {
            get => _supplierCurrencyGuid;
            set => SetProperty(ref _supplierCurrencyGuid, value);
        }

        private string _supplierBuyer;
        [DataMember]
        public string SupplierBuyer
        {
            get { return _supplierBuyer; }
            set { SetProperty(ref _supplierBuyer, value); }
        }

        private Guid _supplierBuyerGuid;
        [DataMember]
        public Guid SupplierBuyerGuid
        {
            get => _supplierBuyerGuid;
            set => SetProperty(ref _supplierBuyerGuid, value);
        }

        private string _supplierTransporterCurrency;
        [DataMember]
        public string SupplierTransporterCurrency
        {
            get { return _supplierTransporterCurrency; }
            set { SetProperty(ref _supplierTransporterCurrency, value); }
        }

        private Guid _supplierTransporterCurrencyGuid;
        [DataMember]
        public Guid SupplierTransporterCurrencyGuid
        {
            get => _supplierTransporterCurrencyGuid;
            set => SetProperty(ref _supplierTransporterCurrencyGuid, value);
        }

        private string _supplierDevelopmentTeam;
        [DataMember]
        public string SupplierDevelopmentTeam
        {
            get { return _supplierDevelopmentTeam; }
            set { SetProperty(ref _supplierDevelopmentTeam, value); }
        }

        private Guid _supplierDevelopmentTeamGuid;
        [DataMember]
        public Guid SupplierDevelopmentTeamGuid
        {
            get => _supplierDevelopmentTeamGuid;
            set => SetProperty(ref _supplierDevelopmentTeamGuid, value);
        }
        #endregion

        #region Purchasing
        private Guid _purchasingSupplierGuid;
        [DataMember]
        public Guid PurchasingSupplierGuid
        {
            get { return _purchasingSupplierGuid; }
            set { SetProperty(ref _purchasingSupplierGuid, value); }
        }

        private string _paymentTerms;
        [DataMember]
        public string PaymentTerms
        {
            get => _paymentTerms;
            set => SetProperty(ref _paymentTerms, value);
        }

        private string _epoCommodityGroup;
        [DataMember]
        public string EPOCommodityGroup
        {
            get { return _epoCommodityGroup; }
            set { SetProperty(ref _epoCommodityGroup, value); }
        }

        private Guid _epoCommodityGroupGuid;
        [DataMember]
        public Guid EPOCommodityGroupGuid
        {
            get => _epoCommodityGroupGuid;
            set => SetProperty(ref _epoCommodityGroupGuid, value);
        }

        private string _CollectionAddress;
        [DataMember]
        public string CollectionAddress
        {
            get => _CollectionAddress;
            set => SetProperty(ref _CollectionAddress, value);
        }

        private string _poPriceEffectiveDateType;
        [DataMember]
        public string POPriceEffectiveDateType
        {
            get { return _poPriceEffectiveDateType; }
            set { SetProperty(ref _poPriceEffectiveDateType, value); }
        }

        private Guid _pOPriceEffectiveDateTypeGuid;
        [DataMember]
        public Guid POPriceEffectiveDateTypeGuid
        {
            get => _pOPriceEffectiveDateTypeGuid;
            set => SetProperty(ref _pOPriceEffectiveDateTypeGuid, value);
        }

        private string _tariffContentEmail;
        [DataMember]
        public string TariffContentEmail
        {
            get { return _tariffContentEmail; }
            set { SetProperty(ref _tariffContentEmail, value); }
        }

        private Guid _tariffContentEmailGuid;
        [DataMember]
        public Guid TariffContentEmailGuid
        {
            get => _tariffContentEmailGuid;
            set => SetProperty(ref _tariffContentEmailGuid, value);
        }

        private bool _tariffNotification;
        [DataMember]
        public bool TariffNotification
        {
            get => _tariffNotification;
            set => SetProperty(ref _tariffNotification, value);
        }

        private int _transporterVolume;
        [DataMember]
        public int TransporterVolume
        {
            get => _transporterVolume;
            set => SetProperty(ref _transporterVolume, value);
        }
        #endregion
    }
}
