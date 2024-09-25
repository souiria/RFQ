using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Sales.DsiAssociation
{
    public interface IBranchConfigurationBend : IService
    {
        Task<byte[]> GetAllBranchConfigurationBendAssociations();
        Task<byte[]> GetBranchConfigurationBendAssociationsByBranchConfigurationId(Guid id);
        Task<byte[]> GetBranchConfigurationBendAssociationsByBendId(Guid id);
        Task<byte[]> GetBranchConfigurationBendAssociationsByHarnessId(Guid id);
    }
}
