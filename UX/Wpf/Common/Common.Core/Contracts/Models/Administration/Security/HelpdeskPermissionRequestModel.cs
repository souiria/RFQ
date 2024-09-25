using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Security;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class HelpdeskPermissionRequestModel : BaseModel<Guid>
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

        private string _callId;
        [DataMember]
        public string CallId
        {
            get => _callId;
            set => SetProperty(ref _callId, value);
        }

        private bool _requestedH1Access;
        [DataMember]
        public bool RequestedH1Access
        {
            get => _requestedH1Access;
            set => SetProperty(ref _requestedH1Access, value);
        }

        //TODO Re-enable once data permissions is implemented
        //private List<ServiceSecurityModel> _requestedDataPermissions;
        //[DataMember]
        //public List<ServiceSecurityModel> RequestedDataPermissions
        //{
        //    get => _requestedDataPermissions;
        //    set => SetProperty(ref _requestedDataPermissions, value);
        //}

        private List<ModuleHierarchyModel> _requestedHierarchy;
        [DataMember]
        public List<ModuleHierarchyModel> RequestedHierarchy
        {
            get => _requestedHierarchy;
            set => SetProperty(ref _requestedHierarchy, value);
        }

        //private List<ViewHierarchyModel> _requestedViews;
        //[DataMember]
        //public List<ViewHierarchyModel> RequestedViews
        //{
        //    get => _requestedViews;
        //    set => SetProperty(ref _requestedViews, value);
        //}

        //private List<FieldHierarchyModel> _requestedFields;
        //[DataMember]
        //public List<FieldHierarchyModel> RequestedFields
        //{
        //    get => _requestedFields;
        //    set => SetProperty(ref _requestedFields, value);
        //}

        private List<ActiveDirectoryGroupModel> _requestedRoles;
        [DataMember]
        public List<ActiveDirectoryGroupModel> RequestedRoles
        {
            get => _requestedRoles;
            set => SetProperty(ref _requestedRoles, value);
        }
    }
}
