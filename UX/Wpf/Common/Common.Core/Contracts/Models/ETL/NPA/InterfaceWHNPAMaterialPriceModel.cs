using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.NPA
{
    [DataContract, Serializable]
    public class InterfaceWHNPAMaterialPriceModel : BindableBaseEntity, IEntity<long>
    {
        private long _id;
        [DataMember, Key]
        public long Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        object IEntity.Id
        {
            get => Id;
            set => Id = (long)Convert.ChangeType(value, typeof(long));
        }

        private long? _npaId;
        [DataMember]
        public long? NPAId
        {
            get => _npaId;
            set => SetProperty(ref _npaId, value);
        }

        private long? _subsidiaryId;
        [DataMember]
        public long? SubsidiaryId
        {
            get => _subsidiaryId;
            set => SetProperty(ref _subsidiaryId, value);
        }

        private string _referenceNumber;
        [DataMember]
        public string ReferenceNumber
        {
            get => _referenceNumber;
            set => SetProperty(ref _referenceNumber, value);
        }

        private int? _type;
        [DataMember]
        public int? Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        private DateTime? _raisedDate;
        [DataMember]
        public DateTime? RaisedDate
        {
            get => _raisedDate;
            set => SetProperty(ref _raisedDate, value);
        }

        private long? _userId;
        [DataMember]
        public long? UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private int? _status;
        [DataMember]
        public int? Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        private string _sumitomoNumber;
        [DataMember]
        public string SumitomoNumber
        {
            get => _sumitomoNumber;
            set => SetProperty(ref _sumitomoNumber, value);
        }

        private string _description;
        [DataMember]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private long? _projectId;
        [DataMember]
        public long? ProjectId
        {
            get => _projectId;
            set => SetProperty(ref _projectId, value);
        }

        private long? _suggestedSupplierId;
        [DataMember]
        public long? SuggestedSupplierId
        {
            get => _suggestedSupplierId;
            set => SetProperty(ref _suggestedSupplierId, value);
        }

        private string _replacedPart;
        [DataMember]
        public string ReplacedPart
        {
            get => _replacedPart;
            set => SetProperty(ref _replacedPart, value);
        }

        private long? _customerId;
        [DataMember]
        public long? CustomerId
        {
            get => _customerId;
            set => SetProperty(ref _customerId, value);
        }

        private string _supplierNumber;
        [DataMember]
        public string SupplierNumber
        {
            get => _supplierNumber;
            set => SetProperty(ref _supplierNumber, value);
        }

        private string _assemblyNumber;
        [DataMember]
        public string AssemblyNumber
        {
            get => _assemblyNumber;
            set => SetProperty(ref _assemblyNumber, value);
        }

        private string _customerNumber;
        [DataMember]
        public string CustomerNumber
        {
            get => _customerNumber;
            set => SetProperty(ref _customerNumber, value);
        }

        private string _unitOfMeasure;
        [DataMember]
        public string UnitOfMeasure
        {
            get => _unitOfMeasure;
            set => SetProperty(ref _unitOfMeasure, value);
        }

        private double? _quantityPerVehicle;
        [DataMember]
        public double? QuantityPerVehicle
        {
            get => _quantityPerVehicle;
            set => SetProperty(ref _quantityPerVehicle, value);
        }

        private string _engineeringComments;
        [DataMember]
        public string EngineeringComments
        {
            get => _engineeringComments;
            set => SetProperty(ref _engineeringComments, value);
        }

        private DateTime? _rfqRequiredDate;
        [DataMember]
        public DateTime? RFQRequiredDate
        {
            get => _rfqRequiredDate;
            set => SetProperty(ref _rfqRequiredDate, value);
        }

        private DateTime? _orderedDate;
        [DataMember]
        public DateTime? OrderedDate
        {
            get => _orderedDate;
            set => SetProperty(ref _orderedDate, value);
        }

        private string _orderedBy;
        [DataMember]
        public string OrderedBy
        {
            get => _orderedBy;
            set => SetProperty(ref _orderedBy, value);
        }

        private DateTime? _deliveryPromiseDate;
        [DataMember]
        public DateTime? DeliveryPromiseDate
        {
            get => _deliveryPromiseDate;
            set => SetProperty(ref _deliveryPromiseDate, value);
        }

        private DateTime? _quotationDate;
        [DataMember]
        public DateTime? QuotationDate
        {
            get => _quotationDate;
            set => SetProperty(ref _quotationDate, value);
        }

        private string _countryOfOrigin;
        [DataMember]
        public string CountryOfOrigin
        {
            get => _countryOfOrigin;
            set => SetProperty(ref _countryOfOrigin, value);
        }

        private string _specialDelivery;
        [DataMember]
        public string SpecialDelivery
        {
            get => _specialDelivery;
            set => SetProperty(ref _specialDelivery, value);
        }

        private string _purchaseOrderNumber;
        [DataMember]
        public string PurchaseOrderNumber
        {
            get => _purchaseOrderNumber;
            set => SetProperty(ref _purchaseOrderNumber, value);
        }

        private double? _price;
        [DataMember]
        public double? Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private string _currency;
        [DataMember]
        public string Currency
        {
            get => _currency;
            set => SetProperty(ref _currency, value);
        }

        private int? _standardLeadTime;
        [DataMember]
        public int? StandardLeadTime
        {
            get => _standardLeadTime;
            set => SetProperty(ref _standardLeadTime, value);
        }

        private string _tariffCode;
        [DataMember]
        public string TariffCode
        {
            get => _tariffCode;
            set => SetProperty(ref _tariffCode, value);
        }

        private string _purchaseUnitOfMeasure;
        [DataMember]
        public string PurchaseUnitOfMeasure
        {
            get => _purchaseUnitOfMeasure;
            set => SetProperty(ref _purchaseUnitOfMeasure, value);
        }

        private int? _minimumOrderQuantity;
        [DataMember]
        public int? MinimumOrderQuantity
        {
            get => _minimumOrderQuantity;
            set => SetProperty(ref _minimumOrderQuantity, value);
        }

        private int? _bagQuantity;
        [DataMember]
        public int? BagQuantity
        {
            get => _bagQuantity;
            set => SetProperty(ref _bagQuantity, value);
        }

        private string _purchasingComments;
        [DataMember]
        public string PurchasingComments
        {
            get => _purchasingComments;
            set => SetProperty(ref _purchasingComments, value);
        }

        private long? _actualSupplierId;
        [DataMember]
        public long? ActualSupplierId
        {
            get => _actualSupplierId;
            set => SetProperty(ref _actualSupplierId, value);
        }

        private int? _materialType;
        [DataMember]
        public int? MaterialType
        {
            get => _materialType;
            set => SetProperty(ref _materialType, value);
        }

        private int? _confacPurchaseOrder;
        [DataMember]
        public int? ConfacPurchaseOrder
        {
            get => _confacPurchaseOrder;
            set => SetProperty(ref _confacPurchaseOrder, value);
        }

        private string _originStatus;
        [DataMember]
        public string OriginStatus
        {
            get => _originStatus;
            set => SetProperty(ref _originStatus, value);
        }

        private DateTime? _expiryDate;
        [DataMember]
        public DateTime? ExpiryDate
        {
            get => _expiryDate;
            set => SetProperty(ref _expiryDate, value);
        }

        private double? _copperWeight;
        [DataMember]
        public double? CopperWeight
        {
            get => _copperWeight;
            set => SetProperty(ref _copperWeight, value);
        }

        private string _supportCentre;
        [DataMember]
        public string SupportCentre
        {
            get => _supportCentre;
            set => SetProperty(ref _supportCentre, value);
        }

        private string _enquiryReference;
        [DataMember]
        public string EnquiryReference
        {
            get => _enquiryReference;
            set => SetProperty(ref _enquiryReference, value);
        }

        private DateTime? _enquiryDate;
        [DataMember]
        public DateTime? EnquiryDate
        {
            get => _enquiryDate;
            set => SetProperty(ref _enquiryDate, value);
        }

        private int? _ppapRequestLevel;
        [DataMember]
        public int? PPAPRequestLevel
        {
            get => _ppapRequestLevel;
            set => SetProperty(ref _ppapRequestLevel, value);
        }

        private string _reqQualDoc;
        [DataMember]
        public string ReqQualDoc
        {
            get => _reqQualDoc;
            set => SetProperty(ref _reqQualDoc, value);
        }

        private string _airFreightReference;
        [DataMember]
        public string AirFreightReference
        {
            get => _airFreightReference;
            set => SetProperty(ref _airFreightReference, value);
        }

        private decimal? _copperRate;
        [DataMember]
        public decimal? CopperRate
        {
            get => _copperRate;
            set => SetProperty(ref _copperRate, value);
        }

        private decimal? _standardBoxLength;
        [DataMember]
        public decimal? StandardBoxLength
        {
            get => _standardBoxLength;
            set => SetProperty(ref _standardBoxLength, value);
        }

        private decimal? _height;
        [DataMember]
        public decimal? Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        private decimal? _width;
        [DataMember]
        public decimal? Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        private int? _packFactor;
        [DataMember]
        public int? PackFactor
        {
            get => _packFactor;
            set => SetProperty(ref _packFactor, value);
        }

        private bool? _ppap;
        [DataMember]
        public bool? PPAP
        {
            get => _ppap;
            set => SetProperty(ref _ppap, value);
        }

        private bool? _statusOne;
        [DataMember]
        public bool? StatusOne
        {
            get => _statusOne;
            set => SetProperty(ref _statusOne, value);
        }

        private string _name;
        [DataMember]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _facilityName;
        [DataMember]
        public string FacilityName
        {
            get => _facilityName;
            set => SetProperty(ref _facilityName, value);
        }

        private decimal? _fullBoxWeight;
        [DataMember]
        public decimal? FullBoxWeight
        {
            get => _fullBoxWeight;
            set => SetProperty(ref _fullBoxWeight, value);
        }

        private DateTime? _offerDate;
        [DataMember]
        public DateTime? OfferDate
        {
            get => _offerDate;
            set => SetProperty(ref _offerDate, value);
        }

        private string _raisedByCSLC;
        [DataMember]
        public string RaisedByCSLC
        {
            get => _raisedByCSLC;
            set => SetProperty(ref _raisedByCSLC, value);
        }

        private decimal? _unitOfMeasureWeight;
        [DataMember]
        public decimal? UnitOfMeasureWeight
        {
            get => _unitOfMeasureWeight;
            set => SetProperty(ref _unitOfMeasureWeight, value);
        }

        private bool? _developmentPart;
        [DataMember]
        public bool? DevelopmentPart
        {
            get => _developmentPart;
            set => SetProperty(ref _developmentPart, value);
        }

        private string _engineerName;
        [DataMember]
        public string EngineerName
        {
            get => _engineerName;
            set => SetProperty(ref _engineerName, value);
        }

        [NotMapped]
        public DateTime CreatedDate { get; set; }
        [NotMapped]
        public DateTime? ModifiedDate { get; set; }
        [NotMapped]
        public Guid CreatedBy { get; set; }
        [NotMapped]
        public Guid ModifiedBy { get; set; }
        [NotMapped]
        public byte[] Version { get; set; }
    }
}
