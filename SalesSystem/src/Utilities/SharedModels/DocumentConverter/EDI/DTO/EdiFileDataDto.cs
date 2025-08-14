namespace SharedModels.DocumentConverter.EDI.Aggregates
{
    public class EdiFileDataDto
    {
        public int Id 
        { get; set; }
        public EdiFileUploadStatus Status
        { get; set; }
        public string? FileName 
        { get; set; }
        public string? FinanceCode 
        { get; set; }
        public DateTime UploadDate 
        { get; set; } = DateTime.Now;
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
        public double Quantity 
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
        public double ExchangeRate 
        { get; set; }
        public string? CustomerPartNumber
        { get; set; }
        public double TotalGrossWeight 
        { get; set; }
        public double TotalNetWeight 
        { get; set; }
        public string? UnitOfMeasure
        { get; set; }
        public string? TariffCode 
        { get; set; }
        public string? DeliveryTerms 
        { get; set; }
        public string? TransportDetails
        { get; set; }
        public string? WmsInvoiceNumber
        { get; set; }
        public decimal OrderPrice 
        { get; set; }
        public string PalletQuantity 
        { get; set; } = string.Empty;
    }
}
