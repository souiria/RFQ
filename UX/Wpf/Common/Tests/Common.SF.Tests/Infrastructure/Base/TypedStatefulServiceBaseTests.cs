using System;
using System.Fabric.Health;
using System.Threading;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;
using Common.SF.Infrastructure.Base.Commercial;
using Common.SF.Infrastructure.Core;
using Common.SF.Tests.MockHelpers;
using Common.SF.Tests.MockServices;
using Common.SF.Tests.MockServices.Base;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceFabric.Mocks;

namespace Common.SF.Tests.Infrastructure.Base
{
    public partial class StatefulServiceBaseTests
    {
        [TestMethod]
        public async Task Subscriptions_IsNotNull()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
            mockHelper.RegisterMockService(await utilities.InitializeNotifications(), new MockNotifications());

            var stateful = mockHelper.CreateStateful<BaseModelTestObject>();

            Assert.IsNotNull(stateful.Subscriptions);
        }

        [TestMethod]
        public async Task ServiceDataFilter_IsNotNull()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
            mockHelper.RegisterMockService(await utilities.InitializeDataFilter(), new MockServiceDataFilter());

            var stateful = mockHelper.CreateStateful<BaseModelTestObject>();

            Assert.IsNotNull(stateful.ServiceDataFilter);
        }

        [TestMethod]
        public async Task RegisterCRUDChannels_When1stParamIsTrue_CallsCreateCrudChannels()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            var notifications = new MockNotifications();
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
            mockHelper.RegisterMockService(await utilities.InitializeNotifications(), notifications);

            var stateful = mockHelper.CreateStateful<BaseModelTestObject>();
            await stateful.RegisterCRUDChannels(true);
            Assert.IsNotNull(notifications.CreateCrudChannelsWasCalled);
            Assert.AreEqual(CrudOperationType.Create, notifications.CreateCrudChannelsWasCalled);
        }

        [TestMethod]
        public async Task RegisterCRUDChannels_When1stParamIsFalse_CallsCreateCrudChannels()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            var notifications = new MockNotifications();
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
            mockHelper.RegisterMockService(await utilities.InitializeNotifications(), notifications);

            var stateful = mockHelper.CreateStateful<BaseModelTestObject>();
            await stateful.RegisterCRUDChannels(false);
            Assert.IsNotNull(notifications.CreateCrudChannelsWasCalled);
            Assert.AreEqual(CrudOperationType.Delete, notifications.CreateCrudChannelsWasCalled);
        }

        [TestMethod]
        public async Task NotificationQueue_LoopsSuccessfully()
        {
            var mockHelper = new MockServiceManager();
            var stateful = new PrivateObject(mockHelper.CreateStateful<BaseModelTestObject>(), new PrivateType(typeof(StatefulServiceBase<BaseModelTestObject>)));
            var cts = new CancellationTokenSource();
            var task = (Task)stateful.Invoke("NotificationQueue", cts.Token);
            await Task.Delay(TimeSpan.FromMilliseconds(1200), cts.Token);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCompleted);
            cts.Cancel();
            Assert.IsTrue(task.IsCanceled);
        }

        [TestMethod]
        public async Task NotificationQueue_PublishesNotification()
        {
            var mockHelper = new MockServiceManager();
            const string expectedPublishChannel = "MockStatefulServiceCreateChannel";
            var pubSubActor = mockHelper.RegisterMockActorService<MockPubSubBrokerActor>(new Uri("fabric:/Core.Framework/SF.Core.PubSubBrokerActor"), new ActorId(expectedPublishChannel));
            var stateManager = new MockReliableStateManager();
            var stateful = new PrivateObject(mockHelper.CreateStateful<BaseModelTestObject>(stateManager), new PrivateType(typeof(StatefulServiceBase<BaseModelTestObject>)));
            var queue = await stateManager.GetOrAddAsync<IReliableQueue<BaseModelTestObject>>(MockStateful<BaseModelTestObject>._notificationQueue);
            using (var tx = stateManager.CreateTransaction())
            {
                await queue.EnqueueAsync(tx, new BaseModelTestObject { CrudOperationType = CrudOperationType.Create });
                await tx.CommitAsync();
            }

            var cts = new CancellationTokenSource();
            var task = (Task)stateful.Invoke("NotificationQueue", cts.Token);
            await Task.Delay(TimeSpan.FromMilliseconds(1200), cts.Token);
            cts.Cancel();
            Assert.IsTrue(task.IsCanceled);
            Assert.AreEqual(expectedPublishChannel, pubSubActor.PublishedMessage);
        }

        [TestMethod]
        public async Task NotificationQueue_WhenQueueObjectIsNull_DisplaysWarning()
        {
            var mockHelper = new MockServiceManager();
            var expectedPublishChannel = "MockStatefulServiceCreateChannel";
            var pubSubActor = mockHelper.RegisterMockActorService<MockPubSubBrokerActor>(new Uri("fabric:/Core.Framework/SF.Core.PubSubBrokerActor"), new ActorId(expectedPublishChannel));

            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful<BaseModelTestObject>(stateManager);
            var privateStateful = new PrivateObject(stateful, new PrivateType(typeof(StatefulServiceBase<BaseModelTestObject>)));
            var queue = await stateManager.GetOrAddAsync<IReliableQueue<BaseModelTestObject>>(MockStateful<BaseModelTestObject>._notificationQueue);
            using (var tx = stateManager.CreateTransaction())
            {
                await queue.EnqueueAsync(tx, null);
                await tx.CommitAsync();
            }

            var cts = new CancellationTokenSource();
            var task = (Task)privateStateful.Invoke("NotificationQueue", cts.Token);
            await Task.Delay(TimeSpan.FromMilliseconds(1200), cts.Token);
            cts.Cancel();

            var serviceHealth = await FabricClientProvider.FabricClient.HealthManager.GetServiceHealthAsync(stateful.Context.ServiceName);

            Assert.IsTrue(task.IsCanceled);
            Assert.AreEqual(HealthState.Warning, serviceHealth.AggregatedHealthState);
        }

        //TODO: Re-implement audit unit tests when one the audit process is understood and accurate unit tests can be made.

        //[TestMethod]
        //public async Task AuditQueue_LoopsSuccessfully()
        //{
        //    var mockHelper = new MockServiceManager();
        //    var stateful = new PrivateObject(mockHelper.CreateStateful<BaseModelTestObject>(), new PrivateType(typeof(StatefulServiceBase<BaseModelTestObject>)));
        //    var cts = new CancellationTokenSource();
        //    var task = (Task)stateful.Invoke("AuditQueue", cts.Token);
        //    await Task.Delay(TimeSpan.FromMilliseconds(1200), cts.Token);
        //    Assert.IsFalse(task.IsFaulted);
        //    Assert.IsFalse(task.IsCompleted);
        //    cts.Cancel();
        //    Assert.IsTrue(task.IsCanceled);
        //}

        //[TestMethod]
        //public async Task AuditQueue_Create_LogsAudit()
        //{
        //    var mockHelper = new MockServiceManager();
        //    var utilities = new MockUtilities();
        //    var logging = new MockLogging();
        //    mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
        //    mockHelper.RegisterMockService(await utilities.InitializeLogging(), logging);
        //    var stateManager = new MockReliableStateManager();
        //    var stateful = new PrivateObject(mockHelper.CreateStateful<BaseModelTestObject>(stateManager), new PrivateType(typeof(StatefulServiceBase<BaseModelTestObject>)));

        //    var testObject = new BaseModelTestObject { CrudOperationType = CrudOperationType.Create };
        //    var dictionary =
        //        await stateManager.GetOrAddAsync<IReliableDictionary<Guid, BaseModelTestObject>>(
        //            $"{MockStateful<BaseModelTestObject>._cacheName}_{testObject.Id.ToDictionaryKey()}");
        //    var queue = await stateManager.GetOrAddAsync<IReliableQueue<BaseModelTestObject>>(MockStateful<BaseModelTestObject>._auditQueue);
        //    using (var tx = stateManager.CreateTransaction())
        //    {
        //        await dictionary.AddAsync(tx, testObject.Id, testObject);
        //        await queue.EnqueueAsync(tx, testObject);
        //        await tx.CommitAsync();
        //    }

        //    var cts = new CancellationTokenSource();
        //    var task = (Task)stateful.Invoke("AuditQueue", cts.Token);
        //    await Task.Delay(TimeSpan.FromMilliseconds(1200), cts.Token);
        //    cts.Cancel();
        //    Assert.IsTrue(task.IsCanceled);
        //    Assert.IsTrue(logging.ProcessAuditsCalled);
        //}

        //[TestMethod]
        //public async Task AuditQueue_Update_LogsAudit()
        //{
        //    var mockHelper = new MockServiceManager();
        //    var utilities = new MockUtilities();
        //    var logging = new MockLogging();
        //    mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
        //    mockHelper.RegisterMockService(await utilities.InitializeLogging(), logging);
        //    var stateManager = new MockReliableStateManager();
        //    var stateful = new PrivateObject(mockHelper.CreateStateful<BaseModelTestObject>(stateManager), new PrivateType(typeof(StatefulServiceBase<BaseModelTestObject>)));

        //    var id = Guid.NewGuid();
        //    var testObjectBefore = new BaseModelTestObject { Id = id, CrudOperationType = CrudOperationType.Update, Name = "Cat" };
        //    var testObjectAfter = new BaseModelTestObject { Id = id, CrudOperationType = CrudOperationType.Update, Name = "Dog" };
        //    var dictionary =
        //        await stateManager.GetOrAddAsync<IReliableDictionary<Guid, BaseModelTestObject>>(
        //            $"{MockStateful<BaseModelTestObject>._cacheName}_{testObjectAfter.Id.ToDictionaryKey()}");
        //    var queue = await stateManager.GetOrAddAsync<IReliableQueue<BaseModelTestObject>>(MockStateful<BaseModelTestObject>._auditQueue);
        //    using (var tx = stateManager.CreateTransaction())
        //    {
        //        await dictionary.AddAsync(tx, testObjectAfter.Id, testObjectAfter);
        //        await queue.EnqueueAsync(tx, testObjectBefore);
        //        await tx.CommitAsync();
        //    }

        //    var cts = new CancellationTokenSource();
        //    var task = (Task)stateful.Invoke("AuditQueue", cts.Token);
        //    await Task.Delay(TimeSpan.FromMilliseconds(1200), cts.Token);
        //    cts.Cancel();
        //    Assert.IsTrue(task.IsCanceled);
        //    Assert.IsTrue(logging.ProcessAuditsCalled);
        //}

        //[TestMethod]
        //public async Task AuditQueue_WhenQueueObjectIsNull_DisplaysWarning()
        //{
        //    var mockHelper = new MockServiceManager();
        //    var expectedPublishChannel = "MockStatefulServiceCreateChannel";
        //    var pubSubActor = mockHelper.RegisterMockActorService<MockPubSubBrokerActor>(new Uri("fabric:/Core.Framework/SF.Core.PubSubBrokerActor"), new ActorId(expectedPublishChannel));

        //    var stateManager = new MockReliableStateManager();
        //    var stateful = mockHelper.CreateStateful<BaseModelTestObject>(stateManager);
        //    var privateStateful = new PrivateObject(stateful, new PrivateType(typeof(StatefulServiceBase<BaseModelTestObject>)));
        //    var queue = await stateManager.GetOrAddAsync<IReliableQueue<BaseModelTestObject>>(MockStateful<BaseModelTestObject>._auditQueue);
        //    using (var tx = stateManager.CreateTransaction())
        //    {
        //        await queue.EnqueueAsync(tx, null);
        //        await tx.CommitAsync();
        //    }

        //    var cts = new CancellationTokenSource();
        //    var task = (Task)privateStateful.Invoke("AuditQueue", cts.Token);
        //    await Task.Delay(TimeSpan.FromMilliseconds(1200), cts.Token);
        //    cts.Cancel();

        //    var serviceHealth = await FabricClientProvider.FabricClient.HealthManager.GetServiceHealthAsync(stateful.Context.ServiceName);

        //    Assert.IsTrue(task.IsCanceled);
        //    Assert.AreEqual(HealthState.Warning, serviceHealth.AggregatedHealthState);
        //}


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task EnqueueAuditLoggingItem_WhenModelIsNull_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful<BaseModelTestObject>();
            var privateStateful = new PrivateObject(stateful, new PrivateType(typeof(StatefulServiceBase<BaseModelTestObject>)));
            stateful.IsAuditLoggingEnabled = true;
            await (Task)privateStateful.Invoke("EnqueueAuditLoggingItem", (BaseModelTestObject)null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task EnqueueAuditLoggingItem_WhenModelIsNotUpdate_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful<BaseModelTestObject>();
            var privateStateful = new PrivateObject(stateful, new PrivateType(typeof(StatefulServiceBase<BaseModelTestObject>)));
            stateful.IsAuditLoggingEnabled = true;
            await (Task)privateStateful.Invoke("EnqueueAuditLoggingItem", (BaseModelTestObject)null);
        }
    }

}
