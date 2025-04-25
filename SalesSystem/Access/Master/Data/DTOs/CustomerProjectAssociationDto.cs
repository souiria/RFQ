namespace Master.Data.DTOs
{
    public class CustomerProjectAssociationDto
    {
        public required Guid? ProjectGuid { get; set; }
        public required Guid? CustomerLocationGuid { get; set; }
        public required Guid? Id { get; set; }
    }
}
