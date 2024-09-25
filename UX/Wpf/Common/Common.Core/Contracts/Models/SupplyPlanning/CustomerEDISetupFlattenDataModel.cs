/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerEDIFlattenDataModel.cs
Function           :   Customer EDI Flatten Data Model
Created By         :   Srashti Gupta
Created on         :   28-Jan-2020
Revision History   :   [29-Jan-2020]:Srashti Gupta
                   :   []: Change the Model name to CustomerEDISetupFlattenDataModel.
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for CustomerEDISetup service
    /// </summary>
    [DataContract, Serializable]
    public class CustomerEDISetupFlattenDataModel
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
            set => _customerGuid=value;
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
            set => _customerName= value;
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

        private Guid _customerEDISetUpGuid;
        /// <summary>
        /// Get or Set for {CustomerEDISetUpGuid}
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerEDISetUpGuid
        {
            get => _customerEDISetUpGuid;
            set => _customerEDISetUpGuid = value;
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
            set =>  _ediFileReceivingStartDate= value;
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
            set => _ediFileReceivingEndDate= value;
        }
        private string _ediUploadPath;
        /// <summary>
        /// Get or Set for {EDIUploadPath}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1000)]
        public string EDIUploadPath
        {
            get => _ediUploadPath;
            set => _ediUploadPath= value;
        }

        private DateTime? _createdDate;
        /// <summary>
        /// Get or Set for {CreatedDate}.
        /// </summary>
        [DataMember, DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get => _createdDate ?? DateTime.UtcNow;
            set =>  _createdDate=value;
        }

        private DateTime? _modifiedDate;
        /// <summary>
        /// Get or Set for {ModifiedDate}.
        /// </summary>
        [DataMember, DataType(DataType.DateTime)]
        public DateTime? ModifiedDate
        {
            get => _modifiedDate ?? DateTime.UtcNow;
            set => _modifiedDate= value;
        }

        private Guid _createdBy;
        /// <summary>
        /// Get or Set for {CreatedBy}.
        /// </summary>
        [DataMember]
        public Guid CreatedBy
        {
            get => _createdBy;
            set => _createdBy=value;
        }

        private Guid _modifiedBy;
        /// <summary>
        /// Get or Set for {ModifiedBy}.
        /// </summary>
        [DataMember]
        public Guid ModifiedBy
        {
            get => _modifiedBy;
            set => _modifiedBy=value;
        }

    }


}
