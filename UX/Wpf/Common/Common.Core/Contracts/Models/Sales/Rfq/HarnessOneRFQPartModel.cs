using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    [DataContract, Serializable]
    public class HarnessOneRFQPartModel
    {
        [DataMember, NotMapped]
        public string MatchedPart { get; set; }
        [DataMember, NotMapped]
        public string SumitomoNumber { get; set; }
        [DataMember, NotMapped]
        public string Customer { get; set; }
        [DataMember, NotMapped]
        public string CustomerNumber { get; set; }
        [DataMember, NotMapped]
        public string Supplier { get; set; }
        [DataMember, NotMapped]
        public string SupplierNumber { get; set; }
        [DataMember, NotMapped]
        public string Currency { get; set; }
        [DataMember, NotMapped]
        public double? Price { get; set; }
        [DataMember, NotMapped]
        public string UnitOfMeasure { get; set; }
        [DataMember, NotMapped]
        public bool IsEMACS { get; set; }
        [DataMember, NotMapped]
        public bool IsCPD { get; set; }
        [DataMember, NotMapped]
        public bool IsNPA { get; set; }
        [DataMember, NotMapped]
        public DateTime? NPARaisedDate { get; set; }
        [DataMember, NotMapped]
        public string NPAReferenceNumber { get; set; }
        [DataMember, NotMapped]
        public int ColourFlag { get; set; }
    }
}
