/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDIMessageDataModel.cs
Function           :   EDI Message Model
Created By         :   Dharmendra 
Created on         :   23-Nov-2022
Revision History   : 
****************************************************************************************************/
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    [DataContract, Serializable]
    public class EDIMessageDetailMappingModel
    {
        private Guid _id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        private string _unbSenderId;
        /// <summary>
        /// Get or Set for {UNBSenderId}.
        /// </summary>
        [DataMember]
        public string UNBSenderId
        {
            get => _unbSenderId;
            set => _unbSenderId = value;
        }
        private int _ediFileCreationDate;
        /// <summary>
        /// Get or Set for {EDIFileCreationDate}.
        /// </summary>
        [DataMember]
        public int EDIFileCreationDate
        {
            get => _ediFileCreationDate;
            set => _ediFileCreationDate = value;
        }


        private int _ediFileCreationTime;
        /// <summary>
        /// Get or Set for {EDIFileCreationTime}.
        /// </summary>
        [DataMember]
        public int EDIFileCreationTime
        {
            get => _ediFileCreationTime;
            set => _ediFileCreationTime = value;
        }
        private string _workStationCode;
        /// <summary>
        /// Get or Set for {WorkStationCode}.
        /// </summary>
        [DataMember]

        public string WorkStationCode
        {
            get => _workStationCode;
            set => _workStationCode = value;
        }


        private string _interchangeControlNumber;
        /// <summary>
        /// Get or Set for {InterchangeControlNumber}.
        /// </summary>
        [DataMember]

        public string InterchangeControlNumber
        {
            get => _interchangeControlNumber;
            set => _interchangeControlNumber = value;
        }

        private string _accountNumber;
        /// <summary>
        /// Get or Set for {AccountNumber}.
        /// </summary>
        [DataMember]
        public string AccountNumber
        {
            get => _accountNumber;
            set => _accountNumber = value;
        }

        private string _messageType;
        /// <summary>
        /// Get or Set for {MessageType}.
        /// </summary>
        [DataMember]
        public string MessageType
        {
            get => _messageType;
            set => _messageType = value;
        }
        private string _transportRoute;
        /// <summary>
        /// Get or Set for {TransportRoute}.
        /// </summary>
        [DataMember]
        public string TransportRoute
        {
            get => _transportRoute;
            set => _transportRoute = value;
        }
        private string _buyerCode;
        /// <summary>
        /// Get or Set for {BuyerCode}.
        /// </summary>
        [DataMember]
        public string BuyerCode
        {
            get => _buyerCode;
            set => _buyerCode = value;
        }
        private string _buyerName;
        /// <summary>
        /// Get or Set for {BuyerCode}.
        /// </summary>
        [DataMember]
        public string BuyerName
        {
            get => _buyerName;
            set => _buyerName = value;
        }


        private string _consigneeCode;
        /// <summary>
        /// Get or Set for {ConsigneeCode}.
        /// </summary>
        [DataMember]
        public string ConsigneeCode
        {
            get => _consigneeCode;
            set => _consigneeCode = value;
        }

        private string _consignorCode;
        /// <summary>
        /// Get or Set for {ConsignorCode}.
        /// </summary>
        [DataMember]
        public string ConsignorCode
        {
            get => _consignorCode;
            set => _consignorCode = value;
        }

        private string _unloadingPoint;
        /// <summary>
        /// Get or Set for {UnloadingPoint}.
        /// </summary>
        [DataMember]
        public string UnloadingPoint
        {
            get => _unloadingPoint;
            set => _unloadingPoint = value;
        }
        private string _vehicleIdentificationNumber;
        /// <summary>
        /// Get or Set for {VehicleIdentificationNumber}.
        /// </summary>
        [DataMember]
        public string VehicleIdentificationNumber
        {
            get => _vehicleIdentificationNumber;
            set => _vehicleIdentificationNumber = value;
        }


        private string _ediMessageFileName;
        /// <summary>
        /// Get or Set for {EDIMessageFileName}.
        /// </summary>
        [DataMember]
        public string EDIMessageFileName
        {
            get => _ediMessageFileName;
            set => _ediMessageFileName = value;
        }


        private string _messageReleaseNumber;
        /// <summary>
        /// Get or Set for {MessageReleaseNumber}.
        /// </summary>
        [DataMember]
        public string MessageReleaseNumber
        {
            get => _messageReleaseNumber;
            set => _messageReleaseNumber = value;
        }

        private string _messageNumber;
        /// <summary>
        /// Get or Set for {MessageNumber}.
        /// </summary>
        [DataMember]
        public string MessageNumber
        {
            get => _messageNumber;
            set => _messageNumber = value;
        }

        private string _applicationReference;
        /// <summary>
        /// Get or Set for {ApplicationReference}.
        /// </summary>
        [DataMember]
        public string ApplicationReference
        {
            get => _applicationReference;
            set => _applicationReference = value;
        }
        private string _messageReferenceNo;
        /// <summary>
        /// Get or Set for {MessageReferenceNo}.
        /// </summary>
        [DataMember]
        public string MessageReferenceNo
        {
            get => _messageReferenceNo;
            set => _messageReferenceNo = value;
        }

        private DateTime _batchStamp;
        /// <summary>
        /// This field will set BatchStamp
        /// </summary>
        [DataMember]
        public DateTime BatchStamp
        {
            get => _batchStamp;
            set => _batchStamp = value;
        }
        private string _orderNumber;
        /// <summary>
        /// Get or Set for {VehicleIdentificationNumber}.
        /// </summary>
        [DataMember]
        public string OrderNumber
        {
            get => _orderNumber;
            set => _orderNumber = value;
        }

        private string _schedulingConditionCode;
        /// <summary>
        /// Get or Set for {SchedulingConditionCode}.
        /// </summary>
        [DataMember]
        public string SchedulingConditionCode
        {
            get => _schedulingConditionCode;
            set => _schedulingConditionCode = value;
        }

        private string _schedulingFrequencyCode;
        /// <summary>
        /// Get or Set for {SchedulingFrequencyCode}.
        /// </summary>
        [DataMember]
        public string SchedulingFrequencyCode
        {
            get => _schedulingFrequencyCode;
            set => _schedulingFrequencyCode = value;
        }
        private bool _isCustomerMapped;
        /// <summary>
        /// Get or Set for {IsCustomerMapped}.
        /// </summary>
        [DataMember]

        public bool IsCustomerMapped
        {
            get => _isCustomerMapped;
            set => _isCustomerMapped = value;
        }
        private bool _isMessageDiscarded;
        /// <summary>
        /// Get or Set for {IsMessageDiscarded}.
        /// </summary>
        [DataMember]
        public bool IsMessageDiscarded
        {
            get => _isMessageDiscarded;
            set => _isMessageDiscarded = value;
        }

        private bool _supplyChainFlag;
        /// <summary>
        /// Get or Set for {SupplyChainFlag}.
        /// </summary>
        [DataMember]
        public bool SupplyChainFlag
        {
            get => _supplyChainFlag;
            set => _supplyChainFlag = value;
        }

        private Guid _batchId;
        /// <summary>
        /// Get or Set for {BatchId}.
        /// </summary>
        [DataMember]
        public Guid BatchId
        {
            get => _batchId;
            set => _batchId = value;
        }

        //private bool? _isAllPartMapped;
        ///// <summary>
        ///// Get or Set for {IsAllPartMapped}.
        ///// </summary>
        //[DataMember]
        //public bool? IsAllPartMapped
        //{
        //    get => _isAllPartMapped;
        //    set => _isAllPartMapped = value;
        //}
        /// <summary>
        /// local variable _createdDate
        /// </summary>
        private DateTime _createdDate;
        [DataMember]
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }

        }
        /// <summary>
        /// local variable _modifiedDate
        /// </summary>
        private DateTime _modifiedDate;
        [DataMember]
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }

        /// <summary>
        /// local variable _createdBy
        /// </summary>
        private Guid _createdBy;
        [DataMember]
        public Guid CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        /// <summary>
        /// local variable _modifiedBy
        /// </summary>
        private Guid _modifiedBy;
        [DataMember]
        public Guid ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }

        private DateTime? _demandStartDate;
        /// <summary>
        /// This field will set DemandStartDate
        /// </summary>
        [DataMember]
        public DateTime? DemandStartDate
        {
            get => _demandStartDate;
            set => _demandStartDate = value;
        }


        private DateTime? _demandEndDate;
        /// <summary>
        /// This field will set DemandEndDate
        /// </summary>
        [DataMember]
        public DateTime? DemandEndDate
        {
            get => _demandEndDate;
            set => _demandEndDate = value;
        }


        private int? _demandQty;
        /// <summary>
        /// Get or Set for {DemandQty}.
        /// </summary>
        [DataMember]
        public int? DemandQty
        {
            get => _demandQty;
            set => _demandQty = value;
        }
        private string _messageVersion;
        /// <summary>
        /// Get or Set for {MessageVersion}.
        /// </summary>
        [DataMember]
        public string MessageVersion
        {
            get => _messageVersion;
            set => _messageVersion = value;
        }


        private string _controllingAgency;
        /// <summary>
        /// Get or Set for {ControllingAgency}.
        /// </summary>
        [DataMember]
        public string ControllingAgency
        {
            get => _controllingAgency;
            set => _controllingAgency = value;
        }

        private long? _requestedDeliveryDateandTime;
        /// <summary>
        /// Get or Set for {RequestedDeliveryDateandTime}.
        /// </summary>
        [DataMember]
        public long? RequestedDeliveryDateandTime
        {
            get => _requestedDeliveryDateandTime;
            set => _requestedDeliveryDateandTime = value;
        }

        private long? _messageIssuedDateandTime;
        /// <summary>
        /// Get or Set for {MessageIssuedDateandTime}.
        /// </summary>
        [DataMember]
        public long? MessageIssuedDateandTime
        {
            get => _messageIssuedDateandTime;
            set => _messageIssuedDateandTime = value;
        }

        private long? _validityStartDateandTime;
        /// <summary>
        /// Get or Set for {ValidityStartDateandTime}.
        /// </summary>
        [DataMember]
        public long? ValidityStartDateandTime
        {
            get => _validityStartDateandTime;
            set =>  _validityStartDateandTime= value;
        }

        private long? _validityExpiryDateandTime;
        /// <summary>
        /// Get or Set for {ValidityExpiryDateandTime}.
        /// </summary>
        [DataMember]
        public long? ValidityExpiryDateandTime
        {
            get => _validityExpiryDateandTime;
            set =>  _validityExpiryDateandTime= value;
        }

        private long? _firstDeliveryDateandTime;
        /// <summary>
        /// Get or Set for {FirstDeliveryDateandTime}.
        /// </summary>
        [DataMember]
        public long? FirstDeliveryDateandTime
        {
            get => _firstDeliveryDateandTime;
            set => _firstDeliveryDateandTime= value;
        }

        private long? _lastDeliveryDateandTime;
        /// <summary>
        /// Get or Set for {LastDeliveryDateandTime}.
        /// </summary>
        [DataMember]
        public long? LastDeliveryDateandTime
        {
            get => _lastDeliveryDateandTime;
            set => _lastDeliveryDateandTime=value;
        }


        private long? _earliestCollectionDateandTime;
        /// <summary>
        /// Get or Set for {EarliestCollectionDateandTime}.
        /// </summary>
        [DataMember]
        public long? EarliestCollectionDateandTime
        {
            get => _earliestCollectionDateandTime;
            set => _earliestCollectionDateandTime = value;
        }


        private long? _latestCollectionDateandTime;
        /// <summary>
        /// Get or Set for {LatestCollectionDateandTime}.
        /// </summary>
        [DataMember]
        public long? LatestCollectionDateandTime
        {
            get => _latestCollectionDateandTime;
            set => _latestCollectionDateandTime= value;
        }

        private long? _latestDeliveryDateandTime;
        /// <summary>
        /// Get or Set for {LatestCollectionDateandTime}.
        /// </summary>
        [DataMember]
        public long? LatestDeliveryDateandTime
        {
            get => _latestDeliveryDateandTime;
            set => _latestDeliveryDateandTime= value;
        }

        private long? _earliestDeliveryDateandTime;
        /// <summary>
        /// Get or Set for {EarliestDeliveryDateandTime}.
        /// </summary>
        [DataMember]
        public long? EarliestDeliveryDateandTime
        {
            get => _earliestDeliveryDateandTime;
            set =>  _earliestDeliveryDateandTime= value;
        }


        private long? _sequenceStartDateandTime;
        /// <summary>
        /// Get or Set for {SequenceStartDateandTime}.
        /// </summary>
        [DataMember]
        public long? SequenceStartDateandTime
        {
            get => _sequenceStartDateandTime;
            set =>  _sequenceStartDateandTime= value;
        }


        private long? _sequenceEndDateandTime;
        /// <summary>
        /// Get or Set for {SequenceEndDateandTime}.
        /// </summary>
        [DataMember]
        public long? SequenceEndDateandTime
        {
            get => _sequenceEndDateandTime;
            set => _sequenceEndDateandTime= value;
        }

        private string _invoiceeCode;
        /// <summary>
        /// Get or Set for {InvoiceeCode}.
        /// </summary>
        [DataMember]
        public string InvoiceeCode
        {
            get => _invoiceeCode;
            set => _invoiceeCode = value;
        }

        private string _invoiceeName;
        /// <summary>
        /// Get or Set for {InvoiceeName}.
        /// </summary>
        [DataMember]
          public string InvoiceeName
        {
            get => _invoiceeName;
            set => _invoiceeName= value;
        }


        private string _consigneeName;
        /// <summary>
        /// Get or Set for {ConsigneeName}.
        /// </summary>
        [DataMember]
         public string ConsigneeName
        {
            get => _consigneeName;
            set =>  _consigneeName=value;
        }


        private string _consignorName;
        /// <summary>
        /// Get or Set for {ConsignorName}.
        /// </summary>
        [DataMember]

        public string ConsignorName
        {
            get => _consignorName;
            set =>  _consignorName= value;
        }

        private string _sellerCode;
        /// <summary>
        /// Get or Set for {SellerCode}.
        /// </summary>
        [DataMember]
        public string SellerCode
        {
            get => _sellerCode;
            set => _sellerCode= value;
        }

        private string _sellerName;
        /// <summary>
        /// Get or Set for {SellerName}.
        /// </summary>
        [DataMember]
          public string SellerName
        {
            get => _sellerName;
            set =>  _sellerName= value;
        }
        private string _contactNameorCode;
        /// <summary>
        /// Get or Set for {ContactNameorCode}.
        /// </summary>
        [DataMember]
        public string ContactNameorCode
        {
            get => _contactNameorCode;
            set =>  _contactNameorCode= value;
        }

        private string _lineItemIdentifier;
        /// <summary>
        /// Get or Set for {LineItemIdentifier}.
        /// </summary>
        [DataMember]
   
        public string LineItemIdentifier
        {
            get => _lineItemIdentifier;
            set => _lineItemIdentifier= value;
        }
        
        private string _actionRequest;
        /// <summary>
        /// Get or Set for {ActionRequest}.
        /// </summary>
        [DataMember]
         public string ActionRequest
        {
            get => _actionRequest;
            set => _actionRequest= value;
        }
        private string _partDescription;
        /// <summary>
        /// Get or Set for {PartDescription}.
        /// </summary>
        [DataMember]
        public string PartDescription
        {
            get => _partDescription;
            set => _partDescription=value;
        }

        private int? _packageQty;
        /// <summary>
        /// Get or Set for {PackageQty}.
        /// </summary>
        [DataMember]
        public int? PackageQty
        {
            get => _packageQty;
            set => _packageQty= value;
        }


        private string _packagingLevelCode;
        /// <summary>
        /// Get or Set for {PackagingLevelCode}.
        /// </summary>
        [DataMember]
        public string PackagingLevelCode
        {
            get => _packagingLevelCode;
            set => _packagingLevelCode = value;
        }

        private string _packagingType;
        /// <summary>
        /// Get or Set for {PackagingType}.
        /// </summary>
        [DataMember]
        public string PackagingType
        {
            get => _packagingType;
            set => _packagingType= value;
        }
          private string _pjiNumber;
        /// <summary>
        /// Get or Set for {PJINumber}.
        /// </summary>
        [DataMember]
         public string PJINumber
        {
            get => _pjiNumber;
            set => _pjiNumber= value;
        }


        private string _moffNumber;
        /// <summary>
        /// Get or Set for {MOFFNumber}.
        /// </summary>
        [DataMember]
        public string MOFFNumber
        {
            get => _moffNumber;
            set => _moffNumber= value;
        }
        private string _l3PSCollectionNumber;
        /// <summary>
        /// Get or Set for {L3PSCollectionNumber}.
        /// </summary>
        [DataMember]
        public string L3PSCollectionNumber
        {
            get => _l3PSCollectionNumber;
            set =>_l3PSCollectionNumber= value;
        }

        private string _l3PSCounter;
        /// <summary>
        /// Get or Set for {L3PSCollectionNumber}.
        /// </summary>
        [DataMember]
        public string L3PSCounter
        {
            get => _l3PSCounter;
            set => _l3PSCounter= value;
        }
         private int? _packQty;
        /// <summary>
        /// Get or Set for {PackQty}.
        /// </summary>
        [DataMember]
        public int? PackQty
        {
            get => _packQty;
            set =>_packQty= value;
        }


        private string _uOM;
        /// <summary>
        /// Get or Set for {UOM}.
        /// </summary>
        [DataMember]
        public string UOM
        {
            get => _uOM;
            set => _uOM= value;
        }


        private string _requestedRAN;
        /// <summary>
        /// Get or Set for {RequestedRAN}.
        /// </summary>
        [DataMember]
        public string RequestedRAN
        {
            get => _requestedRAN;
            set => _requestedRAN= value;
        }


        private string _lastIssuedRAN;
        /// <summary>
        /// Get or Set for {LastIssuedRAN}.
        /// </summary>
        [DataMember]
        public string LastIssuedRAN
        {
            get => _lastIssuedRAN;
            set =>  _lastIssuedRAN= value;
        }


        private string _timeSlotLogisticsXReferenceNumber;
        /// <summary>
        /// Get or Set for {TimeSlotLogisticsXReferenceNumber}.
        /// </summary>
        [DataMember]
        public string TimeSlotLogisticsXReferenceNumber
        {
            get => _timeSlotLogisticsXReferenceNumber;
            set =>_timeSlotLogisticsXReferenceNumber= value;
        }
        private Int32 _isNewPart;
        /// <summary>
        /// Get or Set for {IsNewPart}.
        /// </summary>
        [DataMember]
         public Int32 IsNewPartNumber
        {
            get => _isNewPart;
            set => _isNewPart= value;
        }

        private string _requestedShipmentDateandTime;
        /// <summary>
        /// Get or Set for {RequestedShipmentDateandTime}.
        /// </summary>
        [DataMember]
         public string RequestedShipmentDateandTime
        {
            get => _requestedShipmentDateandTime;
            set =>  _requestedShipmentDateandTime= value;
        }

        private string _despatchDateandTime;
        /// <summary>
        /// Get or Set for {DespatchDateandTime}.
        /// </summary>
        [DataMember]
        public string DespatchDateandTime
        {
            get => _despatchDateandTime;
            set => _despatchDateandTime= value;
        }

        private string _roadConsignmentNoteNo;
        /// <summary>
        /// Get or Set for {RoadConsignmentNoteNo}.
        /// </summary>
        [DataMember]
        public string RoadConsignmentNoteNo
        {
            get => _roadConsignmentNoteNo;
            set => _roadConsignmentNoteNo= value;
        }

        private string _supplierCode;
        /// <summary>
        /// Get or Set for {SupplierCode}.
        /// </summary>
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set =>  _supplierCode= value;
        }

        private string _supplierName;
        /// <summary>
        /// Get or Set for {SupplierName}.
        /// </summary>
        [DataMember]
        public string SupplierName
        {
            get => _supplierName;
            set => _supplierName= value;
        }

        private string _orderedQty;
        /// <summary>
        /// Get or Set for {OrderedQty}.
        /// </summary>
        [DataMember]
        public string OrderedQty
        {
            get => _orderedQty;
            set =>  _orderedQty= value;
        }

        private string _discreteQty;
        /// <summary>
        /// Get or Set for {DiscreteQty}.
        /// </summary>
        [DataMember]
        public string DiscreteQty
        {
            get => _discreteQty;
            set =>_discreteQty= value;
        }

        private string _dueDate;
        /// <summary>
        /// Get or Set for {DueDate}.
        /// </summary>
        [DataMember]
          public string DueDate
        {
            get => _dueDate;
            set =>  _dueDate= value;
        }

        private string _shipWeekofDate;
        /// <summary>
        /// Get or Set for {ShipWeekofDate}.
        /// </summary>
        [DataMember]
         public string ShipWeekofDate
        {
            get => _shipWeekofDate;
            set =>_shipWeekofDate= value;
        }

        //private bool _isCustomerDemandMapped;
        ///// <summary>
        ///// Get or Set for {IsCustomerDemandMapped}.
        ///// </summary>
        //[DataMember]
        //public bool IsCustomerDemandMapped
        //{
        //    get => _isCustomerDemandMapped;
        //    set => _isCustomerDemandMapped= value;
        //}
        private int? _deliveryQty;
        /// <summary>
        /// Get or Set for {DeliveryQty}.
        /// </summary>
        [DataMember]
        public int? DeliveryQty
        {
            get => _deliveryQty;
            set =>  _deliveryQty= value;
        }
        private int? _qtyToBeDelivered;
        /// <summary>
        /// Get or Set for {QtyToBeDelivered}.
        /// </summary>
        [DataMember]
        public int? QtyToBeDelivered
        {
            get => _qtyToBeDelivered;
            set => _qtyToBeDelivered= value;
        }

       
    }
}
