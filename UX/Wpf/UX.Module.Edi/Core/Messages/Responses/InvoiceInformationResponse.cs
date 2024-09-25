using System.Collections.Generic;
using UX.Module.Edi.Core.Dto;
using UX.Module.Edi.SharedKernel;

namespace UX.Module.Edi.Core.Messages.Responses
{
    public class InvoiceInformationResponse : ResponseBase
    {
        public IAsyncEnumerable<EdiInvoiceInformationDto> InvoiceInformation { get; set; }
    }
}
