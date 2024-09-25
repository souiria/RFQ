using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public class UOMAssociationFilteredModel : BaseModel<Guid>
    {
        [DataMember]
        public Guid UomGuid { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string UOMDescription { get; set; } = string.Empty;
        [DataMember]
        public Guid UOMAssociationGuid { get; set; }
        [DataMember]
        public string SourceUnitOfMeasureCode { get; set; } = string.Empty;
    }
}
