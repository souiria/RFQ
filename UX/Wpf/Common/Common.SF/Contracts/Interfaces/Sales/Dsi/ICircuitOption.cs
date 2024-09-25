using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface ICircuitOption : IService
    {
        Task<byte[]> GetCircuitOption(Guid id);
        Task<byte[]> GetCircuitOptionsByIdList(byte[] objData);
        Task<byte[]> GetAllCircuitOptions();
    }
}
