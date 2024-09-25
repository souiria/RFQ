using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Security
{
    public interface ISecurityAudit : IService
    {
        Task<bool> LogChange(byte[] objData);
        Task<byte[]> GetByIndex(int index);
    }
}
