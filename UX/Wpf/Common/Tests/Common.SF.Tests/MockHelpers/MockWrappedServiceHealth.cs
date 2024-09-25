using System.Fabric.Health;
using Common.SF.Infrastructure.Core;

namespace Common.SF.Tests.MockHelpers
{
    internal class MockWrappedServiceHealth : IWrappedServiceHealth
    {
        public HealthState AggregatedHealthState { get; }

        public MockWrappedServiceHealth(HealthState healthState)
        {
            AggregatedHealthState = healthState;
        }
    }
}
