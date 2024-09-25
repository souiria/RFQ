using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IWireMulticoreMarker : IService
    {
        Task<byte[]> GetWireMulticoreMarker(Guid id);
        Task<byte[]> GetAllWireMulticoreMarkers();
        Task<byte[]> GetWireMulticoreMarkersByHarnessId(Guid harnessId);
    }
}
