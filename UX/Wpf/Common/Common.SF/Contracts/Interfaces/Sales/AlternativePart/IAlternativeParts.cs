using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.AlternativePart
{
    public interface IAlternativeParts: IService
    {
        
        Task<byte[]> GetPartsBySumitomoNo(string search);
        Task<byte[]> PartSearch(String Filliter);
        Task<byte[]> ExecuteAlternativePartSearch(byte[] objData);
    }
}
