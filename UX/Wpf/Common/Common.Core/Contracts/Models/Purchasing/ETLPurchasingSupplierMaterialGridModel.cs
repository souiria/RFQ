using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLPurchasingSupplierMaterialGridModel : BaseModel<Guid>
    {
        private Guid _supplierMaterialAssociationGuid;
        [DataMember]
        [Required]
        public Guid SupplierMaterialAssociationGuid
        {
            get => _supplierMaterialAssociationGuid;
            set => SetProperty(ref _supplierMaterialAssociationGuid, value);
        }

        private int _minimumOrderQuantity;
        [DataMember]
        [Required]
        public int MinimumOrderQuantity
        {
            get => _minimumOrderQuantity;
            set => SetProperty(ref _minimumOrderQuantity, value);
        }

        private Guid _unitOfMeasurementGuid;
        [DataMember]
        [Required]
        public Guid UnitOfMeasurementGuid
        {
            get => _unitOfMeasurementGuid;
            set => SetProperty(ref _unitOfMeasurementGuid, value);
        }


        private int _conversionFactor;
        [DataMember]
        [Required]
        public int ConversionFactor
        {
            get => _conversionFactor;
            set => SetProperty(ref _conversionFactor, value);
        }

        private decimal _poPrice;
        [DataMember]
        [DecimalPrecision(9, 5)]
        [Required]
        public decimal POPrice
        {
            get => _poPrice;
            set => SetProperty(ref _poPrice, value);
        }

        private int _orderLeadTime;
        [DataMember]
        [Required]
        public int OrderLeadTime
        {
            get => _orderLeadTime;
            set => SetProperty(ref _orderLeadTime, value);
        }

        private int _issueMinimumLot;
        [DataMember]
        [Required]
        public int IssueMinimumLot
        {
            get => _issueMinimumLot;
            set => SetProperty(ref _issueMinimumLot, value);
        }

        private int _containerQuantity;
        [DataMember]
        [Required]
        public int ContainerQuantity
        {
            get => _containerQuantity;
            set => SetProperty(ref _containerQuantity, value);
        }

        private int _innerContainerQuantity;
        [DataMember]
        [Required]
        public int InnerContainerQuantity
        {
            get => _innerContainerQuantity;
            set => SetProperty(ref _innerContainerQuantity, value);
        }

        private int _noOfInnerContainers;
        [DataMember]
        [Required]
        public int NoOfInnerContainers
        {
            get => _noOfInnerContainers;
            set => SetProperty(ref _noOfInnerContainers, value);
        }

        private string _supplierMaterialNumber;
        [DataMember]

        [StringLength(26)]
        public string SupplierMaterialNumber
        {
            get => _supplierMaterialNumber;
            set => SetProperty(ref _supplierMaterialNumber, value);
        }

        private string _supplierMaterialName;
        [DataMember]
        [StringLength(15)]
        public string SupplierMaterialName
        {
            get => _supplierMaterialName;
            set => SetProperty(ref _supplierMaterialName, value);
        }

        private decimal _poPriceExcludingMetal;
        [DataMember]
        [Required]
        [DecimalPrecision(9, 5)]
        public decimal POPriceExcludingMetal
        {
            get => _poPriceExcludingMetal;
            set => SetProperty(ref _poPriceExcludingMetal, value);
        }

        private int _initialVolumeQuantity;
        [DataMember]
        [Required]
        public int InitialVolumeQuantity
        {
            get => _initialVolumeQuantity;
            set => SetProperty(ref _initialVolumeQuantity, value);
        }

        private string _replacementMaterialNumber;
        [DataMember]

        [StringLength(26)]
        public string ReplacementMaterialNumber
        {
            get => _replacementMaterialNumber;
            set => SetProperty(ref _replacementMaterialNumber, value);
        }

        private decimal _metalWeight;
        [DataMember]
        [DecimalPrecision(10, 5)]
        [Required]
        public decimal MetalWeight
        {
            get => _metalWeight;
            set => SetProperty(ref _metalWeight, value);
        }

        private decimal _metalRate;
        [DataMember]
        [DecimalPrecision(10, 5)]
        [Required]
        public decimal MetalRate
        {
            get => _metalRate;
            set => SetProperty(ref _metalRate, value);
        }

        private decimal _standardBoxLength;
        [DataMember]
        [DecimalPrecision(6, 3)]
        [Required]
        public decimal StandardBoxLength
        {
            get => _standardBoxLength;
            set => SetProperty(ref _standardBoxLength, value);
        }

        private decimal _standardBoxHeight;
        [DataMember]
        [DecimalPrecision(6, 3)]
        [Required]
        public decimal StandardBoxHeight
        {
            get => _standardBoxHeight;
            set => SetProperty(ref _standardBoxHeight, value);
        }

        private decimal _standardBoxWidth;
        [DataMember]
        [DecimalPrecision(6, 3)]
        [Required]
        public decimal StandardBoxWidth
        {
            get => _standardBoxWidth;
            set => SetProperty(ref _standardBoxWidth, value);
        }


        private int _standardPackFactor;
        [DataMember]
        [Required]
        public int StandardPackFactor
        {
            get => _standardPackFactor;
            set => SetProperty(ref _standardPackFactor, value);
        }

        private decimal _fullBoxWeight;
        [DataMember]
        [DecimalPrecision(5, 2)]
        [Required]
        public decimal FullBoxWeight
        {
            get => _fullBoxWeight;
            set => SetProperty(ref _fullBoxWeight, value);
        }

        private Guid _tariffCodeAssociationGuid;
        [DataMember]
        public Guid TariffCodeAssociationGuid
        {
            get => _tariffCodeAssociationGuid;
            set => SetProperty(ref _tariffCodeAssociationGuid, value);
        }
        private string _origin;
        [DataMember]
        [StringLength(15)]
        public string Origin
        {
            get => _origin;
            set => SetProperty(ref _origin, value);
        }

        private DateTime _expiryDate;
        [DataMember]
        public DateTime ExpiryDate
        {
            get => _expiryDate;
            set => SetProperty(ref _expiryDate, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
        private string _pOUnit;
        [DataMember]
        public string POUnit
        {
            get { return _pOUnit; }
            set { SetProperty(ref _pOUnit, value); }
        }

        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get { return _supplierGuid; }
            set { SetProperty(ref _supplierGuid, value); }
        }
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { SetProperty(ref _supplierCode, value); }
        }

        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get { return _materialGuid; }
            set { SetProperty(ref _materialGuid, value); }
        }
        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get { return _materialNumber; }
            set { SetProperty(ref _materialNumber, value); }
        }

        private string _currency;
        [DataMember]
        public string Currency
        {
            get { return _currency; }
            set { SetProperty(ref _currency, value); }
        }

        private string _commodityName;
        [DataMember]
        public string CommodityName
        {
            get { return _commodityName; }
            set { SetProperty(ref _commodityName, value); }
        }


        private string _tariffCodeName;
        [DataMember]
        public string TariffCodeName
        {
            get { return _tariffCodeName; }
            set { SetProperty(ref _tariffCodeName, value); }
        }

        private string _tariffDescription;
        [DataMember]
        public string TariffDescription
        {
            get { return _tariffDescription; }
            set { SetProperty(ref _tariffDescription, value); }
        }

        private string _countryName;
        [DataMember]
        public string CountryName
        {
            get { return _countryName; }
            set { SetProperty(ref _countryName, value); }
        }

        private string _sEWSEUOM;
        [DataMember]
        public string SEWSEUOM
        {
            get { return _sEWSEUOM; }
            set { SetProperty(ref _sEWSEUOM, value); }
        }
        private Guid _tariffCodeGuid;
        [DataMember]
        public Guid TariffCodeGuid
        {
            get => _tariffCodeGuid;
            set => _tariffCodeGuid = value;
        }
        private Guid _countryRegionsAssociationGuid;
        [DataMember]
        public Guid CountryRegionsAssociationGuid
        {
            get => _countryRegionsAssociationGuid;
            set => _countryRegionsAssociationGuid = value;
        }
        private string _alpha2Code;
        [DataMember]
        public string Alpha2Code
        {
            get { return _alpha2Code; }
            set { _alpha2Code = value; }
        }
        private string _bOMUnit;
        [DataMember]
        public string BOMUnit
        {
            get { return _bOMUnit; }
            set { _bOMUnit = value; }
        }
        private bool _matSuppMainSupplier;
        [DataMember]
        public bool MatSuppMainSupplier
        {
            get { return _matSuppMainSupplier; }
            set { _matSuppMainSupplier = value; }
        }
        private string _originDescription;
        [DataMember]
        public string OriginDescription
        {
            get { return _originDescription; }
            set { _originDescription = value; }
        }
    }

    [DataContract, Serializable]
    public class TariffCountryRegionAssociationModel

    {
        private Guid _tariffCodeGuid;
        [DataMember]
        public Guid TariffCodeGuid
        {
            get => _tariffCodeGuid;
            set => _tariffCodeGuid = value;
        }
        private string _tariffCodeName;
        [DataMember]
        public string TariffCodeName
        {
            get { return _tariffCodeName; }
            set { _tariffCodeName = value; }
        }
        private string _countryName;
        [DataMember]
        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }
        private string _regionName;
        [DataMember]
        public string RegionName
        {
            get { return _regionName; }
            set { _regionName = value; }
        }

    }

    [DataContract, Serializable]
    public class SupplierMaterialAssociationListModel
    {
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get { return _materialGuid; }
            set { _materialGuid = value; }
        }

        private Guid _supplierMaterialAssociationGuid;
        [DataMember]
        public Guid SupplierMaterialAssociationGuid
        {
            get { return _supplierMaterialAssociationGuid; }
            set { _supplierMaterialAssociationGuid = value; }
        }
        private bool _isPurchasingSupplierMaterialExists = false;
        [DataMember]
        public bool IsPurchasingSupplierMaterialExists
        {
            get { return _isPurchasingSupplierMaterialExists; }
            set { _isPurchasingSupplierMaterialExists = value; }
        }
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get { return _supplierGuid; }
            set { _supplierGuid = value; }
        }

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get { return _materialNumber; }
            set { _materialNumber = value; }
        }

        private string _materialName;
        [DataMember]
        public string MaterialName
        {
            get { return _materialName; }
            set { _materialName = value; }
        }
        private string _bOMUnit;
        [DataMember]
        public string BOMUnit
        {
            get { return _bOMUnit; }
            set { _bOMUnit = value; }
        }
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }
        private string _supplierName;
        [DataMember]
        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }
        private bool _isActive;
        [DataMember]
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        private bool _isSupplierMaterialAssociationIsActive;
        [DataMember]
        public bool IsSupplierMaterialAssociationIsActive
        {
            get { return _isSupplierMaterialAssociationIsActive; }
            set { _isSupplierMaterialAssociationIsActive = value; }
        }
    }
    public class CountryRegionOriginModel
    {
        private Guid _countryRegionsAssociationGuid;
        [DataMember]
        public Guid CountryRegionsAssociationGuid
        {
            get => _countryRegionsAssociationGuid;
            set => _countryRegionsAssociationGuid = value;
        }

        private string _countryName;
        [DataMember]
        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }
        private string _alpha2Code;
        [DataMember]
        public string Alpha2Code
        {
            get { return _alpha2Code; }
            set { _alpha2Code = value; }
        }

        private string _originStatusCode;
        [DataMember]
        public string OriginStatusCode
        {
            get { return _originStatusCode; }
            set { _originStatusCode = value; }
        }
        private string _originStatusDescription;
        [DataMember]
        public string OriginStatusDescription
        {
            get { return _originStatusDescription; }
            set { _originStatusDescription = value; }
        }

    }
}

