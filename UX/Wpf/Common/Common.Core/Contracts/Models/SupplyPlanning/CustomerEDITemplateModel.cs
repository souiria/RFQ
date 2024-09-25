/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDITemplateModel.cs
Function           :   EDI Template Model
Created By         :   Srashti Gupta
Created on         :   23-Jan-2020
Revision History   :   Srashti Gupta
                   :   [24-Jan-2020]:Change the Model as per the requirements.
                   :   [29-Jan-2020]: Srashti Gupta
                   :   []:Change the StringLength of {TemplateSamplePath}.
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for EDISetUpMasters Service
    /// </summary>
    [DataContract, Serializable]
    public class CustomerEDITemplateModel : BaseModel<Guid>
    {
       
        private string _templateCode;
        /// <summary>
        /// Get or Set for {TemplateCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(10)]
        public string TemplateCode
        {
            get => _templateCode;
            set => SetProperty(ref _templateCode, value);
        }

        private string _templateDescription;
        /// <summary>
        /// Get or Set for {TemplateDescription}.
        /// </summary>
        [DataMember]
        [Required]
        public string TemplateDescription
        {
            get => _templateDescription;
            set => SetProperty(ref _templateDescription, value);
        }


        private Guid _customerEDITypeGuid;
        /// <summary>
        /// Get or Set for {CustomerEDITypeGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerEDITypeGuid
        {
            get => _customerEDITypeGuid;
            set => SetProperty(ref _customerEDITypeGuid, value);
        }

        
        private Guid _ediFileTypeGuid;
        /// <summary>
        /// Get or Set for {EDIFileTypeGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid EDIFileTypeGuid
        {
            get => _ediFileTypeGuid;
            set => SetProperty(ref _ediFileTypeGuid, value);
        }
        private string _ediFileSamples;
        /// <summary>
        /// Get or Set for {EDIFileSamples}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string EDIFileSamples
        {
            get => _ediFileSamples;
            set => SetProperty(ref _ediFileSamples, value);
        }

        private string _templateSamplePath;
        /// <summary>
        /// Get or Set for {TemplateSamplePath}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(200)]
        public string TemplateSamplePath
        {
            get => _templateSamplePath;
            set => SetProperty(ref _templateSamplePath, value);
        }

    }


}
