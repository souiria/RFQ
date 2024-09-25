using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public class SourceApplicationArticleAssociationModel : BaseModel<Guid>
    {
        private Guid _sourceApplicationGuid;
        [DataMember]
        [Required]
        public Guid SourceApplicationGuid
        {
            get => _sourceApplicationGuid;
            set => SetProperty(ref _sourceApplicationGuid, value);
        }

        private Guid _applicationArticleGuid;
        [DataMember]
        [Required]
        public Guid ApplicationArticleGuid 
        {
            get => _applicationArticleGuid;
            set => SetProperty(ref _applicationArticleGuid, value);
        }

        private Guid _h1ConfigurationSettingGuid;
        [DataMember]
        public Guid H1ConfigurationSettingGuid
        {
            get => _h1ConfigurationSettingGuid;
            set => SetProperty(ref _h1ConfigurationSettingGuid, value);
        }
    }
}
