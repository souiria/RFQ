namespace Master.Data.Model
{
    public class DbPlatformHierarchy : IAggregateRoot
    {
        public string? PlatformName
        { get; set; }
        public Guid? CustomerHierarchyGuid
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
        public Guid? PlatformManagerGuid
        { get; set; }
        public string? PlatformManagerName
        { get; set; }
    }
}
