namespace Purchasing.Data.Model
{
    public class DbH1CPD : IAggregateRoot
    {
        public string? SumitomoNumber
        { get; set; }
        public string? UniformSumitomoNumber
        { get; set; }
        public string? SupplierName
        { get; set; }
        public string? SupplierNumber
        { get; set; }
        public string? UniformSupplierNumber
        { get; set; }
        public bool? MainSupplier
        { get; set; }
        public string? CurrencyCode
        { get; set; }
        public string? UnitOfMeasure
        { get; set; }
        public decimal? Price
        { get; set; }
    }
}
