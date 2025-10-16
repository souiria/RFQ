namespace Rfq.Data.Model
{
    public class DbDsiWireMulticoreMarker : IAggregateRoot
    {
        public long RowId
        { get; set; }

        public string? ItemType
        { get; set; }

        public string? ItemName
        { get; set; }

        public string? Option
        { get; set; }

        public string? Location
        { get; set; }

        public string? Text
        { get; set; }

        public string? ColourCode
        { get; set; }

        public double? Spacing
        { get; set; }

        public Guid HarnessID
        { get; set; }

        public DateTime CreatedDate
        { get; set; }

        public DateTime ModifiedDate
        { get; set; }

        public Guid? CreatedBy
        { get; set; }

        public Guid ModifiedBy
        { get; set; }
    }
}
