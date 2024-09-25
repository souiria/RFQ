using System.Fabric.Health;

namespace Common.SF.Infrastructure.Core
{
    public interface IWrappedServiceHealth
    {
        HealthState AggregatedHealthState { get; }
    }

    internal class WrappedServiceHealth : IWrappedServiceHealth
    {
        private ServiceHealth ServiceHealth { get; }
        public WrappedServiceHealth(ServiceHealth serviceHealth)
        {
            ServiceHealth = serviceHealth;
        }

        public HealthState AggregatedHealthState => ServiceHealth.AggregatedHealthState;
    }
}
