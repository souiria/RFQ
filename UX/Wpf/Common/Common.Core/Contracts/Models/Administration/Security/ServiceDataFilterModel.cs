using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class ServiceDataFilterModel : BaseModel<Guid>
    {
        private string _serviceUri;
        [DataMember]
        public string ServiceUri
        {
            get => _serviceUri;
            set => SetProperty(ref _serviceUri, value);
        }

        private Guid _userGuid;
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => SetProperty(ref _userGuid, value);
        }

        private SecurityFilter _filter;
        [DataMember]
        public SecurityFilter Filter
        {
            get => _filter;
            set => SetProperty(ref _filter, value);
        }
    }
}
