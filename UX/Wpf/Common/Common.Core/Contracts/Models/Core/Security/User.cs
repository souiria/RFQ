/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   User.cs
Function           :   User information
Created By         :   Dharmendra 
Created on         :   20-Dec-2019
Revision History   :   [20-Dec-2019] : Dharmendra
                   :   [] : Added New Fields for helddesk and user status  
                   :   [21-Jan-2019] : Dharmendra
                   :   [] : Added New Fields IsH1User  
*                  :  [25-Jan-2020] : Dharmendra
*                  :   [] : Add new properties UserCreationHelpDeskNumber,UserActivationDate,UserActivationBy
****************************************************************************************************/
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Core.Security
{
    [DataContract, Serializable, NotMapped]
    public class User : BindableBaseEntity, IEquatable<User>
    {
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _username;
        [DataMember]
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _name;
        [DataMember]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _firstName;
        [DataMember]
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }


        private string _surname;
        [DataMember]
        public string Surname
        {
            get => _surname;
            set => SetProperty(ref _surname, value);
        }

        private string _emailAddress;
        [DataMember]
        public string EmailAddress
        {
            get => _emailAddress;
            set => SetProperty(ref _emailAddress, value);
        }

        private string _logon;
        [DataMember]
        public string Logon
        {
            get => _logon;
            set => SetProperty(ref _logon, value);
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
        /// <summary>
        /// Local variable Creation Help Desk Date
        /// </summary>
        private DateTime? _creationHelpDeskDate;
        [DataMember]
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
        /// <summary>
        ///Local variable User  Active Directory Deactivation Date
        /// </summary>
        private DateTime? _activeDirectoryDeactivationDate;
        [DataMember]
        public DateTime? ActiveDirectoryDeactivationDate
        {
            get => _activeDirectoryDeactivationDate;
            set => SetProperty(ref _activeDirectoryDeactivationDate, value);
        }
        /// <summary>
        /// Local variable Active Directory User Status
        /// </summary>
        private bool? _isUserActive;
        [DataMember]
        public bool? IsUserActive
        {
            get => _isUserActive;
            set => SetProperty(ref _isUserActive, value);
        }
        /// <summary>
        /// Local variable for Account locked information
        /// </summary>
        private bool _isAccountLocked;
        [DataMember]
        public bool IsAccountLocked
        {
            get => _isAccountLocked;
            set => SetProperty(ref _isAccountLocked, value);
        }


        private string userRoles;
        [DataMember]
        public string UserRoles
        {
            get => userRoles;
            set => SetProperty(ref userRoles, value);
        }
        private DateTime? _createdDate;

        [DataMember, DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get => _createdDate ?? DateTime.UtcNow;
            set => SetProperty(ref _createdDate, value);
        }

        private DateTime? _modifiedDate;
        [DataMember, DataType(DataType.DateTime)]
        public DateTime? ModifiedDate
        {
            get => _modifiedDate ?? DateTime.UtcNow;
            set => SetProperty(ref _modifiedDate, value);
        }

        private Guid _createdBy;
        [DataMember]
        public Guid CreatedBy
        {
            get => _createdBy;
            set => SetProperty(ref _createdBy, value);
        }

        private Guid _modifiedBy;
        [DataMember]
        public Guid ModifiedBy
        {
            get => _modifiedBy;
            set => SetProperty(ref _modifiedBy, value);
        }
        private string _creationHelpDeskDescription;
        [DataMember]
        public string CreationHelpDeskDescription
        {
            get => _creationHelpDeskDescription;
            set => SetProperty(ref _creationHelpDeskDescription, value);
        }
        private string _lastHelpDeskDescription;
        [DataMember]
        public string LastHelpDeskDescription
        {
            get => _lastHelpDeskDescription;
            set => SetProperty(ref _lastHelpDeskDescription, value);
        }
        private DateTime? _lastHelpDeskDate;
        [DataMember]
        public DateTime? LastHelpDeskDate
        {
            get => _lastHelpDeskDate;
            set => SetProperty(ref _lastHelpDeskDate, value);
        }
        /// <summary>
        /// Local variable check is H1 User
        /// </summary>
        private bool _isH1User = false;
        [DataMember]
        public bool IsH1User
        {
            get => _isH1User;
            set => SetProperty(ref _isH1User, value);
        }
        /// <summary>
        /// Local Variable _userCreationHelpDeskNumber
        /// </summary>
        private string _h1UserCreationHelpDeskNumber;
        [DataMember]
        public string H1UserCreationHelpDeskNumber
        {
            get { return _h1UserCreationHelpDeskNumber; }
            set { SetProperty(ref _h1UserCreationHelpDeskNumber, value); }
        }
        /// <summary>
        /// Local Variable _userActivationDate
        /// </summary>
        private DateTime? _h1ActivationDate;
        [DataMember]
        public DateTime? H1ActivationDate
        {
            get { return _h1ActivationDate; }
            set { SetProperty(ref _h1ActivationDate, value); }
        }
        /// <summary>
        ///  Local Variable _userActivationBy;
        /// </summary>
        private string _h1ActivationBy;
        [DataMember]
        public string H1ActivationBy
        {
            get { return _h1ActivationBy; }
            set { SetProperty(ref _h1ActivationBy, value); }
        }
        #region IEquatable

        public bool Equals(User other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is User user)
                return Equals(user);
            // ReSharper disable once BaseObjectEqualsIsObjectEquals
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}
