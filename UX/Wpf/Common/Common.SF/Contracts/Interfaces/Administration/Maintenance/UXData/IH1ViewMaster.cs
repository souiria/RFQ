using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
    public interface IH1ViewMaster : IService
    {
        Task<byte[]> GetView(Guid id);
        Task<byte[]> GetAllViews();
        Task<byte[]> GetViewsByFilter(byte[] filter);
        Task ProcessViews(byte[] objData);
    }
}
