using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.ETL.Npa
{
    [ServiceContract]
    public interface INpaUpload : IService
    {
        [OperationContract]
        Task<byte[]> UploadNpaFromRfq(byte[] objData);
        [OperationContract]
        Task<byte[]> GetSupplierListFromNpa();
        [OperationContract]
        Task<byte[]> GetUomListFromNpa();
    }
}
