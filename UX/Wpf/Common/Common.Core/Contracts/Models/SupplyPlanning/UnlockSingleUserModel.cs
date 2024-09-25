/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   UnlockSingleUserModel.cs
Function           :   UnlockSingleUser Model
Created By         :   Sachin Pandey [HD-00393919]
Created on         :   08-Feb-2024
Revision History   :   []
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Model for SingleUserMaintenance Screen 
    /// </summary>
    [DataContract, Serializable]
    public class UnlockSingleUserModel : BaseModel<Guid>
    {
        private string _hostName;
        /// <summary>
        /// Get or Set for {Host Name}.
        /// </summary>
        [DataMember]
        public string HostName
        {
            get => _hostName;
            set => _hostName = value;
        }

        private Guid _h1MenuGuid;
        /// <summary>
        /// Get or Set for {ScreenGuid}.
        /// </summary>
        [DataMember]
        public Guid H1MenuGuid
        {
            get => _h1MenuGuid;
            set => SetProperty(ref _h1MenuGuid, value);
        }

        private string _screenName;
        /// <summary>
        /// Get or Set for {Screen Name}.
        /// </summary>
        [DataMember]
        public string ScreenName
        {
            get => _screenName;
            set => _screenName = value;
        }
        
        private string _filterParameters;
        /// <summary>
        /// Get or Set for {Filter Parameter}.
        /// </summary>
        [DataMember]
        public string FilterParameters
        {
            get => _filterParameters;
            set => _filterParameters = value;
        }

        private string _lockedBy;
        /// <summary>
        /// Get or Set for {Locked By}.
        /// </summary>
        [DataMember]
        public string LockedBy
        {
            get => _lockedBy;
            set => _lockedBy = value;
        }

        private string _status;
        /// <summary>
        /// Get or Set for {Status}.
        /// </summary>
        [DataMember]
        public string Status
        {
            get => _status;
            set => _status = value;
        }

        private string _lockedTimeStamp;
        /// <summary>
        /// Get or Set for {Locked Time Stamp}.
        /// </summary>
        [DataMember]
        public string LockedTimeStamp
        {
            get => _lockedTimeStamp;
            set => _lockedTimeStamp = value;
        }

        private Guid _applicationGuid;
        /// <summary>
        /// Get or Set for {ApplicationGuid}.
        /// </summary>
        [DataMember]
        public Guid ApplicationGuid
        {
            get => _applicationGuid;
            set => _applicationGuid = value;
        }

        private string _viewName;
        /// <summary>
        /// Get or Set for {ViewName}.
        /// </summary>
        [DataMember]
        public string ViewName
        {
            get => _viewName;
            set => _viewName = value;
        }
    }

    public class SingleUserAccess
    {
        private Guid _userGuid;
        /// <summary>
        /// Get or Set for {UserGuid}.
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }
        private Guid _applicationGuid;
        /// <summary>
        /// Get or Set for {ApplicationGuid}.
        /// </summary>
        [DataMember]
        public Guid ApplicationGuid
        {
            get => _applicationGuid;
            set => _applicationGuid = value;
        }

        private string _hostName;
        /// <summary>
        /// Get or Set for {HostName}.
        /// </summary>
        [DataMember]
        public string HostName
        {
            get => _hostName;
            set => _hostName = value;
        }

        private string _viewName;
        /// <summary>
        /// Get or Set for {ViewName}.
        /// </summary>
        [DataMember]
        public string ViewName
        {
            get => _viewName;
            set => _viewName = value;
        }
        private string _filterParameters;
        /// <summary>
        /// Get or Set for {ViewName}.
        /// </summary>
        [DataMember]
        public string FilterParameters
        {
            get => _filterParameters;
            set => _filterParameters = value;
        }

        private string _lockMessage;
        /// <summary>
        /// Get or Set for {ViewName}.
        /// </summary>
        [DataMember]
        public string LockMessage
        {
            get => _lockMessage;
            set => _lockMessage = value;
        }
    }
}
