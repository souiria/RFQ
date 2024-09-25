/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AuditGradeModel.cs
Function           :   Data contract for AuditGrade
Created By         :   Shivam Dhingra
Created on         :   14-Feb-2020
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
    public class AuditGradeModel : BaseModel<Guid>
    {
        private string _grade;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string Grade
        {
            get => _grade;
            set => SetProperty(ref _grade, value);
        }

    }
}
