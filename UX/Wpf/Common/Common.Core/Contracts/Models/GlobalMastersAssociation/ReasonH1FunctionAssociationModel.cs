using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public class ReasonH1FunctionAssociationModel : BaseModel<Guid>
    {
        private Guid _reasonGuid;
        [DataMember]
        [Required]
        public Guid ReasonGuid
        {
            get => _reasonGuid;
            set => SetProperty(ref _reasonGuid, value);
        }

        private Guid _h1FunctionGuid;
        [DataMember]
        [Required]
        public Guid H1FunctionGuid 
        {
            get => _h1FunctionGuid;
            set => SetProperty(ref _h1FunctionGuid, value);
        }
        
    }
}
