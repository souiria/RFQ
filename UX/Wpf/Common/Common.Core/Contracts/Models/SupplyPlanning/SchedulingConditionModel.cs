/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SchedulingConditionModel.cs
Function           :   Scheduling Condition
Created By         :   Srashti Gupta
Created on         :   10-Feb-2020
Revision History   :   
                   :   
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for EDISetUpMasters Service
    /// </summary>
    [DataContract, Serializable]
    public class SchedulingConditionModel : BaseModel<Guid>
    {
        private string _schedulingConditionCode;
        /// <summary>
        /// Get or Set for {SchedulingConditionCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(3)]
        public string SchedulingConditionCode
        {
            get => _schedulingConditionCode;
            set => SetProperty(ref _schedulingConditionCode, value);
        }

        private string _schedulingConditionDescription;
        /// <summary>
        /// Get or Set for {SchedulingConditionDescription}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string SchedulingConditionDescription
        {
            get => _schedulingConditionDescription;
            set => SetProperty(ref _schedulingConditionDescription, value);
        }
    }
}
