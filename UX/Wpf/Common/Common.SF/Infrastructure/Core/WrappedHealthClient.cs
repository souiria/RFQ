using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SF.Infrastructure.Core
{
    public interface IWrappedHealthClient
    {
        Task<IWrappedServiceHealth> GetServiceHealthAsync(Uri serviceName);
    }

    internal class WrappedHealthClient : IWrappedHealthClient
    {
        private FabricClient.HealthClient HealthClient { get; }
        public WrappedHealthClient(FabricClient.HealthClient healthClient)
        {
            HealthClient = healthClient;
        }

        public async Task<IWrappedServiceHealth> GetServiceHealthAsync(Uri serviceName)
        {
            return new WrappedServiceHealth(await HealthClient.GetServiceHealthAsync(serviceName));
        }
    }
}
