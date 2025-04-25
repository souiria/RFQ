namespace Master.Data.DTOs
{
    public class MilestoneHierarchyDto
    {
        public required string? MilestoneEventName { get; set; }
        public required DateTime? EventStartDate { get; set; }
        public required DateTime? EventEndDate { get; set; }
        public required Guid? ProjectHierarchyGuid { get; set; }
        public required Guid? Id { get; set; }
    }
}
