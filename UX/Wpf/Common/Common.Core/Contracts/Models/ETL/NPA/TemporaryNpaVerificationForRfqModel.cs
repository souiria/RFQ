using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.NPA
{
    [DataContract, NotMapped, Serializable]
    public class TemporaryNpaVerificationForRfqModel
    {
        [DataMember, NotMapped]
        public string NpaReferenceNumber { get; set; }

        [DataMember, NotMapped]
        public DateTime RfqCutOffDate { get; set; }

        [DataMember, NotMapped]
        public string RfqReferenceNumber { get; set; }

        [DataMember, NotMapped]
        public string LoggedInUser { get; set; }
    }
}
