using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.DsiAssociation;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.DsiAssociation
{
    [DataContract, Serializable, Table("CompositeDetailCircuitOptionAssociation")]
    public class CompositeDetailCircuitOptionAssociationModel : BaseModel<Guid>
    {
        [DataMember]
        public Guid CompositeDetailID { get; set; }
        [DataMember]
        public Guid CircuitOptionID { get; set; }
    }
}
