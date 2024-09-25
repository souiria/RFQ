/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ReportSection2Model.cs
Function           :   Data contract for Report Section2
Created By         :   Srashti Gupta
Created on         :   12-March-2020
Revision History   :   [13-March-2020] : Srashti Gupta
*                  :   Change the enum values for PhotoType
*                  :   [04-May-2020] : Shivam Dhingra
*                  :   Added new properties : QCFeedback,ActionOnQCFeedback,ActionOnQCFeedback
*                  :   [06-May-2020] : Amit
*                  :   Good and Bad Image processed
*                  :   [04-Jun-2020] : Pawan
*                  :   Added field for Customer Business Group Inform and Reply
*                  :   [16-Jun-2020] : Pawan
*                  :   Added field for group defined in Yokoten Parameter Settings for Inform and Reply
*                  :   [19-Jun-2020] : Srashti
*                  :   Added field for RootCause, CounterMeasure & remove existing fields
*                  :   [02-Jul-2020] : Pawan
*                  :   Added field for UserGuid in Parameter Reply
                   :   [14-May-2021] : Shivam Dhingra
*                  :   Added new columns in BussinessUnitInformReplyModel
*                  :   [31-Jan-2022] : Shivam Kalia
*                  :   Added new InformModel
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    [DataContract, Serializable]
    public class ReportSection2Model : BaseModel<Guid>
    {
        private string _concernDescription;
        /// <summary>
        /// This field will set ConcernDescription
        /// </summary>
        [DataMember]
        public string ConcernDescription
        {
            get => _concernDescription;
            set => SetProperty(ref _concernDescription, value);
        }
        
        private Dictionary<Guid, string> _yokotenAction;
        /// <summary>
        /// This field will set YokotenAction
        /// </summary>
        [DataMember]
        public Dictionary<Guid, string> YokotenAction
        {
            get => _yokotenAction;
            set => SetProperty(ref _yokotenAction, value);
        }

        private List<GroupInformReplyModel> _yokotenParameterSettingsGroupInformReply;
        /// <summary>
        /// This field will set Inform Reply for groups designed in Yokoten Parameter Settings
        /// </summary>
        [DataMember]
        public List<GroupInformReplyModel> YokotenParameterSettingsGroupInformReply
        {
            get => _yokotenParameterSettingsGroupInformReply;
            set => SetProperty(ref _yokotenParameterSettingsGroupInformReply, value);
        }

        private List<CustomerBusinessGroupInformReplyModel> _customerBusinessGroupInformReply;
        /// <summary>
        /// This field will set Inform Reply for Customer Business Group
        /// </summary>
        [DataMember]
        public List<CustomerBusinessGroupInformReplyModel> CustomerBusinessGroupInformReply
        {
            get => _customerBusinessGroupInformReply;
            set => SetProperty(ref _customerBusinessGroupInformReply, value);
        }

        private List<BussinessUnitInformReplyModel> _bussinessUnitInformReply;
        /// <summary>
        /// This field will set InformReply
        /// </summary>
        [DataMember]
        public List<BussinessUnitInformReplyModel> BussinessUnitInformReply
        {
            get => _bussinessUnitInformReply;
            set => SetProperty(ref _bussinessUnitInformReply, value);
        }

        private List<PhotoInformReplyModel> _photoList;
        /// <summary>
        /// This field will set PhotoList
        /// </summary>
        [DataMember]
        public List<PhotoInformReplyModel> PhotoList
        {
            get => _photoList;
            set => SetProperty(ref _photoList, value);
        }

        private string _qcFeedback;
        /// <summary>
        /// Get or Set for {QCFeedback}.
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string QCFeedback
        {
            get => _qcFeedback;
            set => SetProperty(ref _qcFeedback, value);
        }

        private bool _actionOnQCFeedback;
        /// <summary>
        /// Get or Set for {ActionOnQCFeedback}.
        /// </summary>
        [DataMember]
        public bool ActionOnQCFeedback
        {
            get => _actionOnQCFeedback;
            set => SetProperty(ref _actionOnQCFeedback, value);
        }

        private string _feedbackNotes;
        /// <summary>
        /// Get or Set for {FeedbackNotes}.
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string FeedbackNotes
        {
            get => _feedbackNotes;
            set => SetProperty(ref _feedbackNotes, value);
        }

        private List<RootCauseModel> _rootCause;
        /// <summary>
        /// This field will set RootCause
        /// </summary>
        [DataMember]
        public List<RootCauseModel> RootCause
        {
            get => _rootCause;
            set => SetProperty(ref _rootCause, value);
        }

        private List<CounterMeasuresModel> _counterMeasure;
        /// <summary>
        /// This field will set CounterMeasure
        /// </summary>
        [DataMember]
        public List<CounterMeasuresModel> CounterMeasure
        {
            get => _counterMeasure;
            set => SetProperty(ref _counterMeasure, value);
        }


    }

    /// <summary>
    /// List for BussinessUnitInformReply Model
    /// </summary>
    public class BussinessUnitInformReplyModel
    {
        private Guid _businessUnitGuid;
        /// <summary>
        /// This field will set BusinessUnitGuid
        /// </summary>
        public Guid BusinessUnitGuid
        {
            get { return _businessUnitGuid; }
            set { _businessUnitGuid = value; }
        }

        private bool _isInformRequired;
        /// <summary>
        /// This field will set IsInformRequired
        /// </summary>
        public bool IsInformRequired
        {
            get { return _isInformRequired; }
            set { _isInformRequired = value; }
        }

        private bool _isReplyRequired;
        /// <summary>
        /// This field will set IsReplyRequired
        /// </summary>
        public bool IsReplyRequired
        {
            get { return _isReplyRequired; }
            set { _isReplyRequired = value; }
        }

        private Guid _createdBy;
        /// <summary>
        /// This field will set CreatedBy
        /// </summary>
        public Guid CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        private DateTime _createdDate;
        /// <summary>
        /// This field will set CreatedDate
        /// </summary>
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        private string _location;
        /// <summary>
        /// This field will set Location
        /// </summary>
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

    }

    /// <summary>
    /// List for CustomerBusinessGroupInformReply Model
    /// </summary>
    public class CustomerBusinessGroupInformReplyModel
    {
        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// This field will set CustomerBusinessGroupGuid
        /// </summary>
        public Guid CustomerBusinessGroupGuid
        {
            get { return _customerBusinessGroupGuid; }
            set { _customerBusinessGroupGuid = value; }
        }

        private bool _isInformRequired;
        /// <summary>
        /// This field will set IsInformRequired
        /// </summary>
        public bool IsInformRequired
        {
            get { return _isInformRequired; }
            set { _isInformRequired = value; }
        }

        private bool _isReplyRequired;
        /// <summary>
        /// This field will set IsReplyRequired
        /// </summary>
        public bool IsReplyRequired
        {
            get { return _isReplyRequired; }
            set { _isReplyRequired = value; }
        }
    }
    /// <summary>
    /// List for GroupInformReply Model
    /// </summary>
    public class GroupInformReplyModel
    {
        private Guid _yokotenParameterSettingsGuid;
        /// <summary>
        /// This field will set YokotenParameterSettings
        /// </summary>
        public Guid YokotenParameterSettingsGuid
        {
            get { return _yokotenParameterSettingsGuid; }
            set { _yokotenParameterSettingsGuid = value; }
        }

        private bool _isInformRequired;
        /// <summary>
        /// This field will set IsInformRequired
        /// </summary>
        public bool IsInformRequired
        {
            get { return _isInformRequired; }
            set { _isInformRequired = value; }
        }

        private bool _isReplyRequired;
        /// <summary>
        /// This field will set IsReplyRequired
        /// </summary>
        public bool IsReplyRequired
        {
            get { return _isReplyRequired; }
            set { _isReplyRequired = value; }
        }

        private Guid _userGuid;
        /// <summary>
        /// This field will set UserGuid
        /// </summary>
        public Guid UserGuid
        {
            get { return _userGuid; }
            set { _userGuid = value; }
        }
    }

    /// <summary>
    /// List for BussinessUnitInformReply Model
    /// </summary>
    public class PhotoInformReplyModel
    {
        private Guid photoInformReplyId = Guid.NewGuid();
        [DataMember]
        public Guid PhotoInformReplyId { get => photoInformReplyId; set => photoInformReplyId = value; }

        private string _photoPath;
        /// <summary>
        /// This field will set PhotoName
        /// </summary>
        public string PhotoPath
        {
            get { return _photoPath; }
            set { _photoPath = value; }
        }
        private byte[] _photoContent;
        /// <summary>
        /// This field will set PhotoName
        /// </summary>
        [NotMapped, DataMember]
        public byte[] PhotoContent
        {
            get { return _photoContent; }
            set { _photoContent = value; }
        }

        private PhotoType _photoType;
        /// <summary>
        /// This field will set PhotoType
        /// </summary>
        public PhotoType PhotoType
        {
            get { return _photoType; }
            set { _photoType = value; }
        }
    }

    public enum PhotoType
    {
        Good = 0,
        NotGood = 1
    }

    /// <summary>
    /// List for RootCauseModel Model
    /// </summary>
    public class RootCauseModel
    {
        private string _type;
        /// <summary>
        /// This field will set Type
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _rootCause;
        /// <summary>
        /// This field will set Type
        /// </summary>
        public string RootCause
        {
            get { return _rootCause; }
            set { _rootCause = value; }
        }

        private Guid _id;
        /// <summary>
        /// This field will set Type
        /// </summary>
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }

    /// <summary>
    /// List for RootCauseModel Model
    /// </summary>
    public class CounterMeasuresModel
    {
        private string _type;
        /// <summary>
        /// This field will set Type
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _counterMeasures;
        /// <summary>
        /// This field will set CounterMeasures
        /// </summary>
        public string CounterMeasures
        {
            get { return _counterMeasures; }
            set { _counterMeasures = value; }
        }

        private Guid _id;
        /// <summary>
        /// This field will set Type
        /// </summary>
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }


    /// <summary>
    /// List for InformModel Model
    /// </summary>
    public class InformModel : BaseModel<Guid>
    {

        private Guid _reportSection2Id;
        /// <summary>
        /// This field will set ReportSection2Id
        /// </summary>
        [DataMember]
        public Guid ReportSection2Id
        {
            get { return _reportSection2Id; }
            set { _reportSection2Id = value; }
        }

        private Guid _reportSectionAssociationId;
        /// <summary>
        /// This field will set ReportSectionAssociationId
        /// </summary>
        [DataMember]
        public Guid ReportSectionAssociationId
        {
            get { return _reportSectionAssociationId; }
            set { _reportSectionAssociationId = value; }
        }

        private string _type;
        /// <summary>
        /// This field will set Type
        /// </summary>
        [DataMember]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _typeValue;
        /// <summary>
        /// This field will set TypeValue
        /// </summary>
        [DataMember]
        public string TypeValue
        {
            get { return _typeValue; }
            set { _typeValue = value; }
        }

        private Guid _typeId;
        /// <summary>
        /// This field will set TypeId
        /// </summary>
        [DataMember]
        public Guid TypeId
        {
            get { return _typeId; }
            set { _typeId = value; }
        }

        private Guid _replyFrom;
        /// <summary>
        /// This field will set ReplyFrom
        /// </summary>
        [DataMember]
        public Guid ReplyFrom
        {
            get { return _replyFrom; }
            set { _replyFrom = value; }
        }

        private string _emailId;
        /// <summary>
        /// This field will set EmailId
        /// </summary>
        [DataMember]
        public string EmailId
        {
            get { return _emailId; }
            set { _emailId = value; }
        }

        private bool _readStatus;
        /// <summary>
        /// This field will set ReadStatus
        /// </summary>
        [DataMember]
        public bool ReadStatus
        {
            get { return _readStatus; }
            set { _readStatus = value; }
        }

    }
}
