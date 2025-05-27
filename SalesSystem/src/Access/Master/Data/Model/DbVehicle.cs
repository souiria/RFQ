using SharedKernel;

namespace Master.Data.Model
{
    public class DbVehicle : IAggregateRoot
    {
        public Guid? Id { get; set; }
        public string? VehicleName { get; set; }
        public string? ProjectReference { get; set; }
        public string? VehicleDisplay { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
