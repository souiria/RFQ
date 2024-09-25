/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ManualDemandDocumentDesignModel.cs
Function           :  
Created By         :   Ranjay
Created on         :   18-Apr-2022
Revision History   :   [12-May-2022] : Sejal Srivastava
*                  :   [] : Added UnloadingPoint 
*                  :   [30-Aug-2022] : Sejal Srivastava
*                  :   [] : Added DocumentType 
*                  :   [03-Apr-2023] : Ranjay
*                  :   [HD-00377175] Added ProjectGuid field
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for DaysOfDemandSettings Service
    /// </summary>
    [DataContract, Serializable]
    public class ManualDemandDocumentDesignModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _DocumentId     
        /// </summary>
        private string _documentId;
        /// <summary>
        /// Get or Set for {DocumentId}.
        /// </summary>
        [DataMember]
        public string DocumentId
        {
            get => _documentId;
            set => _documentId = value;
        }
        /// <summary>
        /// Local variable _customerBusinessGroupGuid     
        /// </summary>
        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => _customerBusinessGroupGuid = value;
        }
        /// <summary>
        /// Local variable _customerGuid     
        /// </summary>
        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }
        /// <summary>
        /// Local variable _customerDeliveryPointGuid     
        /// </summary>
        private Guid _customerDeliveryPointGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerDeliveryPointGuid
        {
            get => _customerDeliveryPointGuid;
            set => _customerDeliveryPointGuid = value;
        }
        /// <summary>
        /// Local variable _fromDate     
        /// </summary>
        private DateTime _fromDate;
        /// <summary>
        /// Get or Set for {FromDate}.
        /// </summary>
        [DataMember, DataType(DataType.DateTime)]
        public DateTime FromDate
        {
            get => _fromDate;
            set => _fromDate = value;
        }
        /// <summary>
        /// Local variable _toDate     
        /// </summary>
        private DateTime _toDate;
        /// <summary>
        /// Get or Set for {ToDate}.
        /// </summary>
        [DataMember, DataType(DataType.DateTime)]
        public DateTime ToDate
        {
            get => _toDate;
            set => _toDate = value;
        }
        /// <summary>
        /// Local variable _expiryDate     
        /// </summary>
        private DateTime? _expiryDate;
        /// <summary>
        /// Get or Set for {ExpiryDate}.
        /// </summary>
        [DataMember, DataType(DataType.DateTime)]
        public DateTime ExpiryDate
        {
            get => _expiryDate ?? DateTime.UtcNow;
            set => SetProperty(ref _expiryDate, value);
        }
        /// <summary>
        /// Local variable _rank     
        /// </summary>
        private string _rank;
        /// <summary>
        /// Get or Set for {Rank}.
        /// </summary>
        [DataMember]
        public string Rank
        {
            get => _rank;
            set => _rank = value;
        }
        /// <summary>
        /// Local variable _creationDate     
        /// </summary>
        private DateTime _creationDate;
        /// <summary>
        /// Get or Set for {CreationDate}.
        /// </summary>
        [DataMember, DataType(DataType.DateTime)]
        public DateTime CreationDate
        {
            get => _creationDate;
            set => _creationDate = value;
        }
        /// <summary>
        /// Local variable _status     
        /// </summary>
        private string _status;
        /// <summary>
        /// Get or Set for {Status}.
        /// </summary>
        [DataMember]
        public string Status
        {
            get => _status;
            set => _status = value;
        }

        /// <summary>
        /// Local variable _unloadingPoint     
        /// </summary>
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

        /// <summary>
        /// Local variable _documentType     
        /// </summary>
        private string _documentType;
        /// <summary>
        /// Get or Set for {DocumentType}.
        /// </summary>
        [DataMember]
        public string DocumentType
        {
            get => _documentType;
            set => _documentType = value;
        }

        /// <summary>
        /// Local variable ProjectGuid     
        /// </summary>
        private Guid _projectGuid;
        /// <summary>
        /// Get or Set for {ProjectGuid}.
        /// </summary>
        [DataMember]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => _projectGuid = value;
        }
    }

    public class ManualDemandDocumentDesignRank 
    {
        /// <summary>
        /// Local variable _rank     
        /// </summary>
        private string _rank;
        /// <summary>
        /// Get or Set for {Rank}.
        /// </summary>
        [DataMember]
        public string Rank
        {
            get => _rank;
            set => _rank = value;
        }
    }
}
