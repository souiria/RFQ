using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Security;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class PartialRequestModel : BaseModel<Guid>
    {
        private Guid _userGuid;
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => SetProperty(ref _userGuid, value);
        }

        private string _username;
        [DataMember]
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private ActiveDirectoryGroupModel _role;
        [DataMember]
        public ActiveDirectoryGroupModel Role
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }

        private List<ViewHierarchyModel> _views;
        [DataMember]
        public List<ViewHierarchyModel> Views
        {
            get => _views;
            set => SetProperty(ref _views, value);
        }

        private List<FieldHierarchyModel> _fields;
        [DataMember]
        public List<FieldHierarchyModel> Fields
        {
            get => _fields;
            set => SetProperty(ref _fields, value);
        }

        //private List<ServiceSecurityModel> _dataPermissions;
        //[DataMember]
        //public List<ServiceSecurityModel> DataPermissions
        //{
        //    get => _dataPermissions;
        //    set => SetProperty(ref _dataPermissions, value);
        //}
    }
}
