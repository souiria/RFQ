using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
    public interface ILabels : IService
    {
        Task<byte[]> GetLabel(Guid id);
        Task<byte[]> GetAllLabels();
        Task<byte[]> GetLabelsByFilter(byte[] filter);
        Task ProcessLabels(byte[] objData);
    }
}
