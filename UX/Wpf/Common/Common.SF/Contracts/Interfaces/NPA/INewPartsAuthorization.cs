using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.NPA
{
    public interface INewPartsAuthorization : IService
    {
        Task<byte[]> GetNewPartsAuthorization(Guid id);
        Task<byte[]> GetAllNewPartsAuthorization();
        Task<byte[]> GetNewPartsAuthorizationByFilter(byte[] filter);
        Task ProcessNewPartsAuthorization(byte[] objData);
    }
}
