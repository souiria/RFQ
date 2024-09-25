/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ManualDemandDocumentStatusReviewModel.cs
Function           :   Manual Document Design Status 
Created By         :   Sejal Srivastava
Created on         :   20-Apr-2022
Revision History   :   [12-May-2022] : Sejal Srivastava
*                  :   [] : Added UnloadingPoint 
*                  :   [30-Aug-2022] : Sejal Srivastava
*                  :   [] : Changes w.r.t allowing entry of data at family level, i.e added documentType, familyName
*                  :   [04-Apr-2022] : Ranjay
*                  :   [HD-00377175] Added new field ProjectName
*                  :   [02-Feb-2024] : Sachin 
                   :   [HD-00394058] : Lock During DRP run(Added ViewName Property) .
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract for ManualDemandDocumentStatusReview
    /// </summary>
    [DataContract, Serializable]
    public class ManualDemandDocumentStatusReviewModel : BaseModel<Guid>
    {
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
            set => SetProperty(ref _customerDeliveryPointGuid, value);
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
            set => SetProperty(ref _customerBusinessGroupGuid, value);
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
            set => SetProperty(ref _customerGuid, value);
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
        /// Local variable _projectName     
        /// </summary>
        private string _projectName;
        /// <summary>
        /// Get or Set for {ProjectName}.
        /// </summary>
        [DataMember]
        public string ProjectName
        {
            get => _projectName;
            set => _projectName = value;
        }

        /// <summary>
        /// Local variable _documentId     
        /// </summary>
        private string _documentId;
        /// <summary>
        /// Get or Set for {DocumentId}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DocumentId
        {
            get => _documentId;
            set => SetProperty(ref _documentId, value);
        }

        /// <summary>
        /// Local variable _fromDate     
        /// </summary>
        private DateTime? _fromDate;
        /// <summary>
        /// Get or Set for {FromDate}.
        /// </summary>
        [DataMember]
        public DateTime? FromDate
        {
            get => _fromDate;
            set => SetProperty(ref _fromDate, value);
        }

        /// <summary>
        /// Local variable _toDate     
        /// </summary>
        private DateTime? _toDate;
        /// <summary>
        /// Get or Set for {ToDate}.
        /// </summary>
        [DataMember]
        public DateTime? ToDate
        {
            get => _toDate;
            set => SetProperty(ref _toDate, value);
        }

        /// <summary>
        /// Local variable _reasonForRequest     
        /// </summary>
        private string _reasonForRequest;
        /// <summary>
        /// Get or Set for {ReasonForRequest}.
        /// </summary>
        [DataMember]
        [StringLength(150)]
        public string ReasonForRequest
        {
            get => _reasonForRequest;
            set => SetProperty(ref _reasonForRequest, value);
        }

        /// <summary>
        /// Local variable _status     
        /// </summary>
        private string _status;
        /// <summary>
        /// Get or Set for {Status}.
        /// </summary>
        [DataMember]
        [StringLength(25)]
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        /// <summary>
        /// Local variable _action     
        /// </summary>
        private string _action;
        /// <summary>
        /// Get or Set for {Action}.
        /// </summary>
        [DataMember]
        [StringLength(25)]
        public string Action
        {
            get => _action;
            set => SetProperty(ref _action, value);
        }

        /// <summary>
        /// Local variable _comments     
        /// </summary>
        private string _comments;
        /// <summary>
        /// Get or Set for {Comments}.
        /// </summary>
        [DataMember]
        [StringLength(150)]
        public string Comments
        {
            get => _comments;
            set => SetProperty(ref _comments, value);
        }

        private List<ManualDemandDocumentStatusReviewChildModel> _manualDemandDocumentStatusReviewChild;
        /// <summary>
        /// _manualDemandDocumentStatusReviewChild
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public List<ManualDemandDocumentStatusReviewChildModel> ManualDemandDocumentStatusReviewChild
        {
            get => _manualDemandDocumentStatusReviewChild;
            set => SetProperty(ref _manualDemandDocumentStatusReviewChild, value);
        }

        /// <summary>
        /// Local variable _customerBusinessGroupName     
        /// </summary>
        private string _customerBusinessGroupName;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupName}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string CustomerBusinessGroupName
        {
            get => _customerBusinessGroupName;
            set => SetProperty(ref _customerBusinessGroupName, value);
        }

        /// <summary>
        /// Local variable _customerName     
        /// </summary>
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

        /// <summary>
        /// Local variable _customerDeliveryPoint     
        /// </summary>
        private string _customerDeliveryPoint;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPoint}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string CustomerDeliveryPoint
        {
            get => _customerDeliveryPoint;
            set => SetProperty(ref _customerDeliveryPoint, value);
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
        /// Local variable _viewName     
        /// </summary>
        private string _viewName;
        /// <summary>
        /// Get or Set for {ViewName}.
        /// </summary>
        [NotMapped, DataMember]
        public string ViewName
        {
            get => _viewName;
            set => _viewName = value;
        }
    }

    /// <summary>
    /// _manualDemandDocumentStatusReviewChildModel
    /// </summary>
    [DataContract, Serializable]
    public class ManualDemandDocumentStatusReviewChildModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _manualDemandDocumentGuid     
        /// </summary>
        private Guid _manualDemandDocumentGuid;
        /// <summary>
        /// Get or Set for {ManualDemandDocumentGuid}.
        /// </summary>
        [DataMember]
        public Guid ManualDemandDocumentGuid
        {
            get => _manualDemandDocumentGuid;
            set => SetProperty(ref _manualDemandDocumentGuid, value);
        }

        private string _partNumber;
        /// <summary>
        /// PartNumber
        /// </summary>
        [DataMember]
        [StringLength(18)]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        /// <summary>
        /// Local variable _familyName     
        /// </summary>
        private string _familyName;
        /// <summary>
        /// Get or Set for {Family}.
        /// </summary>
        [DataMember]
        public string FamilyName
        {
            get => _familyName;
            set => SetProperty(ref _familyName, value);
        }
        private DateTime? _demandDate;
        /// <summary>
        /// _demandDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? DemandDate
        {
            get => _demandDate;
            set => SetProperty(ref _demandDate, value);
        }

        private int? _ediDemandQuantity;
        /// <summary>
        /// EdiDemandQuantity
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int? EdiDemandQuantity
        {
            get => _ediDemandQuantity;
            set => SetProperty(ref _ediDemandQuantity, value);
        }

        private int? _manualDemandQuantity;
        /// <summary>
        /// Manual
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int? ManualDemandQuantity
        {
            get => _manualDemandQuantity;
            set => SetProperty(ref _manualDemandQuantity, value);
        }

    }

    /// <summary>
    /// Class File for ManualDemandDocumentStatusFilterModel
    /// </summary>
    [DataContract, Serializable]
    public class ManualDemandDocumentStatusFilterModel
    {
        private string _p_ManualDemandStatus;
        /// <summary>
        /// Get or Set for {_p_ManualDemandStatus}.
        /// </summary>
        [DataMember]
        public string P_ManualDemandStatus
        {
            get => _p_ManualDemandStatus;
            set => _p_ManualDemandStatus = value;
        }

    }


    /// <summary>
    /// Data Contract for ManualDemandDocumentStatusReview
    /// </summary>
    [DataContract, Serializable]
    public class ManualDemandDocumentStatusReviewSaveModel : BaseModel<Guid>
    {
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
            set => SetProperty(ref _customerDeliveryPointGuid, value);
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
            set => SetProperty(ref _customerBusinessGroupGuid, value);
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
            set => SetProperty(ref _customerGuid, value);
        }
        /// <summary>
        /// Local variable _documentId     
        /// </summary>
        private string _documentId;
        /// <summary>
        /// Get or Set for {DocumentId}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DocumentId
        {
            get => _documentId;
            set => SetProperty(ref _documentId, value);
        }
        /// <summary>
        /// Local variable _fromDate     
        /// </summary>
        private DateTime? _fromDate;
        /// <summary>
        /// Get or Set for {FromDate}.
        /// </summary>
        [DataMember]
        public DateTime? FromDate
        {
            get => _fromDate;
            set => SetProperty(ref _fromDate, value);
        }

        /// <summary>
        /// Local variable _toDate     
        /// </summary>
        private DateTime? _toDate;
        /// <summary>
        /// Get or Set for {ToDate}.
        /// </summary>
        [DataMember]
        public DateTime? ToDate
        {
            get => _toDate;
            set => SetProperty(ref _toDate, value);
        }
        /// <summary>
        /// Local variable _expiryDate     
        /// </summary>
        private DateTime? _expiryDate;
        /// <summary>
        /// Get or Set for {ExpiryDate}.
        /// </summary>
        [DataMember]
        public DateTime? ExpiryDate
        {
            get => _expiryDate;
            set => SetProperty(ref _expiryDate, value);
        }
        /// <summary>
        /// Local variable _creationDate     
        /// </summary>
        private DateTime? _creationDate;
        /// <summary>
        /// Get or Set for {ExpiryDate}.
        /// </summary>
        [DataMember]
        public DateTime? CreationDate
        {
            get => _creationDate;
            set => SetProperty(ref _creationDate, value);
        }
        /// <summary>
        /// Local variable _rank     
        /// </summary>
        private string _rank;
        /// <summary>
        /// Get or Set for {Rank}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Rank
        {
            get => _rank;
            set => SetProperty(ref _rank, value);
        }
        /// <summary>
        /// Local variable _reasonForRequest     
        /// </summary>
        private string _reasonForRequest;
        /// <summary>
        /// Get or Set for {ReasonForRequest}.
        /// </summary>
        [DataMember]
        [StringLength(150)]
        public string ReasonForRequest
        {
            get => _reasonForRequest;
            set => SetProperty(ref _reasonForRequest, value);
        }
        /// <summary>
        /// Local variable _status     
        /// </summary>
        private string _status;
        /// <summary>
        /// Get or Set for {Status}.
        /// </summary>
        [DataMember]
        [StringLength(25)]
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }
        /// <summary>
        /// Local variable _action     
        /// </summary>
        private string _action;
        /// <summary>
        /// Get or Set for {Action}.
        /// </summary>
        [DataMember]
        [StringLength(25)]
        public string Action
        {
            get => _action;
            set => SetProperty(ref _action, value);
        }
        /// <summary>
        /// Local variable _comments     
        /// </summary>
        private string _comments;
        /// <summary>
        /// Get or Set for {Comments}.
        /// </summary>
        [DataMember]
        [StringLength(150)]
        public string Comments
        {
            get => _comments;
            set => SetProperty(ref _comments, value);
        }


    }

    /// <summary>
    /// Data Contract for ManualDemandDocumentStatusReview
    /// </summary>
    [DataContract, Serializable]
    public class ManualDemandDocumentStatusReviewUpdateModel : BaseModel<Guid>
    {
       
        /// <summary>
        /// Local variable _documentId     
        /// </summary>
        private string _documentId;
        /// <summary>
        /// Get or Set for {DocumentId}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DocumentId
        {
            get => _documentId;
            set => SetProperty(ref _documentId, value);
        }      
     
        /// <summary>
        /// Local variable _action     
        /// </summary>
        private string _action;
        /// <summary>
        /// Get or Set for {Action}.
        /// </summary>
        [DataMember]
        [StringLength(25)]
        public string Action
        {
            get => _action;
            set => SetProperty(ref _action, value);
        }
        /// <summary>
        /// Local variable _comments     
        /// </summary>
        private string _comments;
        /// <summary>
        /// Get or Set for {Comments}.
        /// </summary>
        [DataMember]
        [StringLength(150)]
        public string Comments
        {
            get => _comments;
            set => SetProperty(ref _comments, value);
        }

    }

}
