using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Security.Access
{
    public interface IModuleOwners : IService
    {
        Task<byte[]> GetModuleOwner(Guid id);
        Task<byte[]> GetAllModuleOwners();
        Task<byte[]> GetModuleOwnersByFilter(byte[] filter);
        Task ProcessModuleOwners(byte[] objData);

        //Task<Guid> GetH1AccessAdmin();
        //Task SetH1AccessAdmin(Guid user);
    }
}
