/**************************************************************************************************
(C) 2020 SEWS-E Ltd., All rights reserved
File Name          :   POPriceListIncSupplierMaterialDetailsGridModel.cs
Function           :   POPriceListIncSupplierMaterialDetailsGridModel
Created By         :   Yati 
Created on         :   19-May-2020
Revision History   :                   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class POPriceListIncSupplierMaterialDetailsGridModel : BaseModel<Guid>
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
    }
}
