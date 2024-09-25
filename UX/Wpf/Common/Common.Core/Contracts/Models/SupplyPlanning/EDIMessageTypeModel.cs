/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDIMessageTypeModel.cs
Function           :   EDI Message Type
Created By         :   Srashti Gupta
Created on         :   10-Feb-2020
Revision History   :   [28-Oct-2022] : Sejal Srivastava
*                  :   [] : Increased EDIMessageTypeCode length from 6 to 8 characters 
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
    public class EDIMessageTypeModel : BaseModel<Guid>
    {
        private string _ediMessageTypeCode;
        /// <summary>
        /// Get or Set for {EDIMessageTypeCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(8)]
        public string EDIMessageTypeCode
        {
            get => _ediMessageTypeCode;
            set => SetProperty(ref _ediMessageTypeCode, value);
        }
        private string _ediMessageTypeDescription;
        /// <summary>
        /// Get or Set for {EDIMessageTypeDescription}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string EDIMessageTypeDescription
        {
            get => _ediMessageTypeDescription;
            set => SetProperty(ref _ediMessageTypeDescription, value);
        }
    }
}
