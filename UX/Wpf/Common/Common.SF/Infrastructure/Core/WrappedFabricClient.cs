using System;
using System.Fabric;

namespace Common.SF.Infrastructure.Core
{

    /// <inheritdoc />
    /// <summary>
    /// An interface for the <see cref="T:Common.SF.Infrastructure.Core.WrappedFabricClient" /> that exposes methods of the FabricClient class that can
    /// be mocked for unit testing.
    /// </summary>
    public interface IWrappedFabricClient : IDisposable
    {
        //Implement necessary FabricClient methods below. This allows the methods to be unit tested.

        /// <summary>
        /// Returns the FabricClient query manager.
        /// </summary>
        IWrappedQueryClient QueryManager { get; }
        IWrappedHealthClient HealthManager { get; }
    }

    /// <inheritdoc />
    /// <summary>
    /// A wrapper for the FabricClient class.
    /// </summary>
    internal class WrappedFabricClient : IWrappedFabricClient
    {
        public WrappedFabricClient()
        {
            Client = new FabricClient();
            QueryManager = new WrappedQueryClient(Client.QueryManager);
            HealthManager = new WrappedHealthClient(Client.HealthManager);
        }

        private FabricClient Client { get; }

        //Implement necessary FabricClient method below.

        /// <inheritdoc />
        /// <summary>
        /// Gets the query manager that can be used to execute queries against the Service Fabric cluster.
        /// </summary>
        public IWrappedQueryClient QueryManager { get; }
        public IWrappedHealthClient HealthManager { get; }

        /// <inheritdoc />
        /// <summary>
        /// Disposes of the fabric client.
        /// </summary>
        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
