using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Settings
{
    public interface IConnections : IService
    {
        Task<byte[]> GetAllConnections();
        Task ProcessConnections(byte[] objData);
    }
}
