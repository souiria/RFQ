using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Engineering
{
    [DataContract, Serializable]
    public class NewPartsAuthorizationModel : BaseModel<Guid>
    {
        private Guid _purchasingOrganisationGuid;
        [DataMember]
        public Guid PurchasingOrganisationGuid
        {
            get => _purchasingOrganisationGuid;
            set => SetProperty(ref _purchasingOrganisationGuid, value);
        }

        private string _referenceNumber;
        [DataMember]
        [Required]
        [StringLength(20)]
        public string ReferenceNumber
        {
            get => _referenceNumber;
            set => SetProperty(ref _referenceNumber, value);
        }

        private Guid _npaTypeGuid;
        [DataMember]
        public Guid NPATypeGuid
        {
            get => _npaTypeGuid;
            set => SetProperty(ref _npaTypeGuid, value);
        }

        private DateTime _raisedDate;
        [DataMember]
        public DateTime RaiseDate
        {
            get => _raisedDate;
            set => SetProperty(ref _raisedDate, value);
        }

        private Guid _raisedByGuid;
        [DataMember]
        public Guid RaisedByGuid      //It will be filled from H1 User List and user Ad Guid will be saved
        {
            get => _raisedByGuid;
            set => SetProperty(ref _raisedByGuid, value);
        }

        private Guid _npaStatusGuid;
        [DataMember]
        public Guid NPAStatusGuid
        {
            get => _npaStatusGuid;
            set => SetProperty(ref _npaStatusGuid, value);
        }

        private string _sumitomoNumber;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string SumitomoNumber
        {
            get => _sumitomoNumber;
            set => SetProperty(ref _sumitomoNumber, value);
        }

        private string _fullDescription;
        [DataMember]
        [StringLength(100)]
        public string FullDescription
        {
            get => _fullDescription;
            set => SetProperty(ref _fullDescription, value);
        }

        private Guid _projectGuid;
        [DataMember]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => SetProperty(ref _projectGuid, value);
        }

        private Guid _suggestedSupplierGuid;
        [DataMember]
        public Guid SuggestedSupplierGuid
        {
            get => _suggestedSupplierGuid;
            set => SetProperty(ref _suggestedSupplierGuid, value);
        }

        private string _replacementPartNumber;
        [DataMember]
        [StringLength(50)]
        public string ReplacementPartNumber
        {
            get => _replacementPartNumber;
            set => SetProperty(ref _replacementPartNumber, value);
        }

        private Guid _customerGuid;
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }

        private string _supplierPartNumber;
        [DataMember]
        [StringLength(50)]
        public string SupplierPartNumber
        {
            get => _supplierPartNumber;
            set => SetProperty(ref _supplierPartNumber, value);
        }

        private string _assemblyNumber;
        [DataMember]
        [StringLength(50)]
        public string AssemblyNumber
        {
            get => _assemblyNumber;
            set => SetProperty(ref _assemblyNumber, value);
        }

        private string _customerPartNumber;
        [DataMember]
        [StringLength(50)]
        public string CustomerPartNumber
        {
            get => _customerPartNumber;
            set => SetProperty(ref _customerPartNumber, value);
        }

        private Guid _unitOfMeasureGuid;
        [DataMember]
        public Guid UnitOfMeasureGuid
        {
            get => _unitOfMeasureGuid;
            set => SetProperty(ref _unitOfMeasureGuid, value);
        }

        private decimal _quantityPerVehicle;
        [DataMember]
        [DecimalPrecision(10, 5)]
        public decimal QuantityPerVehicle
        {
            get => _quantityPerVehicle;
            set => SetProperty(ref _quantityPerVehicle, value);
        }

        private string _engineeringComments;
        [DataMember]
        [StringLength(100)]
        public string EngineeringComments
        {
            get => _engineeringComments;
            set => SetProperty(ref _engineeringComments, value);
        }

        private DateTime _rfqRequiredDate;
        [DataMember]
        public DateTime RFQRequiredDate
        {
            get => _rfqRequiredDate;
            set => SetProperty(ref _rfqRequiredDate, value);
        }

        private DateTime _orderDate;
        [DataMember]
        public DateTime OrderDate
        {
            get => _orderDate;
            set => SetProperty(ref _orderDate, value);
        }

        private Guid _orderedByGuid;
        [DataMember]
        public Guid OrderedByGuid      //It will be filled from H1 User List and user Ad Guid will be saved
        {
            get => _orderedByGuid;
            set => SetProperty(ref _orderedByGuid, value);
        }

        private DateTime _deliveryPromiseDate;
        [DataMember]
        public DateTime DeliveryPromiseDate
        {
            get => _deliveryPromiseDate;
            set => SetProperty(ref _deliveryPromiseDate, value);
        }

        private DateTime _quotationDate;
        [DataMember]
        public DateTime QuotationDate
        {
            get => _quotationDate;
            set => SetProperty(ref _quotationDate, value);
        }

        private Guid _countryRegionsAssociationGuid;
        [DataMember]
        public Guid CountryRegionsAssociationGuid
        {
            get => _countryRegionsAssociationGuid;
            set => SetProperty(ref _countryRegionsAssociationGuid, value);
        }

        private string _specialDelivery;
        [DataMember]
        [StringLength(100)]
        public string SpecialDelivery
        {
            get => _specialDelivery;
            set => SetProperty(ref _specialDelivery, value);
        }

        private string _poNumber;
        [DataMember]
        [StringLength(50)]
        public string PONumber
        {
            get => _poNumber;
            set => SetProperty(ref _poNumber, value);
        }

        private decimal _poPrice;
        [DataMember]
        [DecimalPrecision(9, 5)]
        public decimal POPrice
        {
            get => _poPrice;
            set => SetProperty(ref _poPrice, value);
        }

        private Guid _currencyGuid;
        [DataMember]
        public Guid CurrencyGuid
        {
            get => _currencyGuid;
            set => SetProperty(ref _currencyGuid, value);
        }

        private int _standardLeadTime;
        [DataMember]
        public int StandardLeadTime
        {
            get => _standardLeadTime;
            set => SetProperty(ref _standardLeadTime, value);
        }

        private Guid _tariffCodeGuid;
        [DataMember]
        public Guid TariffCodeGuid
        {
            get => _tariffCodeGuid;
            set => SetProperty(ref _tariffCodeGuid, value);
        }

        private Guid _purchaseUnitOfMeasureGuid;
        [DataMember]
        public Guid PurchaseUnitOfMeasureGuid
        {
            get => _purchaseUnitOfMeasureGuid;
            set => SetProperty(ref _purchaseUnitOfMeasureGuid, value);
        }

        private int _minimumOrderQuantity;
        [DataMember]
        public int MinimumOrderQuantity
        {
            get => _minimumOrderQuantity;
            set => SetProperty(ref _minimumOrderQuantity, value);
        }

        private int _containerQuantity;
        [DataMember]
        public int ContainerQuantity
        {
            get => _containerQuantity;
            set => SetProperty(ref _containerQuantity, value);
        }

        private string _purchasingComments;
        [DataMember]
        [StringLength(100)]
        public string PurchasingComments
        {
            get => _purchasingComments;
            set => SetProperty(ref _purchasingComments, value);
        }

        private Guid _actualSupplierGuid;
        [DataMember]
        public Guid ActualSupplierGuid
        {
            get => _actualSupplierGuid;
            set => SetProperty(ref _actualSupplierGuid, value);
        }

        private Guid _materialTypeGuid;
        [DataMember]
        public Guid MaterialTypeGuid
        {
            get => _materialTypeGuid;
            set => SetProperty(ref _materialTypeGuid, value);
        }

        private int _poConversionFactor;
        [DataMember]
        public int POConversionFactor
        {
            get => _poConversionFactor;
            set => SetProperty(ref _poConversionFactor, value);
        }

        private DateTime _expiryDate;
        [DataMember]
        public DateTime ExpiryDate
        {
            get => _expiryDate;
            set => SetProperty(ref _expiryDate, value);
        }

        private decimal _metalWeight;
        [DataMember]
        [DecimalPrecision(10, 5)]
        public decimal MetalWeight
        {
            get => _metalWeight;
            set => SetProperty(ref _metalWeight, value);
        }

        private string _supportCentre;
        [DataMember]
        [StringLength(50)]
        public string SupportCentre
        {
            get => _supportCentre;
            set => SetProperty(ref _supportCentre, value);
        }

        private string _enquiryReference;
        [DataMember]
        [StringLength(50)]
        public string EnquiryReference
        {
            get => _enquiryReference;
            set => SetProperty(ref _enquiryReference, value);
        }

        private DateTime _enquiryDate;
        [DataMember]
        public DateTime EnquiryDate
        {
            get => _enquiryDate;
            set => SetProperty(ref _enquiryDate, value);
        }

        private Guid _ppapLevelGuid;
        [DataMember]
        public Guid PPAPLevelGuid
        {
            get => _ppapLevelGuid;
            set => SetProperty(ref _ppapLevelGuid, value);
        }

        private string _requirementQualificationDocument;
        [DataMember]
        [StringLength(100)]
        public string RequirementQualificationDocument
        {
            get => _requirementQualificationDocument;
            set => SetProperty(ref _requirementQualificationDocument, value);
        }

        private string _airFreightReference;
        [DataMember]
        [StringLength(50)]
        public string AirFreightReference
        {
            get => _airFreightReference;
            set => SetProperty(ref _airFreightReference, value);
        }

        private decimal _metalRate;
        [DataMember]
        [DecimalPrecision(10, 5)]
        public decimal MetalRate
        {
            get => _metalRate;
            set => SetProperty(ref _metalRate, value);
        }

        private decimal _standardBoxLength;
        [DataMember]
        [DecimalPrecision(6, 3)]
        public decimal StandardBoxLength
        {
            get => _standardBoxLength;
            set => SetProperty(ref _standardBoxLength, value);
        }

        private decimal _standardBoxHeight;
        [DataMember]
        [DecimalPrecision(6, 3)]
        public decimal StandardBoxHeight
        {
            get => _standardBoxHeight;
            set => SetProperty(ref _standardBoxHeight, value);
        }

        private decimal _standardBoxWidth;
        [DataMember]
        [DecimalPrecision(6, 3)]
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
        [DecimalPrecision(5, 2)]
        public decimal FullBoxWeight
        {
            get => _fullBoxWeight;
            set => SetProperty(ref _fullBoxWeight, value);
        }

        private string _sumitomoName;
        [DataMember]
        [Required]
        [StringLength(15)]
        public string SumitomoName
        {
            get => _sumitomoName;
            set => SetProperty(ref _sumitomoName, value);
        }

        private Guid _facilityGuid;
        [DataMember]
        public Guid FacilityGuid
        {
            get => _facilityGuid;
            set => SetProperty(ref _facilityGuid, value);
        }

        private DateTime _offerDate;
        [DataMember]
        public DateTime OfferDate
        {
            get => _offerDate;
            set => SetProperty(ref _offerDate, value);
        }

        private string _raisedByCSLC;
        [DataMember]
        [StringLength(1)]
        public string RaisedByCSLC
        {
            get => _raisedByCSLC;
            set => SetProperty(ref _raisedByCSLC, value);
        }

        private decimal _unitOfMeasureWeight;
        [DataMember]
        [DecimalPrecision(5, 2)]
        public decimal UnitOfMeasureWeight
        {
            get => _unitOfMeasureWeight;
            set => SetProperty(ref _unitOfMeasureWeight, value);
        }

        private string _developedPart;
        [DataMember]
        [StringLength(1)]
        public string DevelopedPart
        {
            get => _developedPart;
            set => SetProperty(ref _developedPart, value);
        }

        private Guid _engineerNameGuid;
        [DataMember]
        public Guid EngineerNameGuid      //It will be filled from H1 User List and user Ad Guid will be saved
        {
            get => _engineerNameGuid;
            set => SetProperty(ref _engineerNameGuid, value);
        }

        private Guid _reasonGuid;
        [DataMember]
        public Guid ReasonGuid      
        {
            get => _reasonGuid;
            set => SetProperty(ref _reasonGuid, value);
        }

        private Guid _businessUnitGuid;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private decimal _quantity;
        [DataMember]
        [DecimalPrecision(10, 5)]
        public decimal Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        private DateTime _requiredDate;
        [DataMember]
        public DateTime RequiredDate
        {
            get => _requiredDate;
            set => SetProperty(ref _requiredDate, value);
        }

        private Guid _responsiblePersonGuid;
        [DataMember]
        public Guid ResponsiblePersonGuid      //It will be filled from H1 User List and user Ad Guid will be saved
        {
            get => _responsiblePersonGuid;
            set => SetProperty(ref _responsiblePersonGuid, value);
        }

        private Guid _receivingBusinessUnitGuid;
        [DataMember]
        public Guid ReceivingBusinessUnitGuid
        {
            get => _receivingBusinessUnitGuid;
            set => SetProperty(ref _receivingBusinessUnitGuid, value);
        }

        private Guid _receivedStatusGuid;
        [DataMember]
        public Guid ReceivedStatusGuid
        {
            get => _receivedStatusGuid;
            set => SetProperty(ref _receivedStatusGuid, value);
        }
    }
}
