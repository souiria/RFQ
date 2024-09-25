/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   H1UserSessionLogModel.cs
Function           :   H1 User Session Info
Created By         :   Dharmendra
Created on         :   13-Jan-2021
Revision History   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.JsoxAudit
{
    /// <summary>
    /// H1UserSessionLogModel class
    /// </summary>
    [DataContract]
    public class H1UserSessionLogModel : BaseModel<Guid>
    {
        private Guid _userGuid;
        /// <summary>
        /// Variable for User Guid
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => SetProperty(ref _userGuid, value);
        }

        private string _viewName;
        /// <summary>
        /// Variable for View Name
        /// </summary>
        [DataMember]
        public string ViewName
        {
            get => _viewName;
            set => SetProperty(ref _viewName, value);
        }
        private DateTime? _entryStamp;
        /// <summary>
        /// Variable for EntryStamp
        /// </summary>
        [DataMember]
        public DateTime? EntryStamp
        {
            get => _entryStamp;
            set => SetProperty(ref _entryStamp, value);
        }

        private string _remarks;
        /// <summary>
        /// Variable for Remarks
        /// </summary>
        [DataMember]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }
        private Guid _id;
        /// <summary>
        /// Variable for Id
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        
    }
}
