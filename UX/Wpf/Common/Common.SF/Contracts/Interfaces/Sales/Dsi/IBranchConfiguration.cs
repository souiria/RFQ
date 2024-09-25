using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface IBranchConfiguration : IService
    {
        Task<byte[]> GetBranchConfiguration(Guid id);
        Task<byte[]> GetAllBranchConfigurations();
        Task<byte[]> GetBranchConfigurationsByHarnessId(Guid harnessId);
    }
}
