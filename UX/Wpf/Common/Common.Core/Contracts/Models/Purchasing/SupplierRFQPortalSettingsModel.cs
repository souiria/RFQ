/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierRFQPortalSettingsModel.cs
Function           :   Manages RFQ Settings for Supplier to login Supplier Web Portal 
Created By         :   Nitin Sagar
Created on         :   05-Jul-2019
Revision History   :   [12-Sep-2019] : Pawan
                   :   [] : Added field for User Email Details
                   :   [17-Oct-2019] : Pawan
                   :   [] : Added field for Is Manual Supplier 
                   :   [04-Feb-2020] : Sai Kiran
                   :   [] : Added field LastPasswordChangeDate,IsPasswordExpired,PreviousPasswords
                   :   [06-Feb-2020] : Srashti Gupta
                   :   [] : Change the return type and property name to PasswordHistory.
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Item of Supplier RFQ Settings
    /// </summary>
    [DataContract, Serializable]
    public class SupplierRFQPortalSettingsModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local Reference of Supplier Group id
        /// </summary>
        private Guid _supplierGroupGuid;

        /// <summary>
        /// Public Reference of Supplier Group id
        /// </summary>
        [DataMember]
        [Required]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => SetProperty(ref _supplierGroupGuid, value);
        }

        /// <summary>
        /// Local Reference of Supplier User Name
        /// </summary>
        private string _supplierUserName;

        /// <summary>
        /// Public Reference of Supplier User Name
        /// </summary>
        [DataMember]
        [Required]
        public string SupplierUserName
        {
            get => _supplierUserName;
            set => SetProperty(ref _supplierUserName, value);
        }

        /// <summary>
        /// Local Reference of Supplier Password
        /// </summary>
        private string _supplierPassword;

        /// <summary>
        /// Public Reference of Supplier Password
        /// </summary>
        [DataMember]
        [Required]
        public string SupplierPassword
        {
            get => _supplierPassword;
            set => SetProperty(ref _supplierPassword, value);
        }
        /// <summary>
        /// Local Reference of Password Encryption Key
        /// </summary>
        private string _passwordEncryptionKey;

        /// <summary>
        /// Public Reference of Password Encryption Key
        /// </summary>
        [DataMember]
        [Required]
        public string PasswordEncryptionKey
        {
            get => _passwordEncryptionKey;
            set => SetProperty(ref _passwordEncryptionKey, value);
        }
        /// <summary>
        /// Local Reference of Supplier Email
        /// </summary>
        private List<EmailModel> _supplierEmail;

        /// <summary>
        ///  Public Reference of Supplier Email
        /// </summary>
        [DataMember]
        [Required]
        public List<EmailModel> SupplierEmail
        {
            get => _supplierEmail;
            set => SetProperty(ref _supplierEmail, value);
        }
        /// <summary>
        /// Local Reference of Contact Guid
        /// </summary>
        private Guid _contactGuid;

        /// <summary>
        /// Public Reference of Contact Guid
        /// </summary>
        [DataMember]
        [Required]
        public Guid ContactGuid
        {
            get => _contactGuid;
            set => SetProperty(ref _contactGuid, value);
        }
        /// <summary>
        /// Local Reference of Locked Status
        /// </summary>
        private bool _lockedStatus;

        /// <summary>
        /// Public Reference of Locked Status
        /// </summary>
        [DataMember]
        [Required]
        public bool LockedStatus
        {
            get => _lockedStatus;
            set => SetProperty(ref _lockedStatus, value);
        }

        /// <summary>
        /// Local Reference of Last Login DateTime
        /// </summary>
        private DateTime _lastLoginDateTime;

        /// <summary>
        /// Public Reference of Last Login DateTime
        /// </summary>
        [DataMember]
        [Required]
        public DateTime LastLoginDateTime
        {
            get => _lastLoginDateTime;
            set => SetProperty(ref _lastLoginDateTime, value);
        }

        /// <summary>
        /// Local Reference of Manual Supplier
        /// </summary>
        private bool _isManualSupplier;

        /// <summary>
        /// Public Reference of Is Manual Supplier
        /// </summary>
        [DataMember]
        [Required]
        public bool IsManualSupplier
        {
            get => _isManualSupplier;
            set => SetProperty(ref _isManualSupplier, value);
        }

        /// <summary>
        /// Local Reference of Last Password Change Date
        /// </summary>
        private DateTime _lastPasswordChangeDate;

        /// <summary>
        /// Public Reference of Last Password Change Date
        /// </summary>
        [DataMember]
        [Required]
        public DateTime LastPasswordChangeDate
        {
            get => _lastPasswordChangeDate;
            set => SetProperty(ref _lastPasswordChangeDate, value);
        }


        /// <summary>
        /// Local Reference of IsPasswordExpired
        /// </summary>
        private bool _isPasswordExpired;
        /// <summary>
        /// Public Reference of IsPasswordExpired
        /// </summary>
        [DataMember]
        [Required]
        public bool IsPasswordExpired
        {
            get => _isPasswordExpired;
            set => SetProperty(ref _isPasswordExpired, value);
        }

        /// <summary>
        /// Local Reference of PasswordHistory
        /// </summary>
        private List<SupplierPasswordHistoryModel> _passwordHistory;
        /// <summary>
        /// Public Reference of PasswordHistory
        /// </summary>
        [DataMember]
        [Required]
        public List<SupplierPasswordHistoryModel> PasswordHistory
        {
            get => _passwordHistory;
            set => SetProperty(ref _passwordHistory, value);
        }

    }
}
