/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplyChainMappingSectionModel.cs
Function           :   Data Contract for SupplyChainMappingSection
Created By         :   Shivam Dhingra
Created on         :   14-May-2020
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
    /// Data Contract for SupplyChainMappingSection
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainMappingSectionModel : BaseModel<Guid>
    {

        private string _supplySection;
        /// <summary>
        /// Get or Set for {_supplySection}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string SupplySection
        {
            get => _supplySection;
            set => SetProperty(ref _supplySection, value);
        }

    }
}
