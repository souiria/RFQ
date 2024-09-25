/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WIPMaintenanceModel.cs
Function           :   WIP Maintenance
Created By         :   Srashti Gupta
Created on         :   11-Nov-2020
Revision History   :   [03-Dec-2020] : Shivam Dhingra
                   :   [] : Added new field BusinessUnitGuid  
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning.DRP
{
    /// <summary>
    /// Data Contract for WIP Maintenance
    /// </summary>
    [DataContract, Serializable]
    public class WIPMaintenanceModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _partNumber  
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(26)]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        /// <summary>
        /// Local variable _wipDate  
        /// </summary>
        private DateTime _wipDate;
        /// <summary>
        /// Get or Set for {WipDate}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime WipDate
        {
            get => _wipDate;
            set => SetProperty(ref _wipDate, value);
        }

        /// <summary>
        /// Local variable _wipQuantity  
        /// </summary>
        private int _wipQuantity = 0;
        /// <summary>
        /// Get or Set for {WipQuantity}.
        /// </summary>
        [DataMember]
        [Required]
        public int WipQuantity
        {
            get => _wipQuantity;
            set => SetProperty(ref _wipQuantity, value);
        }

        /// <summary>
        /// Local variable _businessUnitGuid  
        /// </summary>
        private Guid _businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// Data will store as a ManufacturingSiteGuid
        /// </summary>
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }
    }
}
