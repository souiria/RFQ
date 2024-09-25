namespace Edi.Common.Messages.Requests;
public class InvoiceInformationRequest : RequestBase
{
    public InvoiceInformationRequestType RequestType { get; set; }
    public List<DuplicateDataDto>? DuplicateData { get; set; }

}

public enum InvoiceInformationRequestType
{
    GetAllInvoiceInformation,
    SaveInvoiceInformation,
    ReprocessInvoiceInformation,
    ReprocessDuplicateInformation
}
