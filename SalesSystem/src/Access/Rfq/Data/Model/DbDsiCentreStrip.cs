namespace Rfq.Data.Model
{
    public class DbDsiCentreStrip : IAggregateRoot
    {
        public long RowId
        { get; set; }
        public string? NodeName 
        { get; set; }
        public string? Route 
        { get; set; }
        public string? WireName
        { get; set; }
        public double StripLength 
        { get; set; }
        public string? LengthChangeType 
        { get; set; }
        public double LengthChangeValue
        { get; set; }
        public string? Option
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
