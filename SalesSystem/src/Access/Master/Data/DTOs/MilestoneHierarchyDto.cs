namespace Master.Data.DTOs
{
    public class MilestoneHierarchyDto
    {
        public string? MilestoneEventName
        { get; set; }
        public DateTime? EventStartDate
        { get; set; }
        public DateTime? EventEndDate
        { get; set; }
        public Guid? ProjectHierarchyGuid
        { get; set; }
        public Guid? Id
        { get; set; }
        public bool? IsActive
        { get; set; }
    }
}
