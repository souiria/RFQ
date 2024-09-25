using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.NPR
{
    public interface IProjectDetails : IService
    {
        Task<byte[]> GetProjectDetails(Guid id);
        Task<byte[]> GetAllProjectDetails();
        Task<byte[]> GetProjectDetailsByFilter(byte[] filter);
        Task ProcessProjectDetails(byte[] objData);
    }
}
