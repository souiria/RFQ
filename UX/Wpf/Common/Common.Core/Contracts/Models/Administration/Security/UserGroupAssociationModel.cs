/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   UserGroupAssociationModel.cs
Function           :   User  Group Association
Created By         :   Dharmendra
Created on         :   27-May-2021
Revision History   :   [24-June-2021] : Shivam Kalia
*                  :   [] : Add new properties in UsersDetailsModel
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    /// <summary>
    /// Model class for binidng User Group Association
    /// </summary>
    [DataContract, Serializable]
    public class UserGroupAssociationModel : BaseModel<Guid>
    {
        /// <summary>
        /// local variable _groupGuid
        /// </summary>
        private Guid _groupGuid = Guid.Empty;
        [DataMember]
        public Guid GroupGuid
        {
            get => _groupGuid;
            set => SetProperty(ref _groupGuid, value);
        }
        /// <summary>
        /// local variable _userGuid
        /// </summary>
        private Guid _userGuid;
        [DataMember]
        [Required]
        public Guid UserGuid
        {
            get => _userGuid;
            set => SetProperty(ref _userGuid, value);
        }
        /// <summary>
        /// local variable _isActive
        /// </summary>
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
    /// <summary>
    /// Model class for Bind User Details
    /// </summary>
    [DataContract, Serializable]
    public class UsersDetailsModel
    {
        /// <summary>
        /// local variable _adCommonName
        /// </summary>
        private string _adCommonName;
        [DataMember]
        public string ADCommonName
        {
            get { return _adCommonName; }
            set { _adCommonName = value; }
        }
        /// <summary>
        /// Local variable _adLogon
        /// </summary>
        private string _adLogon;
        [DataMember]
        public string ADLogon
        {
            get { return _adLogon; }
            set { _adLogon = value; }
        }
        /// <summary>
        /// local variable _userGuid
        /// </summary>
        private Guid _userGuid;
        [DataMember]
        public Guid UserGuid
        {
            get { return _userGuid; }
            set { _userGuid = value; }
        }

        /// <summary>
        /// local variable _firstName
        /// </summary>
        private string _firstName;
        [DataMember]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        /// <summary>
        /// local variable _surName
        /// </summary>
        private string _surName;
        [DataMember]
        public string Surname
        {
            get { return _surName; }
            set { _surName = value; }
        }
        /// <summary>
        /// local variable _emailAddress
        /// </summary>
        private string _emailAddress;
        [DataMember]
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }
        /// <summary>
        /// local variable _firstLogin
        /// </summary>
        private DateTime _firstLogin;
        [DataMember]
        public DateTime FirstLogin
        {
            get { return _firstLogin; }
            set { _firstLogin = value; }

        }
        /// <summary>
        /// local variable _lastLogin
        /// </summary>
        private DateTime _lastLogin;
        [DataMember]
        public DateTime LastLogin
        {
            get { return _lastLogin; }
            set { _lastLogin = value; }

        }
        /// <summary>
        /// local variable _userActivationDate
        /// </summary>
        private DateTime _userActivationDate;
        [DataMember]
        public DateTime UserActivationDate
        {
            get { return _userActivationDate; }
            set { _userActivationDate = value; }

        }
        /// <summary>
        /// local variable _userCreationHelpDeskNumber
        /// </summary>
        private string _userCreationHelpDeskNumber;
        [DataMember]
        public string UserCreationHelpDeskNumber
        {
            get { return _userCreationHelpDeskNumber; }
            set { _userCreationHelpDeskNumber = value; }
        }
        /// <summary>
        /// local variable _aDDepartmentName
        /// </summary>
        private string _aDDepartmentName;
        [DataMember]
        public string ADDepartmentName
        {
            get { return _aDDepartmentName; }
            set { _aDDepartmentName = value; }
        }
        /// <summary>
        /// local variable _office
        /// </summary>
        private string _office;
        [DataMember]
        public string Office
        {
            get { return _office; }
            set { _office = value; }
        }
        /// <summary>
        /// local variable _company
        /// </summary>
        private string _company;
        [DataMember]
        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }
        /// <summary>
        /// local variable _title
        /// </summary>
        private string _title;
        [DataMember]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }

    /// <summary>
    /// Model class for binding User Group Association
    /// </summary>
    public class BindUserGroupAssociationModel
    {
        /// <summary>
        /// local variable _adCommonName
        /// </summary>
        private string _groupName;
        [DataMember]
        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }
        /// <summary>
        /// local variable _groupGuid
        /// </summary>
        private Guid _groupGuid = Guid.Empty;
        [DataMember]
        public Guid GroupGuid
        {
            get { return _groupGuid; }
            set { _groupGuid = value; }
            
        }
       
        /// <summary>
        /// local variable _adCommonName
        /// </summary>
        private string _adCommonName;
        [DataMember]
        public string ADCommonName
        {
            get { return _adCommonName; }
            set { _adCommonName = value; }
        }
        /// <summary>
        /// local variable _adCommonName
        /// </summary>
        private string _adLogon;
        [DataMember]
        public string ADLogon
        {
            get { return _adLogon; }
            set { _adLogon = value; }
        }
        /// <summary>
        /// local variable _userGuid
        /// </summary>
        private Guid _userGuid;
        [DataMember]
        public Guid UserGuid
        {
            get { return _userGuid; }
            set { _userGuid = value; }
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        /// <summary>
        /// local variable _id
        /// </summary>
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// local variable _createdDate
        /// </summary>
        private DateTime _createdDate;
        [DataMember]
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
           
        }
        /// <summary>
        /// local variable _modifiedDate
        /// </summary>
        private DateTime _modifiedDate;
        [DataMember]
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }

        /// <summary>
        /// local variable _createdBy
        /// </summary>
        private Guid _createdBy;
        [DataMember]
        public Guid CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        /// <summary>
        /// local variable _modifiedBy
        /// </summary>
        private Guid _modifiedBy;
        [DataMember]
        public Guid ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }
    }

}
