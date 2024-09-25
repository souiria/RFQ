using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLPurchasingSupplierAssociationModel
    {
        private Guid _supplierAssociationGuid;
        [DataMember]
        public Guid SupplierAssociationGuid
        {
            get { return _supplierAssociationGuid; }
            set { _supplierAssociationGuid = value; }
        }
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
        private string _incoTermsCode;
        [DataMember]
        public string IncoTermsCode
        {
            get { return _incoTermsCode; }
            set { _incoTermsCode = value; }
        }
        private string _supplierTypeName;
        [DataMember]
        public string SupplierTypeName
        {
            get { return _supplierTypeName; }
            set { _supplierTypeName = value; }
        }
        private string _supplierGroupName;
        [DataMember]
        public string SupplierGroupName
        {
            get { return _supplierGroupName; }
            set { _supplierGroupName = value; }
        }

        private string _currencyCode;
        [DataMember]
        public string CurrencyCode
        {
            get { return _currencyCode; }
            set { _currencyCode = value; }
        }

        private string _buyerName;
        [DataMember]
        public string BuyerName
        {
            get { return _buyerName; }
            set { _buyerName = value; }
        }

        private string _sDECodeName;
        [DataMember]
        public string SDECodeName
        {
            get { return _sDECodeName; }
            set { _sDECodeName = value; }
        }

        private string _transporterCurrencyCode;
        [DataMember]
        public string TransporterCurrencyCode
        {
            get { return _transporterCurrencyCode; }
            set { _transporterCurrencyCode = value; }
        }

    }
}
