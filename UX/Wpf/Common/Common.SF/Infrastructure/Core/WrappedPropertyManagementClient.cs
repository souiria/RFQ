using System;
using System.Fabric;
using System.Threading.Tasks;

namespace Common.SF.Infrastructure.Core
{
    public interface IWrappedPropertyManagementClient
    {
        Task PutPropertyAsync(Uri parentName, string propertyName, string value);
    }

    internal sealed class WrappedPropertyManagementClient : Wrapped<FabricClient.PropertyManagementClient>, IWrappedPropertyManagementClient
    {
        internal WrappedPropertyManagementClient(FabricClient.PropertyManagementClient client) : base(client) { }

        public Task PutPropertyAsync(Uri parentName, string propertyName, string value) =>
            Value.PutPropertyAsync(parentName, propertyName, value);
    }
}
