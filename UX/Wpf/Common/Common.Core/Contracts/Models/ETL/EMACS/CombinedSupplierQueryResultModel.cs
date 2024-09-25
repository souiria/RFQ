using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.EMACS
{
    [DataContract, Serializable]
    public class CombinedSupplierQueryResultModel
    {
        [DataMember]
        public string MatchedPart { get; set; }
        [DataMember]
        public string SumitomoNumber { get; set; }
        [DataMember]
        public string Supplier { get; set; }
        [DataMember]
        public string SupplierNumber { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string Unit { get; set; }
        [DataMember]
        public byte Ratio { get; set; }
    }
}
