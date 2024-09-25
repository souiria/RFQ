using System.Collections.Generic;
using UX.Module.Edi.Core.Dto;
using UX.Module.Edi.SharedKernel;

namespace UX.Module.Edi.Core.Messages.Requests
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
