using System;
using System.Fabric;
using System.Threading.Tasks;

namespace Common.SF.Infrastructure.Core
{
    public interface IWrappedQueryClient
    {
        Task<IWrappedServicePartitionList> GetPartitionListAsync(Uri serviceName);
        Task<IWrappedApplicationList> GetApplicationListAsync();
        Task<IWrappedServiceList> GetServiceListAsync(Uri applicationName);
    }

    internal class WrappedQueryClient : Wrapped<FabricClient.QueryClient>, IWrappedQueryClient
    {
        public WrappedQueryClient(FabricClient.QueryClient client) : base(client) { }

        public async Task<IWrappedServicePartitionList> GetPartitionListAsync(Uri serviceName)
        {
            return new WrappedServicePartitionList(await Value.GetPartitionListAsync(serviceName));
        }

        public async Task<IWrappedApplicationList> GetApplicationListAsync()
        {
            return new WrappedApplicationList(await Value.GetApplicationListAsync());
        }

        public async Task<IWrappedServiceList> GetServiceListAsync(Uri applicationName)
        {
            return new WrappedServiceList(await Value.GetServiceListAsync(applicationName));
        }
    }
}
