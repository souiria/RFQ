/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   YokotenreplyModel.cs
Function           :   Data contract for Yokoten Reply
Created By         :   Shivam Dhingra
Created on         :   24-March-2020
Revision History   :   [27-Mar-2020] Shivam Dhingra
                   :   [] Removed ForwardSite and added BusinessUnitGuid  
                   :   [02-Jun-2020] Pawan
                   :   [] Changed datatype of DocumentList for upload to server
                   :   [04-July-2020] Srashti Gupta
                   :   [] Added Model ReplyDetails
                   :   [06-July-2020] Pawan
                   :   [] Added field for TypeGuid & ReportGuid
                   :   [07-July-2020] Pawan
                   :   [] Added data contract for view reply
                   :   [09-July-2020] Pawan
                   :   [] Added field for IsReplyCompleted
                   :   [10-July-2020] Pawan
                   :   [] Added field for CreatedDate
                   :   [21-July-2020] Srashti Gupta
                   :   [] Added field for CompletedPercentage
                   :   [21-July-2020] Pawan
                   :   [] Modified model for reply detail
                   :   [08-July-2021] Ashish
                   :   [] Modified model for reply detail
                   :   [20-Dec-2022] Prakhar
                   :   [] Added new Model ResetReplyProgress
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    [DataContract, Serializable]
    public class YokotenReplyModel : BaseModel<Guid>
    {
        private Guid _reportGuid;
        /// <summary>
        /// Get or Set for {ReportId}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid ReportGuid
        {
            get => _reportGuid;
            set => SetProperty(ref _reportGuid, value);
        }

        private string _reportCompletedBy;
        /// <summary>
        /// This field will set ReportCompletedBy
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ReportCompletedBy
        {
            get => _reportCompletedBy;
            set => SetProperty(ref _reportCompletedBy, value);
        }

        private DateTime _completedDate;
        /// <summary>
        /// This field will set CompletedDate
        /// </summary>
        [DataMember]
        [Required]
        public DateTime CompletedDate
        {
            get => _completedDate;
            set => SetProperty(ref _completedDate, value);
        }

        private List<ActionModel> _actionList;
        /// <summary>
        /// Gets of Sets the value of ActionList
        /// </summary>
        [DataMember]
        public List<ActionModel> ActionList
        {
            get => _actionList;
            set => SetProperty(ref _actionList, value);
        }

        private List<ActionModel> _additionalActionList;
        /// <summary>
        /// Gets of Sets the value of AdditionalActionList
        /// </summary>
        [DataMember]
        public List<ActionModel> AdditionalActionList
        {
            get => _additionalActionList;
            set => SetProperty(ref _additionalActionList, value);
        }

        private List<FileUploadModel> _documentList;
        /// <summary>
        /// This field will set DocumentList
        /// </summary>
        [DataMember]
        public List<FileUploadModel> DocumentList
        {
            get => _documentList;
            set => SetProperty(ref _documentList, value);
        }

        private Guid _businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private string _type;
        /// <summary>
        /// This field will set Type
        /// </summary>
        [DataMember]
        public string Type
        {
            get => _type;
            set => _type = value;
        }

        private Guid _typeGuid;
        /// <summary>
        /// This field will set TypeGuid
        /// </summary>
        [DataMember]
        public Guid TypeGuid
        {
            get => _typeGuid;
            set => _typeGuid = value;
        }

        /// <summary>
        /// Local Reference of IsReplyCompleted
        /// </summary>
        private bool _isReplyCompleted = false;
        /// <summary>
        /// Is IsReply Completed
        /// </summary>
        [DataMember]
        public bool IsReplyCompleted
        {
            get => _isReplyCompleted;
            set => SetProperty(ref _isReplyCompleted, value);
        }
    }
    /// <summary>
    /// Data contract for Reply Details
    /// </summary>
    [DataContract, Serializable]
    public class ReplyDetails
    {
        private string _type;
        /// <summary>
        /// This field will set Type
        /// </summary>
        [DataMember]
        public string Type
        {
            get => _type;
            set => _type = value;
        }
        private Guid _userGuid;
        /// <summary>
        /// This field will set UserGuid
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }
        private string _typeValue;
        /// <summary>
        /// This field will set TypeValue
        /// </summary>
        [DataMember]
        public string TypeValue
        {
            get => _typeValue;
            set => _typeValue = value;
        }

        private Guid _typeGuid;
        /// <summary>
        /// This field will set TypeGuid
        /// </summary>
        [DataMember]
        public Guid TypeGuid
        {
            get => _typeGuid;
            set => _typeGuid = value;
        }
        private string _userRole;
        /// <summary>
        /// This field will set UserRole
        /// </summary>
        [DataMember]
        public string UserRole
        {
            get => _userRole;
            set => _userRole = value;
        }
        private string _yokotenNumber;
        /// <summary>
        /// This field will set YokotenNumber
        /// </summary>
        [DataMember]
        public string YokotenNumber
        {
            get => _yokotenNumber;
            set => _yokotenNumber = value;
        }

        private string _completedPercentage;
        /// <summary>
        /// This field will set CompletedPercentage
        /// </summary>
        [DataMember]
        public string CompletedPercentage
        {
            get => _completedPercentage;
            set => _completedPercentage = value;
        }

        private string _isnotifiedview;
        /// <summary>
        /// This field will set CompletedPercentage
        /// </summary>
        [DataMember]
        public string IsNotifiedView
        {
            get => _isnotifiedview;
            set => _isnotifiedview = value;
        }

        private bool _isReplyExists;
        /// <summary>
        /// This field will set IsReplyExists
        /// </summary>
        [DataMember]
        public bool IsReplyExists
        {
            get => _isReplyExists;
            set => _isReplyExists = value;
        }

        private Guid _reportGuid;
        /// <summary>
        /// This field will set ReportGuid
        /// </summary>
        [DataMember]
        public Guid ReportGuid
        {
            get => _reportGuid;
            set => _reportGuid = value;
        }

        private List<ActionModel> _actionList;
        /// <summary>
        /// Gets of Sets the value of ActionList
        /// </summary>
        [DataMember]
        public List<ActionModel> ActionList
        {
            get => _actionList;
            set => _actionList = value;
        }
    }

    /// <summary>
    /// Data contract for View Reply Details
    /// </summary>
    [DataContract, Serializable]
    public class ViewReplyDetails
    {
        private string _type;
        /// <summary>
        /// This field will set Type
        /// </summary>
        [DataMember]
        public string Type
        {
            get => _type;
            set => _type = value;
        }
        private string _typeValue;
        /// <summary>
        /// This field will set TypeValue
        /// </summary>
        [DataMember]
        public string TypeValue
        {
            get => _typeValue;
            set => _typeValue = value;
        }

        private Guid _typeGuid;
        /// <summary>
        /// This field will set TypeGuid
        /// </summary>
        [DataMember]
        public Guid TypeGuid
        {
            get => _typeGuid;
            set => _typeGuid = value;
        }
        private string _yokotenNumber;
        /// <summary>
        /// This field will set YokotenNumber
        /// </summary>
        [DataMember]
        public string YokotenNumber
        {
            get => _yokotenNumber;
            set => _yokotenNumber = value;
        }

        private Guid _reportGuid;
        /// <summary>
        /// This field will set ReportGuid
        /// </summary>
        [DataMember]
        public Guid ReportGuid
        {
            get => _reportGuid;
            set => _reportGuid = value;
        }

        private Guid _replyGuid;
        /// <summary>
        /// This field will set ReplyGuid
        /// </summary>
        [DataMember]
        public Guid ReplyGuid
        {
            get => _replyGuid;
            set => _replyGuid = value;
        }

        private string _reportCompletedBy;
        /// <summary>
        /// This field will set ReportCompletedBy
        /// </summary>
        [DataMember]
        public string ReportCompletedBy
        {
            get => _reportCompletedBy;
            set => _reportCompletedBy = value;
        }

        private DateTime _completedDate;
        /// <summary>
        /// This field will set CompletedDate
        /// </summary>
        [DataMember]
        public DateTime CompletedDate
        {
            get => _completedDate;
            set => _completedDate = value;
        }

        private List<ActionModel> _actionList;
        /// <summary>
        /// Gets of Sets the value of ActionList
        /// </summary>
        [DataMember]
        public List<ActionModel> ActionList
        {
            get => _actionList;
            set => _actionList = value;
        }

        private List<ActionModel> _additionalActionList;
        /// <summary>
        /// Gets of Sets the value of AdditionalActionList
        /// </summary>
        [DataMember]
        public List<ActionModel> AdditionalActionList
        {
            get => _additionalActionList;
            set => _additionalActionList = value;
        }

        private List<FileUploadModel> _documentList;
        /// <summary>
        /// This field will set DocumentList
        /// </summary>
        [DataMember]
        public List<FileUploadModel> DocumentList
        {
            get => _documentList;
            set => _documentList = value;
        }
        /// <summary>
        /// Local Reference of IsReplyCompleted
        /// </summary>
        private bool _isReplyCompleted = false;
        /// <summary>
        /// Is Reply Completed
        /// </summary>
        [DataMember]
        public bool IsReplyCompleted
        {
            get => _isReplyCompleted;
            set => _isReplyCompleted = value;
        }
        /// <summary>
        /// Local Reference of CreatedDate
        /// </summary>
        private DateTime _createdDate;
        /// <summary>
        /// Created Date
        /// </summary>
        [DataMember]
        public DateTime CreatedDate
        {
            get => _createdDate;
            set => _createdDate = value;
        }

        /// <summary>
        /// Local Reference of CompletedPercentage
        /// </summary>
        private string _completedPercentage;
        /// <summary>
        /// CompletedPercentage
        /// </summary>
        [DataMember]
        public string CompletedPercentage
        {
            get => _completedPercentage;
            set => _completedPercentage = value;
        }

       
    }
    //prakhar

    public class ResetReplyProgress : BaseModel<Guid>
    {
        private Guid _reportGuid;
        /// <summary>
        /// Get or Set for {ReportId}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid ReportGuid
        {
            get => _reportGuid;
            set => SetProperty(ref _reportGuid, value);
        }


    }
    //prakhar
}
