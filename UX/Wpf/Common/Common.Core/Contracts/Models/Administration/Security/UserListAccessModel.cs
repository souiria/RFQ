using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class UserListAccessModel : BindableBaseEntity
    {
        private Guid _id;
        [DataMember, Key]
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private PartialRequestModel _accessGiven;
        [DataMember]
        public PartialRequestModel AccessGiven
        {
            get => _accessGiven;
            set => SetProperty(ref _accessGiven, value);
        }

        private DateTime? _dateGiven;
        [DataMember]
        public DateTime? DateGiven
        {
            get => _dateGiven;
            set => SetProperty(ref _dateGiven, value);
        }

        private bool _permissionRemoved = false;
        [DataMember]
        public bool PermissionsRemoved
        {
            get => _permissionRemoved;
            set => SetProperty(ref _permissionRemoved, value);
        }


        private string _helpdeskCallId;
        [DataMember]
        public string HelpdeskCallId
        {
            get => _helpdeskCallId;
            set => SetProperty(ref _helpdeskCallId, value);
        }

        private Guid _requestedBy;
        [DataMember]
        public Guid RequestedBy
        {
            get => _requestedBy;
            set => SetProperty(ref _requestedBy, value);
        }
    }

    [DataContract, Serializable]
    public class AccessRightModel : BindableBaseEntity
    {
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private AccessRightType _accessType;
        [DataMember]
        public AccessRightType AccessType
        {
            get => _accessType;
            set => SetProperty(ref _accessType, value);
        }
    }

    [DataContract, Serializable]
    public enum AccessRightType
    {
        Field,
        Screen
    }
}
