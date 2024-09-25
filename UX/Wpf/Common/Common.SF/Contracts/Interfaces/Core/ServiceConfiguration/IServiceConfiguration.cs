using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Settings
{
    public interface IServiceConfiguration :  IService
    {
        Task<byte[]> GetAllSettingsByService(string serviceName);
        Task<byte[]> UpdateSettings(string serviceName, byte[] settingsData);
        Task UpdateSetting(string serviceName, byte[] settingData);
        Task<byte[]> GetAllServiceSettings();
        Task ProcessServices(byte[] objData);
        Task H1ServiceSettingsDefaultSettings();
    }
}
