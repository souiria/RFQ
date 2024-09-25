using Common.Core.Contracts.Models.Sales.Rfq.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    [DataContract, NotMapped, Serializable]
    public class RFQParentHeirarchyModel
    {
        [DataMember, NotMapped]
        public HeirarchyCategory Category { get; set; }
        [DataMember, NotMapped]
        public List<RFQPartModel> RFQPartList { get; set; }
    }
}
