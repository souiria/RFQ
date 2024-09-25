using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using ServiceFabric.PubSubActors.Interfaces;
using MessageWrapper = Common.SF.Infrastructure.PubSub.Wrappers.MessageWrapper;

namespace Common.SF.Infrastructure.PubSub.Interfaces
{
    public interface IBrokerActor : IActor
    {
        /// <summary>
        /// Registers an Actor as a subscriber for messages.
        /// </summary>
        /// <param name="actor">Reference to the actor to register.</param>
        Task RegisterSubscriberAsync(ActorReference actor);

        /// <summary>
        /// Unregisters an Actor as a subscriber for messages.
        /// </summary>
        /// <param name="actor">Reference to the actor to unregister.</param>
        /// <param name="flushQueue">Publish any remaining messages.</param>
        Task UnregisterSubscriberAsync(ActorReference actor, bool flushQueue);

        /// <summary>
        /// Registers a service as a subscriber for messages.
        /// </summary>
        /// <param name="service">Reference to the actor to register.</param>
        Task RegisterServiceSubscriberAsync(ServiceReference service);

        /// <summary>
        /// Unregisters a service as a subscriber for messages.
        /// </summary>
        /// <param name="actor">Reference to the actor to unregister.</param>
        /// <param name="flushQueue">Publish any remaining messages.</param>
        Task UnregisterServiceSubscriberAsync(ServiceReference actor, bool flushQueue);

        /// <summary>
        /// Takes a published message and forwards it (indirectly) to all Subscribers.
        /// </summary>
        /// <param name="message">The message to publish</param>
        /// <returns></returns>
        Task PublishMessageAsync(MessageWrapper message);
    }
}
