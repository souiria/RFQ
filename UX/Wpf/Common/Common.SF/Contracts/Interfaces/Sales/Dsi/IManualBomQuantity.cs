using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IManualBomQuantity : IService
    {
        Task<byte[]> GetManualBomQuantity(Guid id);
        Task<byte[]> GetAllManualBomQuantities();
        Task<byte[]> GetManualBomQuantitiesByHarnessId(Guid harnessId);
    }
}
