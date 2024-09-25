using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public enum FilterTypes
    {
        [EnumMember(Value = "0")]
        Equals,
        [EnumMember(Value = "1")]
        DoesNotEqual,
        [EnumMember(Value = "2")]
        Contains,
        [EnumMember(Value = "3")]
        DoesNotConatin

    }
}
