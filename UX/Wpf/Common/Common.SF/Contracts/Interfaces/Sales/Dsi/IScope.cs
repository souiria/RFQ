using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IScope : IService
    {
        Task<byte[]> GetScope(Guid id);
        Task<byte[]> GetAllScopes();
    }
}
