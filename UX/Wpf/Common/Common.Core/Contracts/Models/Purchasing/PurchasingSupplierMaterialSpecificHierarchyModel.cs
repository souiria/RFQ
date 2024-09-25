using Common.Core.Contracts.Interfaces.Purchasing;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Purchasing;
using Common.Core.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
  

    [DataContract, Serializable]
    public class PurchasingSupplierMaterialSpecificHierarchyModel : IPurchasingSupplierMaterialSpecificHierarchy
    {
        private string _supplierCode;
        [DataMember]
        [Required]
        [StringLength(4)]
        [Column(TypeName = "VARCHAR")]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }

        private bool _isFCExists = false;
        [DataMember]
        public bool IsFCExists
        {
            get => _isFCExists;
            set => _isFCExists = value;
        }

        private int _minimumOrderQuantity;
        [DataMember]
        [Required]
        public int MinimumOrderQuantity
        {
            get => _minimumOrderQuantity;
            set => _minimumOrderQuantity = value;
        }

        private Guid _unitOfMeasurementGuid;
        [DataMember]
        [Required]
        public Guid UnitOfMeasurementGuid
        {
            get => _unitOfMeasurementGuid;
            set => _unitOfMeasurementGuid = value;
        }


        private int _conversionFactor;
        [DataMember]
        [Required]
        public int ConversionFactor
        {
            get => _conversionFactor;
            set => _conversionFactor = value;
        }

        private decimal _poPrice;
        [DataMember]
        [DecimalPrecision(9, 5)]
        [Required]
        public decimal POPrice
        {
            get => _poPrice;
            set => _poPrice = value;
        }

        private int _orderLeadTime;
        [DataMember]
        [Required]
        public int OrderLeadTime
        {
            get => _orderLeadTime;
            set => _orderLeadTime = value;
        }

        private int _issueMinimumLot;
        [DataMember]
        [Required]
        public int IssueMinimumLot
        {
            get => _issueMinimumLot;
            set => _issueMinimumLot = value;
        }

        private int _containerQuantity;
        [DataMember]
        [Required]
        public int ContainerQuantity
        {
            get => _containerQuantity;
            set => _containerQuantity = value;
        }

        private int _innerContainerQuantity;
        [DataMember]
        [Required]
        public int InnerContainerQuantity
        {
            get => _innerContainerQuantity;
            set => _innerContainerQuantity = value;
        }

        private int _noOfInnerContainers;
        [DataMember]
        [Required]
        public int NoOfInnerContainers
        {
            get => _noOfInnerContainers;
            set => _noOfInnerContainers = value;
        }

        private string _supplierMaterialNumber;
        [DataMember]

        [StringLength(26)]
        public string SupplierMaterialNumber
        {
            get => _supplierMaterialNumber;
            set => _supplierMaterialNumber = value;
        }

        private string _supplierMaterialName;
        [DataMember]
        [StringLength(15)]
        public string SupplierMaterialName
        {
            get => _supplierMaterialName;
            set => _supplierMaterialName = value;
        }

        private decimal _poPriceExcludingMetal;
        [DataMember]
        [Required]
        [DecimalPrecision(9, 5)]
        public decimal POPriceExcludingMetal
        {
            get => _poPriceExcludingMetal;
            set => _poPriceExcludingMetal = value;
        }

        private int _initialVolumeQuantity;
        [DataMember]
        [Required]
        public int InitialVolumeQuantity
        {
            get => _initialVolumeQuantity;
            set => _initialVolumeQuantity = value;
        }

        private string _replacementMaterialNumber;
        [DataMember]

        [StringLength(26)]
        public string ReplacementMaterialNumber
        {
            get => _replacementMaterialNumber;
            set => _replacementMaterialNumber = value;
        }

        private decimal _metalWeight;
        [DataMember]
        [DecimalPrecision(10, 5)]
        [Required]
        public decimal MetalWeight
        {
            get => _metalWeight;
            set => _metalWeight = value;
        }

        private decimal _metalRate;
        [DataMember]
        [DecimalPrecision(10, 5)]
        [Required]
        public decimal MetalRate
        {
            get => _metalRate;
            set => _metalRate = value;
        }

        private decimal _standardBoxLength;
        [DataMember]
        [DecimalPrecision(6, 3)]
        [Required]
        public decimal StandardBoxLength
        {
            get => _standardBoxLength;
            set => _standardBoxLength = value;
        }

        private decimal _standardBoxHeight;
        [DataMember]
        [DecimalPrecision(6, 3)]
        [Required]
        public decimal StandardBoxHeight
        {
            get => _standardBoxHeight;
            set => _standardBoxHeight = value;
        }

        private decimal _standardBoxWidth;
        [DataMember]
        [DecimalPrecision(6, 3)]
        [Required]
        public decimal StandardBoxWidth
        {
            get => _standardBoxWidth;
            set => _standardBoxWidth = value;
        }


        private int _standardPackFactor;
        [DataMember]
        [Required]
        public int StandardPackFactor
        {
            get => _standardPackFactor;
            set => _standardPackFactor = value;
        }

        private decimal _fullBoxWeight;
        [DataMember]
        [DecimalPrecision(5, 2)]
        [Required]
        public decimal FullBoxWeight
        {
            get => _fullBoxWeight;
            set => _fullBoxWeight = value;
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

        private DateTime _expiryDate;
        [DataMember]
        public DateTime ExpiryDate
        {
            get => _expiryDate;
            set => _expiryDate = value;
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
        private bool _matSuppMainSupplier = false;
        [DataMember]
        public bool MatSuppMainSupplier
        {
            get { return _matSuppMainSupplier; }
            set => _matSuppMainSupplier = value;
        }

        private string _euPreferentialOriginStatusCode;
        [DataMember]
        public string EUPreferentialOriginStatusCode
        {
            get => _euPreferentialOriginStatusCode;
            set => _euPreferentialOriginStatusCode = value;
        }
        private List<SupplierMaterialPoPricingSpecificHierarchyModel> _supplierMaterialPOPricingHierarchies;
        [DataMember]
        public List<SupplierMaterialPoPricingSpecificHierarchyModel> SupplierMaterialPOPricingHierarchy
        {
            get => _supplierMaterialPOPricingHierarchies;
            set => _supplierMaterialPOPricingHierarchies = value;
        }
        /// <summary>
        /// Local Reference of SupplierSelectionHierarchy
        /// </summary>
        private List<SupplierSelectionSpecificHierarchyModel> _iSupplierSelectionHierarchy;
        /// <summary>
        /// Hierarchy of Supplier Selection Hierarchy
        /// </summary>
        [DataMember]
        public List<SupplierSelectionSpecificHierarchyModel> SupplierSelectionHierarchy
        {
            get => _iSupplierSelectionHierarchy;
            set => _iSupplierSelectionHierarchy = value;
        }
    }
}
