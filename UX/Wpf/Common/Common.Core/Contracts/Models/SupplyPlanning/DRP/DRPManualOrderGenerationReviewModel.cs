/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DRPManualOrderGenerationModel.cs
Function           :   DRP Manual Order Generation
Created By         :   Ranjay
Created on         :   20-Sep-2023 [HD-00365855]
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning.DRP
{
    /// <summary>
    /// Data Contract use for DRP Manual Order Generation Review
    /// </summary>
    [DataContract, Serializable]
    public class DRPManualOrderGenerationReviewModel : BaseModel<Guid>
    {
        private string _documentId;
        /// <summary>
        /// Get or Set for {DocumentId}.
        /// </summary>
        [DataMember]
        public string DocumentId
        {
            get => _documentId;
            set => SetProperty(ref _documentId, value);
        }

        private string _dcLocation;
        /// <summary>
        /// Get or Set for {DCLocation}.
        /// </summary>
        [DataMember]
        public string DCLocation
        {
            get => _dcLocation;
            set => SetProperty(ref _dcLocation, value);
        }

        private string _manufacturingSite;
        /// <summary>
        /// Get or Set for {ManufacturingSite}.
        /// </summary>
        [DataMember]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => SetProperty(ref _manufacturingSite, value);
        }

        private DateTime? _createdDateInGrid;
        /// <summary>
        /// Get or Set for {CreatedDateInGrid}.
        /// </summary>
        [DataMember]
        public DateTime? CreatedDateInGrid
        {
            get => _createdDateInGrid;
            set => SetProperty(ref _createdDateInGrid, value);
        }

        private string _documentStatus;
        /// <summary>
        /// Get or Set for {DocumentStatus}.
        /// </summary>
        [DataMember]
        public string DocumentStatus
        {
            get => _documentStatus;
            set => SetProperty(ref _documentStatus, value);
        }

        private string _action;
        /// <summary>
        /// Get or Set for {Action}.
        /// </summary>
        [DataMember]
        public string Action
        {
            get => _action;
            set => SetProperty(ref _action, value);
        }

        private List<DRPManualOrderGenerationReviewChildModel> _drpManualOrderGenerationReviewChildModel;
        /// <summary>
        /// Get or Set for {DRPManualOrderGenerationReviewChildModel}.
        /// </summary>
        [DataMember]
        public List<DRPManualOrderGenerationReviewChildModel> DRPManualOrderGenerationReviewChildModel
        {
            get => _drpManualOrderGenerationReviewChildModel;
            set => SetProperty(ref _drpManualOrderGenerationReviewChildModel, value);
        }

        private string _comments;
        /// <summary>
        /// Get or Set for {Comments}.
        /// </summary>
        [DataMember]
        public string Comments
        {
            get => _comments;
            set => SetProperty(ref _comments, value);
        }
    }

    [DataContract, Serializable]
    public class DRPManualOrderGenerationReviewChildModel : BaseModel<Guid>
    {
     
        private DateTime? _receiveDate;
        /// <summary>
        /// Get or Set for {ReceiveDate}.
        /// </summary>
        [DataMember]
        public DateTime? ReceiveDate
        {
            get => _receiveDate;
            set => SetProperty(ref _receiveDate, value);
        }

        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        private int? _orderQuantity;
        /// <summary>
        /// Get or Set for {OrderQuantity}.
        /// </summary>
        [DataMember]
        public int? OrderQuantity
        {
            get => _orderQuantity;
            set => SetProperty(ref _orderQuantity, value);
        }

        private string _reasonForRequest;
        /// <summary>
        /// Get or Set for {ReasonForRequest}.
        /// </summary>
        [DataMember]
        public string ReasonForRequest
        {
            get => _reasonForRequest;
            set => _reasonForRequest = value;
        }
    }

    /// <summary>
    /// Data Contract use for Process DRP Manual Order Generation Review
    /// </summary>
    [DataContract, Serializable]
    public class ProcessDRPManualOrderGenerationReviewModel
    {
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

        private string _action;
        /// <summary>
        /// Get or Set for {Action}.
        /// </summary>
        [DataMember]
        public string Action
        {
            get => _action;
            set => _action = value;
        }

        private string _comments;
        /// <summary>
        /// Get or Set for {Comments}.
        /// </summary>
        [DataMember]
        public string Comments
        {
            get => _comments;
            set => _comments = value;
        }

        private DateTime _modifiedDate;
        /// <summary>
        /// Get or Set for {ModifiedDate}.
        /// </summary>
        [DataMember]
        public DateTime ModifiedDate
        {
            get => _modifiedDate;
            set => _modifiedDate = value;
        }

        private Guid _modifiedBy;
        /// <summary>
        /// Get or Set for {ModifiedBy}.
        /// </summary>
        [DataMember]
        public Guid ModifiedBy
        {
            get => _modifiedBy;
            set => _modifiedBy = value;
        }

    }
}
