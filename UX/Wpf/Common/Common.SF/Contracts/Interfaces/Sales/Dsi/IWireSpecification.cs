using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IWireSpecification : IService
    {
        Task<byte[]> GetWireSpecification(Guid id);
        Task<byte[]> GetAllWireSpecifications();
        Task<byte[]> GetWireSpecificationsByHarnessId(Guid harnessId);
        Task<byte[]> GetWireSpecificationsByComponents(byte[] objData);
    }
}
