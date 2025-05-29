namespace Master.Data.DTOs
{
    public class CustomerBusinessUserAssociationDto
    {
        public Guid? UserGuid
        { get; set; }
        public string? CustomerBusinessHierarchyList
        { get; set; }
        public Guid? Id
        { get; set; }
        public bool? IsActive
        { get; set; }
    }
}
