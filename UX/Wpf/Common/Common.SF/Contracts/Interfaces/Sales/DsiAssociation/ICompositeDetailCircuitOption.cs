using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.DsiAssociation
{
    public interface ICompositeDetailCircuitOption : IService
    {
        Task<byte[]> GetAllCompositeDetailCircuitOptionAssociations();
        Task<byte[]> GetCompositeDetailCircuitOptionAssociationsByCompositeDetailId(Guid id);
        Task<byte[]> GetCompositeDetailCircuitOptionAssociationsByCompositeDetailList(byte[] objData);
        Task<byte[]> GetCompositeDetailCircuitOptionAssociationsByCircuitOptionId(Guid id);
        Task<byte[]> GetCompositeDetailCircuitOptionAssociationsByHarnessId(Guid id);
    }
}
