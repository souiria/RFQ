/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   Audit.cs
Function           :   Data contract for Audit
Created By         :   Shivam Dhingra
Created on         :   07-Feb-2020
Revision History   :   []
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Yokoten
{
    [DataContract, Serializable]
    public class AuditModel : BaseModel<Guid>
    {
        private string _auditType;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string AuditType
        {
            get => _auditType;
            set => SetProperty(ref _auditType, value);
        }
    }
}
