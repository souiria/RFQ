using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDSupplierMaterialModel
    {
        private Guid _supplierMaterialAssociationGuid;
        [DataMember]
        public Guid SupplierMaterialAssociationGuid
        {
            get => _supplierMaterialAssociationGuid;
            set => _supplierMaterialAssociationGuid = value;
        }

        private int _minimumOrderQuantity;
        [DataMember]
        public int MinimumOrderQuantity
        {
            get => _minimumOrderQuantity;
            set => _minimumOrderQuantity = value;
        }

        private Guid _unitOfMeasurementGuid;
        [DataMember]
        public Guid UnitOfMeasurementGuid
        {
            get => _unitOfMeasurementGuid;
            set => _unitOfMeasurementGuid = value;
        }


        private int _conversionFactor;
        [DataMember]
        public int ConversionFactor
        {
            get => _conversionFactor;
            set => _conversionFactor = value;
        }

        private decimal _poPrice;
        [DataMember]
        [DecimalPrecision(9, 5)]
        public decimal POPrice
        {
            get => _poPrice;
            set => _poPrice = value;
        }

        private int _orderLeadTime;
        [DataMember]
        public int OrderLeadTime
        {
            get => _orderLeadTime;
            set => _orderLeadTime = value;
        }

        private int _issueMinimumLot;
        [DataMember]
        public int IssueMinimumLot
        {
            get => _issueMinimumLot;
            set => _issueMinimumLot = value;
        }

        private int _containerQuantity;
        [DataMember]
        public int ContainerQuantity
        {
            get => _containerQuantity;
            set => _containerQuantity = value;
        }

        private int _innerContainerQuantity;
        [DataMember]
        public int InnerContainerQuantity
        {
            get => _innerContainerQuantity;
            set => _innerContainerQuantity = value;
        }

        private int _noOfInnerContainers;
        [DataMember]
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
        [DecimalPrecision(9, 5)]
        public decimal POPriceExcludingMetal
        {
            get => _poPriceExcludingMetal;
            set => _poPriceExcludingMetal = value;
        }

        private int _initialVolumeQuantity;
        [DataMember]
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
        public decimal MetalWeight
        {
            get => _metalWeight;
            set => _metalWeight = value;
        }

        private decimal _metalRate;
        [DataMember]
        [DecimalPrecision(10, 5)]
        public decimal MetalRate
        {
            get => _metalRate;
            set => _metalRate = value;
        }

        private decimal _standardBoxLength;
        [DataMember]
        [DecimalPrecision(6, 3)]
        public decimal StandardBoxLength
        {
            get => _standardBoxLength;
            set => _standardBoxLength = value;
        }

        private decimal _standardBoxHeight;
        [DataMember]
        [DecimalPrecision(6, 3)]
        public decimal StandardBoxHeight
        {
            get => _standardBoxHeight;
            set => _standardBoxHeight = value;
        }

        private decimal _standardBoxWidth;
        [DataMember]
        [DecimalPrecision(6, 3)]
        public decimal StandardBoxWidth
        {
            get => _standardBoxWidth;
            set => _standardBoxWidth = value;
        }


        private int _standardPackFactor;
        [DataMember]
        public int StandardPackFactor
        {
            get => _standardPackFactor;
            set => _standardPackFactor = value;
        }

        private decimal _fullBoxWeight;
        [DataMember]
        [DecimalPrecision(5, 2)]
        public decimal FullBoxWeight
        {
            get => _fullBoxWeight;
            set => _fullBoxWeight = value;
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        private string _pOUnit;
        [DataMember]
        public string POUnit
        {
            get => _pOUnit;
            set => _pOUnit = value;
        }

        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => _supplierGuid = value;
        }
        private string _supplierCode;
        [DataMember]
        [StringLength(4)]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }

        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => _materialGuid = value;
        }
        private string _materialNumber;
        [DataMember]
        [StringLength(26)]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }
        private bool _matSuppMainSupplier;
        [DataMember]
        public bool MatSuppMainSupplier
        {
            get { return _matSuppMainSupplier; }
            set { _matSuppMainSupplier = value; }
        }
        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }

        private Guid _tariffCodeGuid;
        [DataMember]
        public Guid TariffCodeGuid
        {
            get => _tariffCodeGuid;
            set => _tariffCodeGuid =  value;
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

        private string _tariffCodeName;
        [DataMember]
        public string TariffCodeName
        {
            get => _tariffCodeName; 
            set => _tariffCodeName =  value; 
        }

        private string _alpha2Code;
        [DataMember]
        public string Alpha2Code
        {
            get => _alpha2Code;
            set => _alpha2Code = value;
        }

        private string _originStatusCode;
        [DataMember]
        public string OriginStatusCode
        {
            get => _originStatusCode;
            set => _originStatusCode = value;
        }

        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
    }
}
