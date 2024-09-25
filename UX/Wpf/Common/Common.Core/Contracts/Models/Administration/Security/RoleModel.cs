using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    //TODO: Determine whether this class is still in use or can be deprecated

    [DataContract, Serializable]
    public class RoleModel : BaseModel<Guid>
    {
        private string _activeDirectoryGroupName;
        [DataMember]
        public string ActiveDirectoryGroupName
        {
            get => _activeDirectoryGroupName;
            set => SetProperty(ref _activeDirectoryGroupName, value);
        }

        private string _displayName;
        [DataMember]
        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        private string _permissionDescription;
        [DataMember]
        [NotMapped]
        public string PermissionDescription
        {
            get => _permissionDescription;
            set => SetProperty(ref _permissionDescription, value);
        }
    }
}
