using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IComponent : IService
    {
        Task<byte[]> GetComponent(Guid id);
        Task<byte[]> GetAllComponents();
        Task<byte[]> GetComponentsByHarnessId(Guid harnessId);
        Task<byte[]> GetComponentsByCompositeDetailIdList(byte[] objData);
        Task<byte[]> GetDerivativeInformationByHarnessId(Guid harnessId);
    }
}
