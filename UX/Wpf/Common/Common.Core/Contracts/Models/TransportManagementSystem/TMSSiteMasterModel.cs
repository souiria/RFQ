/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  TMSSiteMasterModel.cs
Function           :   
Created By         :  Nishu
Created on         :  25-Apr-2024
Revision History   :   
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.TransportManagementSystem
{
    /// <summary>
    ///  Model for TMSSiteMaste Screen
    /// </summary>
    [DataContract, Serializable]

    public class TMSSiteMasterModel : BaseModel<Guid>
    {
        private Guid _businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// </summary>
        [DataMember][Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => _businessUnitGuid = value;
        }
        private string _shipFromLocation;
        /// <summary>
        /// Get or Set for {BusinessUnitCode}.
        /// </summary>
        [DataMember]
        [Required]
        public string ShipFromLocation
        {
            get => _shipFromLocation;
            set => SetProperty(ref _shipFromLocation, value);
        }
        private string _businessUnitName;
        /// <summary>
        /// Get or Set for {BusinessUnitName}.
        /// </summary>
        [DataMember]
        [Required]
        public string BusinessUnitName
        {
            get => _businessUnitName;
            set => SetProperty(ref _businessUnitName, value);
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

    }
}
