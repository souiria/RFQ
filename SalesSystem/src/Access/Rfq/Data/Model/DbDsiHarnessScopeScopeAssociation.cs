namespace Rfq.Data.Model
{
    public class DbDsiHarnessScopeScopeAssociation : IAggregateRoot
    {
        public long RowId 
        { get; set; }
        public Guid HarnessScopeID
        { get; set; }
        public Guid ScopeID 
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
