using System.Collections.ObjectModel;

namespace SharedModels.DocumentConverter.DSI
{
    public class MidWireComponentModel : Collection<MidWireComponentModel>
    {
        public string? NodeName { get; set; }
        public string? Route { get; set; }
        public string? WireName { get; set; }
        public string? Option { get; set; }
        public string? MidWireOption { get; set; }
        public string? Cavity { get; set; }
        public double? ThroughOrder { get; set; }
        public Guid? HarnessID { get; set; }
    }
}
