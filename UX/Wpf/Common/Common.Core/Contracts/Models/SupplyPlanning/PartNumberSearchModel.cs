/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   PartNumberSearchModel.cs
Function           :   Data contract for PartNumberSearch
Created By         :   Shivam Dhingra
Created on         :   30-Oct-2020
Revision History   :   [] : 
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract for Part Number Search
    /// </summary>
    [DataContract, Serializable]
    public class PartNumberSearchModel
    {
        /// <summary>
        /// Gets or sets the ProductNumberFrom
        /// </summary>
        [DataMember]
        public string PartNumberFrom { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ProductNumberTo
        /// </summary>
        [DataMember]
        public string PartNumberTo { get; set; } = string.Empty;
    }
}
