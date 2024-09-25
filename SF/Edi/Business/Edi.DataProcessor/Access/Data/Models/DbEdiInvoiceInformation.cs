namespace Edi.DataProcessor.Access.Data.Models;
internal class DbEdiInvoiceInformation : IAggregateRoot
{
    public Guid Id { get; set; }

    public string FileName { get; set; }
    public string FinanceCode { get; set; }
    public string DispatchNumber { get; set; }
    public DateTime DispatchDate { get; set; }
    public string CustomerOrderNumber { get; set; }
    public string PartNumber { get; set; }
    public string PartDescription { get; set; }
    public double Quantity { get; set; }
    public string UnloadingPoint { get; set; }
    public string WMSSiteCode { get; set; }
    public string WMSCustomerCode { get; set; }
    public string CustomerDispatchNumber { get; set; }
    public string MessageType { get; set; }
    public double ExchangeRate { get; set; }
    public string CustomerPartNumber { get; set; }
    public double TotalGrossWeight { get; set; }
    public double TotalNetWeight { get; set; }
    public string UnitOfMeasure { get; set; }
    public string TariffCode { get; set; }
    public string DeliveryTerms { get; set; }
    public string TransportDetails { get; set; }
    public string WMSInvoiceNumber { get; set; }

    public Guid CustomerLocationId { get; set; }
    public string BatchId { get; set; }
    public bool IsValidPrice { get; set; }
    public bool IsValidProduct { get; set; }
    public bool IsProcessStarted { get; set; }
    public DateTime ProcessStartDate { get; set; }
    public double OrderPrice { get; set; }
    public string CurrencyCode { get; set; }
    public double TotalInvoicePrice { get; set; }
    public EdiInvoiceStatus Status { get; set; }
    public bool IsAgressoTransferred { get; set; }
    public DateTime ProcessCompletionDate { get; set; }
    public string Customer { get; set; }
    public string CustomerLocation { get; set; }
}
