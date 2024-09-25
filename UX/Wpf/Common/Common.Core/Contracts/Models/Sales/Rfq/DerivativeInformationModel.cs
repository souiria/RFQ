using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    [DataContract, NotMapped, Serializable]
    public class DerivativeInformationModel
    {
        [DataMember, NotMapped]
        public List<CompositePartModel> CompositePartList { get; set; }

        [DataMember, NotMapped]
        public Guid DerivativeId { get; set; }

        [DataMember, NotMapped]
        public string HarnessName { get; set; }

        [DataMember, NotMapped]
        public string DerivativeName { get; set; }
    }
}
