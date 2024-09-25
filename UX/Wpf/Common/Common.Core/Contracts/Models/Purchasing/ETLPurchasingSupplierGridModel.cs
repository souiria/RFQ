using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLPurchasingSupplierGridModel : PurchasingSupplierModel
    {
        #region Properties

        private string _supplierGroupName;
        [DataMember]
        public string SupplierGroupName
        {
            get { return _supplierGroupName; }
            set { SetProperty(ref _supplierGroupName, value); }
        }

        private Guid _supplierGroupGuid;
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get { return _supplierGroupGuid; }
            set { _supplierGroupGuid = value; }
        }


        private string _supplierTypeName;
        [DataMember]
        public string SupplierTypeName
        {
            get { return _supplierTypeName; }
            set { SetProperty(ref _supplierTypeName, value); }
        }

        private Guid _supplierTypeGuid;
        [DataMember]
        public Guid SupplierTypeGuid
        {
            get { return _supplierTypeGuid; }
            set { _supplierTypeGuid = value; }
        }


        private string _paymentTermsName;
        [DataMember]
        public string PaymentTermsName
        {
            get { return _paymentTermsName; }
            set { SetProperty(ref _paymentTermsName, value); }
        }

        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { SetProperty(ref _supplierCode, value); }
        }

        private string _supplierName;
        [DataMember]
        public string SupplierName
        {
            get { return _supplierName; }
            set { SetProperty(ref _supplierName, value); }
        }

        private string _address1;
        [DataMember]
        public string Address1
        {
            get { return _address1; }
            set { SetProperty(ref _address1, value); }
        }

        private string _address2;
        [DataMember]
        public string Address2
        {
            get { return _address2; }
            set { SetProperty(ref _address2, value); }
        }

        private string _address3;
        [DataMember]
        public string Address3
        {
            get { return _address3; }
            set { SetProperty(ref _address3, value); }
        }

        private string _zipCode;
        [DataMember]
        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode, value); }
        }

        private string _city;
        [DataMember]
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }
        private string _region;
        [DataMember]
        public string Region
        {
            get { return _region; }
            set { SetProperty(ref _region, value); }
        }

        private string _country;
        [DataMember]
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }
        private string _currencyCode;
        [DataMember]
        public string CurrencyCode
        {
            get { return _currencyCode; }
            set { SetProperty(ref _currencyCode, value); }
        }
        private string _deliveryTermsName;
        [DataMember]
        public string DeliveryTermsName
        {
            get { return _deliveryTermsName; }
            set { SetProperty(ref _deliveryTermsName, value); }
        }
        private string _incoTermsCode;
        [DataMember]
        public string IncoTermsCode
        {
            get { return _incoTermsCode; }
            set { SetProperty(ref _incoTermsCode, value); }
        }
        private string _sDECodeName;
        [DataMember]
        public string SDECodeName
        {
            get { return _sDECodeName; }
            set { SetProperty(ref _sDECodeName, value); }
        }

        private string _buyerName;
        [DataMember]
        public string BuyerName
        {
            get { return _buyerName; }
            set { SetProperty(ref _buyerName, value); }
        }

        private string _ePOCommodityGroupCode;
        [DataMember]
        public string EPOCommodityGroupCode
        {
            get { return _ePOCommodityGroupCode; }
            set { SetProperty(ref _ePOCommodityGroupCode, value); }
        }

        private string _pOPriceEffectiveDesc;
        [DataMember]
        public string POPriceEffectiveDesc
        {
            get { return _pOPriceEffectiveDesc; }
            set { SetProperty(ref _pOPriceEffectiveDesc, value); }
        }


        private string _transporterCurrencyCode;
        [DataMember]
        public string TransporterCurrencyCode
        {
            get { return _transporterCurrencyCode; }
            set { SetProperty(ref _transporterCurrencyCode, value); }
        }

        private string _tariffContentEmail;
        [DataMember]
        public string TariffContentEmail
        {
            get { return _tariffContentEmail; }
            set { SetProperty(ref _tariffContentEmail, value); }
        }

        private Guid _supplierAssociationGuid;
        [DataMember]
        public Guid SupplierAssociationGuid
        {
            get { return _supplierAssociationGuid; }
            set { _supplierAssociationGuid = value; }

        }
        private Guid _countryGuid;
        [DataMember]
        public Guid CountryGuid
        {
            get { return _countryGuid; }
            set { _countryGuid = value; }
        }

        private bool _isActive = true;
        [DataMember]
        public new bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        #endregion
    }
    [DataContract, Serializable]
    public class PurchasingSupplierSearchModel
    {
        private Guid _supplierGroupGuid;
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get { return _supplierGroupGuid; }
            set { _supplierGroupGuid = value; }
        }

        private Guid _supplierTypeGuid;
        [DataMember]
        public Guid SupplierTypeGuid
        {
            get { return _supplierTypeGuid; }
            set { _supplierTypeGuid = value; }
        }
    }
}
