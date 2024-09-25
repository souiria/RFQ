using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.DsiAssociation
{
    public interface IPinMappingCavityMapping : IService
    {
        Task<byte[]> GetAllPinMappingCavityMappingAssociations();
        Task<byte[]> GetPinMappingCavityMappingAssociationsByPinMappingId(Guid id);
        Task<byte[]> GetPinMappingCavityMappingAssociationsByCavityMappingId(Guid id);
        Task<byte[]> GetPinMappingCavityMappingAssociationsByHarnessId(Guid id);
    }
}
