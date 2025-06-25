using SharedKernel;

namespace Master.Data.Model
{
    public class DbMilestoneHierarchy : IAggregateRoot
    {
        public string? MilestoneEventName
        { get; set; }
        public DateTime EventStartDate
        { get; set; }
        public DateTime EventEndDate
        { get; set; }
        public Guid? ProjectHierarchyGuid
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
        public bool? IsActive
        { get; set; }
        public short? SyncToCPD
        { get; set; }
    }
}
