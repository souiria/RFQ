using System.Collections.Generic;
using UX.Commercial.Edi.Core.Dto;
using UX.Commercial.Edi.SharedKernel;

namespace UX.Commercial.Edi.Core.Messages.Requests
{
    public class InvoiceInformationRequest : RequestBase
    {
        public InvoiceInformationRequestType RequestType { get; set; }
        public List<DuplicateDataDto> DuplicateData { get; set; }

    }

    public enum InvoiceInformationRequestType
    {
        GetAllInvoiceInformation,
        SaveInvoiceInformation,
        ReprocessInvoiceInformation,
        ReprocessDuplicateInformation
    }
}
