using System;
using System.Threading.Tasks;
using Common.SF.Contracts.Interfaces.Base;
using Common.SF.Contracts.Interfaces.Base.Base64;
using Common.SF.Infrastructure.PubSub.Interfaces;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
  public  interface IPurchasingVehicleMaster : IService
    {
        Task<string> GetVehicle(Guid id);
        Task<string> GetAllVehicles();
        Task<string> GetVehicleByFilter(string filter);
        Task ProcessVehicles(string objData);
    }
}
