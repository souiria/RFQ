namespace Edi.Common.Messages.Requests;
public class ValidateProductRequest : IRequest<List<EdiInvoiceInformationDto>>
{
    public required List<EdiInvoiceInformationDto> SalesPriceData { get; set; }
    public required EdiCustomerParameterDto CustomerParameters { get; set; }
}
