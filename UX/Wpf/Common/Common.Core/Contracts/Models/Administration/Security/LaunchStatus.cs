using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public enum LaunchStatus
    {
        [EnumMember]
        Unrequested,
        [EnumMember]
        Requested,
        [EnumMember]
        Completed
    }
}
