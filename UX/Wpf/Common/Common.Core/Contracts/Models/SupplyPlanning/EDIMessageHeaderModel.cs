/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDIMessageHeaderModel.cs
Function           :   EDI Message Model
Created By         :   Shivam Dhingra
Created on         :   07-Apr-2020
Revision History   :   [28-Apr-2020] : Shivam Dhingra
                   :   Modified model as per the change in Tables
                   :   [29-Apr-2020] : Shivam Dhingra
                   :   Added field MessageReferenceNo
                   :   [01-May-2020] : Shivam Dhingra
                   :   Added field ConsigneeCode and Consignor Code
                   :   [07-Jun-2021] : Shivam Kalia
                   :   Changed the data length from 12 characters to 35 characters for UNBSenderId
                   :   [04-Aug-2021] : Shahab Ashraf
                   :   Added field IsAllPartMapped for Customer Product Number mapping check
                   :   [29-Jul-2022] : Shahab Ashraf
                   :   Set nullable field IsAllPartMapped for because column moved to edidetail table
*                  :   [28-Oct-2022] : Sejal Srivastava
*                  :   [] : Increased MessageType length from 6 to 8 characters 
*                  :   [04-Nov-2022] : Prakhar
*                  :   [] : Added new column IsCustomerIdentified 
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
    [DataContract, Serializable]
    public class EDIMessageHeaderModel : BaseModel<Guid>
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

        private Guid _ediMessageSourceId;
        /// <summary>
        /// Get or Set for {EDIMessageSourceId}.
        /// </summary>
        [DataMember]
        public Guid EDIMessageSourceId
        {
            get => _ediMessageSourceId;
            set => SetProperty(ref _ediMessageSourceId, value);
        }


        private int _ediFileCreationDate;
        /// <summary>
        /// Get or Set for {EDIFileCreationDate}.
        /// </summary>
        [DataMember]
        public int EDIFileCreationDate
        {
            get => _ediFileCreationDate;
            set => SetProperty(ref _ediFileCreationDate, value);
        }


        private int _ediFileCreationTime;
        /// <summary>
        /// Get or Set for {EDIFileCreationTime}.
        /// </summary>
        [DataMember]
        public int EDIFileCreationTime
        {
            get => _ediFileCreationTime;
            set => SetProperty(ref _ediFileCreationTime, value);
        }


        private string _workStationCode;
        /// <summary>
        /// Get or Set for {WorkStationCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string WorkStationCode
        {
            get => _workStationCode;
            set => SetProperty(ref _workStationCode, value);
        }


        private string _interchangeControlNumber;
        /// <summary>
        /// Get or Set for {InterchangeControlNumber}.
        /// </summary>
        [DataMember]
        [StringLength(14)]
        public string InterchangeControlNumber
        {
            get => _interchangeControlNumber;
            set => SetProperty(ref _interchangeControlNumber, value);
        }


        private string _applicationReference;
        /// <summary>
        /// Get or Set for {ApplicationReference}.
        /// </summary>
        [DataMember]
        [StringLength(14)]
        public string ApplicationReference
        {
            get => _applicationReference;
            set => SetProperty(ref _applicationReference, value);
        }

        private string _messageReferenceNo;
        /// <summary>
        /// Get or Set for {MessageReferenceNo}.
        /// </summary>
        [DataMember]
        [StringLength(14)]
        public string MessageReferenceNo
        {
            get => _messageReferenceNo;
            set => SetProperty(ref _messageReferenceNo, value);
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
            set => SetProperty(ref _messageType, value);
        }

        private string _messageReleaseNumber;
        /// <summary>
        /// Get or Set for {MessageReleaseNumber}.
        /// </summary>
        [DataMember]
        [StringLength(3)]
        public string MessageReleaseNumber
        {
            get => _messageReleaseNumber;
            set => SetProperty(ref _messageReleaseNumber, value);
        }

        private string _messageNumber;
        /// <summary>
        /// Get or Set for {MessageNumber}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string MessageNumber
        {
            get => _messageNumber;
            set => SetProperty(ref _messageNumber, value);
        }

        private string _accountNumber;
        /// <summary>
        /// Get or Set for {AccountNumber}.
        /// </summary>
        [DataMember]
        [StringLength(70)]
        public string AccountNumber
        {
            get => _accountNumber;
            set => SetProperty(ref _accountNumber, value);
        }
        private string _transportRoute;
        /// <summary>
        /// Get or Set for {TransportRoute}.
        /// </summary>
        [DataMember]
        [StringLength(70)]
        public string TransportRoute
        {
            get => _transportRoute;
            set => SetProperty(ref _transportRoute, value);
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

        private string _buyerName;
        /// <summary>
        /// Get or Set for {BuyerCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string BuyerName
        {
            get => _buyerName;
            set => SetProperty(ref _buyerName, value);
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

        private string _unloadingPoint;
        /// <summary>
        /// Get or Set for {UnloadingPoint}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string UnloadingPoint
        {
            get => _unloadingPoint;
            set => SetProperty(ref _unloadingPoint, value);
        }
        private string _vehicleIdentificationNumber;
        /// <summary>
        /// Get or Set for {VehicleIdentificationNumber}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string VehicleIdentificationNumber
        {
            get => _vehicleIdentificationNumber;
            set => SetProperty(ref _vehicleIdentificationNumber, value);
        }

        private string _orderNumber;
        /// <summary>
        /// Get or Set for {VehicleIdentificationNumber}.
        /// </summary>
        [DataMember]
        [StringLength(70)]
        public string OrderNumber
        {
            get => _orderNumber;
            set => SetProperty(ref _orderNumber, value);
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

        private bool _isCustomerMapped;
        /// <summary>
        /// Get or Set for {IsCustomerMapped}.
        /// </summary>
        [DataMember]
        [Required]
        public bool IsCustomerMapped
        {
            get => _isCustomerMapped;
            set => SetProperty(ref _isCustomerMapped, value);
        }
        private bool _isMessageDiscarded;
        /// <summary>
        /// Get or Set for {IsMessageDiscarded}.
        /// </summary>
        [DataMember]
        [Required]
        public bool IsMessageDiscarded
        {
            get => _isMessageDiscarded;
            set => SetProperty(ref _isMessageDiscarded, value);
        }

        private bool _supplyChainFlag;
        /// <summary>
        /// Get or Set for {SupplyChainFlag}.
        /// </summary>
        [DataMember]
        [Required]
        public bool SupplyChainFlag
        {
            get => _supplyChainFlag;
            set => SetProperty(ref _supplyChainFlag, value);
        }

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
            set => SetProperty(ref _ediMessageFileName, value);
        }

        private DateTime _batchStamp;
        /// <summary>
        /// This field will set BatchStamp
        /// </summary>
        [DataMember]
        [Required]
        public DateTime BatchStamp
        {
            get => _batchStamp;
            set => SetProperty(ref _batchStamp, value);
        }


        private Guid _batchId;
        /// <summary>
        /// Get or Set for {BatchId}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BatchId
        {
            get => _batchId;
            set => SetProperty(ref _batchId, value);
        }

        private bool? _isAllPartMapped;
        /// <summary>
        /// Get or Set for {IsAllPartMapped}.
        /// </summary>
        [DataMember]
        public bool? IsAllPartMapped
        {
            get => _isAllPartMapped;
            set => SetProperty(ref _isAllPartMapped, value);
        }

        private bool _isCustomerIdentified;
        [DataMember]
        public bool IsCustomerIdentified
        {
            get => _isCustomerIdentified;
            set => SetProperty(ref _isCustomerIdentified, value);
        }
    }

}