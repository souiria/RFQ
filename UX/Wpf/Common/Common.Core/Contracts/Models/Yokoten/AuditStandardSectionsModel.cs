/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AuditTypeModel.cs
Function           :   Data contract for Audit Standard Sections
Created By         :   Pawan Kumar
Created on         :   29-Jul-2020
Revision History   :   []
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    /// <summary>
    /// Data Contract for Audit Standard Sections
    /// </summary>
    [DataContract, Serializable]
    public class AuditStandardSectionsModel : BaseModel<Guid>
    {
        private Guid _auditNameGuid;
        /// <summary>
        /// Get or Set for {AuditNameGuid}
        /// </summary>
        [DataMember]
        [Required]
        public Guid AuditNameGuid
        {
            get => _auditNameGuid;
            set => SetProperty(ref _auditNameGuid, value);
        }

        private string _standardSectionsDescription;
        /// <summary>
        /// Get or Set for {StandardSectionsDescription}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(200)]
        public string StandardSectionsDescription
        {
            get => _standardSectionsDescription;
            set => SetProperty(ref _standardSectionsDescription, value);
        }

        private bool _isActive;
        /// <summary>
        /// Get or Set for {IsActive}
        /// </summary>
        [DataMember]
        public new bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

    }
}
