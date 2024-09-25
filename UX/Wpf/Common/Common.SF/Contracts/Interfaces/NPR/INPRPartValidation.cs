using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.NPR
{
  public  interface INPRPartValidation : IService
    {
        Task<string> ValidateNPRPartData(string objData);
    }
}
