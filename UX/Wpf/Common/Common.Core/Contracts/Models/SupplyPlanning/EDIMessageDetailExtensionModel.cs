/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDIMessageDetaiExtensionModel.cs
Function           :   EDI Message Detail Extension Model
Created By         :   Shivam Dhingra
Created on         :   07-Apr-2020
Revision History   :   [28-Apr-2020] : Shivam Dhingra
                   :   Modified model as per the change in Tables 
				   :   [01-May-2020] : Shivam Dhingra
                   :   Removed ConsigneeCode and Consignor Code
                   :   
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    public class EDIMessageDetailExtensionModel : BaseModel<Guid>
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




	}
}
