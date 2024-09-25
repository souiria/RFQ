using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLMaterialNoXReferenceGridModel : BaseModel<Guid>
    {
        #region Properties 
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { SetProperty(ref _supplierCode, value); }
        }
        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get { return _materialNumber; }
            set { SetProperty(ref _materialNumber, value); }
        }
        private string _supplierMaterialNumber;
        [DataMember]

        public string SupplierMaterialNumber
        {
            get => _supplierMaterialNumber;
            set => SetProperty(ref _supplierMaterialNumber, value);
        }

        private string _materialName;
        [DataMember]

        public string MaterialName
        {
            get => _materialName;
            set => SetProperty(ref _materialName, value);
        }

        private decimal _poPrice;
        [DataMember]

        public decimal POPrice
        {
            get => _poPrice;
            set => SetProperty(ref _poPrice, value);
        }
        private int _minimumOrderQuantity;
        [DataMember]
        public int MinimumOrderQuantity
        {
            get => _minimumOrderQuantity;
            set => SetProperty(ref _minimumOrderQuantity, value);
        }
        
        private string _poUnit;
        [DataMember]
        public string POUnit 
        {
            get => _poUnit;
            set => SetProperty(ref _poUnit, value);
        }
        private string _bomUnit;
        [DataMember]
        public string BOMUnit
        {
            get => _bomUnit;
            set => SetProperty(ref _bomUnit, value);
        }

        private int _conversionFactor;
        [DataMember]

        public int ConversionFactor
        {
            get => _conversionFactor;
            set => SetProperty(ref _conversionFactor, value);
        }
        private string _currencyCode;
        [DataMember]
        public string CurrencyCode
        {
            get => _currencyCode;
            set => SetProperty(ref _currencyCode, value);
        }

        private decimal _exchangeRate;
        [DataMember]
        public decimal ExchangeRate
        {
            get => _exchangeRate;
            set => SetProperty(ref _exchangeRate, value);
        }
        private byte _sourceType=0;
        [DataMember]
        public byte SourceType
        {
            get => _sourceType;
            set => SetProperty(ref _sourceType, value);
        }
        private byte _matSuppMainSupplier = 0;
        [DataMember]
        public byte MatSuppMainSupplier
        {
            get => _matSuppMainSupplier;
            set => SetProperty(ref _matSuppMainSupplier, value);
        }
        #endregion
    }
}
