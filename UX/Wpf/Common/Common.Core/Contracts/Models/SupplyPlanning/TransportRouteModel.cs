/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   TransportRouteModel.cs
Function           :   Transport Route
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
    public class TransportRouteModel : BaseModel<Guid>
    {
        private string _transportRouteCode;
        /// <summary>
        /// Get or Set for {TransportRouteCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(70)]
        public string TransportRouteCode
        {
            get => _transportRouteCode;
            set => SetProperty(ref _transportRouteCode, value);
        }
    }
}
