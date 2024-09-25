using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    [DataContract, Serializable]
    public class H1FunctionH1ModuleAssociationModel : BaseModel<Guid>
    {
        private Guid _h1FunctionGuid;
        [DataMember]
        public Guid H1FunctionGuid
        {
            get => _h1FunctionGuid;
            set => SetProperty(ref _h1FunctionGuid, value);
        }

        private Guid _H1ModuleGuid;
        [DataMember]
        public Guid H1ModuleGuid
        {
            get => _H1ModuleGuid;
            set => SetProperty(ref _H1ModuleGuid, value);
        }
    }
}
