using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IWireThroughNode : IService
    {
        Task<byte[]> GetWireThroughNode(Guid id);
        Task<byte[]> GetAllWireThroughNodes();
        Task<byte[]> GetWireThroughNodesByHarnessId(Guid harnessId);
    }
}
