using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Core.Settings
{
    [DataContract, Serializable]
    public class DatabaseSyncModel : BaseModel<Guid>
    {
        private bool? _isDatabaseSyncEnabled = true;
        [DataMember]
        public bool? IsDatabaseSyncEnabled
        {
            get => _isDatabaseSyncEnabled;
            set => SetProperty(ref _isDatabaseSyncEnabled, value);
        }

        private Guid _h1ConfigurationSettingGuid;
        [DataMember]
        [Required]
        public Guid H1ConfigurationSettingGuid
        {
            get => _h1ConfigurationSettingGuid;
            set => SetProperty(ref _h1ConfigurationSettingGuid, value);
        }
    }
}