using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance.UXData
{
    public interface ILanguages : IService
    {
        Task<byte[]> GetLanguage(Guid id);
        Task<byte[]> GetAllLanguages();
        Task<byte[]> GetLanguagesByFilter(byte[] filter);
        Task ProcessLanguages(byte[] objData);
        Task<byte[]> GetLabelsByLanguage(Guid id);
    }
}
