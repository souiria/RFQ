using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IHarness : IService
    {
        Task<byte[]> GetHarness(Guid id);
        Task<byte[]> GetAllHarnesses();
        Task<bool> CheckHarnessExist(string harnessName);
    }
}
