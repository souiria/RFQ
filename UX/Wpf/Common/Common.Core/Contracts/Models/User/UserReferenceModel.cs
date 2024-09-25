using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.User
{
    [DataContract, Serializable]
    public class UserReferenceModel : BaseModel<Guid>
    {
        private Guid? _userGuid;

        [DataMember]
        public Guid? UserGuid
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
    }
}
