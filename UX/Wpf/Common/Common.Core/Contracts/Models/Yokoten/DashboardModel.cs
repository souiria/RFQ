/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DashboardModel.cs
Function           :   Data contract for Dashboard Model
Created By         :   Srashti Gupta
Created on         :   05-May-2020
Revision History   :   [20-June-2020] : Srashti Gupta
*                  :   Added property CQReviewPending, ReplyPending
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    [DataContract, Serializable]
    public class DashboardModel : BaseModel<Guid>
    {
        private int _yokotenMonth;
        /// <summary>
        /// This field will set YokotenMonth
        /// </summary>
        [DataMember]
        public int YokotenMonth
        {
            get => _yokotenMonth;
            set => SetProperty(ref _yokotenMonth, value);
        }
        private int _yokotenYTD;
        /// <summary>
        /// This field will set YokotenYTD
        /// </summary>
        [DataMember]
        public int YokotenYTD
        {
            get => _yokotenYTD;
            set => SetProperty(ref _yokotenYTD, value);
        }
        private int _cqReviewPending;
        /// <summary>
        /// This field will set CQ Review Pending
        /// </summary>
        [DataMember]
        public int CQReviewPending
        {
            get => _cqReviewPending;
            set => SetProperty(ref _cqReviewPending, value);
        }
        private int _replyPending;
        /// <summary>
        /// This field will set ReplyPending
        /// </summary>
        [DataMember]
        public int ReplyPending
        {
            get => _replyPending;
            set => SetProperty(ref _replyPending, value);
        }
    }

    [DataContract, Serializable]
    /// <summary>
    /// List for BussinessInformReplyModel Model
    /// </summary>
    public class BussinessInformReplyModel
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

        private Guid _id;
        /// <summary>
        /// This field will set Id
        /// </summary>
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
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

}
