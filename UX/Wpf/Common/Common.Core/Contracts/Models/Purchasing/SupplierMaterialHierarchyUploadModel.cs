/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierMaterialHierarchyUploadModel.cs
Function           :   Supplier Material Hierarchy Upload Functionality
Created By         :   Srashti Gupta
Created on         :   06-April-2020
Revision History   :   [28-Mar-2022] : Sejal Srivastava
*                  :   [] : Added a new class SupplierMaterialHierarchyStatelessUploadModel 
*                  :   [04-May-2022] : Ranjay
                   :   [] : Added field Supplier guid
 ****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Model for SupplierMaterialHierarchyUploadModel
    /// </summary>
    [DataContract, Serializable]
    public class SupplierMaterialHierarchyUploadModel : BaseModel<Guid>
    {
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }

        [DataMember]
        public string SupplierCode { get; set; }
        [DataMember]
        public string MaterialNumber { get; set; }


        #region Purchasing Supplier Material

        private Guid _unitOfMeasurementGuid;
        [DataMember]
        public Guid UnitOfMeasurementGuid //POUnit
        {
            get { return _unitOfMeasurementGuid; }
            set { SetProperty(ref _unitOfMeasurementGuid, value); }
        }

        private string _pOUnit;
        [DataMember]
        public string POUnit
        {
            get { return _pOUnit; }
            set { SetProperty(ref _pOUnit, value); }
        }

        private decimal _pOPrice;
        [DataMember]
        public decimal POPrice
        {
            get { return _pOPrice; }
            set { SetProperty(ref _pOPrice, value); }
        }

        private decimal _metalWeight;
        [DataMember]
        public decimal MetalWeight
        {
            get { return _metalWeight; }
            set { SetProperty(ref _metalWeight, value); }
        }

        private decimal _metalRate;
        [DataMember]
        public decimal MetalRate
        {
            get { return _metalRate; }
            set { SetProperty(ref _metalRate, value); }
        }

        private decimal _pOPriceExcludingMetal;
        [DataMember]
        public decimal POPriceExcludingMetal
        {
            get { return _pOPriceExcludingMetal; }
            set { SetProperty(ref _pOPriceExcludingMetal, value); }
        }

        private int _minimumOrderQuantity;
        [DataMember]
        public int MinimumOrderQuantity
        {
            get { return _minimumOrderQuantity; }
            set { SetProperty(ref _minimumOrderQuantity, value); }
        }

        private int _orderLeadTime;
        [DataMember]
        public int OrderLeadTime
        {
            get { return _orderLeadTime; }
            set { SetProperty(ref _orderLeadTime, value); }
        }

        private int _containerQuantity;
        [DataMember]
        public int ContainerQuantity
        {
            get { return _containerQuantity; }
            set { SetProperty(ref _containerQuantity, value); }
        }

        private int _innerContainerQuantity;
        [DataMember]
        public int InnerContainerQuantity
        {
            get { return _innerContainerQuantity; }
            set { SetProperty(ref _innerContainerQuantity, value); }
        }

        private bool _matSuppMainSupplier;
        [DataMember]
        public bool MatSuppMainSupplier
        {
            get { return _matSuppMainSupplier; }
            set { SetProperty(ref _matSuppMainSupplier, value); }
        }

        private int _issueMinimumLot;
        [DataMember]
        public int IssueMinimumLot
        {
            get { return _issueMinimumLot; }
            set { SetProperty(ref _issueMinimumLot, value); }
        }

        private int _conversionFactor;
        [DataMember]
        public int ConversionFactor
        {
            get { return _conversionFactor; }
            set { SetProperty(ref _conversionFactor, value); }
        }

        private string _supplierMaterialNumber;
        [DataMember]
        public string SupplierMaterialNumber
        {
            get { return _supplierMaterialNumber; }
            set { SetProperty(ref _supplierMaterialNumber, value); }
        }

        private string _supplierMaterialName;
        [DataMember]
        public string SupplierMaterialName
        {
            get { return _supplierMaterialName; }
            set { SetProperty(ref _supplierMaterialName, value); }
        }

        private decimal _standardBoxLength;
        [DataMember]
        public decimal StandardBoxLength
        {
            get { return _standardBoxLength; }
            set { SetProperty(ref _standardBoxLength, value); }
        }

        private decimal _standardBoxWidth;
        [DataMember]
        public decimal StandardBoxWidth
        {
            get { return _standardBoxWidth; }
            set { SetProperty(ref _standardBoxWidth, value); }
        }

        private decimal _standardBoxHeight;
        [DataMember]
        public decimal StandardBoxHeight
        {
            get { return _standardBoxHeight; }
            set { SetProperty(ref _standardBoxHeight, value); }
        }

        private int _standardPackFactor;
        [DataMember]
        public int StandardPackFactor
        {
            get { return _standardPackFactor; }
            set { SetProperty(ref _standardPackFactor, value); }
        }

        private decimal _fullBoxWeight;
        [DataMember]
        public decimal FullBoxWeight
        {
            get { return _fullBoxWeight; }
            set { SetProperty(ref _fullBoxWeight, value); }
        }

        private int _initialVolumeQuantity;
        [DataMember]
        public int InitialVolumeQuantity
        {
            get { return _initialVolumeQuantity; }
            set { SetProperty(ref _initialVolumeQuantity, value); }
        }

        private string _replacementMaterialNumber;
        [DataMember]
        public string ReplacementMaterialNumber
        {
            get { return _replacementMaterialNumber; }
            set { SetProperty(ref _replacementMaterialNumber, value); }
        }

        private Guid _tariffCodeGuid;
        [DataMember]
        public Guid TariffCodeGuid
        {
            get { return _tariffCodeGuid; }
            set { SetProperty(ref _tariffCodeGuid, value); }
        }

        private string _tariffCode;
        [DataMember]
        public string TariffCode
        {
            get { return _tariffCode; }
            set { SetProperty(ref _tariffCode, value); }
        }

        private DateTime _expiryDate;
        [DataMember]
        public DateTime ExpiryDate
        {
            get { return _expiryDate; }
            set { SetProperty(ref _expiryDate, value); }
        }

        private Guid _countryGuid;
        [DataMember]
        public Guid CountryGuid
        {
            get { return _countryGuid; }
            set { SetProperty(ref _countryGuid, value); }
        }
        private string _countryCode;
        [DataMember]
        public string CountryCode
        {
            get { return _countryCode; }
            set { SetProperty(ref _countryCode, value); }
        }

        private Guid _countryRegionAssociationGuid;
        [DataMember]
        public Guid CountryRegionAssociationGuid
        {
            get { return _countryRegionAssociationGuid; }
            set { SetProperty(ref _countryRegionAssociationGuid, value); }
        }
        private bool _isFCExists = false;
        [DataMember]
        public bool IsFCExists
        {
            get => _isFCExists;
            set => SetProperty(ref _isFCExists, value);
        }
        private int _noOfInnerContainers;
        [DataMember]
        public int NoOfInnerContainers
        {
            get => _noOfInnerContainers;
            set => SetProperty(ref _noOfInnerContainers, value);
        }
        private string _euPreferentialOriginStatusCode;
        [DataMember]
        public string EUPreferentialOriginStatusCode
        {
            get => _euPreferentialOriginStatusCode;
            set => SetProperty(ref _euPreferentialOriginStatusCode, value);
        }
        #endregion

    }

    /// <summary>
    /// Model for SupplierMaterialHierarchyStatelessUploadModel
    /// </summary>
    [DataContract, Serializable]
    public class SupplierMaterialHierarchyStatelessUploadModel : BaseModel<Guid>
    {
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }

        [DataMember]
        public string SupplierCode { get; set; }
        [DataMember]
        public string MaterialNumber { get; set; }


        #region Purchasing Supplier Material

        private Guid _unitOfMeasurementGuid;
        [DataMember]
        public Guid UnitOfMeasurementGuid //POUnit
        {
            get { return _unitOfMeasurementGuid; }
            set { SetProperty(ref _unitOfMeasurementGuid, value); }
        }

        private string _pOUnit;
        [DataMember]
        public string POUnit
        {
            get { return _pOUnit; }
            set { SetProperty(ref _pOUnit, value); }
        }

        private decimal _pOPrice;
        [DataMember]
        public decimal POPrice
        {
            get { return _pOPrice; }
            set { SetProperty(ref _pOPrice, value); }
        }

        private decimal _metalWeight;
        [DataMember]
        public decimal MetalWeight
        {
            get { return _metalWeight; }
            set { SetProperty(ref _metalWeight, value); }
        }

        private decimal _metalRate;
        [DataMember]
        public decimal MetalRate
        {
            get { return _metalRate; }
            set { SetProperty(ref _metalRate, value); }
        }

        private decimal _pOPriceExcludingMetal;
        [DataMember]
        public decimal POPriceExcludingMetal
        {
            get { return _pOPriceExcludingMetal; }
            set { SetProperty(ref _pOPriceExcludingMetal, value); }
        }

        private int _minimumOrderQuantity;
        [DataMember]
        public int MinimumOrderQuantity
        {
            get { return _minimumOrderQuantity; }
            set { SetProperty(ref _minimumOrderQuantity, value); }
        }

        private int _orderLeadTime;
        [DataMember]
        public int OrderLeadTime
        {
            get { return _orderLeadTime; }
            set { SetProperty(ref _orderLeadTime, value); }
        }

        private int _containerQuantity;
        [DataMember]
        public int ContainerQuantity
        {
            get { return _containerQuantity; }
            set { SetProperty(ref _containerQuantity, value); }
        }

        private int _innerContainerQuantity;
        [DataMember]
        public int InnerContainerQuantity
        {
            get { return _innerContainerQuantity; }
            set { SetProperty(ref _innerContainerQuantity, value); }
        }

        private bool _matSuppMainSupplier;
        [DataMember]
        public bool MatSuppMainSupplier
        {
            get { return _matSuppMainSupplier; }
            set { SetProperty(ref _matSuppMainSupplier, value); }
        }

        private int _issueMinimumLot;
        [DataMember]
        public int IssueMinimumLot
        {
            get { return _issueMinimumLot; }
            set { SetProperty(ref _issueMinimumLot, value); }
        }

        private int _conversionFactor;
        [DataMember]
        public int ConversionFactor
        {
            get { return _conversionFactor; }
            set { SetProperty(ref _conversionFactor, value); }
        }

        private string _supplierMaterialNumber;
        [DataMember]
        public string SupplierMaterialNumber
        {
            get { return _supplierMaterialNumber; }
            set { SetProperty(ref _supplierMaterialNumber, value); }
        }

        private string _supplierMaterialName;
        [DataMember]
        public string SupplierMaterialName
        {
            get { return _supplierMaterialName; }
            set { SetProperty(ref _supplierMaterialName, value); }
        }

        private decimal _standardBoxLength;
        [DataMember]
        public decimal StandardBoxLength
        {
            get { return _standardBoxLength; }
            set { SetProperty(ref _standardBoxLength, value); }
        }

        private decimal _standardBoxWidth;
        [DataMember]
        public decimal StandardBoxWidth
        {
            get { return _standardBoxWidth; }
            set { SetProperty(ref _standardBoxWidth, value); }
        }

        private decimal _standardBoxHeight;
        [DataMember]
        public decimal StandardBoxHeight
        {
            get { return _standardBoxHeight; }
            set { SetProperty(ref _standardBoxHeight, value); }
        }

        private int _standardPackFactor;
        [DataMember]
        public int StandardPackFactor
        {
            get { return _standardPackFactor; }
            set { SetProperty(ref _standardPackFactor, value); }
        }

        private decimal _fullBoxWeight;
        [DataMember]
        public decimal FullBoxWeight
        {
            get { return _fullBoxWeight; }
            set { SetProperty(ref _fullBoxWeight, value); }
        }

        private int _initialVolumeQuantity;
        [DataMember]
        public int InitialVolumeQuantity
        {
            get { return _initialVolumeQuantity; }
            set { SetProperty(ref _initialVolumeQuantity, value); }
        }

        private string _replacementMaterialNumber;
        [DataMember]
        public string ReplacementMaterialNumber
        {
            get { return _replacementMaterialNumber; }
            set { SetProperty(ref _replacementMaterialNumber, value); }
        }

        private Guid _tariffCodeGuid;
        [DataMember]
        public Guid TariffCodeGuid
        {
            get { return _tariffCodeGuid; }
            set { SetProperty(ref _tariffCodeGuid, value); }
        }

        private Guid _countryRegionsAssociationGuid;
        [DataMember]
        public Guid CountryRegionsAssociationGuid
        {
            get { return _countryRegionsAssociationGuid; }
            set { SetProperty(ref _countryRegionsAssociationGuid, value); }
        }

        private string _tariffCode;
        [DataMember]
        public string TariffCode
        {
            get { return _tariffCode; }
            set { SetProperty(ref _tariffCode, value); }
        }

        private DateTime _expiryDate;
        [DataMember]
        public DateTime ExpiryDate
        {
            get { return _expiryDate; }
            set { SetProperty(ref _expiryDate, value); }
        }

        private Guid _countryGuid;
        [DataMember]
        public Guid CountryGuid
        {
            get { return _countryGuid; }
            set { SetProperty(ref _countryGuid, value); }
        }
        private string _countryCode;
        [DataMember]
        public string CountryCode
        {
            get { return _countryCode; }
            set { SetProperty(ref _countryCode, value); }
        }

        private Guid _countryRegionAssociationGuid;
        [DataMember]
        public Guid CountryRegionAssociationGuid
        {
            get { return _countryRegionAssociationGuid; }
            set { SetProperty(ref _countryRegionAssociationGuid, value); }
        }
        private bool _isFCExists = false;
        [DataMember]
        public bool IsFCExists
        {
            get => _isFCExists;
            set => SetProperty(ref _isFCExists, value);
        }
        private int _noOfInnerContainers;
        [DataMember]
        public int NoOfInnerContainers
        {
            get => _noOfInnerContainers;
            set => SetProperty(ref _noOfInnerContainers, value);
        }
        private string _euPreferentialOriginStatusCode;
        [DataMember]
        public string EUPreferentialOriginStatusCode
        {
            get => _euPreferentialOriginStatusCode;
            set => SetProperty(ref _euPreferentialOriginStatusCode, value);
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
        #endregion
    }
}

