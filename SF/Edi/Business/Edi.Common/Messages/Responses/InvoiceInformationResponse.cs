namespace Edi.Common.Messages.Responses;
public class InvoiceInformationResponse : ResponseBase
{
    public List<EdiInvoiceInformationDto>? InvoiceInformation { get; set; }
    public List<EdiCustomerParameterDto>? EdiCustomerParameters { get; set; }
}
