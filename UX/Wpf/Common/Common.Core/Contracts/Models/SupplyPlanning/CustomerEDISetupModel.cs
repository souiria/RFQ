/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerEDISetupModel.cs
Function           :   Customer EDI Setup Model
Created By         :   Srashti Gupta
Created on         :   24-Jan-2020
Revision History   :   [29-Jan-2020]: Srashti Gupta
                   :   []:Change the StringLength to 50 of {CustomerName}.
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for CustomerEDISetup service
    /// </summary>
    [DataContract, Serializable]
    public class CustomerEDISetupModel : BaseModel<Guid>
    {
        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }

        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(50)]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

        private List<CustomerEDITemplateSetupModel> _customerEDITemplateSetUp;
        /// <summary>
        /// Get or Set for {CustomerEDITemplateSetUp}
        /// </summary>
        [DataMember]
        [Required]
        public List<CustomerEDITemplateSetupModel> CustomerEDITemplateSetUp
        {
            get => _customerEDITemplateSetUp;
            set => SetProperty(ref _customerEDITemplateSetUp, value);
        }
    }
}
