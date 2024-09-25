using System.Collections.Generic;
using UX.Commercial.Edi.Core.Dto;
using UX.Commercial.Edi.SharedKernel;

namespace UX.Commercial.Edi.Core.Messages.Responses
{
    public class InvoiceInformationResponse : ResponseBase
    {
        public IAsyncEnumerable<EdiInvoiceInformationDto> InvoiceInformation { get; set; }
    }
}
