using System;
using System.Threading.Tasks;
using Common.SF.Infrastructure.PubSub.Interfaces;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Services.Runtime;
using ServiceFabric.PubSubActors;
using BrokerServiceLocator = Common.SF.Infrastructure.PubSub.Models.BrokerServiceLocator;
using MessageWrapper = Common.SF.Infrastructure.PubSub.Wrappers.MessageWrapper;

namespace Common.SF.Infrastructure.PubSub.Helpers
{
    public class PublisherServiceHelper /*: IPublisherServiceHelper*/
    {
        private readonly IBrokerActorLocator _brokerServiceLocator;

        //public PublisherServiceHelper()
        //{
        //    _brokerServiceLocator = new BrokerServiceLocator(ActorProxyFactory);
        //}

        public PublisherServiceHelper(IBrokerActorLocator brokerServiceLocator)
        {
            _brokerServiceLocator = brokerServiceLocator;
        }

        /// <summary>
        /// Publish a message.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="message"></param>
        /// <param name="channel"></param>
        /// <param name="brokerServiceName">The name of a SF Service of type <see cref="BrokerService"/>.</param>
        /// <returns></returns>
        public async Task PublishMessageAsync(StatelessService service, object message, string channel,
            Uri brokerServiceName = null)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (brokerServiceName == null)
            {
                brokerServiceName = await DiscoverBrokerServiceNameAsync(_brokerServiceLocator.ActorProxyFactory);
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException(
                        "No brokerServiceName was provided or discovered in the current application.");
                }
            }

            var brokerService = await _brokerServiceLocator.GetBrokerServiceForMessageAsync(channel, brokerServiceName);
            var wrapper = MessageWrapper.CreateMessageWrapper(message, channel);
            await brokerService.PublishMessageAsync(wrapper);
        }

        /// <summary>
        /// Publish a message.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="message"></param>
        /// <param name="channel"></param>
        /// <param name="brokerServiceName">The name of a SF Service of type <see cref="BrokerService"/>.</param>
        /// <returns></returns>
        public async Task PublishMessageAsync(StatefulServiceBase service, object message, string channel,
            Uri brokerServiceName = null)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (brokerServiceName == null)
            {
                brokerServiceName = await DiscoverBrokerServiceNameAsync(_brokerServiceLocator.ActorProxyFactory);
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException(
                        "No brokerServiceName was provided or discovered in the current application.");
                }
            }

            var brokerService = await _brokerServiceLocator.GetBrokerServiceForMessageAsync(channel, brokerServiceName);
            var wrapper = MessageWrapper.CreateMessageWrapper(message, channel);
            await brokerService.PublishMessageAsync(wrapper);
        }

        /// <summary>
        /// Attempts to discover the <see cref="BrokerService"/> running in this Application.
        /// </summary>
        /// <returns></returns>
        public static Task<Uri> DiscoverBrokerServiceNameAsync(IActorProxyFactory actorProxyFactory)
        {
            var locator = new BrokerServiceLocator(actorProxyFactory);
            return locator.LocateAsync();
        }
    }
}
