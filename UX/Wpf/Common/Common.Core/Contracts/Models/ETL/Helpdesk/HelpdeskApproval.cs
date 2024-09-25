using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.ETL.Helpdesk
{
  [DataContract, Serializable]
    [KnownType(typeof(HelpdeskApproval))]
    public class HelpdeskApproval : ExternalDataSourceModel<object>
    {
        private string _callId;
        [DataMember]
        [Column("callId")]
        public string CallId
        {
            get => _callId;
            set => SetProperty(ref _callId, value);
        }

        private string _approvalId;
        [DataMember]
        [Column("approvalId")]
        [Key]
        public string ApprovalId
        {
            get => _approvalId;
            set => SetProperty(ref _approvalId, value);
        }

        private string _approverName;
        [DataMember]
        [Column("approverName")]
        public string ApproverName
        {
            get => _approverName;
            set => SetProperty(ref _approverName, value);
        }

        private string _approvalNotes;
        [DataMember]
        [Column("approvalNotes")]
        public string ApprovalNotes
        {
            get => _approvalNotes;
            set => SetProperty(ref _approvalNotes, value);
        }

        private string _approvalStatus;
        [DataMember]
        [Column("approvalStatus")]
        public string ApprovalStatus
        {
            get => _approvalStatus;
            set => SetProperty(ref _approvalStatus, value);
        }

        private DateTime? _approvalDate;
        [DataMember]
        [Column("approvalDate")]
        public DateTime? ApprovalDate
        {
            get => _approvalDate;
            set => SetProperty(ref _approvalDate, value);
        }

        private DateTime? _approvedDate;
        [DataMember]
        [Column("approvedDate")]
        public DateTime? ApprovedDate
        {
            get => _approvedDate;
            set => SetProperty(ref _approvedDate, value);
        }

        private string _approverIp;
        [DataMember]
        [Column("approverIp")]
        public string ApproverIp
        {
            get => _approverIp;
            set => SetProperty(ref _approverIp, value);
        }

        private string _assigneeNotes;
        [DataMember]
        [Column("assigneeNotes")]
        public string AssigneeNotes
        {
            get => _assigneeNotes;
            set => SetProperty(ref _assigneeNotes, value);
        }

        private string _approvalNumber;
        [DataMember]
        [Column("approvalNumber")]
        public string ApprovalNumber
        {
            get => _approvalNumber;
            set => SetProperty(ref _approvalNumber, value);
        }

        private string _approvalType;
        [DataMember]
        [Column("approvalType")]
        public string ApprovalType
        {
            get => _approvalType;
            set => SetProperty(ref _approvalType, value);
        }

        private string _approvalExclusive;
        [DataMember]
        [Column("approvalExclusive")]
        public string ApprovalExclusive
        {
            get => _approvalExclusive;
            set => SetProperty(ref _approvalExclusive, value);
        }

        private string _approvalComplete;
        [DataMember]
        [Column("approvalComplete")]
        public string ApprovalComplete
        {
            get => _approvalComplete;
            set => SetProperty(ref _approvalComplete, value);
        }

        private DateTime? _requestDate;
        [DataMember]
        [Column("requestdate")]
        public DateTime? Requestdate
        {
            get => _requestDate;
            set => SetProperty(ref _requestDate, value);
        }

        private string _approverEmail;
        [DataMember, NotMapped]
        public string ApproverEmail
        {
            get => _approverEmail;
            set => SetProperty(ref _approverEmail, value);
        }
    }
}
