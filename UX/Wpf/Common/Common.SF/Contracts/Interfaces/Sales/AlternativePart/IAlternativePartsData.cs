using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Sales.AlternativePart
{
    public interface IAlternativePartsData : IService
    {
        Task<byte[]> AlternativePartsDataGet(Guid ALternativePartID);
        Task<byte[]> AlternativePartsDataGetAll();
        Task<byte[]> AlternativePartDataSave(byte[] objdata);
    }
}
