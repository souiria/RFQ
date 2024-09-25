/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WorkstationModel.cs
Function           :   Workstation
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
    public  class WorkstationModel : BaseModel<Guid>
    {
        private string _workstationCode;
        /// <summary>
        /// Get or Set for {WorkstationCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string WorkstationCode
        {
            get => _workstationCode;
            set => SetProperty(ref _workstationCode, value);
        }

        private string _workstationDescription;
        /// <summary>
        /// Get or Set for {WorkstationDescription}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string WorkstationDescription
        {
            get => _workstationDescription;
            set => SetProperty(ref _workstationDescription, value);
        }
    }
}
