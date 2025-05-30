namespace Master.Data.DTOs
{
    public class ProgramHierarchyDto
    {
        public string? ProgramName
        { get; set; }
        public Guid? PlatformHierarchyGuid
        { get; set; }
        public Guid? Id
        { get; set; }
        public bool? IsActive
        { get; set; }
    }
}
