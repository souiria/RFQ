namespace Edi.Common.Messages.Requests;
public class FindSalesPriceRequest : IRequest<List<EdiInvoiceInformationDto>>
{
    public required EdiCustomerParameterDto Parameters { get; set; }
    public required List<EdiInvoiceInformationDto> InvoiceInformation { get; set; }
}
