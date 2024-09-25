using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Base.Byte
{
    public interface IRecoveryByte : IService
    {
        Task<byte[]> GetAllDatabaseEntries();
        Task RecoveryProcessOperations(byte[] objData);
    }
}