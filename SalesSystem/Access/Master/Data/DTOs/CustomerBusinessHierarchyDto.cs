namespace Master.Data.DTOs
{
    public class CustomerBusinessHierarchyDto
    {
        public required string? CustomerBusinessGroupCode { get; set; }
        public required string? CustomerBusinessGroupName { get; set; }
        public required Guid? Id { get; set; }
        public required string? SEWSEBusinessTeam { get; set; }
    }
}
