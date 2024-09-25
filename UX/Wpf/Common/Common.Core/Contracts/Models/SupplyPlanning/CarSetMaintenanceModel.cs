/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  CarSetMaintenanceModel.cs
Function           :  Car Set Maintenance Model Model
Created By         :  Piyush Anand
Created on         :  [HD-00409165] : 02-Apr-2024
Revision History   : 
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for CarSetMaintenance Service 
    /// </summary>
    [DataContract, Serializable]
    public class CarSetMaintenanceModel : BaseModel<Guid>
    {
        private Guid customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerBusinessGroupGuid
        {
            get => customerBusinessGroupGuid;
            set => customerBusinessGroupGuid = value;
        }

        private Guid vehicleGuid;
        /// <summary>
        /// Get or Set for {VehicleGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid VehicleGuid
        {
            get => vehicleGuid;
            set => vehicleGuid = value;
        }

        private Guid familyGuid;
        /// <summary>
        /// Get or Set for {FamilyGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid FamilyGuid
        {
            get => familyGuid;
            set => familyGuid = value;
        }

        private decimal ratio;
        /// <summary>
        /// Get or Set for {Ratio}.
        /// </summary>
        [DataMember]
        [Required]
        public decimal Ratio
        {
            get => ratio;
            set => ratio = value;
        }

        private string customerBusinessGroupName;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroup}.
        /// </summary>
        [DataMember]
        [Required]
        public string CustomerBusinessGroupName
        {
            get => customerBusinessGroupName;
            set => customerBusinessGroupName = value;
        }

        private string vehicle;
        /// <summary>
        /// Get or Set for {Vehicle}.
        /// </summary>
        [DataMember]
        [Required]
        public string Vehicle
        {
            get => vehicle;
            set => vehicle = value;
        }

        private string family;
        /// <summary>
        /// Get or Set for {Family}.
        /// </summary>
        [DataMember]
        [Required]
        public string Family
        {
            get => family;
            set => family = value;
        }
    }

    /// <summary>
    /// Data Contract use for Family Service 
    /// </summary>
    [DataContract, Serializable]
    public class ComboFamilyModel
    {
        private Guid familyGuid;
        /// <summary>
        /// Get or Set for {FamilyGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid FamilyGuid
        {
            get => familyGuid;
            set => familyGuid = value;
        }

        private string family;
        /// <summary>
        /// Get or Set for {Family}.
        /// </summary>
        [DataMember]
        [Required]
        public string Family
        {
            get => family;
            set => family = value;
        }
    }
    /// <summary>
    /// Data Contract use for Vehicle Service 
    /// </summary>
    [DataContract, Serializable]
    public class ComboVehicleModel
    {
        /// <summary>
        /// Local variable vehicleGuid
        /// </summary>
        private Guid vehicleGuid;
        /// <summary>
        /// Get or Set for {VehicleGuid}.
        /// </summary>
        [DataMember]
        public Guid VehicleGuid
        {
            get => vehicleGuid;
            set => vehicleGuid = value;
        }

        /// <summary>
        /// Local variable vehicle     
        /// </summary>
        private string vehicle;
        /// <summary>
        /// Get or Set for {Vehicle}.
        /// </summary>
        [DataMember]
        public string Vehicle
        {
            get => vehicle;
            set => vehicle = value;
        }
    }
}
