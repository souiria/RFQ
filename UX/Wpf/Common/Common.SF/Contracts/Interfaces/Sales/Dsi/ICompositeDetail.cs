using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Dsi
{
    public interface ICompositeDetail : IService
    {
        Task<byte[]> GetCompositeDetail(Guid id);
        Task<byte[]> GetAllCompositeDetails();
        Task<byte[]> GetCompositeDetailsByHarnessId(Guid harnessId);
        Task<byte[]> GetCompositeDetailsByIdList(byte[] objData);
    }
}
