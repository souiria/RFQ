using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Logging
{
    public interface IErrorLog : IService
    {
        Task<byte[]> GetAllErrors();
        Task<byte[]> GetError(Guid id);
        Task ProcessErrors(byte[] objData);
    }
}
