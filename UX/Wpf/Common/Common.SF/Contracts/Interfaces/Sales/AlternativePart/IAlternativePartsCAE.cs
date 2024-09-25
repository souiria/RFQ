using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.AlternativePart
{
    public interface IAlternativePartsCAE : IService
    {
        Task<byte[]> GetAllBoMAsync();
        Task<byte[]> GetBoMFileID(int x);

        Task<byte[]> FindPriceInfo(byte[] objdata);
    }
}
