/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   TransportSiteMasterModel.cs
Function           :   Creating Trasport Order property for Transport Managment System.
Created By         :   Dharmendra
Created on         :   06-Mar-2024
Revision History   :
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.TransportManagementSystem
{
    [DataContract, Serializable]
    public class TransportSiteMasterModel : BaseModel<Guid>
    {
        private string _customer;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        [Required]
        public string Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }
        private string _shipFromLocation;
        /// <summary>
        /// Get or Set for {ShipFromLocation}.
        /// </summary>
        [DataMember]
        [Required]
        public string ShipFromLocation
        {
            get => _shipFromLocation;
            set => SetProperty(ref _shipFromLocation, value);
        }
        private string _shipToLocation;
        /// <summary>
        /// Get or Set for {ShipToLocation}.
        /// </summary>
        [DataMember]
        [Required]
        public string ShipToLocation
        {
            get => _shipToLocation;
            set => SetProperty(ref _shipToLocation, value);
        }
        private Guid _shipFromLocationGuid;
        /// <summary>
        /// Get or Set for {ShipFromLocationGuid}.
        /// </summary>
        [DataMember]
        public Guid ShipFromLocationGuid
        {
            get => _shipFromLocationGuid;
            set => _shipFromLocationGuid = value;
        }
        private Guid _shipToLocationGuid;
        /// <summary>
        /// Get or Set for {ShipFromLocationGuid}.
        /// </summary>
        [DataMember]
        public Guid ShipToLocationGuid
        {
            get => _shipToLocationGuid;
            set => _shipToLocationGuid = value;
        }
        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {ShipFromLocationGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }
        private bool _isActive = true;
        [DataMember]
        public new bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
