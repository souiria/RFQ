using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Services.Client;
using ServiceFabric.PubSubActors;

namespace Common.SF.Infrastructure.PubSub.Interfaces
{
    public interface IBrokerActorLocator
    {
        IActorProxyFactory ActorProxyFactory { get; }

        /// <summary>
        /// Locates the registered broker service.
        /// </summary>
        /// <returns></returns>
        Task<Uri> LocateAsync();

        ///// <summary>
        ///// Registers the default <see cref="BrokerServiceBase"/> by name.
        ///// </summary>
        ///// <param name="brokerServiceName"></param>
        ///// <returns></returns>
        //Task RegisterAsync(Uri brokerServiceName);
        ///// <summary>
        ///// Resolves the <see cref="ServicePartitionKey"/> to send the message to, based on message type.
        ///// </summary>
        ///// <param name="message">The message to publish</param>
        ///// <param name="brokerServiceName"></param>
        ///// <returns></returns>
        //Task<ServicePartitionKey> GetPartitionForMessageAsync(object message, Uri brokerServiceName);
        ///// <summary>
        ///// Gets the <see cref="IBrokerService"/> instance for the provided <paramref name="message"/>
        ///// </summary>
        ///// <param name="message"></param>
        ///// <param name="brokerServiceName">Uri of BrokerService instance</param>
        ///// <returns></returns>
        //Task<IBrokerActor> GetBrokerServiceForMessageAsync(object message, Uri brokerServiceName);

        /// <summary>
        /// Gets the <see cref="IBrokerService"/> instance for the provided <paramref name="messageTypeName"/>
        /// </summary>
        /// <param name="messageTypeName">Full type name of message object.</param>
        /// <param name="brokerServiceName">Uri of BrokerService instance</param>
        /// <returns></returns>
        Task<IBrokerActor> GetBrokerServiceForMessageAsync(string messageTypeName, Uri brokerServiceName);
    }
}
