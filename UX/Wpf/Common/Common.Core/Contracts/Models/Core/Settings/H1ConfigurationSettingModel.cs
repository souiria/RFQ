using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Core.Settings
{
    [DataContract, Serializable]
    public class H1ConfigurationSettingModel : BaseModel<Guid>
    {
        private Guid _h1FunctionGuid;
        [DataMember]
        [Required]
        public Guid H1FunctionGuid
        {
            get => _h1FunctionGuid;
            set => SetProperty(ref _h1FunctionGuid, value);
        }

        private Guid _h1ModuleGuid;
        [DataMember]
        [Required]
        public Guid H1ModuleGuid
        {
            get => _h1ModuleGuid;
            set => SetProperty(ref _h1ModuleGuid, value);
        }

        private Guid _h1ConfigurationKeyGuid;
        [DataMember]
        [Required]
        public Guid H1ConfigurationKeyGuid
        {
            get => _h1ConfigurationKeyGuid;
            set => SetProperty(ref _h1ConfigurationKeyGuid, value);
        }

        private string _h1ConfigParameterValue;
        [DataMember]
        [Required]
        [StringLength(8000)]
        public string H1ConfigParameterValue
        {
            get => _h1ConfigParameterValue;
            set => SetProperty(ref _h1ConfigParameterValue, value);
        }

        private bool _isEncrypted = false;
        [DataMember]
        public bool IsEncrypted
        {
            get => _isEncrypted;
            set => SetProperty(ref _isEncrypted, value);
        }

        private string _h1EncryptionKey;
        [DataMember]
        [StringLength(50)]
        public string H1EncryptionKey
        {
            get => _h1EncryptionKey;
            set => SetProperty(ref _h1EncryptionKey, value);
        }

        private bool _isActive = true;
        [DataMember]
        [Required]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private string _remarks = "";
        [DataMember]
        [StringLength(200)]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }
    }
}
