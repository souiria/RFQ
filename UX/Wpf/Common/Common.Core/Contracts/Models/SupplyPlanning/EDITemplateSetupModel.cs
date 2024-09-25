using Common.Core.Contracts.Models.Base;
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
    public class EDITemplateSetupModel : BaseModel<Guid>
    {
        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerEDITemplateGuid}.
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
        /// Get or Set for {CustomerEDITemplateGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

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
        [StringLength(1000)]
        public string EDIUploadPath
        {
            get => _ediUploadPath;
            set => SetProperty(ref _ediUploadPath, value);
        }
    }
}
