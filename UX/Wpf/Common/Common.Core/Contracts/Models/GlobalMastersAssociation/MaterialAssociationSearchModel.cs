using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public class MaterialAssociationSearchModel
    {
        [DataMember]
        public Guid MaterialTypeGuid { get; set; }

        [DataMember]
        public string MaterialType { get; set; } = string.Empty;

        [DataMember]
        public Guid MaterialFromGuid { get; set; }

        [DataMember]
        public string MaterialNumberFrom { get; set; } = string.Empty;

        [DataMember]
        public Guid MaterialToGuid { get; set; }

        [DataMember]
        public string MaterialNumberTo { get; set; } = string.Empty;
    }
}
