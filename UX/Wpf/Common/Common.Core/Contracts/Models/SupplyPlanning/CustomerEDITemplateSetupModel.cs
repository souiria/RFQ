/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerEDITemplateSetupModel.cs
Function           :   Customer EDI Template Setup Model
Created By         :   Srashti Gupta
Created on         :   23-Jan-2020
Revision History   :   Srashti Gupta
                   :   [24-Jan-2020]:Added two fields {CustomerNameGuid, TemplateNameGuid}
                   :   Srashti Gupta
                   :   [24-Jan-2020]:Change the Model as per the requirements.
                   :   [29-Jan-2020]: Srashti Gupta
                   :   []:Change the StringLength to 200 of {EDIUploadPath}.
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for CustomerEDISetup Service
    /// </summary>
    [DataContract, Serializable]
    public class CustomerEDITemplateSetupModel : BaseModel<Guid>
    {
       
        private Guid _customerEDITemplateGuid;
        /// <summary>
        /// Get or Set for {CustomerEDITemplateGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerEDITemplateGuid
        {
            get => _customerEDITemplateGuid;
            set => SetProperty(ref _customerEDITemplateGuid, value);
        }
        
        private DateTime _ediFileReceivingStartDate;
        /// <summary>
        /// Get or Set for {EDIFileReceivingStartDate}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime EDIFileReceivingStartDate
        {
            get => _ediFileReceivingStartDate;
            set => SetProperty(ref _ediFileReceivingStartDate, value);
        }
       
        private DateTime _ediFileReceivingEndDate;
        /// <summary>
        /// Get or Set for {EDIFileReceivingEndDate}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime EDIFileReceivingEndDate
        {
            get => _ediFileReceivingEndDate;
            set => SetProperty(ref _ediFileReceivingEndDate, value);
        }
        private string _ediUploadPath;
        /// <summary>
        /// Get or Set for {EDIUploadPath}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(200)]
        public string EDIUploadPath
        {
            get => _ediUploadPath;
            set => SetProperty(ref _ediUploadPath, value);
        }
    }
}
