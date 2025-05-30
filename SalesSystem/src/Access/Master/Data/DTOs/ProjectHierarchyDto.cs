namespace Master.Data.DTOs
{
    public class ProjectHierarchyDto
    {
        public string? ProjectCode
        { get; set; }
        public string? ProjectName
        { get; set; }
        public string? CustomerProjectCode
        { get; set; }
        public string? ProjectDescription
        { get; set; }
        public int? ProjectAnnualVolume
        { get; set; }
        public Guid? ProgramHierarchyGuid
        { get; set; }
        public Guid Id
        { get; set; }
        public bool? IsActive
        { get; set; }
    }
}
