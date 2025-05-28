namespace Master.Data.DTOs
{
    public class ProgramHierarchyDto
    {
        public required string? ProgramName
        { get; set; }
        public required Guid? PlatformHierarchyGuid
        { get; set; }
        public required Guid? Id
        { get; set; }
        public required bool? IsActive
        { get; set; }
    }
}
