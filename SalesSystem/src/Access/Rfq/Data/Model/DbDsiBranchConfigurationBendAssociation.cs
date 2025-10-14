namespace Rfq.Data.Model
{
    public class DbDsiBranchConfigurationBendAssociation : IAggregateRoot
    {
        public long RowId 
        { get; set; }
        public Guid BranchConfigurationId 
        { get; set; }
        public Guid BendId 
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
