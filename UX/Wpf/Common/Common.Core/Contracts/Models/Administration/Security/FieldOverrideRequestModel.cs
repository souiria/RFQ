using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class FieldOverrideRequestModel : BindableBaseEntity
    {
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public List<Guid> GroupGuids { get; set; }
        [DataMember]
        public string ViewName { get; set; }
    }
}
