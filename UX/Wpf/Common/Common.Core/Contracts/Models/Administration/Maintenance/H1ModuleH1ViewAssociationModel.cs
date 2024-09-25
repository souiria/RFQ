using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    [DataContract, Serializable]
    public class H1ModuleH1ViewAssociationModel : BaseModel<Guid>
    {
        private Guid _h1ModuleGuid;
        [DataMember]
        public Guid H1ModuleGuid
        {
            get => _h1ModuleGuid;
            set => SetProperty(ref _h1ModuleGuid, value);
        }
        private Guid _h1ViewGuid;
        [DataMember]
        public Guid H1ViewGuid
        {
            get => _h1ViewGuid;
            set => SetProperty(ref _h1ViewGuid, value);
        }
    }
}
