using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface ICentreStrip : IService
    {
        Task<byte[]> GetCentreStrip(Guid id);
        Task<byte[]> GetAllCentreStrips();
        Task<byte[]> GetCentreStripsByHarnessId(Guid harnessId);
    }
}
