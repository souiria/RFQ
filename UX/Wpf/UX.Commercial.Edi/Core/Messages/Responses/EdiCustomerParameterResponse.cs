using System.Collections.Generic;
using UX.Commercial.Edi.Core.Dto;
using UX.Commercial.Edi.SharedKernel;

namespace UX.Commercial.Edi.Core.Messages.Responses
{
    public class EdiCustomerParameterResponse : ResponseBase
    {
        public List<EdiCustomerParameterDto> CustomerParameters { get; set; }
    }
}
