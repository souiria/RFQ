using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    [DataContract, NotMapped, Serializable]
    public class AssociatedDerivativeInfoModel
    {
        [DataMember, NotMapped]
        public Guid Id { get; set; }

        [DataMember, NotMapped]
        public string AssociatedDerivativeName { get; set; }

        [DataMember, NotMapped]
        public int AssociatedDerivativeQty { get; set; }
    }
}
