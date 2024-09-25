using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    [DataContract, Serializable]
    public class UXResourceLabelModel : BaseModel<Guid>
    {
        private Guid _uxLanguageGuid;
        [DataMember]
        [Required]
        public Guid UXLanguageGuid
        {
            get => _uxLanguageGuid;
            set => SetProperty(ref _uxLanguageGuid, value);
        }

        private string _labelCode;
        [DataMember]
        [Required]
        [StringLength(20)]
        public string LabelCode
        {
            get => _labelCode;
            set => SetProperty(ref _labelCode, value);
        }

        private string _labelValue;
        [DataMember]
        [Required]
        [StringLength(500)]
        public string LabelValue
        {
            get => _labelValue;
            set => SetProperty(ref _labelValue, value);
        }

        private string _labelPurpose;
        [DataMember]
        [Required]
        [StringLength(500)]
        public string LabelPurpose
        {
            get => _labelPurpose;
            set => SetProperty(ref _labelPurpose, value);
        }

        private bool _isActive = true;
        [DataMember]
        [Required]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
