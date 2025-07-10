
namespace SFS.Data.Model
{
    public class DbCarModel : IAggregateRoot
    {
        public Guid? Id
        { get; set; }
        public string? ModelCode 
        { get; set; }
        public string? ModelName
        { get; set; }
        public string? VehicleName 
        { get; set; }
        public string? CustCode 
        { get; set; }
        public required double CuWtKg 
        { get; set; }
        public required double CuBase 
        { get; set; }
        public string? Development
        { get; set; }
        public string? DeliverTo 
        { get; set; }
        public string? DeliveryPoint
        { get; set; }
        public string? FinancialYearOffset
        { get; set; }
        public required DateTime UpdatedDate
        { get; set; }
        public string? UpdatedBy 
        { get; set; }
        public string? Profile 
        { get; set; }
        public required Guid H1Id
        { get; set; }
    }
}
