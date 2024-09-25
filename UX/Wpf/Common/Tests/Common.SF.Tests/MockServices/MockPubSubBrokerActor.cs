using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using ServiceFabric.PubSubActors.Interfaces;
using IBrokerActor = Common.SF.Infrastructure.PubSub.Interfaces.IBrokerActor;
using MessageWrapper = Common.SF.Infrastructure.PubSub.Wrappers.MessageWrapper;

namespace Common.SF.Tests.MockServices
{
    public class MockPubSubBrokerActor : Actor, IBrokerActor
    {
        public string PublishedMessage = null;

        public async Task RegisterSubscriberAsync(ActorReference actor)
        {
            throw new NotImplementedException();
        }

        public async Task UnregisterSubscriberAsync(ActorReference actor, bool flushQueue)
        {
            throw new NotImplementedException();
        }

        public async Task PublishMessageAsync(MessageWrapper message)
        {
            PublishedMessage = message.Channel;
        }

        public async Task UnregisterServiceSubscriberAsync(ServiceReference actor, bool flushQueue)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterServiceSubscriberAsync(ServiceReference service)
        {
            //Do a thing
        }

        public MockPubSubBrokerActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
        }
    }
}
