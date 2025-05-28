using SharedKernel;

namespace Master.Data.Model
{
    public class DbProgramHierarchy : IAggregateRoot
    {
        public string? ProgramName
        { get; set; }
        public Guid? PlatformHierarchyGuid
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
