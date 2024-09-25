namespace Edi.Common.Messages.Requests;
public class ValidateUnit4DispatchRequest : IRequest<List<EdiInvoiceInformationDto>>
{
    public required List<EdiInvoiceInformationDto> SalesPriceData { get; set; }
    public required EdiCustomerParameterDto CustomerParameters { get; set; }
}
