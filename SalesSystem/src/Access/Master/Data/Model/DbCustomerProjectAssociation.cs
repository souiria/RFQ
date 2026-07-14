namespace Master.Data.Model
{
    public class DbCustomerProjectAssociation : IAggregateRoot
    {
        public Guid? ProjectGuid
        { get; set; }
        public Guid? CustomerGuid
        { get; set; }
        public Guid? Id
        { get; set; }
        public Guid? CreatedBy
        { get; set; }
        public Guid? ModifiedBy
        { get; set; }
        public DateTime? CreatedDate
        { get; set; }
        public DateTime? ModifiedDate
        { get; set; }
        public bool? IsActive
        { get; set; }
    }
}
