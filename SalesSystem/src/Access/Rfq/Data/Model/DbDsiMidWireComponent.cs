namespace Rfq.Data.Model
{
    public class DbDsiMidWireComponent : IAggregateRoot
    {
        public long RowId
        { get; set; }

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

        public double ThroughOrder
        { get; set; }

        public Guid HarnessID
        { get; set; }

        public DateTime CreatedDate
        { get; set; }

        public DateTime? ModifiedDate
        { get; set; }

        public Guid CreatedBy
        { get; set; }

        public Guid ModifiedBy
        { get; set; }
    }
}
