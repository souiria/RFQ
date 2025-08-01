namespace EDI.Data.Model
{
    public class DbEdiInvoiceInformation : IAggregateRoot
    {
        public Guid Id
        { get; set; } 
        public string? FileName
        { get; set; } 
        public string? Customer
        { get; set; } 
        public string? CustomerLocation
        { get; set; } 
        public string? FinanceCode
        { get; set; } 
        public string? DispatchNumber
        { get; set; }
        public DateTime DispatchDate
        { get; set; } 
        public string? CustomerOrderNumber
        { get; set; } 
        public string? PartNumber
        { get; set; }
        public string? PartDescription
        { get; set; } 
        public decimal Quantity
        { get; set; } 
        public string? UnloadingPoint
        { get; set; } 
        public string? WmsSiteCode
        { get; set; } 
        public string? WmsCustomerCode
        { get; set; } 
        public string? CustomerDispatchNumber
        { get; set; } 
        public string? MessageType
        { get; set; } 
        public decimal ExchangeRate
        { get; set; } 
        public string? CustomerPartNumber
        { get; set; } 
        public decimal TotalGrossWeight
        { get; set; } 
        public decimal TotalNetWeight
        { get; set; } 
        public string? UnitofMeasure
        { get; set; } 
        public string? TariffCode
        { get; set; }
        public string? DeliveryTerms
        { get; set; } 
        public string? TransportDetails
        { get; set; } 
        public string? WmsInvoiceNumber
        { get; set; } 
        public Guid CustomerLocationId
        { get; set; } 
        public string? BatchId
        { get; set; } 
        public bool IsValidPrice
        { get; set; } 
        public bool IsValidProduct
        { get; set; } 
        public bool IsProcessStarted
        { get; set; } 
        public DateTime ProcessStartDate
        { get; set; } 
        public decimal OrderPrice
        { get; set; } 
        public string? CurrencyCode
        { get; set; } 
        public bool IsAgressoTransferred
        { get; set; } 
        public decimal TotalInvoicePrice
        { get; set; } 
        public int Status
        { get; set; } 
        public DateTime ProcessCompletionDate
        { get; set; } 

        public DbEdiInvoiceInformation()
        {
            Id = Guid.NewGuid();
        }
    }
}
