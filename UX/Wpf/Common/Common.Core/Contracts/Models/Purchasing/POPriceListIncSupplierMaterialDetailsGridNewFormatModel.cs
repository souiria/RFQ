/**************************************************************************************************
(C) 2020 SEWS-E Ltd., All rights reserved
File Name          :   POPriceListIncSupplierMaterialDetailsGridNewFormatModel.cs
Function           :   POPriceListIncSupplierMaterialDetailsGridNewFormatModel
Created By         :   Shvam Dhingra 
Created on         :   17-May-2022
Revision History   :   [27-May-2022] : Shivam Dhingra
                   :   [] : Changed data type from bool to string
                   :   [12-Apr-2023] : Prakhar Singh
                   :   [] : Add new property SupplierPartNumber
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class POPriceListIncSupplierMaterialDetailsGridNewFormatModel : BaseModel<Guid>
    {
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { SetProperty(ref _supplierCode, value); }
        }
        private string _supplierName;
        [DataMember]
        public string SupplierName
        {
            get { return _supplierName; }
            set { SetProperty(ref _supplierName, value); }
        }
        private string _incoterms;
        [DataMember]
        public string Incoterms
        {
            get { return _incoterms; }
            set { SetProperty(ref _incoterms, value); }
        }
        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get { return _materialNumber; }
            set { SetProperty(ref _materialNumber, value); }
        }
        private string _commodity;
        [DataMember]
        public string Commodity
        {
            get { return _commodity; }
            set { SetProperty(ref _commodity, value); }
        }
        private string _currency;
        [DataMember]
        public string Currency
        {
            get { return _currency; }
            set { SetProperty(ref _currency, value); }
        }

        private int _recordEntryID;
        [DataMember]
        public int RecordEntryID
        {
            get => _recordEntryID;
            set => SetProperty(ref _recordEntryID, value);
        }

        private decimal _poPrice;
        [DataMember]
        public decimal POPrice
        {
            get => _poPrice;
            set => SetProperty(ref _poPrice, value);
        }
        private string _priceChangeNotification;
        [DataMember]
        public string PriceChangeNotification
        {
            get => _priceChangeNotification;
            set => SetProperty(ref _priceChangeNotification, value);
        }

        private string _priceType;
        [DataMember]
        public string PriceType
        {
            get => _priceType;
            set => SetProperty(ref _priceType, value);
        }
        private DateTime _priceEffectiveFromDate;
        [DataMember]
        public DateTime PriceEffectiveFromDate
        {
            get => _priceEffectiveFromDate;
            set => SetProperty(ref _priceEffectiveFromDate, value);
        }

        private decimal _metalWeight;
        [DataMember]
        public decimal MetalWeight
        {
            get => _metalWeight;
            set => SetProperty(ref _metalWeight, value);
        }

        private decimal _metalRate;
        [DataMember]
        public decimal MetalRate
        {
            get => _metalRate;
            set => SetProperty(ref _metalRate, value);
        }

        private decimal _poPriceExcludingMetal;
        [DataMember]
        public decimal POPriceExcludingMetal
        {
            get => _poPriceExcludingMetal;
            set => SetProperty(ref _poPriceExcludingMetal, value);
        }
        private string _pOUnit;
        [DataMember]
        public string POUnit
        {
            get => _pOUnit;
            set => SetProperty(ref _pOUnit, value);
        }
        private string _sewsUnitOfMeasure;
        [DataMember]
        public string SEWSUnitOfMeasure
        {
            get => _sewsUnitOfMeasure;
            set => SetProperty(ref _sewsUnitOfMeasure, value);
        }

        private string _bOMUnit;
        [DataMember]
        public string BOMUnit
        {
            get => _bOMUnit;
            set => SetProperty(ref _bOMUnit, value);
        }
        private int _minimumOrderQuantity;
        [DataMember]
        public int MinimumOrderQuantity
        {
            get => _minimumOrderQuantity;
            set => SetProperty(ref _minimumOrderQuantity, value);
        }
        private int _orderLeadTime;
        [DataMember]
        public int OrderLeadTime
        {
            get => _orderLeadTime;
            set => SetProperty(ref _orderLeadTime, value);
        }
        private int _containerQuantity;
        [DataMember]
        public int ContainerQuantity
        {
            get => _containerQuantity;
            set => SetProperty(ref _containerQuantity, value);
        }

        private int _innerContainerQuantity;
        [DataMember]
        public int InnerContainerQuantity
        {
            get => _innerContainerQuantity;
            set => SetProperty(ref _innerContainerQuantity, value);
        }

        private int _noOfInnerContainers;
        [DataMember]
        public int NoOfInnerContainers
        {
            get => _noOfInnerContainers;
            set => SetProperty(ref _noOfInnerContainers, value);
        }
        private int _issueMinimumLot;
        [DataMember]
        public int IssueMinimumLot
        {
            get => _issueMinimumLot;
            set => SetProperty(ref _issueMinimumLot, value);
        }
        private int _conversionFactor;
        [DataMember]
        public int ConversionFactor
        {
            get => _conversionFactor;
            set => SetProperty(ref _conversionFactor, value);
        }
        private string _supplierMaterialNumber;
        [DataMember]
        public string SupplierMaterialNumber
        {
            get => _supplierMaterialNumber;
            set => SetProperty(ref _supplierMaterialNumber, value);
        }

        private string _supplierMaterialName;
        [DataMember]
        public string SupplierMaterialName
        {
            get => _supplierMaterialName;
            set => SetProperty(ref _supplierMaterialName, value);
        }

        private Guid _supplierMaterialGuid;
        [DataMember]
        public Guid SupplierMaterialGuid
        {
            get => _supplierMaterialGuid;
            set => SetProperty(ref _supplierMaterialGuid, value);
        }
        private decimal _standardBoxLength;
        [DataMember]
        public decimal StandardBoxLength
        {
            get => _standardBoxLength;
            set => SetProperty(ref _standardBoxLength, value);
        }

        private decimal _standardBoxHeight;
        [DataMember]
        public decimal StandardBoxHeight
        {
            get => _standardBoxHeight;
            set => SetProperty(ref _standardBoxHeight, value);
        }

        private decimal _standardBoxWidth;
        [DataMember]
        public decimal StandardBoxWidth
        {
            get => _standardBoxWidth;
            set => SetProperty(ref _standardBoxWidth, value);
        }
        private int _standardPackFactor;
        [DataMember]
        public int StandardPackFactor
        {
            get => _standardPackFactor;
            set => SetProperty(ref _standardPackFactor, value);
        }

        private decimal _fullBoxWeight;
        [DataMember]
        public decimal FullBoxWeight
        {
            get => _fullBoxWeight;
            set => SetProperty(ref _fullBoxWeight, value);
        }
        private int _initialVolumeQuantity;
        [DataMember]
        public int InitialVolumeQuantity
        {
            get => _initialVolumeQuantity;
            set => SetProperty(ref _initialVolumeQuantity, value);
        }
        private string _preProductionNumber;
        [DataMember]
        public string PreProductionNumber
        {
            get => _preProductionNumber;
            set => SetProperty(ref _preProductionNumber, value);
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

        private string _countryCode;
        [DataMember]
        public string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
        }
        private string _origin;
        [DataMember]
        public string Origin
        {
            get => _origin;
            set => SetProperty(ref _origin, value);
        }

        private DateTime _originExpiryDate;
        [DataMember]
        public DateTime OriginExpiryDate
        {
            get => _originExpiryDate;
            set => SetProperty(ref _originExpiryDate, value);
        }
        private string _originDescription;
        [DataMember]
        public string OriginDescription
        {
            get { return _originDescription; }
            set { _originDescription = value; }
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
        private bool _matSuppMainSupplier;
        [DataMember]
        public bool MatSuppMainSupplier
        {
            get { return _matSuppMainSupplier; }
            set { _matSuppMainSupplier = value; }
        }
        private string _approved;
        [DataMember]
        public string Approved
        {
            get => _approved;
            set => SetProperty(ref _approved, value);
        }

        private string _column1;
        /// <summary>
        /// Get or Set for {Column1}.
        /// </summary>
        [DataMember]

        public string Column1
        {
            get => _column1;
            set => _column1 = value;
        }
        private string _column2;
        /// <summary>
        /// Get or Set for {Column2}.
        /// </summary>
        [DataMember]

        public string Column2
        {
            get => _column2;
            set => _column2 = value;
        }
        private string _column3;
        /// <summary>
        /// Get or Set for {Column3}.
        /// </summary>
        [DataMember]

        public string Column3
        {
            get => _column3;
            set => _column3 = value;
        }

        private string _column4;
        /// <summary>
        /// Get or Set for {Column4}.
        /// </summary>
        [DataMember]

        public string Column4
        {
            get => _column4;
            set => _column4 = value;
        }

        private string _column5;
        /// <summary>
        /// Get or Set for {Column5}.
        /// </summary>
        [DataMember]

        public string Column5
        {
            get => _column5;
            set => _column5 = value;
        }

        private string _column6;
        /// <summary>
        /// Get or Set for {Column6}.
        /// </summary>
        [DataMember]

        public string Column6
        {
            get => _column6;
            set => _column6 = value;
        }

        private string _column7;
        /// <summary>
        /// Get or Set for {Column7}.
        /// </summary>
        [DataMember]

        public string Column7
        {
            get => _column7;
            set => _column7 = value;
        }

        private string _column8;
        /// <summary>
        /// Get or Set for {Column8}.
        /// </summary>
        [DataMember]

        public string Column8
        {
            get => _column8;
            set => _column8 = value;
        }

        private string _column9;
        /// <summary>
        /// Get or Set for {Column9}.
        /// </summary>
        [DataMember]

        public string Column9
        {
            get => _column9;
            set => _column9 = value;
        }

        private string _column10;
        /// <summary>
        /// Get or Set for {Column10}.
        /// </summary>
        [DataMember]

        public string Column10
        {
            get => _column10;
            set => _column10 = value;
        }

        private string _column11;
        /// <summary>
        /// Get or Set for {Column11}.
        /// </summary>
        [DataMember]

        public string Column11
        {
            get => _column11;
            set => _column11 = value;
        }

        private string _column12;
        /// <summary>
        /// Get or Set for {Column12}.
        /// </summary>
        [DataMember]

        public string Column12
        {
            get => _column12;
            set => _column12 = value;
        }

        private string _column13;
        /// <summary>
        /// Get or Set for {Column13}.
        /// </summary>
        [DataMember]

        public string Column13
        {
            get => _column13;
            set => _column13 = value;
        }

        private string _column14;
        /// <summary>
        /// Get or Set for {Column14}.
        /// </summary>
        [DataMember]

        public string Column14
        {
            get => _column14;
            set => _column14 = value;
        }

        private string _column15;
        /// <summary>
        /// Get or Set for {Column15}.
        /// </summary>
        [DataMember]

        public string Column15
        {
            get => _column15;
            set => _column15 = value;
        }

        private string _column16;
        /// <summary>
        /// Get or Set for {Column16}.
        /// </summary>
        [DataMember]

        public string Column16
        {
            get => _column16;
            set => _column16 = value;
        }

        private string _column17;
        /// <summary>
        /// Get or Set for {Column17}.
        /// </summary>
        [DataMember]

        public string Column17
        {
            get => _column17;
            set => _column17 = value;
        }

        private string _column18;
        /// <summary>
        /// Get or Set for {Column18}.
        /// </summary>
        [DataMember]

        public string Column18
        {
            get => _column18;
            set => _column18 = value;
        }

        private string _column19;
        /// <summary>
        /// Get or Set for {Column19}.
        /// </summary>
        [DataMember]

        public string Column19
        {
            get => _column19;
            set => _column19 = value;
        }

        private string _column20;
        /// <summary>
        /// Get or Set for {Column20}.
        /// </summary>
        [DataMember]

        public string Column20
        {
            get => _column20;
            set => _column20 = value;
        }

        private string _originStatusDescription;
        /// <summary>
        /// Get or Set for {_originStatusDescription}.
        /// </summary>
        [DataMember]

        public string OriginStatusDescription
        {
            get => _originStatusDescription;
            set => _originStatusDescription = value;
        }

        private string _euPreferentialOriginStatusDescription;
        /// <summary>
        /// Get or Set for {_EUPreferentialOriginStatusDescription}.
        /// </summary>
        [DataMember]

        public string EUPreferentialOriginStatusDescription
        {
            get => _euPreferentialOriginStatusDescription;
            set => _euPreferentialOriginStatusDescription = value;
        }

        /// <summary>
        /// Local Reference of SupplierSelectionHierarchy
        /// </summary>
        private List<SupplierSelectionHierarchyModel> _supplierSelectionHierarchy;
        /// <summary>
        /// Hierarchy of Purchasing Supplier Material
        /// </summary>
        [DataMember]
        public List<SupplierSelectionHierarchyModel> SupplierSelectionHierarchy
        {
            get => _supplierSelectionHierarchy;
            set => SetProperty(ref _supplierSelectionHierarchy, value);
        }

        private bool _isFCExists = false;
        [DataMember]
        public bool IsFCExists
        {
            get => _isFCExists;
            set => SetProperty(ref _isFCExists, value);
        }

        private string _distributionContryofOrigin;
        /// <summary>
        /// Get or Set for {_distributionContryofOrigin}.
        /// </summary>
        [DataMember]

        public string DistributionContryofOrigin
        {
            get => _distributionContryofOrigin;
            set => _distributionContryofOrigin = value;
        }

        private string _supplierPartNumber;
        [DataMember]
        public string SupplierPartNumber
        {
            get => _supplierPartNumber;
            set => SetProperty(ref _supplierPartNumber, value);
        }

    }
}

