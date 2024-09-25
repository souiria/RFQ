using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IBranchInsulationThroughNode : IService
    {
        Task<byte[]> GetBranchInsulationThroughNode(Guid id);
        Task<byte[]> GetAllBranchInsulationThroughNodes();
        Task<byte[]> GetBranchInsulationThroughNodesByHarnessId(Guid harnessId);
    }
}
