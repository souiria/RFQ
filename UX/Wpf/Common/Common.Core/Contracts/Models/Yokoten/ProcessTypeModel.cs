/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ProcessTypeModel.cs
Function           :   Data contract for ProcessType
Created By         :   Amit Agarwal
Created on         :   30-Jan-2020
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
    public class ProcessTypeModel : BaseModel<Guid>
    {
        private string _processType;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ProcessType
        {
            get => _processType;
            set => SetProperty(ref _processType, value);
        }

        private string _processDescription;
        [DataMember]
        [Required]
        [StringLength(1000)]
        public string ProcessDescription
        {
            get => _processDescription;
            set => SetProperty(ref _processDescription, value);
        }
    }
}
