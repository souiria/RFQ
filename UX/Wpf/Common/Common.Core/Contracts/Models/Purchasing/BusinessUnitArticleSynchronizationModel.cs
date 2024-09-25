using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    public class BusinessUnitArticleSynchronizationModel : BaseModel<Guid>
    {
        private Guid _applicationArticleGuid;
        [DataMember]
        [Required]
        public Guid ApplicationArticleGuid
        {
            get => _applicationArticleGuid;
            set => SetProperty(ref _applicationArticleGuid, value);
        }

        private Guid _businessUnitGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        
    }
}
