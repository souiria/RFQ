/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   BuyerDetailsModel.cs
Function           :   Buyer Details
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
    public class BuyerDetailsModel : BaseModel<Guid>
    {
        private string _buyerCode;
        /// <summary>
        /// Get or Set for {BuyerCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string BuyerCode
        {
            get => _buyerCode;
            set => SetProperty(ref _buyerCode, value);
        }

        private string _buyerName;
        /// <summary>
        /// Get or Set for {BuyerName}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string BuyerName
        {
            get => _buyerName;
            set => SetProperty(ref _buyerName, value);
        }
    }
}
