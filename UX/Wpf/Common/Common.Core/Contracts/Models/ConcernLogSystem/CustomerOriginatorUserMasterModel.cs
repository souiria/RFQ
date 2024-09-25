/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  CustomerOriginatorUserMasterModel.cs
Function           :  Customer Originator User Master Model
Created By         :  Piyush Anand
Created on         :  30-Oct-2023
Revision History   : 
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    public class CustomerOriginatorUserMasterModel : BaseModel<Guid>
    {
        private Guid userNameGuid;
        /// <summary>
        /// Get or Set for {UserNameGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid UserNameGuid
        {
            get => userNameGuid;
            set => SetProperty(ref userNameGuid, value);
        }

        private Guid customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerGuid
        {
            get => customerGuid;
            set => SetProperty(ref customerGuid, value);
        }

        private Guid businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => businessUnitGuid;
            set => SetProperty(ref businessUnitGuid, value);
        }

        private Guid userManagerGuid;
        /// <summary>
        /// Get or Set for {UserManagerGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid UserManagerGuid
        {
            get => userManagerGuid;
            set => SetProperty(ref userManagerGuid, value);
        }

        private Guid escalateToGuid;
        /// <summary>
        /// Get or Set for {EscalateToGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid EscalateToGuid
        {
            get => escalateToGuid;
            set => SetProperty(ref escalateToGuid, value);
        }

        private Guid shadowToGuid;
        /// <summary>
        /// Get or Set for {ShadowToGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid ShadowToGuid
        {
            get => shadowToGuid;
            set => SetProperty(ref shadowToGuid, value);
        }

        private string businessUnitName;
        /// <summary>
        /// Get or Set for {BusinessUnitName}.
        /// </summary>
        [DataMember]
        [Required]
        public string BusinessUnitName
        {
            get => businessUnitName;
            set => SetProperty(ref businessUnitName, value);
        }

        private string customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        [Required]
        public string CustomerName
        {
            get => customerName;
            set => SetProperty(ref customerName, value);
        }

        private string userName;
        /// <summary>
        /// Get or Set for {UserName}.
        /// </summary>
        [DataMember]
        [Required]
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }
        private string userManager;
        /// <summary>
        /// Get or Set for {UserManager}.
        /// </summary>
        [DataMember]
        [Required]
        public string UserManager
        {
            get => userManager;
            set => SetProperty(ref userManager, value);
        }
        private string escalateTo;
        /// <summary>
        /// Get or Set for {EscalateTo}.
        /// </summary>
        [DataMember]
        [Required]
        public string EscalateTo
        {
            get => escalateTo;
            set => SetProperty(ref escalateTo, value);
        }
        private string shadowTo;
        /// <summary>
        /// Get or Set for {ShadowTo}.
        /// </summary>
        [DataMember]
        [Required]
        public string ShadowTo
        {
            get => shadowTo;
            set => SetProperty(ref shadowTo, value);
        }

        private string customerCode;
        /// <summary>
        /// Get or Set for {ShadowTo}.
        /// </summary>
        [DataMember]
        [Required]
        public string CustomerCode
        {
            get => customerCode;
            set => SetProperty(ref customerCode, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
