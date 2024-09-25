/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDIMessageHeaderMasterModel.cs
Function           :   EDI Message Header Master Model
Created By         :   Shivam Dhingra
Created on         :   07-Apr-2020
Revision History   :   [28-Apr-2020] : Shivam Dhingra
                   :   Modified model as per the change in Tables 
				   :   [01-May-2020] : Shivam Dhingra
                   :   Removed ConsigneeCode, ConsignorCode and removed Required attribute from DemandQty
                   :   [10-June-2022] : Shivam  Kalia
				   :   Added new field IsCustomerDemandMapped
                   :   Removed SupplyChainSetup and supplychainflag from EDIMessageDetail
                   :   [07-Nov-2022] : Dharmendra
				   :   Added new model EDIMessageDetail
                   :   [29-Nov-2022] : Prakhar
                   :   Added new Class EDIMessageExportFromDB

****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data contract used foe EDI Message Header
    /// </summary>

    [DataContract, Serializable]
    public class EDIMessageHeaderMasterModel : EDIMessageHeaderModel

    {
        private Guid _ediMessageHeaderId;
        /// <summary>
        /// Get or Set for {EDIMessageHeaderId}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid EDIMessageHeaderId
        {
            get => _ediMessageHeaderId;
            set => SetProperty(ref _ediMessageHeaderId, value);
        }


        private long? _requestedDeliveryDateandTime;
        /// <summary>
        /// Get or Set for {RequestedDeliveryDateandTime}.
        /// </summary>
        [DataMember]
        public long? RequestedDeliveryDateandTime
        {
            get => _requestedDeliveryDateandTime;
            set => SetProperty(ref _requestedDeliveryDateandTime, value);
        }

        private long? _messageIssuedDateandTime;
        /// <summary>
        /// Get or Set for {MessageIssuedDateandTime}.
        /// </summary>
        [DataMember]

        public long? MessageIssuedDateandTime
        {
            get => _messageIssuedDateandTime;
            set => SetProperty(ref _messageIssuedDateandTime, value);
        }

        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        private string _orderNumber;
        /// <summary>
        /// Get or Set for {OrderNumber}.
        /// </summary>
        [DataMember]
        [StringLength(70)]
        public string OrderNumber
        {
            get => _orderNumber;
            set => SetProperty(ref _orderNumber, value);
        }

        private int? _deliveryQty;
        /// <summary>
        /// Get or Set for {DeliveryQty}.
        /// </summary>
        [DataMember]
        public int? DeliveryQty
        {
            get => _deliveryQty;
            set => SetProperty(ref _deliveryQty, value);
        }
        private int? _qtyToBeDelivered;
        /// <summary>
        /// Get or Set for {QtyToBeDelivered}.
        /// </summary>
        [DataMember]
        public int? QtyToBeDelivered
        {
            get => _qtyToBeDelivered;
            set => SetProperty(ref _qtyToBeDelivered, value);
        }


        private string _messageVersion;
        /// <summary>
        /// Get or Set for {MessageVersion}.
        /// </summary>
        [DataMember]
        [StringLength(3)]
        public string MessageVersion
        {
            get => _messageVersion;
            set => SetProperty(ref _messageVersion, value);
        }


        private string _controllingAgency;
        /// <summary>
        /// Get or Set for {ControllingAgency}.
        /// </summary>
        [DataMember]
        [StringLength(3)]
        public string ControllingAgency
        {
            get => _controllingAgency;
            set => SetProperty(ref _controllingAgency, value);
        }


        private long? _validityStartDateandTime;
        /// <summary>
        /// Get or Set for {ValidityStartDateandTime}.
        /// </summary>
        [DataMember]
        public long? ValidityStartDateandTime
        {
            get => _validityStartDateandTime;
            set => SetProperty(ref _validityStartDateandTime, value);
        }

        private long? _validityExpiryDateandTime;
        /// <summary>
        /// Get or Set for {ValidityExpiryDateandTime}.
        /// </summary>
        [DataMember]
        public long? ValidityExpiryDateandTime
        {
            get => _validityExpiryDateandTime;
            set => SetProperty(ref _validityExpiryDateandTime, value);
        }

        private long? _firstDeliveryDateandTime;
        /// <summary>
        /// Get or Set for {FirstDeliveryDateandTime}.
        /// </summary>
        [DataMember]
        public long? FirstDeliveryDateandTime
        {
            get => _firstDeliveryDateandTime;
            set => SetProperty(ref _firstDeliveryDateandTime, value);
        }

        private long? _lastDeliveryDateandTime;
        /// <summary>
        /// Get or Set for {LastDeliveryDateandTime}.
        /// </summary>
        [DataMember]
        public long? LastDeliveryDateandTime
        {
            get => _lastDeliveryDateandTime;
            set => SetProperty(ref _lastDeliveryDateandTime, value);
        }


        private long? _earliestCollectionDateandTime;
        /// <summary>
        /// Get or Set for {EarliestCollectionDateandTime}.
        /// </summary>
        [DataMember]
        public long? EarliestCollectionDateandTime
        {
            get => _earliestCollectionDateandTime;
            set => SetProperty(ref _earliestCollectionDateandTime, value);
        }


        private long? _latestCollectionDateandTime;
        /// <summary>
        /// Get or Set for {LatestCollectionDateandTime}.
        /// </summary>
        [DataMember]
        public long? LatestCollectionDateandTime
        {
            get => _latestCollectionDateandTime;
            set => SetProperty(ref _latestCollectionDateandTime, value);
        }

        private long? _latestDeliveryDateandTime;
        /// <summary>
        /// Get or Set for {LatestCollectionDateandTime}.
        /// </summary>
        [DataMember]
        public long? LatestDeliveryDateandTime
        {
            get => _latestDeliveryDateandTime;
            set => SetProperty(ref _latestDeliveryDateandTime, value);
        }

        private long? _earliestDeliveryDateandTime;
        /// <summary>
        /// Get or Set for {EarliestDeliveryDateandTime}.
        /// </summary>
        [DataMember]
        public long? EarliestDeliveryDateandTime
        {
            get => _earliestDeliveryDateandTime;
            set => SetProperty(ref _earliestDeliveryDateandTime, value);
        }


        private long? _sequenceStartDateandTime;
        /// <summary>
        /// Get or Set for {SequenceStartDateandTime}.
        /// </summary>
        [DataMember]
        public long? SequenceStartDateandTime
        {
            get => _sequenceStartDateandTime;
            set => SetProperty(ref _sequenceStartDateandTime, value);
        }


        private long? _sequenceEndDateandTime;
        /// <summary>
        /// Get or Set for {SequenceEndDateandTime}.
        /// </summary>
        [DataMember]
        public long? SequenceEndDateandTime
        {
            get => _sequenceEndDateandTime;
            set => SetProperty(ref _sequenceEndDateandTime, value);
        }

        private string _invoiceeCode;
        /// <summary>
        /// Get or Set for {InvoiceeCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string InvoiceeCode
        {
            get => _invoiceeCode;
            set => SetProperty(ref _invoiceeCode, value);
        }

        private string _invoiceeName;
        /// <summary>
        /// Get or Set for {InvoiceeName}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string InvoiceeName
        {
            get => _invoiceeName;
            set => SetProperty(ref _invoiceeName, value);
        }


        private string _consigneeName;
        /// <summary>
        /// Get or Set for {ConsigneeName}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string ConsigneeName
        {
            get => _consigneeName;
            set => SetProperty(ref _consigneeName, value);
        }


        private string _consignorName;
        /// <summary>
        /// Get or Set for {ConsignorName}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string ConsignorName
        {
            get => _consignorName;
            set => SetProperty(ref _consignorName, value);
        }

        private string _sellerCode;
        /// <summary>
        /// Get or Set for {SellerCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string SellerCode
        {
            get => _sellerCode;
            set => SetProperty(ref _sellerCode, value);
        }

        private string _sellerName;
        /// <summary>
        /// Get or Set for {SellerName}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string SellerName
        {
            get => _sellerName;
            set => SetProperty(ref _sellerName, value);
        }

        private string _contactNameorCode;
        /// <summary>
        /// Get or Set for {ContactNameorCode}.
        /// </summary>
        [DataMember]
        [StringLength(17)]
        public string ContactNameorCode
        {
            get => _contactNameorCode;
            set => SetProperty(ref _contactNameorCode, value);
        }

        private string _lineItemIdentifier;
        /// <summary>
        /// Get or Set for {LineItemIdentifier}.
        /// </summary>
        [DataMember]
        [StringLength(7)]
        public string LineItemIdentifier
        {
            get => _lineItemIdentifier;
            set => SetProperty(ref _lineItemIdentifier, value);
        }


        private string _actionRequest;
        /// <summary>
        /// Get or Set for {ActionRequest}.
        /// </summary>
        [DataMember]
        [StringLength(7)]
        public string ActionRequest
        {
            get => _actionRequest;
            set => SetProperty(ref _actionRequest, value);
        }


        private string _partDescription;
        /// <summary>
        /// Get or Set for {PartDescription}.
        /// </summary>
        [DataMember]
        [StringLength(256)]
        public string PartDescription
        {
            get => _partDescription;
            set => SetProperty(ref _partDescription, value);
        }



        private int? _packageQty;
        /// <summary>
        /// Get or Set for {PackageQty}.
        /// </summary>
        [DataMember]
        public int? PackageQty
        {
            get => _packageQty;
            set => SetProperty(ref _packageQty, value);
        }


        private string _packagingLevelCode;
        /// <summary>
        /// Get or Set for {PackagingLevelCode}.
        /// </summary>
        [DataMember]
        [StringLength(3)]
        public string PackagingLevelCode
        {
            get => _packagingLevelCode;
            set => SetProperty(ref _packagingLevelCode, value);
        }

        private string _packagingType;
        /// <summary>
        /// Get or Set for {PackagingType}.
        /// </summary>
        [DataMember]
        [StringLength(17)]
        public string PackagingType
        {
            get => _packagingType;
            set => SetProperty(ref _packagingType, value);
        }


        private string _pjiNumber;
        /// <summary>
        /// Get or Set for {PJINumber}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string PJINumber
        {
            get => _pjiNumber;
            set => SetProperty(ref _pjiNumber, value);
        }


        private string _moffNumber;
        /// <summary>
        /// Get or Set for {MOFFNumber}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string MOFFNumber
        {
            get => _moffNumber;
            set => SetProperty(ref _moffNumber, value);
        }


        private string _l3PSCollectionNumber;
        /// <summary>
        /// Get or Set for {L3PSCollectionNumber}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string L3PSCollectionNumber
        {
            get => _l3PSCollectionNumber;
            set => SetProperty(ref _l3PSCollectionNumber, value);
        }

        private string _l3PSCounter;
        /// <summary>
        /// Get or Set for {L3PSCollectionNumber}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string L3PSCounter
        {
            get => _l3PSCounter;
            set => SetProperty(ref _l3PSCounter, value);
        }


        private int? _packQty;
        /// <summary>
        /// Get or Set for {PackQty}.
        /// </summary>
        [DataMember]
        public int? PackQty
        {
            get => _packQty;
            set => SetProperty(ref _packQty, value);
        }


        private string _uOM;
        /// <summary>
        /// Get or Set for {UOM}.
        /// </summary>
        [DataMember]
        [StringLength(8)]
        public string UOM
        {
            get => _uOM;
            set => SetProperty(ref _uOM, value);
        }


        private string _requestedRAN;
        /// <summary>
        /// Get or Set for {RequestedRAN}.
        /// </summary>
        [DataMember]
        [StringLength(70)]
        public string RequestedRAN
        {
            get => _requestedRAN;
            set => SetProperty(ref _requestedRAN, value);
        }



        private string _lastIssuedRAN;
        /// <summary>
        /// Get or Set for {LastIssuedRAN}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string LastIssuedRAN
        {
            get => _lastIssuedRAN;
            set => SetProperty(ref _lastIssuedRAN, value);
        }


        private string _timeSlotLogisticsXReferenceNumber;
        /// <summary>
        /// Get or Set for {TimeSlotLogisticsXReferenceNumber}.
        /// </summary>
        [DataMember]
        [StringLength(70)]
        public string TimeSlotLogisticsXReferenceNumber
        {
            get => _timeSlotLogisticsXReferenceNumber;
            set => SetProperty(ref _timeSlotLogisticsXReferenceNumber, value);
        }
        private DateTime? _demandStartDate;
        /// <summary>
        /// This field will set DemandStartDate
        /// </summary>
        [DataMember]
        public DateTime? DemandStartDate
        {
            get => _demandStartDate;
            set => SetProperty(ref _demandStartDate, value);
        }


        private DateTime? _demandEndDate;
        /// <summary>
        /// This field will set DemandEndDate
        /// </summary>
        [DataMember]
        public DateTime? DemandEndDate
        {
            get => _demandEndDate;
            set => SetProperty(ref _demandEndDate, value);
        }


        private int? _demandQty;
        /// <summary>
        /// Get or Set for {DemandQty}.
        /// </summary>
        [DataMember]
        public int? DemandQty
        {
            get => _demandQty;
            set => SetProperty(ref _demandQty, value);
        }
        private bool _isNewPart;
        /// <summary>
        /// Get or Set for {IsNewPart}.
        /// </summary>
        [DataMember]
        [Required]
        public bool IsNewPart
        {
            get => _isNewPart;
            set => SetProperty(ref _isNewPart, value);
        }

        private string _requestedShipmentDateandTime;
        /// <summary>
        /// Get or Set for {RequestedShipmentDateandTime}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string RequestedShipmentDateandTime
        {
            get => _requestedShipmentDateandTime;
            set => SetProperty(ref _requestedShipmentDateandTime, value);
        }

        private string _despatchDateandTime;
        /// <summary>
        /// Get or Set for {DespatchDateandTime}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string DespatchDateandTime
        {
            get => _despatchDateandTime;
            set => SetProperty(ref _despatchDateandTime, value);
        }

        private string _roadConsignmentNoteNo;
        /// <summary>
        /// Get or Set for {RoadConsignmentNoteNo}.
        /// </summary>
        [DataMember]
        [StringLength(70)]
        public string RoadConsignmentNoteNo
        {
            get => _roadConsignmentNoteNo;
            set => SetProperty(ref _roadConsignmentNoteNo, value);
        }

        private string _supplierCode;
        /// <summary>
        /// Get or Set for {SupplierCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string SupplierCode
        {
            get => _supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }

        private string _supplierName;
        /// <summary>
        /// Get or Set for {SupplierName}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string SupplierName
        {
            get => _supplierName;
            set => SetProperty(ref _supplierName, value);
        }

        private string _orderedQty;
        /// <summary>
        /// Get or Set for {OrderedQty}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string OrderedQty
        {
            get => _orderedQty;
            set => SetProperty(ref _orderedQty, value);
        }

        private string _discreteQty;
        /// <summary>
        /// Get or Set for {DiscreteQty}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string DiscreteQty
        {
            get => _discreteQty;
            set => SetProperty(ref _discreteQty, value);
        }

        private string _dueDate;
        /// <summary>
        /// Get or Set for {DueDate}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string DueDate
        {
            get => _dueDate;
            set => SetProperty(ref _dueDate, value);
        }

        private string _shipWeekofDate;
        /// <summary>
        /// Get or Set for {ShipWeekofDate}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string ShipWeekofDate
        {
            get => _shipWeekofDate;
            set => SetProperty(ref _shipWeekofDate, value);
        }

        private bool _isCustomerDemandMapped;
        /// <summary>
        /// Get or Set for {IsCustomerDemandMapped}.
        /// </summary>
        [DataMember]
        public bool IsCustomerDemandMapped
        {
            get => _isCustomerDemandMapped;
            set => SetProperty(ref _isCustomerDemandMapped, value);
        }



    }

    /// <summary>
    /// class for EDIMessage Detail
    /// </summary>
    [DataContract, Serializable]
    public class EDIMessageDetail
    {

        private string _unbSenderId;
        /// <summary>
        /// Get or Set for {UNBSenderId}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string UNBSenderId
        {
            get => _unbSenderId;
            set => _unbSenderId = value;
        }

        private string _messageType;
        /// <summary>
        /// Get or Set for {MessageType}.
        /// </summary>
        [DataMember]
        [StringLength(8)]
        public string MessageType
        {
            get => _messageType;
            set => _messageType = value;
        }

        private string _buyerCode;
        /// <summary>
        /// Get or Set for {BuyerCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string BuyerCode
        {
            get => _buyerCode;
            set => _buyerCode = value;
        }

        private string _consigneeCode;
        /// <summary>
        /// Get or Set for {ConsigneeCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
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
        [StringLength(35)]
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
        [StringLength(35)]
        public string UnloadingPoint
        {
            get => _unloadingPoint;
            set => _unloadingPoint = value;
        }

        private string _schedulingFrequencyCode;
        /// <summary>
        /// Get or Set for {SchedulingFrequencyCode}.
        /// </summary>
        [DataMember]
        [StringLength(3)]
        public string SchedulingFrequencyCode
        {
            get => _schedulingFrequencyCode;
            set => _schedulingFrequencyCode = value;
        }

        //private bool _supplyChainFlag;
        ///// <summary>
        ///// Get or Set for {SupplyChainFlag}.
        ///// </summary>
        //[DataMember]
        //[Required]
        //public bool SupplyChainFlag
        //{
        //    get => _supplyChainFlag;
        //    set => _supplyChainFlag = value;
        //}

        private string _ediMessageFileName;
        /// <summary>
        /// Get or Set for {EDIMessageFileName}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(150)]
        public string EDIMessageFileName
        {
            get => _ediMessageFileName;
            set => _ediMessageFileName = value;
        }

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

        private Guid _ediMessageHeaderId;
        /// <summary>
        /// Get or Set for {EDIMessageHeaderId}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid EDIMessageHeaderId
        {
            get => _ediMessageHeaderId;
            set => _ediMessageHeaderId = value;
        }

        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
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

        //private bool _supplyChainSetup;
        ///// <summary>
        ///// Get or Set for {SupplyChainSetup}.
        ///// </summary>
        //[DataMember]
        //[Required]
        //public bool SupplyChainSetup
        //{
        //    get => _supplyChainSetup;
        //    set => _supplyChainSetup = value;
        //}

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
        private bool _isCustomerIdentified;
        [DataMember]
        public bool IsCustomerIdentified
        {
            get => _isCustomerIdentified;
            set => _isCustomerIdentified = value;
        }
        private bool _isDemandMapped;
        [DataMember]
        public bool IsDemandMapped
        {
            get => _isDemandMapped;
            set => _isDemandMapped = value;
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
    }

    [DataContract, Serializable]
    public class EDIMessageExportFromDB
    {

        private string _returnMessage;
        /// <summary>
        /// Get or Set for {UNBSenderId}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string ReturnMessage
        {
            get => _returnMessage;
            set => _returnMessage = value;
        }
    }
}
