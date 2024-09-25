using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
    public interface IHierarchy : IService
    {
        Task<byte[]> GetHierarchy();
        Task<byte[]> GetHierarchyByUser(Guid userGuid);

        //Task<byte[]> GetFunctionHierarchyByUser(Guid userGuid, Guid functionGuid);

        Task<byte[]> GetAllRoles();
        Task<byte[]> GetAllRolesByUser(Guid userGuid);

        Task ModifyPermissions(byte[] objData);
    }
}
