

namespace SFS.Data.DTOs
{
   public class DbH1VehicleDto
    {
        public Guid? Id
        { get; set; }
        public string? VehicleName
        { get; set; }
        public string? ProjectReference
        { get; set; }
        public string? VehicleDisplay
        { get; set; }
        public bool IsActive
        { get; set; }
    }
}
