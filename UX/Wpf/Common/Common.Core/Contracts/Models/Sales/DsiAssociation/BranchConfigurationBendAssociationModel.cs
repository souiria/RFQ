using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.DsiAssociation;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.DsiAssociation
{
    [DataContract, Serializable, Table("BranchConfigurationBendAssociation")]
    public class BranchConfigurationBendAssociationModel : BaseModel<Guid>
    {
        [DataMember]
        public Guid BranchConfigurationID { get; set; }
        [DataMember]
        public Guid BendID { get; set; }
    }
}
