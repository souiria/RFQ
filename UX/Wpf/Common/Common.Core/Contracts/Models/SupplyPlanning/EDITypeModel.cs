/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDITypeModel.cs
Function           :   EDI Type Model
Created By         :   Srashti Gupta
Created on         :   23-Jan-2020
Revision History   :   Srashti Gupta
                   :   [24-Jan-2020]:Change the Model as per the requirements.  
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
    public class EDITypeModel : BaseModel<Guid>
    {
        private string _customerEDIType;
        /// <summary>
        /// Forecast Order, Firm Order, Mix, Supplement
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(50)]
        public string CustomerEDIType
        {
            get => _customerEDIType;
            set => SetProperty(ref _customerEDIType, value);
        }
    }
}
