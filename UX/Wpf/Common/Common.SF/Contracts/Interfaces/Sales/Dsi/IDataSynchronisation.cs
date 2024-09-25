using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IDataSynchronisation : IService
    {
        Task<byte[]> ProcessOperation(byte[] objData);
        Task<byte[]> LoadHarness(Guid harnessID);
    }
}
