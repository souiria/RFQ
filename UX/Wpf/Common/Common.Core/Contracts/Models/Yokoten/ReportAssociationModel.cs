/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ReportSection2Model.cs
Function           :   Data contract for Report Section3
Created By         :   Srashti Gupta
Created on         :   20-March-2020
Revision History   :   [20-March-2020] : Srashti Gupta
*                  :   Modified the Property Name as per the standards.
*                  :   [12-Jun-2020] : Pawan
*                  :   Added property for Approve , Reject and Comment
*                  :   [23-Mar-2021] : Ashish
*                  :   Added property for ReportStatus
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    /// <summary>
    /// Data Contract for Report Association Model
    /// </summary>
    [DataContract, Serializable]
    public class ReportAssociationModel : BaseModel<Guid>
    {
        private Guid _section1Guid;
        /// <summary>
        /// This field will set Section1Guid
        /// </summary>
        [DataMember]
        public Guid Section1Guid
        {
            get => _section1Guid;
            set => SetProperty(ref _section1Guid, value);
        }

        private Guid _section2Guid;
        /// <summary>
        /// This field will set Section2Guid
        /// </summary>
        [DataMember]
        public Guid Section2Guid
        {
            get => _section2Guid;
            set => SetProperty(ref _section2Guid, value);
        }

        private Guid _section3Guid;
        /// <summary>
        /// This field will set Section3Guid
        /// </summary>
        [DataMember]
        public Guid Section3Guid
        {
            get => _section3Guid;
            set => SetProperty(ref _section3Guid, value);
        }

        private bool _delayed;
        /// <summary>
        /// This field will set Delayed
        /// </summary>
        [DataMember]
        public bool Delayed
        {
            get => _delayed;
            set => SetProperty(ref _delayed, value);
        }

        private bool _isCQApproved;
        /// <summary>
        /// This field will set Is CQ Approved
        /// </summary>
        [DataMember]
        public bool IsCQApproved
        {
            get => _isCQApproved;
            set => SetProperty(ref _isCQApproved, value);
        }

        private bool _isCQRejected;
        /// <summary>
        /// This field will set Is CQ Rejected
        /// </summary>
        [DataMember]
        public bool IsCQRejected
        {
            get => _isCQRejected;
            set => SetProperty(ref _isCQRejected, value);
        }

        private string _cqComments;
        /// <summary>
        /// This field will set CQ Comments
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string CQComments
        {
            get => _cqComments;
            set => SetProperty(ref _cqComments, value);
        }

        private DateTime? _delayedUntil;
        /// <summary>
        /// This field will set DelayedUntil
        /// </summary>
        [DataMember]
        public DateTime? DelayedUntil
        {
            get => _delayedUntil;
            set => SetProperty(ref _delayedUntil, value);
        }

        private string _reportState;
        /// <summary>
        /// This field will set ReportState
        /// </summary>
        [DataMember]
        public string ReportState
        {
            get => _reportState;
            set => SetProperty(ref _reportState, value);
        }

        private string _reportstatus;
        /// <summary>
        /// This field will set ReportState
        /// </summary>
        [DataMember]
        public string ReportStatus
        {
            get => _reportstatus;
            set => SetProperty(ref _reportstatus, value);
        }
    }
}
