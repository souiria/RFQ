using System;
using System.Threading.Tasks;
using Common.SF.Tests.MockHelpers;
using Common.SF.Tests.MockServices;
using Microsoft.ServiceFabric.Actors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceFabric.Mocks;

namespace Common.SF.Tests.Infrastructure.Base
{
    [TestClass]
    public class ActorServiceBaseTests
    {
        [TestMethod]
        public async Task Constructor_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
            mockHelper.RegisterMockService(await utilities.InitializeLogging(), new MockLogging());
            mockHelper.RegisterMockService(await utilities.InitializeNotifications(), new MockNotifications());

            var actor = mockHelper.CreateActor(ActorId.CreateRandom());

            Assert.IsNotNull(actor.MockPublisherActorHelper);
            Assert.IsNotNull(actor.MockSubscriberActorHelper);
        }

        [TestMethod]
        public async Task OnActivateAsync_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
            mockHelper.RegisterMockService(await utilities.InitializeLogging(), new MockLogging());
            mockHelper.RegisterMockService(await utilities.InitializeNotifications(), new MockNotifications());

            var actor = mockHelper.CreateActor(ActorId.CreateRandom());
            await actor.InvokeOnActivateAsync();

            Assert.IsNotNull(actor.MockUtilityProxy);
            Assert.IsNotNull(actor.MockLogging);
            Assert.IsNotNull(actor.MockSubscriptions);
        }
    }
}
