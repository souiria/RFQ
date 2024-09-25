/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   JsoxAuditH1UsersScreenPermission.cs
Function           :   To display Jsox Audit User Permission
Created By         :   Dharmendra
Created on         :  06-July-2020
Revision History   : [13-Jul-2020] Dharmendra Kumar
                   : [ ] Add new property OperationName
                   : [05-Oct-2021] Dharmendra Kumar
                   : [ ] Add new property Application Status,InActiveDate,total No of Users,NoOfUsersWithoutPermission andd NoOfUsersWithPermission
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Dynamic;
using System.Runtime.Serialization;

namespace Common.Core.Contracts
{
    public class JsoxAuditH1UsersScreenPermissionModel : BaseModel<Guid>
    {
        private string _username;
        [DataMember]
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
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
        private string _screenName;
        [DataMember]
        public string  ScreenName
        {
            get => _screenName;
            set => SetProperty(ref _screenName, value);
        }
        private string _operationName;
        [DataMember]
        public string OperationName
        {
            get => _operationName;
            set => SetProperty(ref _operationName, value);
        }
        private DateTime? _applicationInActiveDate;
        /// <summary>
        /// Local variable ApplicationInActiveDate
        /// </summary>
        [DataMember]
        public DateTime? ApplicationInActiveDate
        {
            get { return _applicationInActiveDate; }
            set { SetProperty(ref _applicationInActiveDate, value); }
        }
        /// <summary>
        ///  Local Variable ApplicationStatus;
        /// </summary>
        private string _applicationStatus;
        [DataMember]
        public string ApplicationStatus
        {
            get { return _applicationStatus; }
            set { SetProperty(ref _applicationStatus, value); }
        }
        /// <summary>
        ///Local variable for _noOfUsersWithPermission
        /// </summary>
        private int _noOfUsersWithPermission;
        [DataMember]
        public int NoOfUsersWithPermission
        {
            get { return _noOfUsersWithPermission; }
            set { SetProperty(ref _noOfUsersWithPermission, value); }
        }
        /// <summary>
        ///Local variable for _noOfUsersWithoutPermission
        /// </summary>
        private int _noOfUsersWithoutPermission;
        [DataMember]
        public int NoOfUsersWithoutPermission
        {
            get { return _noOfUsersWithoutPermission; }
            set { SetProperty(ref _noOfUsersWithoutPermission, value); }
        }
        /// <summary>
        /// Local variable for _totalNoOfUsers
        /// </summary>
        private int _totalNoOfUsers;
        [DataMember]
        public int TotalNoOfUsers
        {
            get { return _totalNoOfUsers; }
            set { SetProperty(ref _totalNoOfUsers, value); }
        }
    }
}
