/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   TransportCustomerMappingModel.cs
Function           :   Model for Transport Customer Mapping Screen
Created By         :   Sachin Pandey
Created on         :   29-Apr-2024
Revision History   :
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.TransportManagementSystem
{
    public class TransportCustomerMappingModel : BaseModel<Guid>
    {
        private Guid _transportSiteCustomerGuid;
        /// <summary>
        /// Get or Set for {TransportSiteCustomerGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid TransportSiteCustomerGuid
        {
            get => _transportSiteCustomerGuid;
            set => SetProperty(ref _transportSiteCustomerGuid, value);
        }

        private string _customer;
        /// <summary>
        /// Get or Set for {Customer}.
        /// </summary>
        [DataMember]
        public string Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        private string _customerCode;
        /// <summary>
        /// Get or Set for {CustomerCode}.
        /// </summary>
        [DataMember]
        public string CustomerCode
        {
            get => _customerCode;
            set => SetProperty(ref _customerCode, value);
        }

        private bool _isActive = true;
        [DataMember]
        public new bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
    public class CustomerBusinessGroupDropDownModel
    {
        private Guid _Id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid Id
        {
            get => _Id;
            set => _Id = value;
        }
        private string _customer;
        /// <summary>
        /// Get or Set for {Customer}.
        /// </summary>
        [DataMember]
        [Required]
        public string Customer
        {
            get => _customer;
            set => _customer = value;
        }
    }
}
