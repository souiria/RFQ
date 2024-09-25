using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.DsiAssociation
{
    public interface IHarnessScopeScope : IService
    {
        Task<byte[]> GetAllHarnessScopeScopeAssociations();
        Task<byte[]> GetHarnessScopeScopeAssociationsByHarnessScopeId(Guid id);
        Task<byte[]> GetHarnessScopeScopeAssociationsByScopeId(Guid id);
        Task<byte[]> GetHarnessScopeScopeAssociationsByHarnessId(Guid id);
    }
}
