/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  TMSSiteUserAssociationModel.cs
Function           :   
Created By         :  Nishu
Created on         :  01-May-2024
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.TransportManagementSystem
{
    /// <summary>
    ///  Model for TMSSiteUserAssociationMaster Screen
    /// </summary>
    [DataContract, Serializable]
   public class TMSSiteUserAssociationModel: BaseModel<Guid>
    {
        private Guid _userGuid;
        /// <summary>
        /// Get or Set for {UserGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid UserGuid 
        {
            get => _userGuid;
            set => _userGuid = value;
        }
        private string _aDLogon;
        /// <summary>
        /// Get or Set for {ADLogon}.
        /// </summary>
        [DataMember]
        public string ADLogon
        {
            get => _aDLogon;
            set => SetProperty(ref _aDLogon, value);
        }
        private string _emailAddress;
        /// <summary>
        /// Get or Set for {EmailAddress}.
        /// </summary>
        [DataMember]
        public string EmailAddress
        {
            get => _emailAddress;
            set => SetProperty(ref _emailAddress, value);
        }
        private Guid _tMSSiteMasterGuid;
        /// <summary>
        /// Get or Set for {TMSSiteMasterGuid}.
        /// </summary>
        [DataMember]
        public Guid TMSSiteMasterGuid 
        {
            get => _tMSSiteMasterGuid;
            set => SetProperty(ref _tMSSiteMasterGuid, value);
        }
        private string _businessUnitCode;
        /// <summary>
        /// Get or Set for {BusinessUnitCode}.
        /// </summary>
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }
        private string _businessUnitName;
        /// <summary>
        /// Get or Set for {BusinessUnitName}.
        /// </summary>
        [DataMember]
        public string BusinessUnitName
        {
            get => _businessUnitName;
            set => SetProperty(ref _businessUnitName, value);
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

    }

    public class ADUserNameComboModel : BindableBaseEntity
    {
        private Guid _id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        //private string _aDUserName;
        ///// <summary>
        ///// Get or Set for {ADUserName}.
        ///// </summary>
        //[DataMember]
        //public string ADUserName
        //{
        //    get => _aDUserName;
        //    set => SetProperty(ref _aDUserName, value);
        //}
        private string _ADLogon;
        /// <summary>
        /// Get or Set for {ADLogon}.
        /// </summary>
        [DataMember]
        public string ADLogon
        {
            get => _ADLogon;
            set => SetProperty(ref _ADLogon, value);
        }
        private string _eMailAddress;
        /// <summary>
        /// Get or Set for {ADLogon}.
        /// </summary>
        [DataMember]
        public string EmailAddress
        {
            get => _eMailAddress;
            set => SetProperty(ref _eMailAddress, value);
        }
    }
    public class BusinessUnitCodeComboModel : BindableBaseEntity
    {
        private Guid _businessUnitGuid;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private string _businessUnitCode;
        /// <summary>
        /// Get or Set for {BusinessUnitCode}.
        /// </summary>
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }
        private string _businessUnitName;
        /// <summary>
        /// Get or Set for {BusinessUnitName}.
        /// </summary>
        [DataMember]
        public string BusinessUnitName
        {
            get => _businessUnitName;
            set => SetProperty(ref _businessUnitName, value);
        }
    }
}
