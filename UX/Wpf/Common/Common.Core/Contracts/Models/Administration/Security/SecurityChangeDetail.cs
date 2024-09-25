using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract]
    public class SecurityChangeDetail
    {
        [DataMember, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DataMember]
        public Guid TransactionId { get; set; }

        [DataMember]
        public Guid SecurityId { get; set; }

        [DataMember]
        public string SecurityName { get; set; }

        [DataMember]
        public DetailType DetailType { get; set; }

        [DataMember]
        public Operation Operation { get; set; }
    }

    [DataContract]
    public enum DetailType
    {
        [EnumMember]
        Role,
        [EnumMember]
        ModuleOwner,
        [EnumMember]
        View,
        [EnumMember]
        Field
    }

    [DataContract]
    public enum Operation
    {
        [EnumMember]
        Add,
        [EnumMember]
        Remove
    }
}
