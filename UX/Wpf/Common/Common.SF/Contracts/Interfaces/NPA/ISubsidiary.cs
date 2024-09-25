using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.NPA
{
    public interface ISubsidiary : IService
    {
        Task<byte[]> GetSubsidiary(Guid id);
        Task<byte[]> GetAllSubsidiary();
        Task<byte[]> GetSubsidiaryByFilter(byte[] filter);
        Task ProcessSubsidiary(byte[] objData);
    }
}
