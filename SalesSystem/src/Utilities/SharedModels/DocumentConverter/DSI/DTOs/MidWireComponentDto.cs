namespace SharedModels.DocumentConverter.DSI.DTOs
{
    public class MidWireComponentDto : Collection<MidWireComponentDto>
    {
        public string? NodeName
        { get; set; }
        public string? Route
        { get; set; }
        public string? WireName
        { get; set; }
        public string? Option
        { get; set; }
        public string? MidWireOption
        { get; set; }
        public string? Cavity
        { get; set; }
        public double? ThroughOrder
        { get; set; }
        public Guid? HarnessID
        { get; set; }
    }
}
