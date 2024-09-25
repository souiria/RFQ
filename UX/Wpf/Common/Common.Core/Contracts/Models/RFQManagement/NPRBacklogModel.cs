/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NPRBacklogModel.cs
Function           :   NPR Backlog Business Model, and Status type
Created By         :   Amit Agarwal
Created on         :   04-Jul-2019
Revision History   :   [05-Sep-2019] : Pawan
                   :   [] : Commented fields NPR Backlog Status and NPR Stage as per demo discussion on 04-Sep-2019 
                   :   [12-Sep-2019] : Pawan
                   :   [] : Added field for BusinessNotWon
                   :   [17-Sep-2019] : Sai Kiran
                   :   [] : Added Mutiple fields as for changes to fixed fields
                   :   [24-Sep-2019] : Sai Kiran
                   :   [] : Added AdditionalComments field
                   :   [27-Sep-2019] : Sai Kiran
                   :   [] : Added field for PO Conversion Factor
                   :   [17-Oct-2019] : Pawan Kumar
                   :   [] : Added field for CapacityConfirmationAtSOP & SOPComments
                   :   [11-Nov-2019] : Pawan Kumar
                   :   [] : Added field for RFQ Issue Date
                   :   [07-Dec-2019] : Sai Kiran
                   :   [] : Added field for Purchasing Supplier Comments
                   :   [06-Jan-2020] : Sai Kiran
                   :   [] : Added field for Supplier Returned Comments                   
                   :   [06-Jan-2020] : Sai Kiran
                   :   [] : Added String Length Attribute for Supplier Returned Comments and Purchasing Supplier Comments
                   :   [30-Mar-2020] : Pawan
                   :   [] : Added field for RFQ Issue Comments    
                   :   [21-Jan-2020] : Shivam Dhingra
                   :   [] : Added field IsCancelledFromNPR
                   :   [29-Apr-2022] : Shivam Dhingra
                   :   [] : Added field BusinessUnitGuid
                   :   [04-May-2022] : Ranjay
                   :   [] : Added field Supplier guid
                   :   [10-May-2022] : Shivam Kalia
                   :   [] : Added field CountryGuid
                   :   [02-Aug-2022] : Ranjay
                   :   [] : Added field CurrencyGuid,IncotermGuid
*                  :   [22-Aug-2022] : Sejal Srivastava
*                  :   [] : Added field PurchaseOrderUnitOfMeasurementGuid
*                  :   [30-Jan-2023] : Ashish Dutta
*                  :   [] : Changes for NPR Screen Performance
                   :   [25-Apr-2023] : Vishwadeep Singh 
                   :   [HD-00376675] : Added class NPRBacklogFilterModel
                   :   [26-Jun-2023] : Ashish Dutta
                   :   [HD-00367280] : Added Property in Npr Backlog
                   :   [27-Jun-2023] : Prakhar
                   :   [HD-00367280] : Added Property in BacklogSupplierPortal
                   :   [28-Jun-2023] : Prakhar
                   :   [HD-00367280] : Added Property in BacklogSupplierPortalFilterModel


****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.NPR;
using Common.Core.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.RFQManagement
{
    ///// <summary>
    ///// Types of NPR Backlog
    ///// </summary>
    //public enum NPRBacklogStatusType
    //{
    //    /// <summary>
    //    /// NPR is submitted to NPR Log
    //    /// </summary>
    //    NPRSubmittedToNPRBacklog,
    //    /// <summary>
    //    /// NPR transfer to Quarantine
    //    /// </summary>
    //    NPRTransferToQuarantine,
    //    /// <summary>
    //    /// RFQ Created 
    //    /// </summary>
    //    RFQCreated,
    //    /// <summary>
    //    /// Email Notification Send
    //    /// </summary>
    //    EmailNotificationSend
    //}
    /// <summary>
    /// Item of NPR Backlog
    /// </summary>
    [DataContract, Serializable]
    public class NPRBacklogModel : BaseModel<Guid>
    {
        /////// <summary>
        /////// Local Reference of {NewPartRequestModel} property
        /////// </summary>
        //private NewPartRequestModel _newPartRequest;

        ///// <summary>
        ///// Gets or Sets the value of {NewPartRequestModel}
        ///// </summary>
        //[DataMember]
        //[Required]
        //public NewPartRequestModel NewPartRequestModel
        //{
        //    get => _newPartRequest;
        //    set => SetProperty(ref _newPartRequest, value);
        //}

        ///// <summary>
        ///// Local status of NPR Backlog Item
        ///// </summary>
        //private NPRBacklogStatusType _nprBacklogStatus = NPRBacklogStatusType.NPRSubmittedToNPRBacklog;
        ///// <summary>
        ///// Status of NPR Backlog Item
        ///// </summary>
        //[DataMember]
        //public NPRBacklogStatusType NPRBacklogStatus
        //{
        //    get => _nprBacklogStatus;
        //    set => SetProperty(ref _nprBacklogStatus, value);
        //}
        //Added By Ashish on 26-Jun-2023

        private string _customerCode;
        /// <summary>
        /// Get or Sets the value of {CustomerCode} of NPR, exp: DENSO , NISSAN
        /// </summary>
        [DataMember]
        [StringLength(100)]
        [Required]
        public string CustomerCode
        {
            get => _customerCode;
            set => SetProperty(ref _customerCode, value);
        }
        /// <summary>
        /// Local Reference of RequestID
        /// </summary>
        private string _requestID;
        /// <summary>
        /// Get or Sets the value of indicating {RequestID} of NPR, exp: NPR0000001 for New Part Request, PUR0000001 for Price Update Request
        /// </summary>
        [DataMember]
        [StringLength(18)]
        [Required]
        public string RequestID
        {
            get => _requestID;
            set => SetProperty(ref _requestID, value);
        }

        /// <summary>
        /// Local reference of when NPR is created.
        /// </summary>
        private DateTime _creationDate;
        /// <summary>
        /// Gets of Sets the value of indicating {CreationDate} of NPR
        /// </summary>
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime CreationDate
        {
            get => _creationDate;
            set => SetProperty(ref _creationDate, value.Date);
        }

        /// <summary>
        /// Local reference of OriginatorName
        /// </summary>
        private string _originatorName;
        /// <summary>
        /// Gets of Sets the value of indicating {Originator} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string OriginatorName
        {
            get => _originatorName;
            set => SetProperty(ref _originatorName, value);
        }

        /// <summary>
        /// Local reference of DeadlineDate
        /// </summary>
        private DateTime _deadlineDate;
        /// <summary>
        /// Gets of Sets the value of indicating {DeadlineDate} of NPR
        /// </summary>
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime DeadlineDate
        {
            get => _deadlineDate;
            set => SetProperty(ref _deadlineDate, value.Date);
        }

        /// <summary>
        /// Local reference of ReasonDescription
        /// </summary>
        private string _reasonDescription;
        /// <summary>
        /// Gets of Sets the value of indicating {ReasonDescription} of NPR , exp : New Business from OEM/Product Distribution/Supplier Tender
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(50)]
        public string ReasonDescription
        {
            get => _reasonDescription;
            set => SetProperty(ref _reasonDescription, value);
        }

        /// <summary>
        /// Local reference of MaterialNumber
        /// </summary>
        private string _materialNumber;
        /// <summary>
        /// Gets of Sets the value of indicating {MaterialNumber} of NPR , also known as Sumitomo Part Number , can be left blank.
        /// </summary>
        [DataMember]
        [StringLength(26)]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => SetProperty(ref _materialNumber, value);
        }

        /// <summary>
        /// Local reference of MaterialDescription
        /// </summary>
        private string _materialDescription;
        /// <summary>
        /// Gets of Sets the value of indicating {MaterialDescription} of NPR
        /// </summary>
        [DataMember]
        [StringLength(15)]
        public string MaterialDescription
        {
            get => _materialDescription;
            set => SetProperty(ref _materialDescription, value);
        }

        /// <summary>
        /// Local reference of MaterialTypeCode
        /// </summary>
        private string _materialTypeCode;
        /// <summary>
        /// Gets of Sets the value of indicating {MaterialTypeCode} of NPR, exp: 1 - Component/2 - Cut Tube/3 - Wire
        /// </summary>
        [DataMember]
        [StringLength(1)]
        [Required]
        public string MaterialTypeCode
        {
            get => _materialTypeCode;
            set => SetProperty(ref _materialTypeCode, value);
        }

        /// <summary>
        /// Local reference of MaterialTypeDescription property
        /// </summary>
        private string _materialTypeDescription;
        /// <summary>
        /// Gets of Sets the value of indicating {MaterialTypeDescription} of NPR, exp: Component/CutTubes/Wire
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string MaterialTypeDescription
        {
            get => _materialTypeDescription;
            set => SetProperty(ref _materialTypeDescription, value);
        }

        /// <summary>
        /// Local reference of CommodityDescription
        /// </summary>
        private string _commodityDescription;
        /// <summary>
        /// Gets of Sets the value of indicating {CommodityDescription} of NPR , exp : BATTERY CABLE , Clamp
        /// </summary>
        [DataMember]
        [StringLength(30)]
        [Required]
        public string CommodityDescription
        {
            get => _commodityDescription;
            set => SetProperty(ref _commodityDescription, value);
        }

        /// <summary>
        /// Local reference of CustomerPartNumber
        /// </summary>
        private string _customerPartNumber;
        /// <summary>
        /// Gets of Sets the value of indicating {CustomerPartNumber} of NPR
        /// </summary>
        [DataMember]
        [StringLength(26)]
        public string CustomerPartNumber
        {
            get => _customerPartNumber;
            set => SetProperty(ref _customerPartNumber, value);
        }

        /// <summary>
        /// Local reference of SupplierPartNumber
        /// </summary>
        private string _supplierPartNumber;
        /// <summary>
        /// Gets of Sets the value of indicating {SupplierPartNumber} of NPR
        /// </summary>
        [DataMember]
        [StringLength(26)]
        [Required]
        public string SupplierPartNumber
        {
            get => _supplierPartNumber;
            set => SetProperty(ref _supplierPartNumber, value);
        }

        /// <summary>
        /// Local reference of BOMUnitOfMeasurement
        /// </summary>
        private string _bomUnitofMeasurement;
        /// <summary>
        /// Gets of Sets the value of indicating {BOMUnitOfMeasurement} of NPR
        /// </summary>
        [DataMember]
        [StringLength(10)]
        [Required]
        public string BOMUnitOfMeasurement
        {
            get => _bomUnitofMeasurement;
            set => SetProperty(ref _bomUnitofMeasurement, value);
        }


        /// <summary>
        /// Local reference of SEWSEUnitOfMeasurement
        /// </summary>
        private string _sewseUnitofMeasurement;
        /// <summary>
        /// Gets of Sets the value of indicating {SEWSEUnitOfMeasurement} of NPR
        /// </summary>
        [DataMember]
        [StringLength(10)]
        [Required]
        public string SEWSEUnitOfMeasurement
        {
            get => _sewseUnitofMeasurement;
            set => SetProperty(ref _sewseUnitofMeasurement, value);
        }

        /// <summary>
        /// Local reference of ManufacturerGroup property
        /// </summary>
        private string _manufacturerGroup;
        /// <summary>
        /// Gets of Sets the value of indicating {ManufacturerGroup} supplier group of NPR , exp : ACAPLAST , SEI
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string ManufacturerGroup
        {
            get => _manufacturerGroup;
            set => SetProperty(ref _manufacturerGroup, value);
        }

        /// <summary>
        /// Local reference of ProjectCode property
        /// </summary>
        private string _projectCode;
        /// <summary>
        /// Gets of Sets the value of indicating {ProjectCode}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ProjectCode
        {
            get => _projectCode;
            set => SetProperty(ref _projectCode, value);
        }


        /// <summary>
        /// Local reference of QtyPerVehicle property
        /// </summary>
        private decimal _qtyPerVehicle;
        /// <summary>
        /// Gets of Sets the value of indicating {QtyPerVehicle}
        /// </summary>
        [DataMember]
        [Required]
        public decimal QtyPerVehicle
        {
            get => _qtyPerVehicle;
            set => SetProperty(ref _qtyPerVehicle, value);
        }

        /// <summary>
        /// Local reference of AnnualVolume property
        /// </summary>
        private Int64 _vehicleAnnualVolume;
        /// <summary>
        /// Gets of Sets the value of indicating {AnnualVolume}
        /// </summary>
        [DataMember]
        [Required]
        public Int64 VehicleAnnualVolume
        {
            get => _vehicleAnnualVolume;
            set => SetProperty(ref _vehicleAnnualVolume, value);
        }

        /// <summary>
        /// Local reference of TotalQuantity property
        /// </summary>
        private Int64 _vehicleTotalQuantity;
        /// <summary>
        /// Gets of Sets the value of indicating {VehicleTotalQuantity} , autocalculated as QtyPerVehicle * VehicleAnnualVolume
        /// </summary>
        [DataMember]
        [Required]
        public Int64 VehicleTotalQuantity
        {
            get => _vehicleTotalQuantity;
            set => SetProperty(ref _vehicleTotalQuantity, value);
        }


        private string _nprStage;
        /// <summary>
        /// Gets or sets a string value for the NPR Stages.
        /// </summary>
        [DataMember]
        [StringLength(2)]
        public string NPRStage
        {
            get => _nprStage;
            set => SetProperty(ref _nprStage, value);
        }
        /// <summary>
        /// Local Reference of NPRStatus
        /// </summary>
        private string _nprType;
        /// <summary>
        /// Get or Sets the value of indicating {NPRStatus} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(20)]
        public string NPRType
        {
            get => _nprType;
            set => SetProperty(ref _nprType, value);
        }
        /// <summary>
        /// Local Reference of SupplierDetailComments
        /// </summary>
        private string _supplierDetailComments;
        /// <summary>
        /// Get or Sets the value of indicating {SupplierDetailsComments} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(500)]
        public string SupplierDetailComments
        {
            get => _supplierDetailComments;
            set => SetProperty(ref _supplierDetailComments, value);
        }

        /// <summary>
        /// Local Reference of NPRCancellationComments
        /// </summary>
        private string _nprCancellationComments;
        /// <summary>
        /// Get or Sets the value of indicating {NPRCancellationComments} , it can only be cancelled by Engineering or Purchasing
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(500)]
        public string NPRCancellationComments
        {
            get => _nprCancellationComments;
            set => SetProperty(ref _nprCancellationComments, value);
        }

        /// <summary>
        /// Local Reference of NPRRaisedRemarks
        /// </summary>
        private string _nprRaisedRemarks;
        /// <summary>
        /// Get or Sets the value of indicating {NPRRaisedRemarks} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(500)]
        public string NPRRaisedRemarks
        {
            get => _nprRaisedRemarks;
            set => SetProperty(ref _nprRaisedRemarks, value);
        }

        /// <summary>
        /// Local reference of ManufacturingSite
        /// </summary>
        private string _manufacturingSite;
        /// <summary>
        /// Gets of Sets the value of indicating {ManufacturingSite} of NPR
        /// </summary>
        [DataMember]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => SetProperty(ref _manufacturingSite, value);
        }

        /// <summary>
        /// Local Reference of NPRReturnedRemarks
        /// </summary>
        private string _nprReturnedRemarks;
        /// <summary>
        /// NPR Returned Remarks
        /// </summary>
        [DataMember]
        public string NPRReturnedRemarks
        {
            get => _nprReturnedRemarks;
            set => SetProperty(ref _nprReturnedRemarks, value);
        }

        /// <summary>
        /// Local Reference of IsCustomerNominatedSupplier
        /// </summary>
        private bool _isCustomerNominatedSupplier;
        /// <summary>
        /// Is Customer Nominated Supplier
        /// </summary>
        [DataMember]
        public bool IsCustomerNominatedSupplier
        {
            get => _isCustomerNominatedSupplier;
            set => SetProperty(ref _isCustomerNominatedSupplier, value);
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
            set => SetProperty(ref _isCustomerNominatedMaterial, value);
        }

        /// <summary>
        /// Local reference of PlatformName property
        /// </summary>
        private string _platformName;
        /// <summary>
        /// Gets of Sets the value of indicating {PlatformName}
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string PlatformName
        {
            get => _platformName;
            set => SetProperty(ref _platformName, value);
        }


        /// <summary>
        /// Local reference of ProgramName property
        /// </summary>
        private string _programName;
        /// <summary>
        /// Gets of Sets the value of indicating {ProgramName}
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string ProgramName
        {
            get => _programName;
            set => SetProperty(ref _programName, value);
        }

        /// <summary>
        /// Local Reference of IsAdhoc
        /// </summary>
        private bool _isAdhoc = false;
        /// <summary>
        /// Is Adhoc NPR
        /// </summary>
        [DataMember]
        public bool IsAdhoc
        {
            get => _isAdhoc;
            set => SetProperty(ref _isAdhoc, value);
        }


        /// <summary>
        /// Local reference of SuggestedManufacturerGroup property
        /// </summary>
        private string _suggestedmanufacturerGroup;
        /// <summary>
        /// Gets of Sets the value of indicating {_suggestedManufacturerGroup} supplier group of NPR , exp : ACAPLAST , SEI
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string SuggestedManufacturerGroup
        {
            get => _suggestedmanufacturerGroup;
            set => SetProperty(ref _suggestedmanufacturerGroup, value);
        }

        private string _associatedParts;
        /// <summary>
        /// Gets of Sets the value of indicating {AssociatedParts} 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string AssociatedParts
        {
            get => _associatedParts;
            set => SetProperty(ref _associatedParts, value);
        }


        private List<Guid> _ManufacturingSiteGuid;
        /// <summary>
        /// Gets of Sets the value of indicating {AssociatedParts} 
        /// </summary>
        [DataMember]

        public List<Guid> ManufacturingSiteGuid
        {
            get => _ManufacturingSiteGuid;
            set => SetProperty(ref _ManufacturingSiteGuid, value);
        }

        /// <summary>
        /// Local Reference of NPRId
        /// </summary>
        private Guid _NPRId;
        /// <summary>
        /// Additional Remarks if any
        /// </summary>
        [DataMember]
        public Guid NPRId
        {
            get => _NPRId;
            set => SetProperty(ref _NPRId, value);
        }
        //Added End By Ashish on 26-Jun-2023
        /// <summary>
        /// Local Reference of NPRId
        /// </summary>
        private string _remarks;
        /// <summary>
        /// Additional Remarks if any
        /// </summary>
        [DataMember]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }

        /// <summary>
        /// Local reference of RFQ Submit all field model Item
        /// </summary>
        private RFQSubmitAllFieldsModel _rFQSubmitAllFieldsInput;
        /// <summary>
        /// RFQSubmitAllFields input items
        /// </summary>
        [DataMember]
        public RFQSubmitAllFieldsModel RFQSubmitAllFieldsInput
        {
            get => _rFQSubmitAllFieldsInput;
            set => SetProperty(ref _rFQSubmitAllFieldsInput, value);
        }

        /// <summary>
        /// Local reference of RFQIssueDate
        /// </summary>
        private DateTime _rfqIssueDate;
        /// <summary>
        /// Gets of Sets the value of indicating {RFQIssueDate} of NPR
        /// </summary>
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime RFQIssueDate
        {
            get => _rfqIssueDate;
            set => SetProperty(ref _rfqIssueDate, value.Date);
        }
        //private string _nprStage;

        ///// <summary>
        ///// Gets or sets a string value for the NPR Stages.
        ///// </summary>
        //[DataMember]
        //[StringLength(2)]
        //public string NPRStage
        //{
        //    get => _nprStage;
        //    set => SetProperty(ref _nprStage, value);
        //}

        ///// <summary>
        ///// Local Reference of NPRReturnedToSupplierRemarks
        ///// </summary>
        //private string _nprReturnedtoSupplierRemarks;
        ///// <summary>
        ///// NPR Returned Remarks
        ///// </summary>
        //[DataMember]
        //public string NPRReturnedToSupplierRemarks
        //{
        //    get => _nprReturnedtoSupplierRemarks;
        //    set => SetProperty(ref _nprReturnedtoSupplierRemarks, value);
        //}

        private string _businessUnitCode;
        /// <summary>
        /// Business Unit Code
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(4)]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }

        private string _supplierCode;

        /// <summary>
        /// Gets or sets a string value for the Supplier Code.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string SupplierCode
        {
            get => _supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }
        private string _priceTypeCode;
        /// <summary>
        /// Gets or sets a string value for the Price Type Code.
        /// </summary>
        [DataMember]
        [StringLength(2)]
        public string PriceTypeCode
        {
            get => _priceTypeCode;
            set => SetProperty(ref _priceTypeCode, value);
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

        /// <summary>
        /// Local Reference of MaterialOriginCountryAlpha2Code
        /// </summary>
        private string _materialOriginCountryAlpha2Code;
        /// <summary>
        /// Gets or sets a string value for the Material Origin Country Alpha2Code.
        /// </summary>
        [DataMember]
        [StringLength(2)]
        public string MaterialOriginCountryAlpha2Code
        {
            get => _materialOriginCountryAlpha2Code;
            set => SetProperty(ref _materialOriginCountryAlpha2Code, value);
        }


        /// <summary>
        /// Local Reference of MetalWeight
        /// </summary>
        private decimal _metalWeight;
        /// <summary>
        /// Gets or sets a decimal value for the Metal Weight.
        /// </summary>
        [DataMember]
        [DecimalPrecision(10, 5)]
        [Required]
        public decimal MetalWeight
        {
            get => _metalWeight;
            set => SetProperty(ref _metalWeight, value);
        }

        /// <summary>
        /// Local Reference of OrderLeadTime
        /// </summary>
        private int _orderLeadTime;
        /// <summary>
        /// Gets or sets a integer value for the Order Lead Time.
        /// </summary>
        [DataMember]
        [Required]
        public int OrderLeadTime
        {
            get => _orderLeadTime;
            set => SetProperty(ref _orderLeadTime, value);
        }

        /// <summary>
        /// Local Reference of POMinimumOrderQuantity
        /// </summary>
        private int _poMinimumOrderQuantity;
        /// <summary>
        /// Gets or sets a integer value for the POMinimum Order Quantity.
        /// </summary>
        [DataMember]
        [Required]
        public int POMinimumOrderQuantity
        {
            get => _poMinimumOrderQuantity;
            set => SetProperty(ref _poMinimumOrderQuantity, value);
        }

        /// <summary>
        /// Local Reference of ContainerQuantity
        /// </summary>
        private int _containerQuantity;
        /// <summary>
        /// Gets or sets a integer value for the  Container Quantity.
        /// </summary>
        [DataMember]
        [Required]
        public int ContainerQuantity
        {
            get => _containerQuantity;
            set => SetProperty(ref _containerQuantity, value);
        }


        /// <summary>
        /// Local Reference of POPriceIncludingMetal
        /// </summary>
        private decimal _poPriceIncludingMetal;
        /// <summary>
        /// Gets or sets a decimal value for the  POPrice Including Metal.
        /// </summary>
        [DataMember]
        [Required]
        [DecimalPrecision(9, 5)]
        public decimal POPriceIncludingMetal
        {
            get => _poPriceIncludingMetal;
            set => SetProperty(ref _poPriceIncludingMetal, value);
        }


        /// <summary>
        /// Local Reference of POPriceExcludingMetal
        /// </summary>
        private decimal _poPriceExcludingMetal;
        /// <summary>
        /// Gets or sets a decimal value for the  POPrice Excluding Metal.
        /// </summary>
        [DataMember]
        [Required]
        [DecimalPrecision(9, 5)]
        public decimal POPriceExcludingMetal
        {
            get => _poPriceExcludingMetal;
            set => SetProperty(ref _poPriceExcludingMetal, value);
        }


        /// <summary>
        /// Local Reference of MaterialTariffCode
        /// </summary>
        private string _materialTariffCode;
        /// <summary>
        /// Gets or sets a string value for the  Material Tariff Code.
        /// </summary>
        [DataMember]
        [StringLength(8)]
        [Required]
        public string MaterialTariffCode
        {
            get => _materialTariffCode;
            set => SetProperty(ref _materialTariffCode, value);
        }


        /// <summary>
        /// Local Reference of PurchaseOrderUnitOfMeasurement
        /// </summary>
        private string _purchaseOrderUnitOfMeasurement;
        /// <summary>
        /// Gets or sets a string value for the  Purchase Order Unit Of Measurement.
        /// </summary>
        [DataMember]
        [Required]
        public string PurchaseOrderUnitOfMeasurement
        {
            get => _purchaseOrderUnitOfMeasurement;
            set => SetProperty(ref _purchaseOrderUnitOfMeasurement, value);
        }

        /// <summary>
        /// Local Reference of MetalRate
        /// </summary>
        private decimal _metalRate;
        /// <summary>
        /// Gets or sets a decimal value for the Metal Rate.
        /// </summary>
        [DataMember]
        public decimal MetalRate
        {
            get { return _metalRate; }
            set { SetProperty(ref _metalRate, value); }
        }

        /// <summary>
        /// Local Reference of StandardBoxLength
        /// </summary>
        private decimal _standardBoxLength;
        /// <summary>
        /// Gets or sets a decimal value for the Standard Box Length.
        /// </summary>
        [DataMember]
        public decimal StandardBoxLength
        {
            get { return _standardBoxLength; }
            set { SetProperty(ref _standardBoxLength, value); }
        }

        /// <summary>
        /// Local Reference of StandardBoxWidth
        /// </summary>
        private decimal _standardBoxWidth;
        /// <summary>
        /// Gets or sets a decimal value for the Standard Box Width.
        /// </summary>
        [DataMember]
        public decimal StandardBoxWidth
        {
            get { return _standardBoxWidth; }
            set { SetProperty(ref _standardBoxWidth, value); }
        }

        /// <summary>
        /// Local Reference of StandardBoxHeight
        /// </summary>
        private decimal _standardBoxHeight;
        /// <summary>
        /// Gets or sets a decimal value for the Standard Box Height.
        /// </summary>
        [DataMember]
        public decimal StandardBoxHeight
        {
            get { return _standardBoxHeight; }
            set { SetProperty(ref _standardBoxHeight, value); }
        }

        /// <summary>
        /// Local Reference of StandardPackFactor
        /// </summary>
        private int _standardPackFactor;
        /// <summary>
        /// Gets or sets a integer value for the  Standard Pack Factor.
        /// </summary>
        [DataMember]
        public int StandardPackFactor
        {
            get { return _standardPackFactor; }
            set { SetProperty(ref _standardPackFactor, value); }
        }

        /// <summary>
        /// Local Reference of FullBoxWeight
        /// </summary>
        private decimal _fullBoxWeight;
        /// <summary>
        /// Gets or sets a decimal value for the Full Box Weight.
        /// </summary>
        [DataMember]
        public decimal FullBoxWeight
        {
            get { return _fullBoxWeight; }
            set { SetProperty(ref _fullBoxWeight, value); }
        }

        /// <summary>
        /// Local Reference of IncotermCode
        /// </summary>
        private string _incotermCode;
        /// <summary>
        /// Gets or sets a string value for the Incoterm Code.
        /// </summary>
        [DataMember]
        public string IncotermCode
        {
            get { return _incotermCode; }
            set { SetProperty(ref _incotermCode, value); }
        }

        /// <summary>
        /// Local Reference of CurrencyCode
        /// </summary>
        private string _currencyCode;
        /// <summary>
        /// Gets or sets a string value for the Currency Code.
        /// </summary>
        [DataMember]
        public string CurrencyCode
        {
            get { return _currencyCode; }
            set { SetProperty(ref _currencyCode, value); }
        }

        /// <summary>
        /// Local Reference of PackSize
        /// </summary>
        private int _packSize;
        /// <summary>
        /// Gets or sets a string value for the Pack Size.
        /// </summary>
        [DataMember]
        public int PackSize
        {
            get { return _packSize; }
            set { SetProperty(ref _packSize, value); }
        }

        /// <summary>
        /// Local Reference of Category
        /// </summary>
        private string _category;
        /// <summary>
        /// Gets or sets a string value for the Category i.e. A or B.
        /// </summary>
        [DataMember]
        public string Category
        {
            get { return _category; }
            set { SetProperty(ref _category, value); }
        }

        /// <summary>
        /// Local Reference of AdditionalComments
        /// </summary>
        private string _additionalComments;
        /// <summary>
        /// Gets or sets a string value for the AdditionalComments.
        /// </summary>
        [DataMember]
        public string AdditionalComments
        {
            get { return _additionalComments; }
            set { SetProperty(ref _additionalComments, value); }
        }

        /// <summary>
        /// Local Reference of POConversionFactor
        /// </summary>
        private int _poConversionFactor;
        /// <summary>
        /// Gets or sets a integer value for the  PO Conversion Factor.
        /// </summary>
        [DataMember]
        public int POConversionFactor
        {
            get { return _poConversionFactor; }
            set { SetProperty(ref _poConversionFactor, value); }
        }

        /// <summary>
        /// Local Reference of Capacity Confirmation at SOP
        /// </summary>
        private string _capacityConfirmationAtSOP;
        /// <summary>
        /// Gets or sets a string value for the AdditionalComments.
        /// </summary>
        [DataMember]
        public string CapacityConfirmationAtSOP
        {
            get { return _capacityConfirmationAtSOP; }
            set { SetProperty(ref _capacityConfirmationAtSOP, value); }
        }

        /// <summary>
        /// Local Reference of SOPComments
        /// </summary>
        private string _sopComments;
        /// <summary>
        /// Gets or sets a string value for the SOPComments.
        /// </summary>
        [DataMember]
        public string SOPComments
        {
            get { return _sopComments; }
            set { SetProperty(ref _sopComments, value); }
        }

        /// <summary>
        /// Local Reference of PurchasingSupplierComments
        /// </summary>
        private string _purchasingSupplierComments;// Added by Sai Kiran on 07-Dec-19
        /// <summary>
        /// Gets or sets a string value for the PurchasingSupplierComments.
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string PurchasingSupplierComments
        {
            get { return _purchasingSupplierComments; }
            set { SetProperty(ref _purchasingSupplierComments, value); }
        }

        /// <summary>
        /// Local Reference of SupplierReturnedComments
        /// </summary>
        private string _supplierReturnedComments;// Added by Sai Kiran on 06-Jan-2020
        /// <summary>
        /// Gets or sets a string value for the SupplierReturnedComments.
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string SupplierReturnedComments
        {
            get { return _supplierReturnedComments; }
            set { SetProperty(ref _supplierReturnedComments, value); }
        }

        /// <summary>
        /// Local Reference of RFQIssueComments
        /// </summary>
        private string _rfqIssueComments;// Added by Pawan on [30-Mar-2020]
        /// <summary>
        /// Gets or sets a string value for the RFQIssueComments.
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string RFQIssueComments
        {
            get { return _rfqIssueComments; }
            set { SetProperty(ref _rfqIssueComments, value); }
        }

        /// <summary>
        /// Local Reference of IsCancelledFromNPR
        /// </summary>
        private bool _isCancelledFromNPR;
        /// <summary>
        /// get or set for IsCancelledFromNPR
        /// </summary>
        [DataMember]
        public bool IsCancelledFromNPR
        {
            get => _isCancelledFromNPR;
            set => SetProperty(ref _isCancelledFromNPR, value);
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
        /// Local Reference of _currencyGuid
        /// </summary>
        private Guid _currencyGuid;
        /// <summary>
        /// get or set for CurrencyGuid
        /// </summary>
        [DataMember]
        public Guid CurrencyGuid
        {
            get => _currencyGuid;
            set => SetProperty(ref _currencyGuid, value);
        }

        /// <summary>
        /// Local Reference of _incotermGuid
        /// </summary>
        private Guid _incotermGuid;
        /// <summary>
        /// get or set for IncotermGuid
        /// </summary>
        [DataMember]
        public Guid IncotermGuid
        {
            get => _incotermGuid;
            set => SetProperty(ref _incotermGuid, value);
        }

        /// <summary>
        /// Local Reference of _purchaseOrderUnitOfMeasurementGuid
        /// </summary>
        private Guid _purchaseOrderUnitOfMeasurementGuid;
        /// <summary>
        /// get or set for PurchaseOrderUnitOfMeasurementGuid
        /// </summary>
        [DataMember]
        public Guid PurchaseOrderUnitOfMeasurementGuid
        {
            get => _purchaseOrderUnitOfMeasurementGuid;
            set => SetProperty(ref _purchaseOrderUnitOfMeasurementGuid, value);
        }

        private List<NPRSampleSiteModel> _sampleSiteDetails;
        /// <summary>
        /// Gets of Sets the value of indicating {SampleSiteDetails} a key value pair of Project details
        /// </summary>
        [DataMember]
        public List<NPRSampleSiteModel> SampleSiteDetails
        {

            get => _sampleSiteDetails;
            set => SetProperty(ref _sampleSiteDetails, value);
        }
    }
    public class NPRBacklogModelFilter
    {
        private string _nprId;
        [DataMember]
        public string NPRId
        {
            get => _nprId;
            set => _nprId = value;
        }

        //private string _nprStage;
        ///// <summary>
        ///// Get or Set for {NprStage}.
        ///// </summary>
        //[DataMember]
        //public string NprStage
        //{
        //    get => _nprStage;
        //    set => _nprStage = value;
        //}

        //private string _projectHierarchyGuid;
        ///// <summary>
        ///// Get or Set for {ProjectHierarchyGuid}.
        ///// </summary>
        //[DataMember]
        //public string ProjectHierarchyGuid
        //{
        //    get => _projectHierarchyGuid;
        //    set => _projectHierarchyGuid = value;
        //}

    }

    [DataContract, Serializable]
    public class NPRBacklogFilterModel
    {
        private string _nprType;
        [DataMember]
        public string NPRType
        {
            get => _nprType;
            set => _nprType = value;
        }
        private Guid _supplierGroupGuid;
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => _supplierGroupGuid = value;
        }
        private string _buyer;
        [DataMember]
        public string Buyer
        {
            get => _buyer;
            set => _buyer = value;
        }
        private string _requestID;
        [DataMember]
        public string RequestID
        {
            get => _requestID;
            set => _requestID = value;
        }
        private int _nPRStage;
        [DataMember]
        public int NPRStage
        {
            get => _nPRStage;
            set => _nPRStage = value;
        }
    }

    public class BacklogSupplierPortal:NPRBacklogModel{

        private Guid _CustomerHierarchyGuid;
        [DataMember]
        public Guid CustomerHierarchyGuid
        {
            get => _CustomerHierarchyGuid;
            set => _CustomerHierarchyGuid = value;
        }

        private Guid _projectHierarchyGuid;
        [DataMember]
        public Guid ProjectHierarchyGuid
        {
            get => _projectHierarchyGuid;
            set => _projectHierarchyGuid = value;
        }
    }

    public class BacklogSupplierPortalFilterModel 
    {

        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => _supplierGuid = value;
        }

        private Guid _iD;
        [DataMember]
        public Guid ID
        {
            get => _iD;
            set => _iD = value;
        }
    }
}