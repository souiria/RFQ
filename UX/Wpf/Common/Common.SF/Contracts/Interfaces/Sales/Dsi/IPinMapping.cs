using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IPinMapping : IService
    {
        Task<byte[]> GetPinMapping(Guid id);
        Task<byte[]> GetAllPinMappings();
        Task<byte[]> GetPinMappingsByHarnessId(Guid harnessId);
    }
}
