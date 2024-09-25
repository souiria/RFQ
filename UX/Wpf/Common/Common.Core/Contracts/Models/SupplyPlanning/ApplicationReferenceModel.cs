/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ApplicationReferenceModel.cs
Function           :   Application Reference
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
    public class ApplicationReferenceModel : BaseModel<Guid>
    {
        private string _applicationReferenceTypeCode;
        /// <summary>
        /// Get or Set for {ApplicationReferenceTypeCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(14)]
        public string ApplicationReferenceTypeCode
        {
            get => _applicationReferenceTypeCode;
            set => SetProperty(ref _applicationReferenceTypeCode, value);
        }
        private string _applicationReferenceTypeDescription;
        /// <summary>
        /// Get or Set for {ApplicationReferenceTypeDescription}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ApplicationReferenceTypeDescription
        {
            get => _applicationReferenceTypeDescription;
            set => SetProperty(ref _applicationReferenceTypeDescription, value);
        }
    }
}
