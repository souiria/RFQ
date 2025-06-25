using SharedKernel;

namespace Master.Data.Model
{
    public class DbCustomerBusinessHierarchy : IAggregateRoot
    {
        public string? CustomerBusinessGroupCode
        { get; set; }
        public string? CustomerBusinessGroupName
        { get; set; }
        public Guid? Id
        { get; set; }
        public DateTime? CreatedDate
        { get; set; }
        public DateTime? ModifiedDate
        { get; set; }
        public Guid? CreatedBy
        { get; set; }
        public Guid? ModifiedBy
        { get; set; }
        public bool IsActive
        { get; set; }
        public short? SyncToCPD
        { get; set; }
        public string? SEWSEBusinessTeam
        { get; set; }
    }
}
