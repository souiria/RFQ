using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Notifications;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Notifications
{
    public interface ISubscriptions :IService
    {
        /// <summary>
        /// Processes a list of <see cref="SubscriptionChannel"/>s based on the <see cref="CrudOperationType"/>. Channels that are created
        /// as part of this method are also registered to the PubSubActor. Channels that are removed are deactivated but not removed.
        /// </summary>
        /// <param name="objData">A compressed list of <see cref="SubscriptionChannel"/></param>
        /// <returns></returns>
        Task ProcessChannels(byte[] objData);

        /// <summary>
        /// Creates or removes a Create, Update and Delete <see cref="SubscriptionChannel"/> for the passed service
        /// </summary>
        /// <param name="serviceName">The name of the service to create Crud channels for</param>
        /// <param name="operation">The operation to be performed with the created channels</param>
        /// <returns></returns>
        Task CreateCrudChannels(string serviceName, CrudOperationType operation);

        /// <summary>
        /// Gets all the <see cref="SubscriptionChannel"/>s compressed.
        /// </summary>
        /// <returns>All of the <see cref="SubscriptionChannel"/>s compressed</returns>
        Task<byte[]> GetAllChannels();
    }
}
