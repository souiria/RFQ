/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AuditNameModel.cs
Function           :   Data contract for Audit Name
Created By         :   Pawan Kumar
Created on         :   29-Jul-2020
Revision History   :   [17-Aug-2020] :Pawan
                   :   [] : Added field for IsIATF , IsStandardSectionExists 
                   :   [03-Sep-2020] :Pawan
                   :   [] : Added field for IsNonConformity  
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    /// <summary>
    /// Data Contract for Audit Name
    /// </summary>
    [DataContract, Serializable]
    public class AuditNameModel : BaseModel<Guid>
    {
        private Guid _auditTypeGuid;
        /// <summary>
        /// Get or Set for {AuditTypeGuid}
        /// </summary>
        [DataMember]
        [Required]
        public Guid AuditTypeGuid
        {
            get => _auditTypeGuid;
            set => SetProperty(ref _auditTypeGuid, value);
        }

        private string _auditNameDescription;
        /// <summary>
        /// Get or Set for {AuditNameDescription}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string AuditNameDescription
        {
            get => _auditNameDescription;
            set => SetProperty(ref _auditNameDescription, value);
        }

        private bool _isAttachmentsRequired;
        /// <summary>
        /// Get or Set for {IsAttachmentsRequired}
        /// </summary>
        [DataMember]
        public bool IsAttachmentsRequired
        {
            get => _isAttachmentsRequired;
            set => SetProperty(ref _isAttachmentsRequired, value);
        }

        private bool _isProcessMandatory;
        /// <summary>
        /// Get or Set for {IsProcessMandatory}
        /// </summary>
        [DataMember]
        public bool IsProcessMandatory
        {
            get => _isProcessMandatory;
            set => SetProperty(ref _isProcessMandatory, value);
        }

        private bool _isIATF;
        /// <summary>
        /// Get or Set for {IsIATF}
        /// </summary>
        [DataMember]
        public bool IsIATF
        {
            get => _isIATF;
            set => SetProperty(ref _isIATF, value);
        }

        private bool _isStandardSectionsExist;
        /// <summary>
        /// Get or Set for {IsStandardSectionsExist}
        /// </summary>
        [DataMember]
        public bool IsStandardSectionsExist
        {
            get => _isStandardSectionsExist;
            set => SetProperty(ref _isStandardSectionsExist, value);
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

        private bool _isNonConformity;
        /// <summary>
        /// Get or Set for {IsNonConformity}
        /// </summary>
        [DataMember]
        public bool IsNonConformity
        {
            get => _isNonConformity;
            set => SetProperty(ref _isNonConformity, value);
        }

    }
}
