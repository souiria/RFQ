using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Logging;

namespace Common.Core.Contracts.Models.Core.Settings
{
    [DataContract, Serializable]
    public class H1ServiceConfigurationSettingModel : BaseModel<Guid>
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

        private AuditLoggingModel _auditLoggingModel;
        [DataMember]
        public AuditLoggingModel AuditLoggingModel
        {
            get => _auditLoggingModel;
            set => SetProperty(ref _auditLoggingModel, value);
        }

        private DatabaseSyncModel _databaseSyncModel;
        [DataMember]
        public DatabaseSyncModel DatabaseSyncModel
        {
            get => _databaseSyncModel;
            set => SetProperty(ref _databaseSyncModel, value);
        }

        private ServiceValidationModel _serviceValidationModel;
        [DataMember]
        public ServiceValidationModel ServiceValidation
        {
            get => _serviceValidationModel;
            set => SetProperty(ref _serviceValidationModel, value);
        }

        private bool _allowRefreshing = false;
        [DataMember]
        [Required]
        public bool AllowRefreshing
        {
            get => _allowRefreshing;
            set => SetProperty(ref _allowRefreshing, value);
        }

        private bool _isLegacySystemSynchronizationEnabled = false;
        [DataMember]
        [Required]
        public bool IsLegacySystemSynchronizationEnabled
        {
            get => _isLegacySystemSynchronizationEnabled;
            set => SetProperty(ref _isLegacySystemSynchronizationEnabled, value);
        }

        private bool _isTextLoggingEnabled = false;
        [DataMember]
        [Required]
        public bool IsTextLoggingEnabled
        {
            get => _isTextLoggingEnabled;
            set => SetProperty(ref _isTextLoggingEnabled, value);
        }

        private bool _isAutomatedCrudNotifications = false;
        [DataMember]
        [Required]
        public bool IsAutomatedCrudNotifications
        {
            get => _isAutomatedCrudNotifications;
            set => SetProperty(ref _isAutomatedCrudNotifications, value);
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
