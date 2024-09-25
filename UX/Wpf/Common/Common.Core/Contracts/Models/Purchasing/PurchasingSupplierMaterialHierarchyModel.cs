/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   PurchasingSupplierMaterialHierarchyModel.cs
Function           :   Model for Supplier Material Hierarchy Screen.
Created By         :   Srashti Gupta
Created on         :   14-Oct-2019
Revision History   :   [28-Mar-2022] : Sejal Srivastava
*                  :   [] : Added a new class PurchasingSupplierMaterialHierarchyStatelessModel
*                  :   [04-May-2022] : Ranjay
                   :   [] : Added field Supplier guid
****************************************************************************************************/

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
    public class PurchasingSupplierMaterialHierarchyModel : BaseModel<Guid>, IPurchasingSupplierMaterialHierarchy
    {
        private string _supplierCode;
        [DataMember]
        [Required]
        [StringLength(4)]
        [Column(TypeName = "VARCHAR")]
        public string SupplierCode
        {
            get => _supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }

        private bool _isFCExists = false;
        [DataMember]
        public bool IsFCExists
        {
            get => _isFCExists;
            set => SetProperty(ref _isFCExists, value);
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
        private List<SupplierMaterialPOPricingHierarchyModel> _supplierMaterialPOPricingHierarchies;
        [DataMember]
        public List<SupplierMaterialPOPricingHierarchyModel> SupplierMaterialPOPricingHierarchy
        {
            get => _supplierMaterialPOPricingHierarchies;
            set => SetProperty(ref _supplierMaterialPOPricingHierarchies, value);
        }
        /// <summary>
        /// Local Reference of SupplierSelectionHierarchy
        /// </summary>
        private List<SupplierSelectionHierarchyModel> _iSupplierSelectionHierarchy;
        /// <summary>
        /// Hierarchy of Supplier Selection Hierarchy
        /// </summary>
        [DataMember]
        public List<SupplierSelectionHierarchyModel> SupplierSelectionHierarchy
        {
            get => _iSupplierSelectionHierarchy;
            set => SetProperty(ref _iSupplierSelectionHierarchy, value);
        }

        /// <summary>
        /// Local Reference of _supplierGuid
        /// </summary>
        private Guid _supplierGuid;
        /// <summary>
        /// get or set for SupplierGuid
        /// </summary>
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }
    }

    public class PurchasingSupplierMaterialHierarchyStatelessModel : BaseModel<Guid>
    {
        private string _supplierCode;
        [DataMember]
        [Required]
        [StringLength(4)]
        //[Column(TypeName = "VARCHAR")]
        public string SupplierCode
        {
            get => _supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }

        private bool _isFCExists = false;
        [DataMember]
        public bool IsFCExists
        {
            get => _isFCExists;
            set => SetProperty(ref _isFCExists, value);
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

        private Guid _materialHierarchyGuid;
        [DataMember]
        public Guid MaterialHierarchyGuid
        {
            get => _materialHierarchyGuid;
            set => SetProperty(ref _materialHierarchyGuid, value);
        }

        /// <summary>
        /// Local Reference of _supplierGuid
        /// </summary>
        private Guid _supplierGuid;
        /// <summary>
        /// get or set for SupplierGuid
        /// </summary>
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }

    }

    [DataContract, Serializable]
    public class PurchasingSupplierMaterialHierarchyExportAllStatelessModel : BaseModel<Guid>
    {
        private string _supplierCode;
        [DataMember]
        [Required]
        [StringLength(4)]
        
        public string SupplierCode
        {
            get => _supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }

        /// <summary>
        /// Local Reference of _supplierGuid
        /// </summary>
        private Guid _supplierGuid;
        /// <summary>
        /// get or set for SupplierGuid
        /// </summary>
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }

        private bool _isFCExists = false;
        [DataMember]
        public bool IsFCExists
        {
            get => _isFCExists;
            set => SetProperty(ref _isFCExists, value);
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
        private List<SupplierMaterialPOPricingHierarchyModel> _supplierMaterialPOPricingHierarchies;
        [DataMember]
        public List<SupplierMaterialPOPricingHierarchyModel> SupplierMaterialPOPricingHierarchy
        {
            get => _supplierMaterialPOPricingHierarchies;
            set => SetProperty(ref _supplierMaterialPOPricingHierarchies, value);
        }
        /// <summary>
        /// Local Reference of SupplierSelectionHierarchy
        /// </summary>
        private List<SupplierSelectionHierarchyModel> _iSupplierSelectionHierarchy;
        /// <summary>
        /// Hierarchy of Supplier Selection Hierarchy
        /// </summary>
        [DataMember]
        
        public List<SupplierSelectionHierarchyModel> SupplierSelectionHierarchy
        {
            get => _iSupplierSelectionHierarchy;
            set => SetProperty(ref _iSupplierSelectionHierarchy, value);
        }
    }
}
