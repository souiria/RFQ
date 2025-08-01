namespace SharedModels.DocumentConverter.DSI.DTOs
{
    public class WireThroughNodeDto
    {
        public string? WireName
        { get; set; }
        public string? Option
        { get; set; }
        public double? ThroughOrder
        { get; set; }
        public string? ThroughNode
        { get; set; }
        public string? ThroughRoute
        { get; set; }
        public bool? IsThroughFlag
        { get; set; }
        public Guid? HarnessID
        { get; set; }
    }
}
