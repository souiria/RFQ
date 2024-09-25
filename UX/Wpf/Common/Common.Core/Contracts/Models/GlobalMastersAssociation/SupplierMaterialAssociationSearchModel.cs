using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public class SupplierMaterialAssociationSearchModel
    {
        [DataMember]
        public Guid SupplierGuid { get; set; }

        [DataMember]
        public string SupplierCode { get; set; } = string.Empty;

        [DataMember]
        public Guid MaterialFromGuid { get; set; }

        [DataMember]
        public string MaterialNumberFrom { get; set; } = string.Empty;

        [DataMember]
        public Guid MaterialToGuid { get; set; }

        [DataMember]
        public string MaterialNumberTo { get; set; } = string.Empty;

        [DataMember]
        public bool IsActive { get; set; } = true;
    }
}
