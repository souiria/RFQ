namespace Rfq.Data.Model
{
    public class DbDsiModuleCompatibility : IAggregateRoot
    {
        public long RowId
        { get; set; }
        public string? ModuleCode1 
        { get; set; }
        public string? ModuleCode2 
        { get; set; }
        public string? Relationship
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
