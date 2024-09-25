using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.ETL.Npa
{
    public interface INpaStatus : IService
    {
        Task<byte[]> GetNpaStatusByReferenceNumber(string objData);
        Task<byte[]> GetNpaStatusByReferenceNumberList(byte[] objData);
    }
}
