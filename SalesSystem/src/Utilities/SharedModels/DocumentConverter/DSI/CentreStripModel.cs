namespace SharedModels.DocumentConverter.DSI
{
    public class CentreStripModel
    {
        public string? NodeName
        { get; set; }
        public string? Route
        { get; set; }
        public string? WireName
        { get; set; }
        public double? StripLength
        { get; set; }
        public string? LengthChangeType
        { get; set; }
        public double? LengthChangeValue
        { get; set; }
        public string? Option
        { get; set; }
        public double? ThroughOrder
        { get; set; }
        public Guid? HarnessID
        { get; set; }
    }
}
