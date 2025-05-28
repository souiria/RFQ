namespace Master.Data.DTOs
{
    public class ProjectHierarchyDto
    {
        public required string? ProjectCode
        { get; set; }
        public required string? ProjectName
        { get; set; }
        public required string? CustomerProjectCode
        { get; set; }
        public required string? ProjectDescription
        { get; set; }
        public required int? ProjectAnnualVolume
        { get; set; }
        public required Guid? ProgramHierarchyGuid
        { get; set; }
        public required Guid Id
        { get; set; }
        public required bool? IsActive
        { get; set; }
    }
}
