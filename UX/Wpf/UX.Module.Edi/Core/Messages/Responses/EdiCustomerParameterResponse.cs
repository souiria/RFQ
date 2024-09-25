using System.Collections.Generic;
using UX.Module.Edi.Core.Dto;
using UX.Module.Edi.SharedKernel;

namespace UX.Module.Edi.Core.Messages.Responses
{
    public class EdiCustomerParameterResponse : ResponseBase
    {
        public List<EdiCustomerParameterDto> CustomerParameters { get; set; }
    }
}
