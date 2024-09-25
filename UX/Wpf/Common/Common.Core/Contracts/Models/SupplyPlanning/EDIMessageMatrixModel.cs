/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDIMessageMatrixModel.cs
Function           :   EDI Message Matrix
Created By         :   Srashti Gupta
Created on         :   10-Feb-2020
Revision History   :   [10-Feb-2020]: Srashti Gupta
                   :   Change the datatype of {CustomerAccountNumber}
                   :   [13-Feb-2020] : Nitin
                   :   Added new properties CustomerName and CustomerGuid
                   :   [24-Feb-2020] : Shivam Dhingra
                   :   Added new properties DistributionCenterForDeliveryToCustomer and ShipmentFromManufacturingSiteToDistributionCenter
                   :   [27-Mar-2020] : Sai Kiran Thota
                   :   Added new properties UNBSenderId
                   :   [01-Apr-2020] : Dharmendra Kumar
                   :   Added new properties EDIMessageSourceId,EDIFileCreationDate,EDIFileCreationTime,MessageReleaseNumber,EDIMessageFileName   
                   :   [06-Apr-2020] : Dharmendra Kumar
                       Modified property CustomerAccountNumber to AccountNumber
                   :   [01-May-2020] : Shivam Dhingra
                   :   Added properties DemandStartDateFieldMapping,DemandFinishDateFieldMapping,DemandQtyFieldMapping. Also removed required from 
                       DistributionCenterForDeliveryToCustomer and ShipmentFromManufacturingSiteToDistributionCenter
                   :   [30-Jun-2020] : Shivam Dhingra
                   :   Removed required attribute from nullabe fields
*                  :   [21-Oct-2022] : Vidhwadeep Singh
*                  :   [] : added DemandStartDateFormat,DemandEndDateFormat
*                  :   [28-Oct-2022] : Sejal Srivastava
*                  :   [] : Increased EDIMessageTypeCode length from 6 to 8 characters 
*                  :   [02-Feb-2024] : Prakhar Singh
*                  :   [HD-00394058] : Added Property ViewName
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for EDISetUpMasters Service
    /// </summary>
    [DataContract, Serializable]
    public class EDIMessageMatrixModel : BaseModel<Guid>
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
            set => SetProperty(ref _unbSenderId, value);
        }

        private string _applicationReferenceTypeCode;
        /// <summary>
        /// Get or Set for {ApplicationReferenceTypeCode}.
        /// </summary>
        [DataMember]
        [StringLength(14)]
        public string ApplicationReferenceTypeCode
        {
            get => _applicationReferenceTypeCode;
            set => SetProperty(ref _applicationReferenceTypeCode, value);
        }

        private string _ediMessageTypeCode;
        /// <summary>
        /// Get or Set for {EDIMessageTypeCode}.
        /// </summary>
        [DataMember]
        [StringLength(8)]
        public string EDIMessageTypeCode
        {
            get => _ediMessageTypeCode;
            set => SetProperty(ref _ediMessageTypeCode, value);
        }

        private string _accountNumber;
        /// <summary>
        /// Get or Set for {CustomerAccountNumber}.
        /// </summary>
        [DataMember]
        [StringLength(70)]
        public string AccountNumber
        {
            get => _accountNumber;
            set => SetProperty(ref _accountNumber, value);
        }

        private string _transportRouteCode;
        /// <summary>
        /// Get or Set for {TransportRouteCode}.
        /// </summary>
        [DataMember]
        [StringLength(70)]
        public string TransportRouteCode
        {
            get => _transportRouteCode;
            set => SetProperty(ref _transportRouteCode, value);
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
            set => SetProperty(ref _buyerCode, value);
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

        private string _consigneeCode;
        /// <summary>
        /// Get or Set for {ConsigneeCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string ConsigneeCode
        {
            get => _consigneeCode;
            set => SetProperty(ref _consigneeCode, value);
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
            set => SetProperty(ref _consignorCode, value);
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

        private string _unloadingPointCode;
        /// <summary>
        /// Get or Set for {UnloadingPointCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string UnloadingPointCode
        {
            get => _unloadingPointCode;
            set => SetProperty(ref _unloadingPointCode, value);
        }

        private string _workstationCode;
        /// <summary>
        /// Get or Set for {WorkstationCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string WorkstationCode
        {
            get => _workstationCode;
            set => SetProperty(ref _workstationCode, value);
        }

        private string _schedulingConditionCode;
        /// <summary>
        /// Get or Set for {SchedulingConditionCode}.
        /// </summary>
        [DataMember]
        [StringLength(3)]
        public string SchedulingConditionCode
        {
            get => _schedulingConditionCode;
            set => SetProperty(ref _schedulingConditionCode, value);
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
            set => SetProperty(ref _schedulingFrequencyCode, value);
        }
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }
        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }

        private string _customerDeliveryLocation;
        /// <summary>
        /// Get or Set for {CustomerDeliveryLocation}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string CustomerDeliveryLocation
        {
            get => _customerDeliveryLocation;
            set => SetProperty(ref _customerDeliveryLocation, value);
        }
        private Guid _distributionCenterForDeliveryToCustomerGuid;
        /// <summary>
        /// Get or Set for {DistributionCenterForDeliveryToCustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid DistributionCenterForDeliveryToCustomerGuid
        {
            get => _distributionCenterForDeliveryToCustomerGuid;
            set => SetProperty(ref _distributionCenterForDeliveryToCustomerGuid, value);
        }

        private Guid _shipmentFromManufacturingSiteToDistributionCenterGuid;
        /// <summary>
        /// Get or Set for {DistributionCenterForDeliveryToCustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid ShipmentFromManufacturingSiteToDistributionCenterGuid
        {
            get => _shipmentFromManufacturingSiteToDistributionCenterGuid;
            set => SetProperty(ref _shipmentFromManufacturingSiteToDistributionCenterGuid, value);
        }

        private string _shipmentFromManufacturingSiteToDistributionCenter;
        /// <summary>
        /// Get or Set for {ShipmentFromManufacturingSiteToDistributionCenter}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string ShipmentFromManufacturingSiteToDistributionCenter
        {
            get => _shipmentFromManufacturingSiteToDistributionCenter;
            set => SetProperty(ref _shipmentFromManufacturingSiteToDistributionCenter, value);
        }

        private string _distributionCenterForDeliveryToCustomer;
        /// <summary>
        /// Get or Set for {DistributionCenterForDeliveryToCustomer}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string DistributionCenterForDeliveryToCustomer
        {
            get => _distributionCenterForDeliveryToCustomer;
            set => SetProperty(ref _distributionCenterForDeliveryToCustomer, value);
        }
        private bool _isCustomerMapped = true;
         [DataMember]
        public virtual bool IsCustomerMapped
        {
            get => _isCustomerMapped;
            set => SetProperty(ref _isCustomerMapped, value);
        }
        private bool _isMessageDiscarded = true;
        [DataMember]
        public  bool IsMessageDiscarded
        {
            get => _isMessageDiscarded;
            set => SetProperty(ref _isMessageDiscarded, value);
        }

        private Guid _ediMessageSourceId;
        [DataMember]
        public Guid EDIMessageSourceId
        {
            get => _ediMessageSourceId;
            set => SetProperty(ref _ediMessageSourceId, value);
        }
        private int _ediFileCreationDate;
        [DataMember]
        public int EDIFileCreationDate
        {
            get => _ediFileCreationDate;
            set => SetProperty(ref _ediFileCreationDate, value);
        }
        private int _ediFileCreationTime;
        [DataMember]
        public int EDIFileCreationTime
        {
            get => _ediFileCreationTime;
            set => SetProperty(ref _ediFileCreationTime, value);
        }
        private string _messageReleaseNumber;
        [DataMember]
        [StringLength(3)]
        public string MessageReleaseNumber
        {
            get => _messageReleaseNumber;
            set => SetProperty(ref _messageReleaseNumber, value);
        }
        
        private string _messageNumber;
        [DataMember]
        [StringLength(35)]
        public string MessageNumber
        {
            get => _messageNumber;
            set => SetProperty(ref _messageNumber, value);
        }
        private string _ediMessageFileName;
        [DataMember]
        [StringLength(150)]
        public string EDIMessageFileName
        {
            get => _ediMessageFileName;
            set => SetProperty(ref _ediMessageFileName, value);
        }
        private Guid _ediMessageHeaderBatchId;
        [DataMember]
        [StringLength(150)]
        public Guid EDIMessageHeaderBatchId
        {
            get => _ediMessageHeaderBatchId;
            set => SetProperty(ref _ediMessageHeaderBatchId, value);
        }
        private DateTime _ediMessageHeaderBatchStamp;
        [DataMember]
        [DataType(DataType.DateTime)]
        public DateTime EDIMessageHeaderBatchStamp
        {
           
            get => _ediMessageHeaderBatchStamp;
            set => SetProperty(ref _ediMessageHeaderBatchStamp, value);
        }

        private string _demandStartDateFieldMapping;
        [DataMember]
        [StringLength(100)]
        public string DemandStartDateFieldMapping
        {
            get => _demandStartDateFieldMapping;
            set => SetProperty(ref _demandStartDateFieldMapping, value);
        }



        private string _demandFinishDateFieldMapping;
        [DataMember]
        [StringLength(100)]
        public string DemandFinishDateFieldMapping
        {
            get => _demandFinishDateFieldMapping;
            set => SetProperty(ref _demandFinishDateFieldMapping, value);
        }



        private string _demandQtyFieldMapping;
        [DataMember]
        [StringLength(100)]
        public string DemandQtyFieldMapping
        {
            get => _demandQtyFieldMapping;
            set => SetProperty(ref _demandQtyFieldMapping, value);
        }

        private string _demandStartDateFormat;
        [DataMember]
        [StringLength(50)]
        public string DemandStartDateFormat
        {
            get => _demandStartDateFormat;
            set => SetProperty(ref _demandStartDateFormat, value);
        }

        private string _demandEndDateFormat;
        [DataMember]
        [StringLength(50)]
        public string DemandEndDateFormat
        {
            get => _demandEndDateFormat;
            set => SetProperty(ref _demandEndDateFormat, value);
        }

        private string _viewName;
        [DataMember]
        public string ViewName
        {
            get { return _viewName; }
            set { SetProperty(ref _viewName, value); }
        }
    }
}
