using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows;

namespace Common.Core.Contracts.Models.Sales.AlternativePart
{
    [DataContract, NotMapped, Serializable]
    public class AlternativePartsResults : ExternalDataSourceModel<long>
    {
        private bool _foundEmacs;
        [DataMember, NotMapped]
        public bool FoundEmacs
        {
            get => _foundEmacs;
            set => SetProperty(ref _foundEmacs, value);
        }
        private bool _foundCPD;
        [DataMember, NotMapped]
        public bool FoundCPD 
        {
            get => _foundCPD;
            set => SetProperty(ref _foundCPD, value);
        }
        private bool _foundNPA;
        [DataMember, NotMapped]
        public bool FoundNPA
        {
            get => _foundNPA;
            set => SetProperty(ref _foundNPA, value);
        }

        //EMacsInfo
        private string _emacsSumitomoNumber;
        [DataMember, NotMapped]
        public string EmacsSumitomoNumber
        {
            get => _emacsSumitomoNumber;
            set => SetProperty(ref _emacsSumitomoNumber, value);
        }
        private string _emacsOPJName;
        [DataMember, NotMapped]
        public string EmacsOPJName
        {
            get => _emacsOPJName;
            set => SetProperty(ref _emacsOPJName, value);
        }
        private string _emacsOPEName;
        [DataMember, NotMapped]
        public string EmacsOPEName
        {
            get => _emacsOPEName;
            set => SetProperty(ref _emacsOPEName, value);
        }
        private string _emacsGroup1;
        [DataMember, NotMapped]
        public string EmacsGroup1
        {
            get => _emacsGroup1;
            set => SetProperty(ref _emacsGroup1, value);
        }
        private string _emacsGroup2;
        [DataMember, NotMapped]
        public string EmacsGroup2
        {
            get => _emacsGroup2;
            set => SetProperty(ref _emacsGroup2, value);
        }
        private string _emacsGroup3;
        [DataMember, NotMapped]
        public string EmacsGroup3
        {
            get => _emacsGroup3;
            set => SetProperty(ref _emacsGroup3, value);
        }
        private string _emacsGroup4;
        [DataMember, NotMapped]
        public string EmacsGroup4
        {
            get => _emacsGroup4;
            set => SetProperty(ref _emacsGroup4, value);
        }
        private string _emacsGroup5;
        [DataMember, NotMapped]
        public string EmacsGroup5
        {
            get => _emacsGroup5;
            set => SetProperty(ref _emacsGroup5, value);
        }
        private string _emacsGroup6;
        [DataMember, NotMapped]
        public string EmacsGroup6
        {
            get => _emacsGroup6;
            set => SetProperty(ref _emacsGroup6, value);
        }
        private string _emacsGroup7;
        [DataMember, NotMapped]
        public string EmacsGroup7
        {
            get => _emacsGroup7;
            set => SetProperty(ref _emacsGroup7, value);
        }
        private string _emacsGroup8;
        [DataMember, NotMapped]
        public string EmacsGroup8 {
            get => _emacsGroup8;
            set => SetProperty(ref _emacsGroup8, value);
        }
        private string _emacsColourCode;
        [DataMember, NotMapped]
        public string EmacsColourCode
        {
            get => _emacsColourCode;
            set => SetProperty(ref _emacsColourCode, value);
        }
        private string _emacsOldPartCode1;
        [DataMember, NotMapped]
        public string EmacsOldPartCode1
        {
            get => _emacsOldPartCode1;
            set => SetProperty(ref _emacsOldPartCode1, value);
        }
        private string _emacsPartCode1;
        [DataMember, NotMapped]
        public string EmacsPartCode1
        {
            get => _emacsPartCode1;
            set => SetProperty(ref _emacsPartCode1, value);
        }
        private string _emacsOldPartCode2;
        [DataMember, NotMapped]
        public string EmacsOldPartCode2
        {
            get => _emacsOldPartCode2;
            set => SetProperty(ref _emacsOldPartCode2, value);
        }
        private string _emacsPartCode2;
        [DataMember, NotMapped]
        public string EmacsPartCode2
        {
            get => _emacsPartCode2;
            set => SetProperty(ref _emacsPartCode2, value);
        }
        private string _emacsPartCategoryCode;
        [DataMember, NotMapped]
        public string EmacsPartCategoryCode
        {
            get => _emacsPartCategoryCode;
            set => SetProperty(ref _emacsPartCategoryCode, value);
        }
        private string _emacsMaterial1;
        [DataMember, NotMapped]
        public string EmacsMaterial1
        {
            get => _emacsMaterial1;
            set => SetProperty(ref _emacsMaterial1, value);
        }
        private string _emacsMaterial2;
        [DataMember, NotMapped]
        public string EmacsMaterial2
        {
            get => _emacsMaterial2;
            set => SetProperty(ref _emacsMaterial2, value);
        }
        private decimal? _emacInsideDiameter;
        [DataMember, NotMapped]
        public decimal? EmacsInsideDiameter
        {
            get => _emacInsideDiameter;
            set => SetProperty(ref _emacInsideDiameter, value);
        }
        private decimal? _emacsWallThickness;
        [DataMember, NotMapped]
        public decimal? EmacsWallThickness
        {
            get => _emacsWallThickness;
            set => SetProperty(ref _emacsWallThickness, value);
        }
        private short? _emacsNumberOfCavity;
        [DataMember, NotMapped]
        public short? EmacsNumberOfCavity
        {
            get => _emacsNumberOfCavity;
            set => SetProperty(ref _emacsNumberOfCavity, value);
        }
        private decimal? _emacsLength;
        [DataMember, NotMapped]
        public decimal? EmacsLength
        {
            get => _emacsLength;
            set => SetProperty(ref _emacsLength, value);
        }
        private decimal? _emacsWidithOrOutsideDiameter;
        [DataMember, NotMapped]
        public decimal? EmacsWidithOrOutsideDiameter
        {
            get => _emacsWidithOrOutsideDiameter;
            set => SetProperty(ref _emacsWidithOrOutsideDiameter, value);
        }
        private short? _emacsHoleDiameter;
        [DataMember, NotMapped]
        public short? EmacsHoleDiameter
        {
            get => _emacsHoleDiameter;
            set => SetProperty(ref _emacsHoleDiameter, value);
        }
        private short? _emacsL1;
        [DataMember, NotMapped]
        public short? EmacsL1
        {
            get => _emacsL1;
            set => SetProperty(ref _emacsL1, value);
        }
        private short? _emacsL2;
        [DataMember, NotMapped]
        public short? EmacsL2
        {
            get => _emacsL2;
            set => SetProperty(ref _emacsL2, value);
        }
        private short? _emacsL3;
        [DataMember, NotMapped]
        public short? EmacsL3
        {
            get => _emacsL3;
            set => SetProperty(ref _emacsL3, value);
        }
        private short? _emacsShrinkRateLength;
        [DataMember, NotMapped]
        public short? EmacsShrinkRateLength
        {
            get => _emacsShrinkRateLength;
            set => SetProperty(ref _emacsShrinkRateLength, value);
        }
        private short? _emacsNumberOfTappingSpots;
        [DataMember, NotMapped]
        public short? EmacsNumberOfTappingSpots
        {
            get => _emacsNumberOfTappingSpots;
            set => SetProperty(ref _emacsNumberOfTappingSpots, value);
        }
        private string _emacsUoM;
        [DataMember, NotMapped]
        public string EmacsUoM
        {
            get => _emacsUoM;
            set => SetProperty(ref _emacsUoM, value);
        }
        private decimal? _emacsQuainty;
        [DataMember, NotMapped]
        public decimal? EmacsQuainty
        {
            get => _emacsQuainty;
            set => SetProperty(ref _emacsQuainty, value);
        }
        private decimal? _emacsMassOrWeight;
        [DataMember, NotMapped]
        public decimal? EmacsMassOrWeight
        {
            get => _emacsMassOrWeight;
            set => SetProperty(ref _emacsMassOrWeight, value);
        }
        private decimal? _emacsMassOrWeight2;
        [DataMember, NotMapped]
        public decimal? EmacsMassOrWeight2
        {
            get => _emacsMassOrWeight2;
            set => SetProperty(ref _emacsMassOrWeight2, value);
        }
        private decimal? _emacsPitchWidth;
        [DataMember, NotMapped]
        public decimal? EmacsPitchWidth
        {
            get => _emacsPitchWidth;
            set => SetProperty(ref _emacsPitchWidth, value);
        }
        private decimal? _emacsTilt;
        [DataMember, NotMapped]
        public decimal? EmacsTilt
        {
            get => _emacsTilt;
            set => SetProperty(ref _emacsTilt, value);
        }
        private decimal? _emacsGrease;
        [DataMember, NotMapped]
        public decimal? EmacsGrease
        {
            get => _emacsGrease;
            set => SetProperty(ref _emacsGrease, value);
        }
        //CPD og
        private string _cpdOgMaterialNumber;
        [DataMember, NotMapped]
        public string CpdOgMaterialNumber
        {
            get => _cpdOgMaterialNumber;
            set => SetProperty(ref _cpdOgMaterialNumber, value);
        }
        private string _cpdOgSupplierCode;
        [DataMember, NotMapped]
        public string CpdOgSupplierCode
        {
            get => _cpdOgSupplierCode;
            set => SetProperty(ref _cpdOgSupplierCode, value);
        }
        private string _cpdOgSiteCode;
        [DataMember, NotMapped]
        public string CpdOgSiteCode
        {
            get => _cpdOgSiteCode;
            set => SetProperty(ref _cpdOgSiteCode, value);
        }
        private DateTime? _cpdOgExpiryDate;
        [DataMember, NotMapped]
        public DateTime? CpdOgExpiryDate
        {
            get => _cpdOgExpiryDate;
            set => SetProperty(ref _cpdOgExpiryDate, value);
        }
        private string _cpdOgSupplierMaterialNumber;
        [DataMember, NotMapped]
        public string CpdOgSupplierMaterialNumber
        {
            get => _cpdOgSupplierMaterialNumber;
            set => SetProperty(ref _cpdOgSupplierMaterialNumber, value);
        }
        private decimal? _cpdOgPOPrice;
        [DataMember, NotMapped]
        public decimal? CpdOgPOPrice
        {
            get => _cpdOgPOPrice;
            set => SetProperty(ref _cpdOgPOPrice, value);
        }
        private string _cpdOgCurrencyCode;
        [DataMember, NotMapped]
        public string CpdOgCurrencyCode
        {
            get => _cpdOgCurrencyCode;
            set => SetProperty(ref _cpdOgCurrencyCode, value);
        }
        private string _cpdOgMRPDemand;
        [DataMember, NotMapped]
        public string CpdOgMRPDemand
        {
            get => _cpdOgMRPDemand;
            set => SetProperty(ref _cpdOgMRPDemand, value);
        }

        //CPD Sup
        private string _cpdSupMaterialNumber;
        [DataMember, NotMapped]
        public string CpdSupMaterialNumber
        {
            get => _cpdSupMaterialNumber;
            set => SetProperty(ref _cpdSupMaterialNumber, value);
        }
        private string _cpdSupSupplierCode;
        [DataMember, NotMapped]
        public string CpdSupSupplierCode
        {
            get => _cpdSupSupplierCode;
            set => SetProperty(ref _cpdSupSupplierCode, value);
        }
        private string _cpdSupPOUnit;
        [DataMember, NotMapped]
        public string CpdSupPOUnit
        {
            get => _cpdSupPOUnit;
            set => SetProperty(ref _cpdSupPOUnit, value);
        }
        private int? _cpdSupPOMinimumOrderQuantity;
        [DataMember, NotMapped]
        public int? CpdSupPOMinimumOrderQuantity
        {
            get => _cpdSupPOMinimumOrderQuantity;
            set => SetProperty(ref _cpdSupPOMinimumOrderQuantity, value);
        }
        private decimal? _cpdSupPOPrice;
        [DataMember, NotMapped]
        public decimal? CpdSupPOPrice
        {
            get => _cpdSupPOPrice;
            set => SetProperty(ref _cpdSupPOPrice, value);
        }
        private byte? _cpdSupPORatio;
        [DataMember, NotMapped]
        public byte? CpdSupPORatio
        {
            get => _cpdSupPORatio;
            set => SetProperty(ref _cpdSupPORatio, value);
        }
        private string _cpdSupSupplierMaterialNumber;
        [DataMember, NotMapped]
        public string CpdSupSupplierMaterialNumber
        {
            get => _cpdSupSupplierMaterialNumber;
            set => SetProperty(ref _cpdSupSupplierMaterialNumber, value);
        }
        private string _cpdSupSupplierMaterialName;
        [DataMember, NotMapped]
        public string CpdSupSupplierMaterialName
        {
            get => _cpdSupSupplierMaterialName;
            set => SetProperty(ref _cpdSupSupplierMaterialName, value);
        }
        private DateTime? _cpdSupEntryDate;
        [DataMember, NotMapped]
        public DateTime? CpdSupEntryDate
        {
            get => _cpdSupEntryDate;
            set => SetProperty(ref _cpdSupEntryDate, value);
        }
        private DateTime? _cpdSupUpdateDate;
        [DataMember, NotMapped]
        public DateTime? CpdSupUpdateDate
        {
            get => _cpdSupUpdateDate;
            set => SetProperty(ref _cpdSupUpdateDate, value);
        }

        //NPA
        private string _npaID;
        [DataMember, NotMapped]
        public string NPAId
        {
            get => _npaID;
            set => SetProperty(ref _npaID, value);
        }
        private long? _npaSubsidiaryId;
        [DataMember, NotMapped]
        public long? NpaSubsidiaryId
        {
            get => _npaSubsidiaryId;
            set => SetProperty(ref _npaSubsidiaryId, value);
        }
        private string _npaReferenceNumber;
        [DataMember, NotMapped]
        public string NpaReferenceNumber
        {
            get => _npaReferenceNumber;
            set => SetProperty(ref _npaReferenceNumber, value);
        }
        private int? _npaType;
        [DataMember, NotMapped]
        public int? NpaType
        {
            get => _npaType;
            set => SetProperty(ref _npaType, value);
        }
        private DateTime? _npaRaisedDate;
        [DataMember, NotMapped]
        public DateTime? NpaRaisedDate
        {
            get => _npaRaisedDate;
            set => SetProperty(ref _npaRaisedDate, value);
        }
        private long? _npaUserId;
        [DataMember, NotMapped]
        public long? NpaUserId
        {
            get => _npaUserId;
            set => SetProperty(ref _npaUserId, value);
        }
        private int? _npaStatus;
        [DataMember, NotMapped]
        public int? NpaStatus
        {
            get => _npaStatus;
            set => SetProperty(ref _npaStatus, value);
        }
        private string _npaDescription;
        [DataMember, NotMapped]
        public string NpaDescription
        {
            get => _npaDescription;
            set => SetProperty(ref _npaDescription, value);
        }
        private long? _npaProjectId;
        [DataMember, NotMapped]
        public long? NpaProjectId
        {
            get => _npaProjectId;
            set => SetProperty(ref _npaProjectId, value);
        }
        private long? _npaSuggestedSupplierId;
        [DataMember, NotMapped]
        public long? NpaSuggestedSupplierId
        {
            get => _npaSuggestedSupplierId;
            set => SetProperty(ref _npaSuggestedSupplierId, value);
        }
        private string _npaReplacedPart;
        [DataMember, NotMapped]
        public string NpaReplacedPart
        {
            get => _npaReplacedPart;
            set => SetProperty(ref _npaReplacedPart, value);
        }
        private long? _npaCustomerId;
        [DataMember, NotMapped]
        public long? NpaCustomerId
        {
            get => _npaCustomerId;
            set => SetProperty(ref _npaCustomerId, value);
        }
        private string _npaSupplierNumber;
        [DataMember, NotMapped]
        public string NpaSupplierNumber
        {
            get => _npaSupplierNumber;
            set => SetProperty(ref _npaSupplierNumber, value);
        }
        private string _npaAssemblyNumber;
        [DataMember, NotMapped]
        public string NpaAssemblyNumber
        {
            get => _npaAssemblyNumber;
            set => SetProperty(ref _npaAssemblyNumber, value);
        }
        private string _npaCustomerNumber;
        [DataMember, NotMapped]
        public string NpaCustomerNumber
        {
            get => _npaCustomerNumber;
            set => SetProperty(ref _npaCustomerNumber, value);
        }
        private string _npaUnitOfMeasure;
        [DataMember, NotMapped]
        public string NpaUnitOfMeasure
        {
            get => _npaUnitOfMeasure;
            set => SetProperty(ref _npaUnitOfMeasure, value);
        }
        private double? _npaQuantityPerVehicle;
        [DataMember, NotMapped]
        public double? NpaQuantityPerVehicle
        {
            get => _npaQuantityPerVehicle;
            set => SetProperty(ref _npaQuantityPerVehicle, value);
        }
        private string _npaEngineeringComments;
        [DataMember, NotMapped]
        public string NpaEngineeringComments
        {
            get => _npaEngineeringComments;
            set => SetProperty(ref _npaEngineeringComments, value);
        }
        private DateTime? _npaRFQRequiredDate;
        [DataMember, NotMapped]
        public DateTime? NpaRFQRequiredDate
        {
            get => _npaRFQRequiredDate;
            set => SetProperty(ref _npaRFQRequiredDate, value);
        }
        private DateTime? _npaOrderedDate;
        [DataMember, NotMapped]
        public DateTime? NpaOrderedDate
        {
            get => _npaOrderedDate;
            set => SetProperty(ref _npaOrderedDate, value);
        }
        private string _npaOrderedBy;
        [DataMember, NotMapped]
        public string NpaOrderedBy
        {
            get => _npaOrderedBy;
            set => SetProperty(ref _npaOrderedBy, value);
        }
        private DateTime? _npaDeliveryPromiseDate;
        [DataMember, NotMapped]
        public DateTime? NpaDeliveryPromiseDate
        {
            get => _npaDeliveryPromiseDate;
            set => SetProperty(ref _npaDeliveryPromiseDate, value);
        }
        private DateTime? _npaQuotationDate;
        [DataMember, NotMapped]
        public DateTime? NpaQuotationDate
        {
            get => _npaQuotationDate;
            set => SetProperty(ref _npaQuotationDate, value);
        }
        private string _npaCountryOfOrigin;
        [DataMember, NotMapped]
        public string NpaCountryOfOrigin
        {
            get => _npaCountryOfOrigin;
            set => SetProperty(ref _npaCountryOfOrigin, value);
        }
        private string _npaSpecialDelivery;
        [DataMember, NotMapped]
        public string NpaSpecialDelivery
        {
            get => _npaSpecialDelivery;
            set => SetProperty(ref _npaSpecialDelivery, value);
        }
        private string _npaPurchaseOrderNumber;
        [DataMember, NotMapped]
        public string NpaPurchaseOrderNumber
        {
            get => _npaPurchaseOrderNumber;
            set => SetProperty(ref _npaPurchaseOrderNumber, value);
        }
        private decimal? _npaPrice;
        [DataMember, NotMapped]
        public decimal? NpaPrice
        {
            get => _npaPrice;
            set => SetProperty(ref _npaPrice, value);
        }
        private string _npaCurrency;
        [DataMember, NotMapped]
        public string NpaCurrency
        {
            get => _npaCurrency;
            set => SetProperty(ref _npaCurrency, value);
        }
        private int? _npaStandardLeadTime;
        [DataMember, NotMapped]
        public int? NpaStandardLeadTime
        {
            get => _npaStandardLeadTime;
            set => SetProperty(ref _npaStandardLeadTime, value);
        }
        private string _npaTariffCode;
        [DataMember, NotMapped]
        public string NpaTariffCode
        {
            get => _npaTariffCode;
            set => SetProperty(ref _npaTariffCode, value);
        }
        private string _npaPurchaseUnitOfMeasure;
        [DataMember, NotMapped]
        public string NpaPurchaseUnitOfMeasure
        {
            get => _npaPurchaseUnitOfMeasure;
            set => SetProperty(ref _npaPurchaseUnitOfMeasure, value);
    }
        private int? _npaMinimumOrderQuantity;
        [DataMember, NotMapped]
        public int? NpaMinimumOrderQuantity
        {
            get => _npaMinimumOrderQuantity;
            set => SetProperty(ref _npaMinimumOrderQuantity, value);
        }
        private int? _npaBagQuantity;
        [DataMember, NotMapped]
        public int? NpaBagQuantity
        {
            get => _npaBagQuantity;
            set => SetProperty(ref _npaBagQuantity, value);
        }
        private string _npaPurchasingComments;
        [DataMember, NotMapped]
        public string NpaPurchasingComments
        {
            get => _npaPurchasingComments;
            set => SetProperty(ref _npaPurchasingComments, value);
        }
        private string _npaActualSupplierId;
        [DataMember, NotMapped]
        public string NpaActualSupplierId
        {
            get => _npaActualSupplierId;
            set => SetProperty(ref _npaActualSupplierId, value);
        }
        private int? _npaMaterialType;
        [DataMember, NotMapped]
        public int? NpaMaterialType
        {
            get => _npaMaterialType;
            set => SetProperty(ref _npaMaterialType, value);
        }
        private int? _npaConfacPurchaseOrder;
        [DataMember, NotMapped]
        public int? NpaConfacPurchaseOrder
        {
            get => _npaConfacPurchaseOrder;
            set => SetProperty(ref _npaConfacPurchaseOrder, value);
        }
        private string _npaOriginStatus;
        [DataMember, NotMapped]
        public string NpaOriginStatus
        {
            get => _npaOriginStatus;
            set => SetProperty(ref _npaOriginStatus, value);
        }
        private DateTime? _npaExpiryDate;
        [DataMember, NotMapped]
        public DateTime? NpaExpiryDate
        {
            get => _npaExpiryDate;
            set => SetProperty(ref _npaExpiryDate, value);
        }
        private double? _npaCopperWeight;
        [DataMember, NotMapped]
        public double? NpaCopperWeight
        {
            get => _npaCopperWeight;
            set => SetProperty(ref _npaCopperWeight, value);
        }
        private string _npaSupportCentre;
        [DataMember, NotMapped]
        public string NpaSupportCentre
        {
            get => _npaSupportCentre;
            set => SetProperty(ref _npaSupportCentre, value);
        }

        private string _npaEnquiryReference;
        [DataMember, NotMapped]
        public string NpaEnquiryReference
        {
            get => _npaEnquiryReference;
            set => SetProperty(ref _npaEnquiryReference, value);
        }
        private DateTime? _npaEnquiryDate;
        [DataMember, NotMapped]
        public DateTime? NpaEnquiryDate
        {
            get => _npaEnquiryDate;
            set => SetProperty(ref _npaEnquiryDate, value);
        }
        private int? _npaPPAPRequestLevel;
        [DataMember, NotMapped]
        public int? NpaPPAPRequestLevel
        {
            get => _npaPPAPRequestLevel;
            set => SetProperty(ref _npaPPAPRequestLevel, value);
        }
        private string _npaReqQualDoc;
        [DataMember, NotMapped]
        public string NpaReqQualDoc
        {
            get => _npaReqQualDoc;
            set => SetProperty(ref _npaReqQualDoc, value);
        }
        private string _npaAirFreightReference;
        [DataMember, NotMapped]
        public string NpaAirFreightReference
        {
            get => _npaAirFreightReference;
            set => SetProperty(ref _npaAirFreightReference, value);
        }
        private decimal? _npaCopperRate;
        [DataMember, NotMapped]
        public decimal? NpaCopperRate
        {
            get => _npaCopperRate;
            set => SetProperty(ref _npaCopperRate, value);
        }
        private decimal? _npaStandardBoxLength;
        [DataMember, NotMapped]
        public decimal? NpaStandardBoxLength
        {
            get => _npaStandardBoxLength;
            set => SetProperty(ref _npaStandardBoxLength, value);
        }
        private decimal? _npaHeight;
        [DataMember, NotMapped]
        public decimal? NpaHeight
        {
            get => _npaHeight;
            set => SetProperty(ref _npaHeight, value);
        }
        private decimal? _npaWidth;
        [DataMember, NotMapped]
        public decimal? NpaWidth
        {
            get => _npaWidth;
            set => SetProperty(ref _npaWidth, value);
        }
        private int? _npaPackFactor;
        [DataMember, NotMapped]
        public int? NpaPackFactor
        {
            get => _npaPackFactor;
            set => SetProperty(ref _npaPackFactor, value);
        }
        private bool? _npaPPAP;
        [DataMember, NotMapped]
        public bool? NpaPPAP
        {
            get => _npaPPAP;
            set => SetProperty(ref _npaPPAP, value);
        }
        private bool? _npaStatusOne;
        [DataMember, NotMapped]
        public bool? NpaStatusOne
        {
            get => _npaStatusOne;
            set => SetProperty(ref _npaStatusOne, value);
        }
        private string _npaName;
        [DataMember, NotMapped]
        public string NpaName
        {
            get => _npaName;
            set => SetProperty(ref _npaName, value);
        }
        private string _npaFacilityName;
        [DataMember, NotMapped]
        public string NpaFacilityName
        {
            get => _npaFacilityName;
            set => SetProperty(ref _npaFacilityName, value);
        }
        private decimal? _npaFullBoxWeight;
        [DataMember, NotMapped]
        public decimal? NpaFullBoxWeight
        {
            get => _npaFullBoxWeight;
            set => SetProperty(ref _npaFullBoxWeight, value);
        }
        private DateTime? _npaOfferDate;
        [DataMember, NotMapped]
        public DateTime? NpaOfferDate
        {
            get => _npaOfferDate;
            set => SetProperty(ref _npaOfferDate, value);
        }
        private string _npaRaisedByCSLC;
        [DataMember, NotMapped]
        public string NpaRaisedByCSLC
        {
            get => _npaRaisedByCSLC;
            set => SetProperty(ref _npaRaisedByCSLC, value);
        }
        private decimal? _npaUnitOfMeasureWeight;
        [DataMember, NotMapped]
        public decimal? NpaUnitOfMeasureWeight
        {
            get => _npaUnitOfMeasureWeight;
            set => SetProperty(ref _npaUnitOfMeasureWeight, value);
        }
        private bool? _npaDevelopmentPart;
        [DataMember, NotMapped]
        public bool? NpaDevelopmentPart
        {
            get => _npaDevelopmentPart;
            set => SetProperty(ref _npaDevelopmentPart, value);
        }
        private string _npaEngineerName;
        [DataMember, NotMapped]
        public string NpaEngineerName
        {
            get => _npaEngineerName;
            set => SetProperty(ref _npaEngineerName, value);
        }
        public Uri Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }
        private Uri _image;
    }
}
