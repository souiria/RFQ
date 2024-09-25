/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierUserMaster.cs
Function           :   SupplierUserMaster Model
Created By         :   Sachin Pandey
Created on         :   04-Dec-2023
Revision History   :   []
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    /// <summary>
    /// Model for SupplierUserMaster Screen
    /// </summary>
    [DataContract, Serializable]
    public class SupplierUserMasterModel : BaseModel<Guid>
    {
        private Guid _businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }
        private string _businessUnit;
        /// <summary>
        /// Get or Set for {BusinessUnit}.
        /// </summary>
        [DataMember]
        [Required]
        public string BusinessUnit
        {
            get => _businessUnit;
            set => SetProperty(ref _businessUnit, value);
        }

        private bool _userType;
        /// <summary>
        /// Get or Set for {UserType}.
        /// </summary>
        [DataMember]

        public bool UserType
        {
            get => _userType;
            set => SetProperty(ref _userType, value);
        }

        private string _aDUserName;
        /// <summary>
        /// Get or Set for {ADUserName}.
        /// </summary>
        [DataMember]
        [Required]
        public string ADUserName
        {
            get => _aDUserName;
            set => SetProperty(ref _aDUserName, value);
        }

        private string _userLogOnName;
        /// <summary>
        /// Get or Set for {UserLogOnName}.
        /// </summary>
        [DataMember]
        [Required]
        public string UserLogOnName
        {
            get => _userLogOnName;
            set => SetProperty(ref _userLogOnName, value);
        }

        private Guid _roleGuid;
        /// <summary>
        /// Get or Set for {RoleGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid RoleGuid
        {
            get => _roleGuid;
            set => SetProperty(ref _roleGuid, value);
        }

        private string _role;
        /// <summary>
        /// Get or Set for {Role}.
        /// </summary>
        [DataMember]
        [Required]
        public string Role
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }

        private string _userPassword;
        /// <summary>
        /// Get or Set for {UserPassword}.
        /// </summary>
        [DataMember]
        [Required]
        public string UserPassword
        {
            get => _userPassword;
            set => SetProperty(ref _userPassword, value);
        }

        private string _passwordEncryptionKey = "Base64";
        /// <summary>
        /// Get or Set for {PasswordEncryptionKey}.
        /// </summary>
        [DataMember]
        [Required]
        public string PasswordEncryptionKey
        {
            get => _passwordEncryptionKey;
            set => SetProperty(ref _passwordEncryptionKey, value);
        }
        private string _emailAddress;
        /// <summary>
        /// Get or Set for {EmailAddress}.
        /// </summary>
        [DataMember]
        [Required]
        public string EmailAddress
        {
            get => _emailAddress;
            set => _emailAddress = value;
        }

        private Guid _departmentGuid;
        /// <summary>
        /// Get or Set for {DepartmentUnitGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid DepartmentGuid
        {
            get => _departmentGuid;
            set => SetProperty(ref _departmentGuid, value);
        }

        private string _department;
        /// <summary>
        /// Get or Set for {Department}.
        /// </summary>
        [DataMember]
        [Required]
        public string Department
        {
            get => _department;
            set => SetProperty(ref _department, value);
        }

        private DateTime? _lastLoginDateTime;
        /// <summary>
        /// Get or Set for {LastLoginDateTime}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime? LastLoginDateTime
        {
            get => _lastLoginDateTime;
            set => SetProperty(ref _lastLoginDateTime, value);
        }

        private bool _resetPassword;
        /// <summary>
        /// Get or Set for {ResetPassword}.
        /// </summary>
        [DataMember]

        public bool ResetPassword
        {
            get => _resetPassword;
            set => SetProperty(ref _resetPassword, value);
        }

        private bool _lockedStatus;
        /// <summary>
        /// Get or Set for {LockedStatus}.
        /// </summary>
        [DataMember]

        public bool LockedStatus
        {
            get => _lockedStatus;
            set => SetProperty(ref _lockedStatus, value);
        }

        private DateTime? _lastPasswordChangeDate;
        /// <summary>
        /// Get or Set for {LastPasswordChangeDate}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime? LastPasswordChangeDate
        {
            get => _lastPasswordChangeDate;
            set => SetProperty(ref _lastPasswordChangeDate, value);
        }

        private bool _isPasswordExpired;
        /// <summary>
        /// Get or Set for {IsPasswordExpired}.
        /// </summary>
        [DataMember]

        public bool IsPasswordExpired
        {
            get => _isPasswordExpired;
            set => SetProperty(ref _isPasswordExpired, value);
        }

        private bool _isActive;
        /// <summary>
        /// Get or Set for {IsActive}.
        /// </summary>
        [DataMember]

        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private bool _supplierPortalAccountRequired;
        /// <summary>
        /// Get or Set for {SupplierPortalAccountRequired}.
        /// </summary>
        [DataMember]
        public bool SupplierPortalAccountRequired
        {
            get => _supplierPortalAccountRequired;
            set => SetProperty(ref _supplierPortalAccountRequired, value);
        }
    }
    //For Business Unit DropDown
    public class BusinessUnitDropDownModel
    {
        private Guid businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => businessUnitGuid;
            set => businessUnitGuid = value;
        }

        private string _businessUnitName;
        /// <summary>
        /// Get or Set for {BusinessUnitName}.
        /// </summary>
        [DataMember]
        [Required]
        public string BusinessUnitName
        {
            get => _businessUnitName;
            set => _businessUnitName = value;
        }

        private string _businessUnitCode;
        /// <summary>
        /// Get or Set for {BusinessUnitCode}.
        /// </summary>
        [DataMember]
        [Required]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }


        private string clsType;
        /// <summary>
        /// Get or Set for {ClsType}.
        /// </summary>
        [DataMember]
        [Required]
        public string ClsType
        {
            get => clsType;
            set => clsType = value;
        }
    }
    public class DepartmentDropDownModel
    {
        private Guid _Id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid Id
        {
            get => _Id;
            set => _Id = value;
        }
        private string _departmentName;
        /// <summary>
        /// Get or Set for {ClsType}.
        /// </summary>
        [DataMember]
        [Required]
        public string DepartmentName
        {
            get => _departmentName;
            set => _departmentName = value;
        }
    }
    public class RoleDropDownModel
    {
        private Guid _Id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid Id
        {
            get => _Id;
            set => _Id = value;
        }
        private string _systemRole;
        /// <summary>
        /// Get or Set for {SystemRole}.
        /// </summary>
        [DataMember]
        [Required]
        public string SystemRole
        {
            get => _systemRole;
            set => _systemRole = value;
        }
        private string _userFunction;
        /// <summary>
        /// Get or Set for {UserFunction}.
        /// </summary>
        [DataMember]
        [Required]
        public string UserFunction
        {
            get => _userFunction;
            set => _userFunction = value;
        }
    }
    public class ADUserNameDropDownModel
    {
        private Guid _userGuid;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }
        private string _aDCommonName;
        /// <summary>
        /// Get or Set for {ADCommonName}.
        /// </summary>
        [DataMember]
        [Required]
        public string ADCommonName
        {
            get => _aDCommonName;
            set => _aDCommonName = value;
        }
        private string _emailAddress;
        /// <summary>
        /// Get or Set for {EmailAddress}.
        /// </summary>
        [DataMember]
        [Required]
        public string EmailAddress
        {
            get => _emailAddress;
            set => _emailAddress = value;
        }
    }
}
