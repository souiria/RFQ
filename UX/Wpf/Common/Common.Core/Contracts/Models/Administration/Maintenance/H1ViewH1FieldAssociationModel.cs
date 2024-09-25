using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    [DataContract, Serializable]
    public class H1ViewH1FieldAssociationModel : BaseModel<Guid>
    {
        private Guid _h1ViewGuid;
        [DataMember]
        public Guid H1ViewGuid
        {
            get => _h1ViewGuid;
            set => SetProperty(ref _h1ViewGuid, value);
        }

        private Guid _h1fieldGuid;
        [DataMember]
        public Guid H1FieldGuid
        {
            get => _h1fieldGuid;
            set => SetProperty(ref _h1fieldGuid, value);
        }
    }
}
