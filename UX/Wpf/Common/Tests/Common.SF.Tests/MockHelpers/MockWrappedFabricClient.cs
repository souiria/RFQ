using Common.SF.Infrastructure.Core;

namespace Common.SF.Tests.MockHelpers
{
    internal class MockWrappedFabricClient : IWrappedFabricClient
    {
        public void Dispose()
        {
            //Does nothing
        }

        public IWrappedQueryClient QueryManager { get; } = new MockWrappedQueryClient();
        public IWrappedHealthClient HealthManager { get; } = new MockWrappedHealthClient();
    }
}
