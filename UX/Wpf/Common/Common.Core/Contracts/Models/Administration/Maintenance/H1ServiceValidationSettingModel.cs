using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    [DataContract, Serializable]
    public class H1ServiceValidationSettingModel : BaseModel<Guid>
    {
        private string _serviceName;
        [DataMember]
        [Required]
        [StringLength(500)]
        public string ServiceName
        {
            get => _serviceName;
            set => SetProperty(ref _serviceName, value);
        }
        private string _referencedServiceName;
        [DataMember]
        [Required]
        [StringLength(500)]
        public string ReferencedServiceName
        {
            get => _referencedServiceName;
            set => SetProperty(ref _referencedServiceName, value);
        }
        private bool _isServiceValidationEnabled  = false;
        [DataMember]
        [Required]
        public bool IsServiceValidationEnabled
        {
            get => _isServiceValidationEnabled ;
            set => SetProperty(ref _isServiceValidationEnabled , value);
        }
    }
}
