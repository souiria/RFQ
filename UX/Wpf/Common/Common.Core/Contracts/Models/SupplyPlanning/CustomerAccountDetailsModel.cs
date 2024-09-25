/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerAccountDetailsModel.cs
Function           :   Customer Account Details
Created By         :   Srashti Gupta
Created on         :   10-Feb-2020
Revision History   :   [10-Feb-2020]: Srashti Gupta
                   :   Change the datatype of {CustomerAccountNumber}
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
    public class CustomerAccountDetailsModel : BaseModel<Guid>
    {
        private string _customerAccountNumber;
        /// <summary>
        /// Get or Set for {CustomerAccountNumber}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(70)]
        public string CustomerAccountNumber
        {
            get => _customerAccountNumber;
            set => SetProperty(ref _customerAccountNumber, value);
        }
    }
}
