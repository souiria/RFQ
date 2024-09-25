using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IMulticoreSpecification : IService
    {
        Task<byte[]> GetMulticoreSpecification(Guid id);
        Task<byte[]> GetAllMulticoreSpecifications();
        Task<byte[]> GetMulticoreSpecificationsByHarnessId(Guid harnessId);
    }
}
