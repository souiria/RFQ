/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AuditPrimaryProcessModel.cs
Function           :   Data contract for Audit Primary Process
Created By         :   Pawan
Created on         :   29-Jul-2020
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    /// <summary>
    /// Data contract to maintain Audit Primary Process
    /// </summary>
    [DataContract, Serializable]
    public class AuditPrimaryProcessModel : BaseModel<Guid>
    {
        private string _auditPrimaryProcessName;
        /// <summary>
        /// Get or Set for {AuditPrimaryProcessName}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string AuditPrimaryProcessName
        {
            get => _auditPrimaryProcessName;
            set => SetProperty(ref _auditPrimaryProcessName, value);
        }
       
        private Guid _parentId;
        /// <summary>
        /// Get or Set for {ParentId}
        /// </summary>
        [DataMember]
        [Required]
        
        public Guid ParentId
        {
            get => _parentId;
            set => SetProperty(ref _parentId, value);
        }
    }
}
