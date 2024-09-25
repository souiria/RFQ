using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.EMACS
{
    [DataContract, Serializable]
    public class CombinedCustomerQueryResultModel
    {
        [DataMember]
        public string MatchedPart { get; set; }
        [DataMember]
        public string CustomerNumber { get; set; }
        [DataMember]
        public string SumitomoNumber { get; set; }
        [DataMember]
        public string CustomerID { get; set; }
    }
}
