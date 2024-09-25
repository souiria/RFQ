using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Core.Settings
{
    [DataContract, Serializable]
    public class H1ConfigurationKeyModel : BaseModel<Guid>
    {
        private string _keyName;
        [DataMember]
        [Required]
        [StringLength(50)]

        public string KeyName
        {
            get => _keyName;
            set => SetProperty(ref _keyName, value);
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


