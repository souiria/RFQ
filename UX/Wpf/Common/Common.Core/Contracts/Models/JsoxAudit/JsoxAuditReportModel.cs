/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   JsoxAuditReportModel.cs
Function           :   To display Jsox Audit Report
Created By         :   Dharmendra
Created on         :   09-Jun-2020
Revision History   :  [17-Jun-2020] : Dharmendra
*                  :   [] : Add new properties UserLeaverDate and UserLeaverHDCallNumber
*                  :  [12-Jan-2020] : Dharmendra
*                  :   [] : Add new properties UserCreationHelpDeskNumber,UserActivationDate,UserActivationBy
*                  :  [19-Feb-2021] : Vedanshu
*                  :   [] : Add new properties UserStatus
*                  :  [23-Sept-2021] : Sejal Srivastava
*                  :  [] : Modified UserLeaverDate as nullable
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;
namespace Common.Core.Contracts
{

    [DataContract]
    public class JsoxAuditReportModel : BaseModel<Guid>
    {
        private string _username;
        [DataMember]
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _displanName;
        [DataMember]
        public string DisplayName
        {
            get => _displanName;
            set => SetProperty(ref _displanName, value);
        }
        private string _logon;
        [DataMember]
        public string Logon
        {
            get => _logon;
            set => SetProperty(ref _logon, value);
        }

        private string _department;
        [DataMember]
        public string Department
        {
            get => _department;
            set => SetProperty(ref _department, value);
        }

        private string _roles;
        [DataMember]
        public string Roles
        {
            get => _roles;
            set => SetProperty(ref _roles, value);
        }

        private string _screenAccessMatrix;
        [DataMember]
        public string ScreenAccessMatrix
        {
            get => _screenAccessMatrix;
            set => SetProperty(ref _screenAccessMatrix, value);
        }
        private string _emailAddress;
        [DataMember]
        public string EmailAddress
        {
            get => _emailAddress;
            set => SetProperty(ref _emailAddress, value);
        }


        private DateTime? _lastLogin;
        [DataMember]
        public DateTime? LastLogin
        {
            get => _lastLogin;
            set => SetProperty(ref _lastLogin, value);
        }

        private DateTime? _firstLogin;
        [DataMember]
        public DateTime? FirstLogin
        {
            get => _firstLogin;
            set => SetProperty(ref _firstLogin, value);
        }
        /// <summary>
        /// Local variable Last Helpdesk Number
        /// </summary>
        private string _lastHelpDeskNumber;
        [DataMember]
        public string LastHelpDeskNumber
        {
            get => _lastHelpDeskNumber;
            set => SetProperty(ref _lastHelpDeskNumber, value);
        }

        private DateTime? _creationHelpDeskDate;
        [DataMember]
        /// <summary>
        /// Local variable Creation Help Desk Date
        /// </summary>
        public DateTime? CreationHelpDeskDate
        {
            get => _creationHelpDeskDate;
            set => SetProperty(ref _creationHelpDeskDate, value);
        }
        /// <summary>
        ///Local variable Creation Help Desk Number
        /// </summary>
        private string _creationHelpDeskNumber;
        [DataMember]
        public string CreationHelpDeskNumber
        {
            get => _creationHelpDeskNumber;
            set => SetProperty(ref _creationHelpDeskNumber, value);
        }
        private DateTime? _userLeaverDate;
        /// <summary>
        /// Local variable UserLeaverDate
        /// </summary>
        [DataMember]
        public DateTime? UserLeaverDate
        {
            get { return _userLeaverDate; }
            set { SetProperty(ref _userLeaverDate, value); }
        }

        private string _userLeaverHDCallNumber;
        [DataMember]
        /// <summary>
        /// Local variable User Leaver HD Call Number
        /// </summary>
        public string UserLeaverHDCallNumber
        {
            get { return _userLeaverHDCallNumber; }
            set { SetProperty(ref _userLeaverHDCallNumber, value); }
        }
        /// <summary>
        /// Local Variable _userCreationHelpDeskNumber
        /// </summary>
        private string _userCreationHelpDeskNumber;
        [DataMember]
        public string UserCreationHelpDeskNumber
        {
            get { return _userCreationHelpDeskNumber; }
            set { SetProperty(ref _userCreationHelpDeskNumber, value); }
        }
        /// <summary>
        /// Local Variable _userActivationDate
        /// </summary>
        private DateTime? _userActivationDate;
        [DataMember]
        public DateTime? UserActivationDate
        {
            get { return _userActivationDate; }
            set { SetProperty(ref _userActivationDate, value); }
        }
        /// <summary>
        ///  Local Variable _userActivationBy;
        /// </summary>
        private string _userActivationBy;
        [DataMember]
        public string UserActivationBy
        {
            get { return _userActivationBy; }
            set { SetProperty(ref _userActivationBy, value); }
        }
        /// <summary>
        ///  Local Variable _userStatus;
        /// </summary>
        private String _userStatus;
        [DataMember]
        public String UserStatus
        {
            get { return _userStatus; }
            set { SetProperty(ref _userStatus, value); }
        }


    }
}
