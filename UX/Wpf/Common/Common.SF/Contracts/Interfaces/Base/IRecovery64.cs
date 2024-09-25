using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Base.Base64
{
    public interface IRecovery64 : IService
    {
        Task<string> GetAllDatabaseEntries();
        Task RecoveryProcessOperations(string objData);
    }
}
