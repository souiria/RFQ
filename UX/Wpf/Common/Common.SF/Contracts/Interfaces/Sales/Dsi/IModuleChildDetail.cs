using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IModuleChildDetail : IService
    {
        Task<byte[]> GetModuleChildDetail(Guid id);
        Task<byte[]> GetAllModuleChildDetails();
        Task<byte[]> GetModuleChildDetailsByHarnessId(Guid harnessId);
    }
}
