using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class SupplierMatertialHierarchyModel : BaseModel<Guid>
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

        private string _materialName;
        [DataMember]

        [StringLength(26)]
        public string MaterialName
        {
            get => _materialName;
            set => SetProperty(ref _materialName, value);
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

        private Guid _tariffCodeGuid;
        [DataMember]
        public Guid TariffCodeGuid
        {
            get => _tariffCodeGuid;
            set => SetProperty(ref _tariffCodeGuid, value);
        }

        private Guid _countryRegionsAssociationGuid;
        [DataMember]
        public Guid CountryRegionsAssociationGuid
        {
            get => _countryRegionsAssociationGuid;
            set => SetProperty(ref _countryRegionsAssociationGuid, value);
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
        private bool _matSuppMainSupplier = false;
        [DataMember]
        public bool MatSuppMainSupplier
        {
            get { return _matSuppMainSupplier; }
            set { SetProperty(ref _matSuppMainSupplier, value); }
        }

        private string _euPreferentialOriginStatusCode;
        [DataMember]
        public string EUPreferentialOriginStatusCode
        {
            get => _euPreferentialOriginStatusCode;
            set => SetProperty(ref _euPreferentialOriginStatusCode, value);
        }
    }

    public class SupplierMaterialHierarchyComboModel
    {
        private string _materialNumber;
        /// <summary>
        /// Get or Set for {MaterialNumber}.
        /// </summary>
        [DataMember]

        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }

        private string _materialName;
        /// <summary>
        /// Get or Set for {MaterialName}.
        /// </summary>
        [DataMember]

        public string MaterialName
        {
            get => _materialName;
            set => _materialName = value;
        }

        private Guid? _materialGuid;
        /// <summary>
        /// Get or Set for {MaterialGuid}.
        /// </summary>
        [DataMember]

        public Guid? MaterialGuid
        {
            get => _materialGuid;
            set => _materialGuid = value;
        }


        private bool _isActive;
        /// <summary>
        /// Get or Set for {IsActive}.
        /// </summary>
        [DataMember]

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
    }

    [DataContract,Serializable]
    public class SupplierMaterialHierarchyFilterParametersModel
    {
       
        private string _supplierCode;
        /// <summary>
        /// Get or Set for {SuplierCode}.
        /// </summary>
        [DataMember]

        public string SuplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }

      
    }

    [DataContract, Serializable]
    public class SupplierMaterialHierarchyFilterParametersWithMaterialNumberModel
    {

        private string _supplierCode;
        /// <summary>
        /// Get or Set for {SuplierCode}.
        /// </summary>
        [DataMember]

        public string SuplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }

        private string _materialNumber;
        /// <summary>
        /// Get or Set for {_materialNumber}.
        /// </summary>
        [DataMember]

        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }


    }
}
