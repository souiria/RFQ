/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SchedulingFrequencyModel.cs
Function           :   Scheduling Frequency
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
    public class SchedulingFrequencyModel : BaseModel<Guid>
    {
        private string _schedulingFrequencyCode;
        /// <summary>
        /// Get or Set for {SchedulingFrequencyCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(3)]
        public string SchedulingFrequencyCode
        {
            get => _schedulingFrequencyCode;
            set => SetProperty(ref _schedulingFrequencyCode, value);
        }

        private string _schedulingFrequencyDescription;
        /// <summary>
        /// Get or Set for {SchedulingFrequencyDescription}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string SchedulingFrequencyDescription
        {
            get => _schedulingFrequencyDescription;
            set => SetProperty(ref _schedulingFrequencyDescription, value);
        }
    }
}
