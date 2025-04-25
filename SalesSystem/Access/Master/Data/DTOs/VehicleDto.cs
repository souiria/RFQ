namespace Master.Data.DTOs
{
    public class VehicleDto
    {
        public required Guid? Id { get; set; }
        public required string? VehicleName { get; set; }
        public required string? ProjectReference { get; set; }
        public required string? VehicleDisplay { get; set; }
    }
}
