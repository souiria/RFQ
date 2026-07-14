namespace Rfq.Data.Model
{
    public class DbDsiPinMapping : IAggregateRoot
    {
        public long RowId
        { get; set; }
        public Guid PinMappingId 
        { get; set; }
        public string? Node1 
        { get; set; }
        public string? Node2
        { get; set; }
        public string? HarnessName1 
        { get; set; }
        public string? HarnessIssue1 
        { get; set; }
        public string? HarnessName2
        { get; set; }
        public string? HarnessIssue2 
        { get; set; }
        public string? Separator 
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
