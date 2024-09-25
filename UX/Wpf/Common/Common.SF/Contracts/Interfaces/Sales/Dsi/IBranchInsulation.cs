using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IBranchInsulation : IService
    {
        Task<byte[]> GetBranchInsulation(Guid id);
        Task<byte[]> GetAllBranchInsulations();
        Task<byte[]> GetBranchInsulationsByHarnessId(Guid harnessId);
    }
}
