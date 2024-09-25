using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IRestoreServiceDataFromDB :IService
    {
       Task<string> RestoreServiceData(Dictionary<string ,bool> ServiceInfo);
    }
}
