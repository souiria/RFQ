using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Core.Email
{
    [DataContract, Serializable]
    public class EmailDetail
    {
        [DataMember]
        public Guid Id { get; set; } = Guid.NewGuid();

        [DataMember]
        public List<string> Recipients { get; set; } = new List<string>();

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string Body { get; set; }

        [DataMember]
        public DateTime SendDate { get; set; }

        [DataMember]
        public Template Template { get; set; }

        //TODO: Consider multiple snapshots and resources (eg. List<byte[]> Resources)
        [DataMember]
        public byte[] SnapShot { get; set; }

        public EmailDetail() { }

        public EmailDetail(string recipient, string subject, string body)
        {
            Recipients.Add(recipient);
            Subject = subject;
            Body = body;
            SendDate = DateTime.UtcNow;
        }
    }
}
