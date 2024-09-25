/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   UnloadingPointModel.cs
Function           :   Unloading Point
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
    public class UnloadingPointModel : BaseModel<Guid>
    {
        private string _unloadingPointCode;
        /// <summary>
        /// Get or Set for {UnloadingPointCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string UnloadingPointCode
        {
            get => _unloadingPointCode;
            set => SetProperty(ref _unloadingPointCode, value);
        }

        private string _unloadingPointDescription;
        /// <summary>
        /// Get or Set for {UnloadingPointDescription}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string UnloadingPointDescription
        {
            get => _unloadingPointDescription;
            set => SetProperty(ref _unloadingPointDescription, value);
        }
    }
}
