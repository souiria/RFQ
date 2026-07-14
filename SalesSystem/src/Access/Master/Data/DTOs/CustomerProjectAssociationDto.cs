namespace Master.Data.DTOs
{
    public class CustomerProjectAssociationDto
    {
        public Guid? ProjectGuid
        { get; set; }
        public Guid? CustomerLocationGuid
        { get; set; }
        public Guid? Id
        { get; set; }
        public bool? IsActive
        { get; set; }
    }
}
