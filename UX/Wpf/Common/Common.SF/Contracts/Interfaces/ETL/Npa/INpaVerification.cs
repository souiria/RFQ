using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.ETL.Npa
{
    [ServiceContract]
    public interface INpaVerification : IService
    {
        [OperationContract]
        Task<byte[]> VerifyNpaFromRfq(byte[] objData);
    }
}
