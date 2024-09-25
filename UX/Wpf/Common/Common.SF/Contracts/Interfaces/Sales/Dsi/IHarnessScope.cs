using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IHarnessScope : IService
    {
        Task<byte[]> GetHarnessScope(Guid id);
        Task<byte[]> GetAllHarnessScopes();
        Task<byte[]> GetHarnessScopesByHarnessId(Guid harnessId);
    }
}
