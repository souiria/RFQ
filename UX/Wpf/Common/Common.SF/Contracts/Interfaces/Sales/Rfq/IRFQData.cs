using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Sales.Rfq
{
    public interface IRFQData : IService
    {
        Task<byte[]> RfqMetadataProcessOperation(byte[] objData);
        Task RfqMetadataSaveUserList(byte[] objData);
        Task<byte[]> RfqPartProcessOperation(byte[] objData);

        Task<byte[]> GetAllRfqMetadata();
        Task<byte[]> GetRfqMetadataById(Guid id);
        Task<byte[]> GetRfqMetadataByUserId(Guid userId);
        Task<byte[]> GetLast5RfqMetadata();
        Task<byte[]> GetAllRfqPartsByRfqId(Guid rfqId);
        Task<byte[]> GetNoMatchNPARefNo(byte[] objData);
    }
}