using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
    public interface IH1FunctionH1ModuleAssociation : IService
    {
        Task<byte[]> GetFunctionModuleAssociation(Guid id);
        Task<byte[]> GetAllFunctionModuleAssociations();
        Task<byte[]> GetFunctionModuleAssociationsByFilter(byte[] filter);
        Task ProcessFunctionModuleAssociations(byte[] objData);
        Task<byte[]> GetModulesByFunction(Guid id);
        Task<byte[]> GetFunctionsByModule(Guid id);
    }
}
