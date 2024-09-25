using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract]
    public class SecurityChangeTransaction
    {
        [DataMember, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [DataMember]
        public Guid UserGuid { get; set; }

        [DataMember, DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public Guid? CreatedBy { get; set; }

        [DataMember]
        public string HelpdeskId { get; set; }

        [DataMember]
        public string HelpdeskDesc { get; set; }

        [DataMember, ForeignKey("TransactionId")]
        public List<SecurityChangeDetail> ChangeDetails { get; set; }
    }
}
