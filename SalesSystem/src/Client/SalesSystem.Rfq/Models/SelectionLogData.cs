namespace SalesSystem.Rfq.Models
{
    public class SelectionLogData
    {
        public string? HarnessId { get; set; }

        [JsonObjectCreationHandling(
            JsonObjectCreationHandling.Populate)]
        public Collection<string> HarnessIds { get; } =
            new Collection<string>();

        public long RfqId { get; set; }

        public IEnumerable<SelectedCompositeData>? Selections
        {
            get;
            set;
        }
    }
}