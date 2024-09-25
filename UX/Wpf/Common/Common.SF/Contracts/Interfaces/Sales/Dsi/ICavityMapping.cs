using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface ICavityMapping : IService
    {
        Task<byte[]> GetCavityMapping(Guid id);
        Task<byte[]> GetAllCavityMappings();
    }
}
