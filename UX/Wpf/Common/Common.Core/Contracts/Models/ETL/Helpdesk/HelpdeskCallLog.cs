using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.ETL.Helpdesk
{
    [DataContract, Serializable]
    public class HelpdeskCallLog : ExternalDataSourceModel<object>
    { 
        //Todo: Change to exact helpdesk database schema in order to allow Entity framework to import the data
        private string _callId;
        [DataMember]
        [Key]
        [Column("CallID")]
        public string CallId
        {
            get => _callId;
            set => SetProperty(ref _callId, value);
        }

        private string _custId;
        [DataMember]
        [Column("CustID")]
        public string CustId
        {
            get => _custId;
            set => SetProperty(ref _custId, value);
        }

        private string _ad_guid;
        [DataMember]
        [Column("Ad_Guid")]
        public string Ad_Guid
        {
            get => _ad_guid;
            set => SetProperty(ref _ad_guid, value);
        }

        private string _custType;
        [DataMember]
        [Column("CustType")]
        public string CustType
        {
            get => _custType;
            set => SetProperty(ref _custType, value);
        }

        private string _callType;
        [DataMember]
        [Column("CallType")]
        public string CallType
        {
            get => _callType;
            set => SetProperty(ref _callType, value);
        }

        private string _tracker;
        [DataMember]
        [Column("Tracker")]
        public string Tracker
        {
            get => _tracker;
            set => SetProperty(ref _tracker, value);
        }

        private string _callStatus;
        [DataMember]
        [Column("CallStatus")]
        public string CallStatus
        {
            get => _callStatus;
            set => SetProperty(ref _callStatus, value);
        }

        private string _priority;
        [DataMember]
        [Column("Priority")]
        public string Priority
        {
            get => _priority;
            set => SetProperty(ref _priority, value);
        }

        private string _callDescription;
        [DataMember]
        [Column("CallDesc")]
        public string CallDescription
        {
            get => _callDescription;
            set => SetProperty(ref _callDescription, value);
        }

        private string _closeDescription;
        [DataMember]
        [Column("CloseDesc")]
        public string CloseDescription
        {
            get => _closeDescription;
            set => SetProperty(ref _closeDescription, value);
        }

        private string _assignee;
        [DataMember]
        [Column("Assignee")]
        public string Assignee
        {
            get => _assignee;
            set => SetProperty(ref _assignee, value);
        }

        private string _engineerNotes;
        [DataMember]
        [Column("EngineerNotes")]
        public string EngineerNotes
        {
            get => _engineerNotes;
            set => SetProperty(ref _engineerNotes, value);
        }

        private DateTime _loggedTime;
        [DataMember]
        [Column("LoggedTime")]
        public DateTime LoggedTime
        {
            get => _loggedTime;
            set => SetProperty(ref _loggedTime, value);
        }

        private string _isGap;
        [DataMember]
        [Column("IsGap")]
        public string IsGap
        {
            get => _isGap;
            set => SetProperty(ref _isGap, value);
        }

        private string _gapType;
        [DataMember]
        [Column("GapType")]
        public string GapType
        {
            get => _gapType;
            set => SetProperty(ref _gapType, value);
        }

        private string _gapCategory;
        [DataMember]
        [Column("GapCategory")]
        public string GapCategory
        {
            get => _gapCategory;
            set => SetProperty(ref _gapCategory, value);
        }

        private string _gapSize;
        [DataMember]
        [Column("GapSize")]
        public string GapSize
        {
            get => _gapSize;
            set => SetProperty(ref _gapSize, value);
        }

        private string _gapSpecfication;
        [DataMember]
        [Column("GapSpecification")]
        public string GapSpecification
        {
            get => _gapSpecfication;
            set => SetProperty(ref _gapSpecfication, value);
        }

        private string _gapTargetDate;
        [DataMember]
        [Column("GapTargetDate")]
        public string GapTargetDate
        {
            get => _gapTargetDate;
            set => SetProperty(ref _gapTargetDate, value);
        }

        private string _gapReleased;
        [DataMember]
        [Column("GapReleased")]
        public string GapReleased
        {
            get => _gapReleased;
            set => SetProperty(ref _gapReleased, value);
        }

        private string _gapMind;
        [DataMember]
        [Column("GapMind")]
        public string GapMind
        {
            get => _gapMind;
            set => SetProperty(ref _gapMind, value);
        }

        private DateTime? _closedTime;
        [DataMember]
        [Column("ClosedTime")]
        public DateTime? ClosedTime
        {
            get => _closedTime;
            set => SetProperty(ref _closedTime, value);
        }

        private string _feedback;
        [DataMember]
        [Column("Feedback")]
        public string Feedback
        {
            get => _feedback;
            set => SetProperty(ref _feedback, value);
        }

        private string _rating;
        [DataMember]
        [Column("rating")]
        public string Rating
        {
            get => _rating;
            set => SetProperty(ref _rating, value);
        }        

        private string _location;
        [DataMember]
        [Column("Location")]
        public string Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        private string _loggedBy;
        [DataMember]
        [Column("LoggedBy")]
        public string LoggedBy
        {
            get => _loggedBy;
            set => SetProperty(ref _loggedBy, value);
        }

        private string _updatedBy;
        [DataMember]
        [Column("UpdatedBy")]
        public string UpdatedBy
        {
            get => _updatedBy;
            set => SetProperty(ref _updatedBy, value);
        }

        private string _gapParent;
        [DataMember]
        [Column("GapParent")]
        public string GapParent
        {
            get => _gapParent;
            set => SetProperty(ref _gapParent, value);
        }

        private string _sers;
        [DataMember]
        [Column("SERS")]
        public string SERS
        {
            get => _sers;
            set => SetProperty(ref _sers, value);
        }

        private DateTime? _updateTime;
        [DataMember]
        [Column("UpdateTime")]
        public DateTime? UpdateTime
        {
            get => _updateTime;
            set => SetProperty(ref _updateTime, value);
        }

        private string _gapValue;
        [DataMember]
        [Column("GapValue")]
        public string GapValue
        {
            get => _gapValue;
            set => SetProperty(ref _gapValue, value);
        }

        private string _solutionAgreedUser;
        [DataMember]
        [Column("SolutionAgreedUser")]
        public string SolutionAgreedUser
        {
            get => _solutionAgreedUser;
            set => SetProperty(ref _solutionAgreedUser, value);
        }

        private DateTime? _solutionAgreedTime;
        [DataMember]
        [Column("SolutionAgreedTime")]
        public DateTime? SolutionAgreedTime
        {
            get => _solutionAgreedTime;
            set => SetProperty(ref _solutionAgreedTime, value);
        }

        private string _solutionAgreedState;
        [DataMember]
        [Column("SolutionAgreedState")]
        public string SolutionAgreedState
        {
            get => _solutionAgreedState;
            set => SetProperty(ref _solutionAgreedState, value);
        }

        private string _suggestedSolution;
        [DataMember]
        [Column("SuggestedSolution")]
        public string SuggestedSolution
        {
            get => _suggestedSolution;
            set => SetProperty(ref _suggestedSolution, value);
        }

        private string _soltuionComments;
        [DataMember]
        [Column("SolutionComments")]
        public string SolutionComments
        {
            get => _soltuionComments;
            set => SetProperty(ref _soltuionComments, value);
        }

        private string _jsox;
        [DataMember]
        [Column("Jsox")]
        public string Jsox
        {
            get => _jsox;
            set => SetProperty(ref _jsox, value);
        }

        private string _loggedByIpAddress;
        [DataMember]
        [Column("LoggedByIpAddress")]
        public string LoggedByIpAddress
        {
            get => _loggedByIpAddress;
            set => SetProperty(ref _loggedByIpAddress, value);
        }

        private string _employees;
        [DataMember]
        [Column("Employees")]
        public string Employees
        {
            get => _employees;
            set => SetProperty(ref _employees, value);
        }

        private string _reminderEmailSent;
        [DataMember]
        [Column("ReminderEmailSent")]
        public string ReminderEmailSent
        {
            get => _reminderEmailSent;
            set => SetProperty(ref _reminderEmailSent, value);
        }

        private DateTime? _reminderEmailDate;
        [DataMember]
        [Column("ReminderEmailDate")]
        public DateTime? ReminderEmailDate
        {
            get => _reminderEmailDate;
            set => SetProperty(ref _reminderEmailDate, value);
        }

        private string _jsoxPattern;
        [DataMember]
        [Column("JsoxPattern")]
        public string JsoxPattern
        {
            get => _jsoxPattern;
            set => SetProperty(ref _jsoxPattern, value);
        }

        private string _escalateNotes;
        [DataMember]
        [Column("EscalateNotes")]
        public string EscalateNotes
        {
            get => _escalateNotes;
            set => SetProperty(ref _escalateNotes, value);
        }

        private string _escalateBy;
        [DataMember]
        [Column("EscalateBy")]
        public string EscalateBy
        {
            get => _escalateBy;
            set => SetProperty(ref _escalateBy, value);
        }

        private DateTime? _escalateDate;
        [DataMember]
        [Column("EscalateDate")]
        public DateTime? EscalateDate
        {
            get => _escalateDate;
            set => SetProperty(ref _escalateDate, value);
        }

        private string _dayOpen;
        [DataMember]
        [Column("DayOpen")]
        public string DayOpen
        {
            get => _dayOpen;
            set => SetProperty(ref _dayOpen, value);
        }

        private string _daysSinceUpdate;
        [DataMember]
        [Column("DaysSinceUpdate")]
        public string DaysSinceUpdate
        {
            get => _daysSinceUpdate;
            set => SetProperty(ref _daysSinceUpdate, value);
        }

        private string _addApprover;
        [DataMember]
        [Column("AddApprover")]
        public string AddApprover
        {
            get => _addApprover;
            set => SetProperty(ref _addApprover, value);
        }

        private string _approvalStatus;
        [DataMember]
        [Column("ApprovalStatus")]
        public string ApprovalStatus
        {
            get => _approvalStatus;
            set => SetProperty(ref _approvalStatus, value);
        }

        private string _company;
        [DataMember]
        [Column("Company")]
        public string Company
        {
            get => _company;
            set => SetProperty(ref _company, value);
        }

        private bool? _confidential;
        [DataMember]
        [Column("Confidential")]
        public bool? Confidential
        {
            get => _confidential;
            set => SetProperty(ref _confidential, value);
        }

        private DateTime? _closedDate;
        [DataMember]
        [Column("ClosedDate")]
        public DateTime? ClosedDate
        {
            get => _closedDate;
            set => SetProperty(ref _closedDate, value);
        }

        private string _closedByIp;
        [DataMember]
        [Column("ClosedByIp")]
        public string ClosedByIp
        {
            get => _closedByIp;
            set => SetProperty(ref _closedByIp, value);
        }

        private string _closedByUser;
        [DataMember]
        [Column("ClosedByUser")]
        public string ClosedByUser
        {
            get => _closedByUser;
            set => SetProperty(ref _closedByUser, value);
        }

        private string _closedPage;
        [DataMember]
        [Column("ClosedPage")]
        public string ClosedPage
        {
            get => _closedPage;
            set => SetProperty(ref _closedPage, value);
        }

        private DateTime? _firstUpdate;
        [DataMember]
        [Column("FirstUpdate")]
        public DateTime? FirstUpdate
        {
            get => _firstUpdate;
            set => SetProperty(ref _firstUpdate, value);
        }

        private string _helpdesk;
        [DataMember]
        [Column("Helpdesk")]
        public string Helpdesk
        {
            get => _helpdesk;
            set => SetProperty(ref _helpdesk, value);
        }

        private string _custSSID;
        [DataMember]
        [Column("CustSSID")]
        public string CustSSID
        {
            get => _custSSID;
            set => SetProperty(ref _custSSID, value);
        }

        private bool _majorIncident;
        [DataMember]
        [Column("MajorIncident")]
        public bool MajorIncident
        {
            get => _majorIncident;
            set => SetProperty(ref _majorIncident, value);
        }

        private string _originalCustId;
        [DataMember]
        [Column("OriginalCustId")]
        public string OriginalCustId
        {
            get => _originalCustId;
            set => SetProperty(ref _originalCustId, value);
        }

        private string _thirdPartyTicketReference;
        [DataMember]
        [Column("ThirdPartyTicketReference")]
        public string ThirdPartyTicketReference
        {
            get => _thirdPartyTicketReference;
            set => SetProperty(ref _thirdPartyTicketReference, value);
        }

        private bool? _jsoxCompliant;
        [DataMember]
        [Column("JsoxCompliant")]
        public bool? JsoxCompliant
        {
            get => _jsoxCompliant;
            set => SetProperty(ref _jsoxCompliant, value);
        }
    }
}
