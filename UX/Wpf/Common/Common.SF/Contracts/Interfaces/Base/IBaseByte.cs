using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Base.Byte
{
    public interface IBaseByte : IService
    {
        Task<byte[]> GetAll();
        Task<byte[]> GetAllByPartition(string key);
        Task<byte[]> Get(Guid id);
        Task<byte[]> GetByFilter(byte[] filter);
        Task<byte[]> GetByFilterByPartition(string key, byte[] filter);
        Task<byte[]> ProcessOperation(byte[] objData);
        Task<byte[]> GetAllSecureDataByPartition(string key, byte[] guidObjData);
    }
}