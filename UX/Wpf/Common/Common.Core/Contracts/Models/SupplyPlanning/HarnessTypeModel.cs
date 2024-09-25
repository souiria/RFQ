/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   HarnessTypeModel.cs
Function           :   HarnessType
Created By         :   Shivam Dhingra
Created on         :   16-Oct-2020
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

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for HarnessType
    /// </summary>
    [DataContract, Serializable]
    public class HarnessTypeModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _harnessTypeCode  
        /// </summary>
        private string _harnessTypeCode;
        /// <summary>
        /// Get or Set for {HarnessTypeCode}.
        /// Value will automatically generated through FunctionControlSequence
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(18)]
        public string HarnessTypeCode
        {
            get => _harnessTypeCode;
            set => SetProperty(ref _harnessTypeCode, value);
        }

        /// <summary>
        /// Local variable _harnessTypeDescription     
        /// </summary>
        private string _harnessTypeDescription;
        /// <summary>
        /// Get or Set for {HarnessTypeDescription}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string HarnessTypeDescription
        {
            get => _harnessTypeDescription;
            set => SetProperty(ref _harnessTypeDescription, value);
        }
    }
}
