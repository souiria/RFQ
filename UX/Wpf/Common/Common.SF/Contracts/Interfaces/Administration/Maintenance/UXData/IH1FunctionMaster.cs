using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
    public interface IH1FunctionMaster : IService
    {
        Task<byte[]> GetFunction(Guid id);
        Task<byte[]> GetAllFunctions();
        Task<byte[]> GetFunctionsByFilter(byte[] filter);
        Task ProcessFunctions(byte[] objData);
    }
}
