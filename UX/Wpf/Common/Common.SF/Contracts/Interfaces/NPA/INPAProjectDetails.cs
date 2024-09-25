using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.NPA
{
    public interface INPAProjectDetails : IService
    {
        Task<byte[]> GetNPAProjectDetails(Guid id);
        Task<byte[]> GetAllNPAProjectDetails();
        Task<byte[]> GetNPAProjectDetailsByFilter(byte[] filter);
        Task ProcessNPAProjectDetails(byte[] objData);
    }
}
