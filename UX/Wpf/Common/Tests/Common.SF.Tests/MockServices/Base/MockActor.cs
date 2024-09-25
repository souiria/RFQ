using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.SF.Contracts.Interfaces.Core;
using Common.SF.Contracts.Interfaces.Core.Logging;
using Common.SF.Contracts.Interfaces.Core.Notifications;
using Common.SF.Infrastructure.Base;
using Common.SF.Infrastructure.PubSub.Helpers;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace Common.SF.Tests.MockServices.Base
{
    internal class MockActor : ActorServiceBase
    {
        public MockActor(ActorService actorService, ActorId actorId, IServiceProxyFactory proxyFactory) : base(actorService, actorId, proxyFactory) { }
        public IUtilities MockUtilityProxy => UtilityProxy;
        public ILogging MockLogging => Logging;
        public ISubscriptions MockSubscriptions => Subscriptions;
        public PublisherActorHelper MockPublisherActorHelper => PublisherActorHelper;
        public SubscriberActorHelper MockSubscriberActorHelper => SubscriberActorHelper;
    }
}
