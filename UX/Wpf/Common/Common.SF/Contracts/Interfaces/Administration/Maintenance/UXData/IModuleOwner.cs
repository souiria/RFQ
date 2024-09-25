using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
    public interface IModuleOwner : IService
    {
        Task<byte[]> GetModuleOwner(Guid id);
        Task<byte[]> GetAllModuleOwners();
        Task<byte[]> GetModuleOwnersByFilter(byte[] filter);
        Task ProcessModuleOwners(byte[] objData);
        Task<Guid> GetH1AccessAdmin();
        Task SetH1AccessAdmin(Guid user);
    }
}
