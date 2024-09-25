using System;
using System.Threading.Tasks;
using Common.Core.Infrastructure.Helpers;
using Common.SF.Contracts.Interfaces.Core.Settings;
using Newtonsoft.Json;

namespace Common.SF.Tests.MockServices.Base
{
    public class MockServiceConfiguration : IServiceConfiguration
    {
        private Func<object> _returnedObjects;

        public IServiceConfiguration RegisterReturnValue(Func<object> returns)
        {
            _returnedObjects = returns;
            return this;
        }

        public Task<byte[]> GetAllSettingsByService(string serviceName)
        {
            if (_returnedObjects == null) throw new NullReferenceException("The MockServiceConfiguration has not been prepared with the RegisterReturnValue method. Please assign a return result through that method first.");
            return Task.FromResult(JsonConvert.SerializeObject(_returnedObjects()).Compress());
        }

        public Task<byte[]> UpdateSettings(string serviceName, byte[] settingsData)
        {
            if (_returnedObjects == null) throw new NullReferenceException("The MockServiceConfiguration has not been prepared with the RegisterReturnValue method. Please assign a return result through that method first.");
            return Task.FromResult(JsonConvert.SerializeObject(_returnedObjects()).Compress());
        }

        public Task UpdateSetting(string serviceName, byte[] settingData)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetAllServiceSettings()
        {
            if (_returnedObjects == null) throw new NullReferenceException("The MockServiceConfiguration has not been prepared with the RegisterReturnValue method. Please assign a return result through that method first.");
            return Task.FromResult(JsonConvert.SerializeObject(_returnedObjects()).Compress());
        }

        public Task ProcessServices(byte[] objData)
        {
            throw new NotImplementedException();
        }

        public Task H1ServiceSettingsDefaultSettings()
        {
            throw new NotImplementedException();
        }
    }
}
