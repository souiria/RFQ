using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.NPA
{
    public interface INPAType : IService
    {
        Task<byte[]> GetNPAType(Guid id);
        Task<byte[]> GetAllNPAType();
        Task<byte[]> GetNPATypeByFilter(byte[] filter);
        Task ProcessNPAType(byte[] objData);
    }
}
