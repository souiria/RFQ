using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.DsiAssociation;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.DsiAssociation
{
    [DataContract, Serializable, Table("HarnessScopeScopeAssociation")]
    public class HarnessScopeScopeAssociationModel : BaseModel<Guid>
    {
        [DataMember]
        public Guid HarnessScopeID { get; set; }
        [DataMember]
        public Guid ScopeID { get; set; }
    }
}
