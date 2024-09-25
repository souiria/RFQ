using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
    public interface IH1ModuleH1ViewAssociation : IService
    {
        Task<byte[]> GetModuleViewAssociation(Guid id);
        Task<byte[]> GetAllModuleViewAssociations();
        Task<byte[]> GetModuleViewAssociationsByFilter(byte[] filter);
        Task ProcessModuleViewAssociations(byte[] objData);
        Task<byte[]> GetViewsByModule(Guid id);
        Task<byte[]> GetModulesByView(Guid id);
    }
}
