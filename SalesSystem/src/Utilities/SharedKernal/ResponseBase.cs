namespace SharedKernel
{
    public class ResponseBase
    {
        public string? OperationId { get; set; }
#pragma warning disable CA1002 // Do not expose generic lists
#pragma warning disable CA2227 // Collection properties should be read only
        public List<Exception> Exceptions { get; set; } = [];
#pragma warning restore CA2227 // Collection properties should be read only
#pragma warning restore CA1002 // Do not expose generic lists
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[]? CompressedMessage { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
        public bool HasHeartBeat { get; set; }
        public string? DebugMessage { get; set; }
    }
}
