using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class SecurityFilter : BaseModel<Guid>
    {
        [DataMember]
        public string FilterProperty { get; set; }
        [DataMember]
        public string FilterValue { get; set; }
        //[DataMember]
        //public bool DoesNot { get; set; }
        [DataMember]
        public FilterTypes FilterType { get; set; }
    }
}
