using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
    public interface IH1ModuleMaster : IService
    {
        Task<byte[]> GetModule(Guid id);
        Task<byte[]> GetAllModules();
        Task<byte[]> GetModulesByFilter(byte[] filter);
        Task ProcessModules(byte[] objData);
    }
}
