namespace Edi.Common.Messages.Requests;
public class DispatchDataInserted
{
    public required List<EdiInvoiceInformationDto> DispatchData { get; set; }
}
