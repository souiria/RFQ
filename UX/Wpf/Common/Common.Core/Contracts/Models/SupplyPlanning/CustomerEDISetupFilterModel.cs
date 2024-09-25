/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerEDIFilterModel.cs
Function           :   Customer EDI Filter Model
Created By         :   Srashti Gupta
Created on         :   28-Jan-2020
Revision History   :   [29-Jan-2020]: Srashti Gupta
                   :   []:Change the name of Model to CustomerEDISetupFilterModel.
****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    [DataContract, Serializable]
    public class CustomerEDISetupFilterModel
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
            set => _customerGuid = value;
        }
        private Guid _customerEDITemplateSetUpGuid;
        /// <summary>
        /// Get or Set for {CustomerEDITemplateSetUpGuid}
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerEDITemplateSetUpGuid
        {
            get => _customerEDITemplateSetUpGuid;
            set => _customerEDITemplateSetUpGuid = value;
        }
    }
}
