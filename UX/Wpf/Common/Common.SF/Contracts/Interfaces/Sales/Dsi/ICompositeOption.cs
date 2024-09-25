using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface ICompositeOption : IService
    {
        Task<byte[]> GetCompositeOption(Guid id);
        Task<byte[]> GetAllCompositeOptions();
        Task<byte[]> GetCompositeOptionsByHarnessId(Guid harnessId);
    }
}
