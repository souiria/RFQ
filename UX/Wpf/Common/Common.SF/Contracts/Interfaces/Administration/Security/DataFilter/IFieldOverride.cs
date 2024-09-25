using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Security.DataFilter
{
    public interface IFieldOverride : IService
    {
        Task<byte[]> GetAllFieldOverrides();
        Task<byte[]> GetFieldOverride(Guid id);
        Task<byte[]> GetFieldOverridesByFilter(byte[] objData);
        Task ProcessFieldOverrides(byte[] objData);
        Task<byte[]> GetUserPermissionsByView(byte[] requestModelData);
    }
}
