/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDIMessageDataModel.cs
Function           :   EDI Message Model
Created By         :   Dharmendra 
Created on         :   17-Nov-2022
Revision History   : 
****************************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    [DataContract, Serializable]
  public  class EDIMessageDataModel
    {
        private Guid _id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id=value;
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
        private int _isCustomerIdentified;
        [DataMember]
        public int IsCustomerIdentified
        {
            get => _isCustomerIdentified;
            set => _isCustomerIdentified = value;
        }
        private int _isAllPartMapped;
        [DataMember]
        public int IsAllPartMapped
        {
            get => _isAllPartMapped;
            set => _isAllPartMapped = value;
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
        private int _isCustomerDemandMapped;
        [DataMember]
        public int IsCustomerDemandMapped
        {
            get => _isCustomerDemandMapped;
            set => _isCustomerDemandMapped = value;
        }
    }
}
