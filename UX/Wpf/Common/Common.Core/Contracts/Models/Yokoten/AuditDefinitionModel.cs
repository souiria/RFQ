/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AuditDefinitionModel.cs
Function           :   Data contract for AuditDefinition
Created By         :   Shivam Dhingra
Created on         :   14-Feb-2020
Revision History   :   [20-Feb-2020] : Pawan
                   :   [] : Added field for Task Sequence  
                   :   [21-Feb-2020] : Srashti
                   :   [] : Added field for AuditDefinition
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
    public class AuditDefinitionModel : BaseModel<Guid>
    {
        private Guid parentId;
        [DataMember]
        [Required]
        public Guid ParentId
        {
            get => parentId;
            set => SetProperty(ref parentId, value);
        }

        private string _grade;
        [DataMember]
        [StringLength(5000)]
        public string Grade
        {
            get => _grade;
            set => SetProperty(ref _grade, value);
        }

        private string _auditDefinition;
        /// <summary>
        /// This field will set Sequence of Audit Definition
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string AuditDefinition
        {
            get => _auditDefinition;
            set => SetProperty(ref _auditDefinition, value);
        }

        private int _taskSequence;
        /// <summary>
        /// This field will set Sequence of Audit Tasks
        /// </summary>
        [DataMember]
        [Required]
        public int TaskSequence
        {
            get => _taskSequence;
            set => SetProperty(ref _taskSequence, value);
        }

    }
}
