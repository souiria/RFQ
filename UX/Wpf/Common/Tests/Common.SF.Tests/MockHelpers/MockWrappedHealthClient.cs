using System;
using System.Collections.Generic;
using System.Fabric.Health;
using System.Fabric.Query;
using System.Threading.Tasks;
using Common.SF.Infrastructure.Core;

namespace Common.SF.Tests.MockHelpers
{
    public class MockWrappedHealthClient : IWrappedHealthClient
    {
        private Dictionary<Uri, HealthState> Services { get; } = new Dictionary<Uri, HealthState>();

        public void AddService(Uri serviceName)
        {
            Services.Add(serviceName, HealthState.Ok);
        }

        public void SetHealthState(Uri serviceName, HealthState healthState)
        {
            Services[serviceName] = healthState;
        }

        public Task<IWrappedServiceHealth> GetServiceHealthAsync(Uri serviceName)
        {
            IWrappedServiceHealth result = new MockWrappedServiceHealth(Services[serviceName]);
            return Task.FromResult(result);
        }
    }
}
