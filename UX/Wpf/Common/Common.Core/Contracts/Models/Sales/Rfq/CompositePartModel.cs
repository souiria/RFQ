using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    [DataContract, NotMapped, Serializable]
    public class CompositePartModel
    {
        [DataMember, NotMapped]
        public string PartNumber1 { get; set; }
        [DataMember, NotMapped]
        public string PartNumber2 { get; set; }
        [DataMember, NotMapped]
        public string PartNumber3 { get; set; }
        [DataMember, NotMapped]
        public int Quantity { get; set; }
        [DataMember, NotMapped]
        public string PartNumberType { get; set; }
    }
}
