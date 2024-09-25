namespace hartbeat.shared.Messages
{
    public class ResponseBase
    {
        public string? OperationId { get; set; }
        public List<Exception> Exceptions { get; set; } = new();
        public byte[]? CompressedMessage { get; set; }
        public bool HasHeartBeat { get; set; }
        public string? DebugMessage { get; set; }
    }
}
