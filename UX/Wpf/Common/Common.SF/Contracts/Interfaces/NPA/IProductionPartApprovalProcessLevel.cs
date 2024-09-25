using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.NPA
{
    public interface IProductionPartApprovalProcessLevel : IService
    {
        Task<byte[]> GetProductionPartApprovalProcessLevel(Guid id);
        Task<byte[]> GetAllProductionPartApprovalProcessLevel();
        Task<byte[]> GetProductionPartApprovalProcessLevelByFilter(byte[] filter);
        Task ProcessProductionPartApprovalProcessLevel(byte[] objData);
    }
}
