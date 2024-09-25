/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SellerDetailsModel.cs
Function           :   Seller Details
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
    public class SellerDetailsModel : BaseModel<Guid>
    {
        private string _sellerCode;
        /// <summary>
        /// Get or Set for {SellerCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string SellerCode
        {
            get => _sellerCode;
            set => SetProperty(ref _sellerCode, value);
        }

        private string _sellerName;
        /// <summary>
        /// Get or Set for {SellerName}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string SellerName
        {
            get => _sellerName;
            set => SetProperty(ref _sellerName, value);
        }
    }
}
