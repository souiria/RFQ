using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.NPA
{
    public interface IArchiveNewPartsAuthorization : IService
    {
        Task<byte[]> GetArchiveNewPartsAuthorization(Guid id);
        Task<byte[]> GetAllArchiveNewPartsAuthorization();
        Task<byte[]> GetArchiveNewPartsAuthorizationByFilter(byte[] filter);
        Task ProcessArchiveNewPartsAuthorization(byte[] objData);
    }
}
