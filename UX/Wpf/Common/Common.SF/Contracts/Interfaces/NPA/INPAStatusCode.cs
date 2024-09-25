using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.NPA
{
    public interface INPAStatusCode : IService
    {
        Task<byte[]> GetNPAStatusCode(Guid id);
        Task<byte[]> GetAllNPAStatusCode();
        Task<byte[]> GetNPAStatusCodeByFilter(byte[] filter);
        Task ProcessNPAStatusCode(byte[] objData);
    }
}
