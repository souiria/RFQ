
namespace SFS.Data.Model
{
    public class DbCarModel : IAggregateRoot
    {
        public int? Id
        { get; set; }
        public string? ModelCode 
        { get; set; }
        public string? ModelName
        { get; set; }
        public string? VehicleName 
        { get; set; }
        public string? CustCode 
        { get; set; }
        public  decimal? Cu_wt_KG
        { get; set; }
        public decimal? Cu_base
        { get; set; }
        public string? Development
        { get; set; }
        public string? DeliverTo 
        { get; set; }
        public string? DeliveryPoint
        { get; set; }
        public string? FinancialYearOffset
        { get; set; }
        public  DateTime UpdatedDate
        { get; set; }
        public string? UpdatedBy 
        { get; set; }
        public string? Profile 
        { get; set; }
        public Guid? H1Id
        { get; set; }
    }
}
