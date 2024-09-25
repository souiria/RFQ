/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ConsigneeDetailsModel.cs
Function           :   Consignee Details
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
    public class ConsigneeDetailsModel : BaseModel<Guid>
    {
        private string _consigneeCode;
        /// <summary>
        /// Get or Set for {ConsigneeCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string ConsigneeCode
        {
            get => _consigneeCode;
            set => SetProperty(ref _consigneeCode, value);
        }

        private string _consigneeName;
        /// <summary>
        /// Get or Set for {ConsigneeName}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string ConsigneeName
        {
            get => _consigneeName;
            set => SetProperty(ref _consigneeName, value);
        }
    }
}
