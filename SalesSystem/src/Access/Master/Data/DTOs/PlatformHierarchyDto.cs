namespace Master.Data.DTOs
{
    public class PlatformHierarchyDto
    {
        public string? PlatformName
        { get; set; }
        public Guid? CustomerHierarchyGuid
        { get; set; }
        public Guid? Id
        { get; set; }
        public string? PlatformManagerName
        { get; set; }
        public bool? IsActive
        { get; set; }
    }
}
