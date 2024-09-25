using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IModuleCompatibility : IService
    {
        Task<byte[]> GetModuleCompatibility(Guid id);
        Task<byte[]> GetAllModuleCompatibilities();
        Task<byte[]> GetModuleCompatibilitiesByHarnessId(Guid harnessId);
    }
}
