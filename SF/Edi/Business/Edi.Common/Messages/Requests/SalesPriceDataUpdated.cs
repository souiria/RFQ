namespace Edi.Common.Messages.Requests;
public class SalesPriceDataUpdated
{
    public required List<EdiInvoiceInformationDto> SalesPriceData { get; set; }
}
