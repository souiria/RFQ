using System;
using System.Threading.Tasks;
using Common.SF.Infrastructure.PubSub.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using ServiceFabric.PubSubActors;
using ServiceFabric.PubSubActors.Helpers;
using BrokerServiceLocator = Common.SF.Infrastructure.PubSub.Models.BrokerServiceLocator;

namespace Common.SF.Infrastructure.PubSub.Helpers
{
    /// <summary>
    /// Common operations for Actors to become Subscribers
    /// </summary>
    public class SubscriberActorHelper : ISubscriberActorHelper
    {

        private readonly IBrokerActorLocator _brokerServiceLocator;

        public SubscriberActorHelper()
        {
            _brokerServiceLocator = new BrokerServiceLocator(_brokerServiceLocator.ActorProxyFactory);
        }

        public SubscriberActorHelper(IBrokerActorLocator brokerServiceLocator)
        {
            _brokerServiceLocator = brokerServiceLocator;
        }
        #region Type Subscriptions
        /// <summary>
        /// Registers this Actor as a subscriber for messages of type <paramref name="messageType"/> with the <see cref="BrokerService"/>.
        /// </summary>
        /// <returns></returns>
        public async Task RegisterMessageTypeAsync(ActorBase actor, Type messageType, Uri brokerServiceName = null)
        {
            if (messageType == null) throw new ArgumentNullException(nameof(messageType));
            if (actor == null) throw new ArgumentNullException(nameof(actor));
            if (brokerServiceName == null)
            {
                brokerServiceName = await PublisherServiceHelper.DiscoverBrokerServiceNameAsync(_brokerServiceLocator.ActorProxyFactory);
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException("No brokerServiceName was provided or discovered in the current application.");
                }
            }
            var brokerService = await _brokerServiceLocator.GetBrokerServiceForMessageAsync(messageType.Name, brokerServiceName);
            await brokerService.RegisterSubscriberAsync(ActorReference.Get(actor));
        }

        /// <summary>
        /// Unregisters this Actor as a subscriber for messages of type <paramref name="messageType"/> with the <see cref="BrokerService"/>.
        /// </summary>
        /// <returns></returns>
        public async Task UnregisterMessageTypeAsync(ActorBase actor, Type messageType, bool flushQueue,
            Uri brokerServiceName = null)
        {
            if (messageType == null) throw new ArgumentNullException(nameof(messageType));
            if (actor == null) throw new ArgumentNullException(nameof(actor));

            if (brokerServiceName == null)
            {
                brokerServiceName = await PublisherServiceHelper.DiscoverBrokerServiceNameAsync(_brokerServiceLocator.ActorProxyFactory);
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException("No brokerServiceName was provided or discovered in the current application.");
                }
            }
            var brokerService = await _brokerServiceLocator.GetBrokerServiceForMessageAsync(messageType.Name, brokerServiceName);
            await brokerService.UnregisterSubscriberAsync(ActorReference.Get(actor), flushQueue);
        }
#endregion
        /// <summary>
        /// Registers this Actor as a subscriber for messages of type <paramref name="messageType"/> with the <see cref="BrokerService"/>.
        /// </summary>
        /// <returns></returns>
        public async Task RegisterMessageChannelAsync(ActorBase actor, string channel, Uri brokerServiceName = null)
        {
            if (channel == null) throw new ArgumentNullException(nameof(channel));
            if (actor == null) throw new ArgumentNullException(nameof(actor));
            if (brokerServiceName == null)
            {
                brokerServiceName = await PublisherServiceHelper.DiscoverBrokerServiceNameAsync(_brokerServiceLocator.ActorProxyFactory);
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException("No brokerServiceName was provided or discovered in the current application.");
                }
            }
            var brokerService = await _brokerServiceLocator.GetBrokerServiceForMessageAsync(channel, brokerServiceName);
            await brokerService.RegisterSubscriberAsync(ActorReference.Get(actor));
        }

        /// <summary>
        /// Unregisters this Actor as a subscriber for messages of type <paramref name="messageType"/> with the <see cref="BrokerService"/>.
        /// </summary>
        /// <returns></returns>
        public async Task UnregisterMessageChannelAsync(ActorBase actor, string channel, bool flushQueue,
            Uri brokerServiceName = null)
        {
            if (channel == null) throw new ArgumentNullException(nameof(channel));
            if (actor == null) throw new ArgumentNullException(nameof(actor));

            if (brokerServiceName == null)
            {
                brokerServiceName = await PublisherServiceHelper.DiscoverBrokerServiceNameAsync(_brokerServiceLocator.ActorProxyFactory);
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException("No brokerServiceName was provided or discovered in the current application.");
                }
            }
            var brokerService = await _brokerServiceLocator.GetBrokerServiceForMessageAsync(channel, brokerServiceName);
            await brokerService.UnregisterSubscriberAsync(ActorReference.Get(actor), flushQueue);
        }
    }
}
