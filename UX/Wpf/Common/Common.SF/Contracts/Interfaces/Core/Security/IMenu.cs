using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Security
{
    public interface IMenu : IService
    {
        Task<byte[]> GetAllMenuItems();

        Task ProcessMenuItems(byte[] objData);

        Task<byte[]> GetMenu(Guid id);
    }
}
