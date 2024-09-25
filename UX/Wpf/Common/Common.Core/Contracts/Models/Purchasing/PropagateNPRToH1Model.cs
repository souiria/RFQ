/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   PropagateNPRToH1Model.cs
Function           :   Propagate NPR Data to H1
Created By         :   Pawan
Created on         :   27-Aug-2019
Revision History   :   [13-Sep-2019] : Pawan
                   :   [] : Added fields for PO Price Exc Metal and Is Customer Nominated Material
                   :   [16-Sep-2019] : Pawan
                   :   [] : Added fields for NPR Stage
                   :   [11-Mar-2020] : Pawan
                   :   [] : Changed data type for Initial Volume Quantity
                   :   [04-May-2022] : Ranjay
                   :   [] : Added field Supplier guid
                   :   [09-May-2022] : Shivam Dhingra
                   :   [] : Added field BusinessUnitGuid
                   :   [10-May-2022] : Shivam Kalia
                   :   [] : Added field CountryGuid
                   :   [23-Aug-2022] : Ranjay
                   :   Code modified w.r.t. propagation changes (2 services merged into 1), changes done as per HD Call No 00350290 
                   :   [05-July-2023] : Virendra
                   :   [HD:00367280] Make this 'BusinessUnitGuid' as a List type
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;
using System.Collections.Generic;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Propagate NPR Data to H1 Screens
    /// </summary>
    [DataContract, Serializable]
    public class PropagateNPRToH1Model : BaseModel<Guid>
    {
        private string _materialNumber;
        /// <summary>
        /// Material Number
        /// </summary>
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }
        private string _materialDescription;
        /// <summary>
        /// Material Description
        /// </summary>
        [DataMember]
        public string MaterialDescription
        {
            get => _materialDescription;
            set => _materialDescription = value;
        }

        private string _materialType;
        /// <summary>
        /// Material Type
        /// </summary>
        [DataMember]
        public string MaterialType
        {
            get => _materialType;
            set => _materialType = value;
        }

        private string _bomUnit;
        /// <summary>
        /// BOM Unit
        /// </summary>
        [DataMember]
        public string BOMUnit
        {
            get => _bomUnit;
            set => _bomUnit = value;
        }

        private string _supplierCode;
        /// <summary>
        /// Supplier Code
        /// </summary>
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }

        private string _poUnit;
        /// <summary>
        /// PO Unit
        /// </summary>
        [DataMember]
        public string POUnit
        {
            get => _poUnit;
            set => _poUnit = value;
        }

        private int _poMinimumOrderQuantity;
        /// <summary>
        /// PO Minimum Order Quantity
        /// </summary>
        [DataMember]
        public int POMinimumOrderQuantity
        {
            get => _poMinimumOrderQuantity;
            set => _poMinimumOrderQuantity = value;
        }
        private decimal _poPrice;
        /// <summary>
        /// PO Price
        /// </summary>
        [DataMember]
        [DecimalPrecision(13, 5)]
        public decimal POPrice
        {
            get => _poPrice;
            set => _poPrice = value;
        }

        private decimal _poPriceExCopperRate;
        /// <summary>
        /// PO Price
        /// </summary>
        [DataMember]
        [DecimalPrecision(13, 5)]
        public decimal POPriceExCopperRate
        {
            get => _poPriceExCopperRate;
            set => _poPriceExCopperRate = value;
        }
        private int _orderLeadTime;
        /// <summary>
        /// Order Lead Time
        /// </summary>
        [DataMember]
        public int OrderLeadTime
        {
            get => _orderLeadTime;
            set => _orderLeadTime = value;
        }
        private int _unitConversionFactorPO;
        /// <summary>
        /// Unit Conversion Factor
        /// </summary>
        [DataMember]
        public int UnitConversionFactorPO
        {
            get => _unitConversionFactorPO;
            set => _unitConversionFactorPO = value;
        }
        private string _supplierMaterialNumber;
        /// <summary>
        /// Supplier Material Number
        /// </summary>
        [DataMember]
        public string SupplierMaterialNumber
        {
            get => _supplierMaterialNumber;
            set => _supplierMaterialNumber = value;
        }
        private string _tariffCode;
        /// <summary>
        /// Tariff Code
        /// </summary>
        [DataMember]
        public string TariffCode
        {
            get => _tariffCode;
            set => _tariffCode = value;
        }
        private string _originCountryCode;
        /// <summary>
        /// Origin Country Code
        /// </summary>
        [DataMember]
        public string OriginCountryCode
        {
            get => _originCountryCode;
            set => _originCountryCode = value;
        }

        private string _originStatus;
        /// <summary>
        /// Origin Status
        /// </summary>
        [DataMember]
        public string OriginStatus
        {
            get => _originStatus;
            set => _originStatus = value;
        }

        private DateTime _expiryDate;
        /// <summary>
        /// Expiry Date
        /// </summary>
        [DataMember]
        public DateTime ExpiryDate
        {
            get => _expiryDate;
            set => _expiryDate = value;
        }

        private string _remarks;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Remarks
        {
            get => _remarks;
            set => _remarks = value;
        }
        private string _businessUnitCode;
        /// <summary>
        /// Business Unit Code
        /// </summary>
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }

        private int _bagQuantity;
        /// <summary>
        /// Bag Quantity
        /// </summary>
        [DataMember]
        public int BagQuantity
        {
            get => _bagQuantity;
            set => _bagQuantity = value;
        }

        private decimal _copperWeight;
        /// <summary>
        /// Copper Weight
        /// </summary>
        [DataMember]
        public decimal CopperWeight
        {
            get => _copperWeight;
            set => _copperWeight = value;
        }

        private int _initialVolumeQuantity = 1;
        /// <summary>
        /// Initial Volume  Quantity
        /// </summary>
        [DataMember]
        public int InitialVolumeQuantity
        {
            get => _initialVolumeQuantity;
            set => _initialVolumeQuantity = value;
        }

        private string _replaceMaterialNumber = "Replace material number";
        /// <summary>
        /// Replace Material Number
        /// </summary>
        [DataMember]
        public string ReplaceMaterialNumber
        {
            get => _replaceMaterialNumber;
            set => _replaceMaterialNumber = value;
        }

        private decimal _copperRate = 0;
        /// <summary>
        /// Copper Rate
        /// </summary>
        [DataMember]
        [DecimalPrecision(16, 6)]
        public decimal CopperRate
        {
            get => _copperRate;
            set => _copperRate = value;
        }

        private decimal _standardBoxLength = 1;
        /// <summary>
        /// Standard Box Length
        /// </summary>
        [DataMember]
        [DecimalPrecision(6, 3)]
        public decimal StandardBoxLength
        {
            get => _standardBoxLength;
            set => _standardBoxLength = value;
        }

        private decimal _standardBoxHeight = 1;
        /// <summary>
        /// Standard Box Height
        /// </summary>
        [DataMember]
        [DecimalPrecision(6, 3)]
        public decimal StandardBoxHeight
        {
            get => _standardBoxHeight;
            set => _standardBoxHeight = value;
        }
        private decimal _standardBoxWidth = 1;
        /// <summary>
        /// Standard Box Width
        /// </summary>
        [DataMember]
        [DecimalPrecision(6, 3)]
        public decimal StandardBoxWidth
        {
            get => _standardBoxWidth;
            set => _standardBoxWidth = value;
        }
        private int _standardPackFactor;
        /// <summary>
        /// Standard Pack Factor
        /// </summary>
        [DataMember]
        public int StandardPackFactor
        {
            get => _standardPackFactor;
            set => _standardPackFactor = value;
        }

        private decimal _fullBoxWeight = 0;
        /// <summary>
        /// Full Box Weight
        /// </summary>
        [DataMember]
        [DecimalPrecision(6, 2)]
        public decimal FullBoxWeight
        {
            get => _fullBoxWeight = 0;
            set => _fullBoxWeight = value;
        }

        private string _priceTypeCode;
        /// <summary>
        /// Price Type Code
        /// </summary>
        [DataMember]
        public string PriceTypeCode
        {
            get => _priceTypeCode;
            set => _priceTypeCode = value;
        }

        /// <summary>
        /// Local Reference of IsCustomerNominatedMaterial
        /// </summary>
        private bool _isCustomerNominatedMaterial;
        /// <summary>
        /// Is Customer Nominated Material
        /// </summary>
        [DataMember]
        public bool IsCustomerNominatedMaterial
        {
            get => _isCustomerNominatedMaterial;
            set => _isCustomerNominatedMaterial = value;
        }

        private string _nprStage;
        /// <summary>
        /// NPR Stage
        /// </summary>
        [DataMember]
        public string NPRStage
        {
            get => _nprStage;
            set => _nprStage = value;
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

        private List<Guid> _businessUnitGuid;
        /// <summary>
        /// Business Unit Guid
        /// </summary>
        [DataMember]
        public List<Guid> BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        /// <summary>
        /// Local Reference of _countryGuid
        /// </summary>
        private Guid _countryGuid;
        /// <summary>
        /// get or set for CountryGuid
        /// </summary>
        [DataMember]
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => SetProperty(ref _countryGuid, value);
        }

        /// <summary>
        /// Local Reference of _NPRId
        /// </summary>
        private Guid _NPRId;
        /// <summary>
        /// get or set for _NPRId
        /// </summary>
        [DataMember]
        public Guid NPRId
        {
            get => _NPRId;
            set => SetProperty(ref _NPRId, value);
        }
        /// <summary>
        /// Local Reference of PurchasingSupplierComments
        /// </summary>
        private string _purchasingSupplierComments;
        /// <summary>
        /// Gets or sets a string value for the PurchasingSupplierComments.
        /// </summary>
        [DataMember]
        public string PurchasingSupplierComments
        {
            get { return _purchasingSupplierComments; }
            set { SetProperty(ref _purchasingSupplierComments, value); }
        }
        /// <summary>
        /// Local Reference of IsBusinessNotWon
        /// </summary>
        private bool _isBusinessNotWon;
        /// <summary>
        /// May only be temporary until Status from Project Master can be used
        /// </summary>
        [DataMember]
        public bool IsBusinessNotWon
        {
            get => _isBusinessNotWon;
            set => SetProperty(ref _isBusinessNotWon, value);
        }

        private string _nprCancellationComments;
        /// <summary>
        /// Gets or sets a value for CancelledNPRRemarks
        /// </summary>
        [DataMember]
        public string NPRCancellationComments
        {
            get => _nprCancellationComments;
            set => SetProperty(ref _nprCancellationComments, value);
        }
        /// <summary>
        /// Local Reference of NPRReturnedRemarks
        /// </summary>
        private string _nprReturnedRemarks;
        /// <summary>
        /// Get or Sets the value of indicating {NPRReturnedRemarks} of NPR
        /// </summary>
        [DataMember]
        public string NPRReturnedRemarks
        {
            get => _nprReturnedRemarks;
            set => SetProperty(ref _nprReturnedRemarks, value);
        }
    }
}
