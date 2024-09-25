using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.DsiAssociation
{
    [DataContract, Serializable, Table("PinMappingCavityMappingAssociation")]
    public class PinMappingCavityMappingAssociationModel : BaseModel<Guid>
    {
        [DataMember]
        public Guid PinMappingID { get; set; }
        [DataMember]
        public Guid CavityMappingID { get; set; }
        [DataMember]
        public int MappingNumber { get; set; }
    }
}
