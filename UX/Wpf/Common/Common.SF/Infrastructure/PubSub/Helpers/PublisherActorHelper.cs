using System;
using System.Threading.Tasks;
using Common.SF.Infrastructure.PubSub.Interfaces;
using Common.SF.Infrastructure.PubSub.Wrappers;
using Microsoft.ServiceFabric.Actors.Runtime;
using ServiceFabric.PubSubActors;

namespace Common.SF.Infrastructure.PubSub.Helpers
{
    /// <summary>
    /// Common operations of <see cref="ServiceFabric.PubSubActors.PublisherActors"/>
    /// </summary>
    public class PublisherActorHelper /*: IPublisherActorHelper*/
    {
        private readonly IBrokerActorLocator _brokerServiceLocator;

        //public PublisherActorHelper()
        //{
        //    _brokerServiceLocator = new BrokerServiceLocator(ActorProxyFactory);
        //}

        public PublisherActorHelper(IBrokerActorLocator brokerServiceLocator)
        {
            _brokerServiceLocator = brokerServiceLocator;
        }

        /// <summary>
        /// Publish a message.
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="message"></param>
        /// <param name="channel"></param>
        /// <param name="brokerServiceName">The name of the SF Service of type <see cref="BrokerService"/>.</param>
        /// <returns></returns>
        public async Task PublishMessageAsync(ActorBase actor, object message, string channel,
            Uri brokerServiceName = null)
        {
            if (actor == null) throw new ArgumentNullException(nameof(actor));
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (brokerServiceName == null)
            {
                brokerServiceName = await PublisherServiceHelper.DiscoverBrokerServiceNameAsync(_brokerServiceLocator.ActorProxyFactory);
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException("No brokerServiceName was provided or discovered in the current application.");
                }
            }

            var brokerService = await _brokerServiceLocator.GetBrokerServiceForMessageAsync(channel, brokerServiceName);
            var wrapper = MessageWrapper.CreateMessageWrapper(message, channel);
            await brokerService.PublishMessageAsync(wrapper);
        }
    }
}
