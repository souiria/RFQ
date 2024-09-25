/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   H1UserRegisterModel.cs
Function           :   H1 User
Created By         :   Dharmendra
Created on         :   20-Jan-2021
Revision History   :  [03-Mar-2021] : Dharmendra
*                  :   [] : Add new properties UserStatus
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.JsoxAudit
{
    /// <summary>
    /// H1UserRegisterReportModel class
    /// </summary>
    [DataContract]
    public class H1UserRegisterReportModel : BaseModel<Guid>
    {
        private string _adCommonNamee;
        /// <summary>
        /// Variable for  Acitve directory Display Name
        /// </summary>
        [DataMember]
        public string ADCommonName
        {
            get => _adCommonNamee;
            set => SetProperty(ref _adCommonNamee, value);
        }

        private string _adLogon;
        /// <summary>
        /// Variable for Active Directory Logon
        /// </summary>
        [DataMember]
        public string ADLogon
        {
            get => _adLogon;
            set => SetProperty(ref _adLogon, value);
        }
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
        private string _adDepartmentName;
        /// <summary>
        /// Variable for Department Name
        /// </summary>
        [DataMember]
        public string ADDepartmentName
        {
            get => _adDepartmentName;
            set => SetProperty(ref _adDepartmentName, value);
        }
        private string _userCreationHelpDeskNumber;
        /// <summary>
        /// Variable for User Creation Help Desk Number
        /// </summary>
        [DataMember]
        public string UserCreationHelpDeskNumber
        {
            get => _userCreationHelpDeskNumber;
            set => SetProperty(ref _userCreationHelpDeskNumber, value);
        }
        private DateTime? _userActivationDate;
        /// <summary>
        /// Variable for User Activation Date
        /// </summary>
        [DataMember]
        public DateTime? UserActivationDate
        {
            get => _userActivationDate;
            set => SetProperty(ref _userActivationDate, value);
        }
        private Guid? _userActivationBy;
        /// <summary>
        /// Variable for User Activation By
        /// </summary>
        [DataMember]
        public Guid? UserActivationBy
        {
            get => _userActivationBy;
            set => SetProperty(ref _userActivationBy, value);
        }

        private DateTime? _firstLogin;
        /// <summary>
        /// Variable for First Login
        /// </summary>
        [DataMember]
        public DateTime? FirstLogin
        {
            get => _firstLogin;
            set => SetProperty(ref _firstLogin, value);
        }
        private DateTime? _lastLogin;
        /// <summary>
        /// Variable for LastLogin
        /// </summary>
        [DataMember]
        public DateTime? LastLogin
        {
            get => _lastLogin;
            set => SetProperty(ref _lastLogin, value);
        }

        private bool _isLeaver;
        /// <summary>
        /// Variable for check is user leaver or not
        /// </summary>
        [DataMember]
        public bool IsLeaver
        {
            get { return _isLeaver; }
            set { SetProperty(ref _isLeaver, value); }
        }
        private DateTime? _leaverDate;
        /// <summary>
        /// Local variable UserLeaverDate
        /// </summary>
        [DataMember]
        public DateTime? LeaverDate
        {
            get { return _leaverDate; }
            set { SetProperty(ref _leaverDate, value); }
        }

        private string _recordInsertionSource;
        /// <summary>
        /// Variable for Record Insertion Source like Installer/Service
        /// </summary>
        [DataMember]
        public string RecordInsertionSource
        {
            get => _recordInsertionSource;
            set => SetProperty(ref _recordInsertionSource, value);
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
        private string _viewName;
        /// <summary>
        /// Variable for ViewName
        /// </summary>
        [DataMember]
        public string ViewName
        {
            get => _viewName;
            set => SetProperty(ref _viewName, value);
        }
        private string _isNewUser;
        /// <summary>
        /// Variable for ViewName
        /// </summary>
        [DataMember]
        public string IsNewUser
        {
            get => _isNewUser;
            set => SetProperty(ref _isNewUser, value);
        }
        private string _userStatus;
        /// <summary>
        /// Variable for check  Status
        /// </summary>
        [DataMember]
        public string UserStatus
        {
            get => _userStatus;
            set => SetProperty(ref _userStatus, value);
        }
    }
}
