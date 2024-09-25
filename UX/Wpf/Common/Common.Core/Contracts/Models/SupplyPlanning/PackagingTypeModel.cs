/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   PackagingTypeModel.cs
Function           :   Packaging Type
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
    public class PackagingTypeModel : BaseModel<Guid>
    {
        private string _packagingType;
        /// <summary>
        /// Get or Set for {PackagingType}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(17)]
        public string PackagingType
        {
            get => _packagingType;
            set => SetProperty(ref _packagingType, value);
        }

        private string _packagingDescription;
        /// <summary>
        /// Get or Set for {PackagingDescription}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string PackagingDescription
        {
            get => _packagingDescription;
            set => SetProperty(ref _packagingDescription, value);
        }
    }
}
