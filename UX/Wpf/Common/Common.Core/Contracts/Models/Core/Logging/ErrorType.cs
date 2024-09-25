using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Core.Logging
{
    public enum ErrorType
    {
        [EnumMember(Value = "1")]
        ValidationMessage = 1,
        [EnumMember(Value = "2")]
        Logging = 2,
        [EnumMember(Value = "3")]
        Exception = 3,
    }
}
