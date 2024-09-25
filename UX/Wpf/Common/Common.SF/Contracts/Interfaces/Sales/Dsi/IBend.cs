using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IBend : IService
    {
        Task<byte[]> GetBend(Guid id);
        Task<byte[]> GetAllBends();
    }
}
