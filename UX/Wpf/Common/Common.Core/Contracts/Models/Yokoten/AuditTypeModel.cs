/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AuditTypeModel.cs
Function           :   Data contract for Audit Type
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
    /// Data Contract for Audit Type
    /// </summary>
    [DataContract, Serializable]
    public class AuditTypeModel : BaseModel<Guid>
    {
        private string _auditTypeDescription;
        /// <summary>
        /// Get or Set for {AuditTypeDescription}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(50)]
        public string AuditTypeDescription
        {
            get => _auditTypeDescription;
            set => SetProperty(ref _auditTypeDescription, value);
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
