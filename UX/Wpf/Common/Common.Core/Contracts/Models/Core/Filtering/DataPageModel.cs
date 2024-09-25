using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Core.Filtering
{
    [DataContract, Serializable]
    public class DataPageModel
    {
        [DataMember]
        public int PageSize { get; set; } = 10000;

        [DataMember]
        public int PageNumber { get; set; } = 1;
    }
}
