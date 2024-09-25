using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLMaterialOriginGridModel : MaterialOriginModel
    {
        #region Properties 
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get { return _materialGuid; }
            set { _materialGuid = value; }
        }
        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get { return _materialNumber; }
            set { _materialNumber = value; }
        }
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get { return _supplierGuid; }
            set { _supplierGuid = value; }
        }
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }
        private string _tariffCodeName;
        [DataMember]
        public string TariffCodeName
        {
            get { return _tariffCodeName; }
            set { _tariffCodeName = value; }
        }
        private string _tariffCodeDescription;
        [DataMember]
        public string TariffCodeDescription
        {
            get { return _tariffCodeDescription; }
            set { _tariffCodeDescription = value; }
        }
        private string _countryName;
        [DataMember]
        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }
        private string _status1;
        [DataMember]
        public string Status1
        {
            get { return _status1; }
            set { _status1 = value; }
        }
        private string _originDescription;
        [DataMember]
        public string OriginDescription
        {
            get { return _originDescription; }
            set { _originDescription = value; }
        }
        private decimal _poPrice;
        [DataMember]
        public decimal POPrice
        {
            get { return _poPrice; }
            set { _poPrice = value; }
        }
        private string _supplierMaterialNumber;
        [DataMember]
        public string SupplierMaterialNumber
        {
            get { return _supplierMaterialNumber; }
            set { _supplierMaterialNumber = value; }
        }
        private string _message;
        [DataMember]
        [StringLength(500)]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private string _currency;
        [DataMember]
        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }
        #endregion
    }
}
