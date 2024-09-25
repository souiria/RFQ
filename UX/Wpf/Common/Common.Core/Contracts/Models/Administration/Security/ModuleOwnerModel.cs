using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class ModuleOwnerModel : BaseModel<Guid>
    {
        public ModuleOwnerModel()
        { }

        public ModuleOwnerModel(Guid userGuid, Guid h1ModuleGuid, Guid createdBy)
        {
            Id = Guid.NewGuid();
            UserGuid = userGuid;
            H1ModuleGuid = h1ModuleGuid;
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
            CreatedBy = createdBy;
            ModifiedBy = createdBy;
        }

        private Guid _userGuid;
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => SetProperty(ref _userGuid, value);
        }


        private Guid _h1ModuleGuid;
        [DataMember]
        public Guid H1ModuleGuid
        {
            get => _h1ModuleGuid;
            set => SetProperty(ref _h1ModuleGuid, value);
        }
    }
}
