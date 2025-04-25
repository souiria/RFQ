namespace Master.Data.DTOs
{
    public class PlatformHierarchyDto
    {
        public required string? PlatformName { get; set; }
        public required Guid? CustomerHierarchyGuid { get; set; }
        public required Guid? Id { get; set; }
        public required string? PlatformManagerName { get; set; }
    }
}
