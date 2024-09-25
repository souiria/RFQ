/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ConsignorDetailsModel.cs
Function           :   Consignor Details
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
    public class ConsignorDetailsModel : BaseModel<Guid>
    {
        private string _consignorCode;
        /// <summary>
        /// Get or Set for {ConsignorCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string ConsignorCode
        {
            get => _consignorCode;
            set => SetProperty(ref _consignorCode, value);
        }

        private string _consignorName;
        /// <summary>
        /// Get or Set for {ConsignorName}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string ConsignorName
        {
            get => _consignorName;
            set => SetProperty(ref _consignorName, value);
        }
    }
}
