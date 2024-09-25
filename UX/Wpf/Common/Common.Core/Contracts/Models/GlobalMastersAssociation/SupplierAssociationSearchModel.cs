using Common.Core.Contracts.Models.Core.Filtering;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public class SupplierAssociationSearchModel
    {
        [DataMember]
        public Guid SupplierTypeGuid { get; set; }

        [DataMember]
        public Guid SupplierGroupGuid { get; set; }

        [DataMember]
        public DataPageModel DataPager { get; set; }
    }
}
