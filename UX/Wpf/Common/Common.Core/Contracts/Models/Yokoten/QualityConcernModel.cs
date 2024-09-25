/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   QualityConcernModel.cs
Function           :   Quality Concern Model
Created By         :   Nitin
Created on         :   30-Jan-2020
Revision History   :   [01-May-2020]  : Pawan
                   :   [] : Removed field for replydate and added field DaysForReply      
                   :   [10-Jun-2020] : Pawan
                   :   [] : Added field for Is Critical
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    /// <summary>
    /// Data Contract use for QualityConcernModel Service
    /// </summary>
    [DataContract, Serializable]
    public class QualityConcernModel : BaseModel<Guid>
    {
        private string _concern;
        /// <summary>
        /// Get or Set for {Concern}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Concern
        {
            get => _concern;
            set => SetProperty(ref _concern, value);
        }
        private bool _initialEmail;
        /// <summary>
        /// Get or Set for {InitialEmail}.
        /// </summary>
        [DataMember]
        public bool InitialEmail
        {
            get => _initialEmail;
            set => SetProperty(ref _initialEmail, value);
        }
        private bool _isCritical;
        /// <summary>
        /// Get or Set for {IsCritical}.
        /// </summary>
        [DataMember]
        public bool IsCritical
        {
            get => _isCritical;
            set => SetProperty(ref _isCritical, value);
        }
        private bool _qCReview;
        /// <summary>
        /// Get or Set for {QCReview}.
        /// </summary>
        [DataMember]
        public bool QCReview
        {
            get => _qCReview;
            set => SetProperty(ref _qCReview, value);
        }
        private bool _replyDateRequired;
        /// <summary>
        /// Get or Set for {ReplyDateRequired}.
        /// </summary>
        [DataMember]
        public bool ReplyDateRequired
        {
            get => _replyDateRequired;
            set => SetProperty(ref _replyDateRequired, value);
        }

        private bool _auditInfoRequired;
        /// <summary>
        /// Get or Set for {AuditInfoRequired}.
        /// </summary>
        [DataMember]
        public bool AuditInfoRequired
        {
            get => _auditInfoRequired;
            set => SetProperty(ref _auditInfoRequired, value);
        }
        private bool _sEWSEFlashReport;
        /// <summary>
        /// Get or Set for {SEWSEFlashReport}.
        /// </summary>
        [DataMember]
        public bool SEWSEFlashReport
        {
            get => _sEWSEFlashReport;
            set => SetProperty(ref _sEWSEFlashReport, value);
        }

        private int _daysForReply;
        /// <summary>
        /// Get or Set for {DaysForReply}.
        /// </summary>
        [DataMember]
        public int DaysForReply
        {
            get => _daysForReply;
            set => SetProperty(ref _daysForReply, value);
        }

        private bool _reminderRequired;
        /// <summary>
        /// Get or Set for {ReminderRequired}.
        /// </summary>
        [DataMember]
        public bool ReminderRequired
        {
            get => _reminderRequired;
            set => SetProperty(ref _reminderRequired, value);
        }
        private int _daysForReminder;
        /// <summary>
        /// Get or Set for {DaysForReminder}.
        /// </summary>
        [DataMember]
        public int DaysForReminder
        {
            get => _daysForReminder;
            set => SetProperty(ref _daysForReminder, value);
        }






    }
}
