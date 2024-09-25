using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDMaterialOriginDataSyncModel : MaterialOriginModel
    {
        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }

        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }
        private string _businessUnit;
        [DataMember]
        public string BusinessUnit
        {
            get => _businessUnit;
            set => _businessUnit = value;
        }
        private string _tariffCode;
        [DataMember]
        public string TariffCode
        {
            get => _tariffCode;
            set => _tariffCode = value;
        }
        private string _originCountry;
        [DataMember]
        public string OriginCountry
        {
            get => _originCountry;
            set => _originCountry = value;
        }

        private string _poPrice;
        [DataMember]
        public string POPrice
        {
            get => _poPrice;
            set => _poPrice = value;
        }
        private string _currencyCode ;
        [DataMember]
        public string CurrencyCode
        {
            get => _currencyCode;
            set => _currencyCode = value;
        }
        private string _mrpdmd;
        [DataMember]
        public string MRPdmd
        {
            get => _mrpdmd;
            set => _mrpdmd = value;
        }
        private string _userId;
        [DataMember]
        public string UserId
        {
            get => _userId;
            set => _userId = value;
        }
        private DateTime _entrydate;
        [DataMember]
        public DateTime Entrydate
        {
            get => _entrydate;
            set => _entrydate = value;
        }
        private DateTime? _updateDate;
        [DataMember]
        public DateTime? UpdateDate
        {
            get => _updateDate;
            set => _updateDate = value;
        }
        private string _supplierMaterialNumber;
        [DataMember]
        public string SupplierMaterialNumber
        {
            get => _supplierMaterialNumber;
            set => _supplierMaterialNumber = value;
        }
    }
}
