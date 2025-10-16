namespace Rfq.Data.Model
{
    public class DbDsiHarnessScope : IAggregateRoot
    {
        public long RowId
        { get; set; }
        public Guid HarnessScopeId 
        { get; set; }
        public string? HarnessName1 
        { get; set; }
        public string? HarnessIssue1
        { get; set; }
        public string? HarnessName2 
        { get; set; }
        public string? HarnessIssue2 
        { get; set; }
        public string? ScopeCategory 
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
