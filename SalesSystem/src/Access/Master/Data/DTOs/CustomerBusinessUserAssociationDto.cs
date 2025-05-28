namespace Master.Data.DTOs
{
    public class CustomerBusinessUserAssociationDto
    {
        public required Guid? UserGuid
        { get; set; }
        public required string? CustomerBusinessHierarchyList
        { get; set; }
        public required Guid? Id
        { get; set; }
        public required bool? IsActive
        { get; set; }
    }
}
