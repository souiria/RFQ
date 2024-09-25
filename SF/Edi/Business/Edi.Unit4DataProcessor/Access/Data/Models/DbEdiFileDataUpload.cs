namespace Edi.Unit4DataProcessor.Access.Data.Models;
internal class DbEdiFileDataUpload : IAggregateRoot
{
    public int Id { get; set; }
    public required string FileName { get; set; }
    public required string FinanceCode { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.Now;
    public required string DispatchNumber { get; set; }
    public DateTime DispatchDate { get; set; }
    public string? CustomerOrderNumber { get; set; }
    public required string PartNumber { get; set; }
    public required string PartDescription { get; set; }
    public double Quantity { get; set; }
    public required string UnloadingPoint { get; set; }
    public required string WmsSiteCode { get; set; }
    public required string WmsCustomerCode { get; set; }
    public required string CustomerDispatchNumber { get; set; }
    public string? MessageType { get; set; }
    public double ExchangeRate { get; set; }
    public required string CustomerPartNumber { get; set; }
    public double TotalGrossWeight { get; set; }
    public double TotalNetWeight { get; set; }
    public required string UnitOfMeasure { get; set; }
    public required string TariffCode { get; set; }
    public required string DeliveryTerms { get; set; }
    public required string TransportDetails { get; set; }
    public required string WmsInvoiceNumber { get; set; }
}
