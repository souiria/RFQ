using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Health;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.Core.Settings.Commercial;
using Common.SF.Infrastructure.Core;
using Common.SF.Infrastructure.PubSub.Wrappers;
using Common.SF.Tests.MockHelpers;
using Common.SF.Tests.MockServices;
using Common.SF.Tests.MockServices.Base;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ServiceFabric.Mocks;

namespace Common.SF.Tests.Infrastructure.Base
{
    internal class TestObject
    {
        internal string Name { get; set; }
        internal string Desc { get; set; }
    }

    internal class BaseModelTestObject : BaseModel<Guid>
    {
        public string Detail { get; set; }
    }

    [TestClass]
    public partial class StatefulServiceBaseTests
    {
        [TestMethod]
        public async Task RunAsync_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            var serviceConfiguration = new MockServiceConfiguration();
            serviceConfiguration.RegisterReturnValue(() => new List<ServiceConfig>());
            mockHelper.RegisterMockActorService<MockPubSubBrokerActor>(new Uri("fabric:/Core.Framework/SF.Core.PubSubBrokerActor"), new ActorId("SettingsUpdate: MockStatefulService"));
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
            mockHelper.RegisterMockService(await utilities.InitializeLogging(), new MockLogging());
            mockHelper.RegisterMockService(await utilities.InitializeNotifications(), new MockNotifications());
            mockHelper.RegisterMockService(await utilities.InitializeServiceConfiguration(), serviceConfiguration);

            var stateful = mockHelper.CreateStateful();
            var cts = new CancellationTokenSource();
            await stateful.InvokeRunAsync(cts.Token);
        }

        [TestMethod]
        public async Task GetUtilities_IsNotNull()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);

            var stateful = mockHelper.CreateStateful();

            Assert.IsNotNull(stateful.UtilityProxy);
        }

        [TestMethod]
        public async Task GetLogging_IsNotNull()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
            mockHelper.RegisterMockService(await utilities.InitializeLogging(), new MockLogging());

            var stateful = mockHelper.CreateStateful();

            Assert.IsNotNull(stateful.Logging);
        }

        [TestMethod]
        public async Task GetServiceConfiguration_IsNotNull()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
            mockHelper.RegisterMockService(await utilities.InitializeServiceConfiguration(), new MockServiceConfiguration());

            var stateful = mockHelper.CreateStateful();

            Assert.IsNotNull(stateful.ServiceConfiguration);
        }

        [TestMethod]
        public void GetPublisherServiceHelper_IsNotNull()
        {
            var mockHelper = new MockServiceManager();

            var stateful = mockHelper.CreateStateful();

            Assert.IsNotNull(stateful.PublisherServiceHelper);
        }

        [TestMethod]
        public void GetSubscriberServiceHelper_IsNotNull()
        {
            var mockHelper = new MockServiceManager();

            var stateful = mockHelper.CreateStateful();

            Assert.IsNotNull(stateful.SubscriberServiceHelper);
        }

        [TestMethod]
        public async Task UpdateSettings_SettingsUpdated()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var serviceConfig = new ServiceConfig
            {
                IsEnabled = true,
                IsEnabledParameterName = "EnabledTestSetting",
                Value = "NewValue",
                ValueType = ConfigType.All,
                ValueParameterName = "StringTestSetting"
            };
            var settings = new List<ServiceConfig> { serviceConfig };

            await stateful.UpdateSettings(settings);

            Assert.AreEqual("NewValue", stateful.StringTestSetting);
            Assert.AreEqual(true, stateful.EnabledTestSetting);
        }

        [TestMethod]
        public async Task UpdateSettings_WhenValueParameterNameIsNull_SettingsNotUpdated()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var serviceConfig = new ServiceConfig
            {
                IsEnabled = true,
                IsEnabledParameterName = "EnabledTestSetting",
                Value = "NewValue",
                ValueType = ConfigType.All,
                ValueParameterName = null
            };
            var settings = new List<ServiceConfig> { serviceConfig };

            await stateful.UpdateSettings(settings);

            Assert.AreNotEqual(serviceConfig.Value, stateful.StringTestSetting);
        }

        [TestMethod]
        public async Task UpdateSettings_WhenValueParameterNameDoesNotExist_SettingsNotUpdated()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var serviceConfig = new ServiceConfig
            {
                IsEnabled = true,
                IsEnabledParameterName = "EnabledTestSetting",
                Value = "NewValue",
                ValueType = ConfigType.All,
                ValueParameterName = "NotStringTestSetting"
            };
            var settings = new List<ServiceConfig> { serviceConfig };

            await stateful.UpdateSettings(settings);

            Assert.AreNotEqual(serviceConfig.Value, stateful.StringTestSetting);
        }

        [TestMethod]
        public async Task UpdateSettings_WhenValueIsNull_SettingsNotUpdated()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var serviceConfig = new ServiceConfig
            {
                IsEnabled = true,
                IsEnabledParameterName = "EnabledTestSetting",
                Value = null,
                ValueType = ConfigType.All,
                ValueParameterName = "StringTestSetting"
            };
            var settings = new List<ServiceConfig> { serviceConfig };

            await stateful.UpdateSettings(settings);

            Assert.AreNotEqual(serviceConfig.Value, stateful.StringTestSetting);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task UpdateSettings_WhenPropertyHasNoSetter_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var serviceConfig = new ServiceConfig
            {
                IsEnabled = true,
                IsEnabledParameterName = "EnabledTestSetting",
                Value = "NewValue",
                ValueType = ConfigType.All,
                ValueParameterName = "StringWithoutSetterTestSetting"
            };
            var settings = new List<ServiceConfig> { serviceConfig };

            await stateful.UpdateSettings(settings);

            Assert.Fail();
        }

        [TestMethod]
        public async Task UpdateSettings_WhenPropertyIsPrivate_SettingUpdated()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var serviceConfig = new ServiceConfig
            {
                IsEnabled = true,
                IsEnabledParameterName = "EnabledTestSetting",
                Value = "NewValue",
                ValueType = ConfigType.All,
                ValueParameterName = "PrivateStringTestSetting"
            };
            var settings = new List<ServiceConfig> { serviceConfig };

            await stateful.UpdateSettings(settings);

            Assert.AreEqual("NewValue", stateful.GetPrivateStringSetting);
        }

        [TestMethod]
        public async Task UpdateSettings_WhenSettingIsField_SettingNotUpdated()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var serviceConfig = new ServiceConfig
            {
                IsEnabled = true,
                IsEnabledParameterName = "EnabledTestSetting",
                Value = "NewValue",
                ValueType = ConfigType.All,
                ValueParameterName = "FieldStringTestSetting"
            };
            var settings = new List<ServiceConfig> { serviceConfig };

            await stateful.UpdateSettings(settings);

            Assert.AreNotEqual("NewValue", stateful.FieldStringTestSetting);
        }

        [TestMethod]
        public async Task UpdateSettings_WhenValueTypeIsNumber_WhenValueCannotBeParsed_SettingsNotUpdated()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var beforeTest = stateful.NumberTestSetting;
            var serviceConfig = new ServiceConfig
            {
                IsEnabled = true,
                IsEnabledParameterName = "EnabledTestSetting",
                Value = "dog",
                ValueType = ConfigType.Numbers,
                ValueParameterName = "NumberTestSetting"
            };
            var settings = new List<ServiceConfig> { serviceConfig };

            await stateful.UpdateSettings(settings);

            Assert.AreEqual(beforeTest, stateful.NumberTestSetting);
        }

        [TestMethod]
        public async Task UpdateSettings_WhenValueTypeIsNumber_SettingUpdated()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var serviceConfig = new ServiceConfig
            {
                IsEnabled = true,
                IsEnabledParameterName = "EnabledTestSetting",
                Value = "44",
                ValueType = ConfigType.Numbers,
                ValueParameterName = "NumberTestSetting"
            };
            var settings = new List<ServiceConfig> { serviceConfig };

            await stateful.UpdateSettings(settings);

            Assert.AreEqual(44, stateful.NumberTestSetting);
        }

        [TestMethod]
        public async Task UpdateSettings_WhenIsEnabledParameterNameIsNull_SettingNotUpdated()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var serviceConfig = new ServiceConfig
            {
                IsEnabled = true,
                IsEnabledParameterName = null,
                Value = "NewValue",
                ValueType = ConfigType.All,
                ValueParameterName = "StringTestSetting"
            };
            var settings = new List<ServiceConfig> { serviceConfig };

            await stateful.UpdateSettings(settings);

            Assert.AreNotEqual(true, stateful.EnabledTestSetting);
        }

        [TestMethod]
        public async Task UpdateSettings_WhenIsEnabledParameterNameDoesNotExist_SettingNotUpdated()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var serviceConfig = new ServiceConfig
            {
                IsEnabled = true,
                IsEnabledParameterName = "NotEnabledTestSetting",
                Value = "NewValue",
                ValueType = ConfigType.All,
                ValueParameterName = "StringTestSetting"
            };
            var settings = new List<ServiceConfig> { serviceConfig };

            await stateful.UpdateSettings(settings);

            Assert.AreNotEqual(true, stateful.EnabledTestSetting);
        }

        [TestMethod]
        public async Task ReceiveMessageAsync_WhenChannelIsSettingsUpdate_UpdateSettings()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var setting = new ServiceConfig
            {
                IsEnabled = true,
                IsEnabledParameterName = "EnabledTestSetting",
                Value = "NewValue",
                ValueType = ConfigType.All,
                ValueParameterName = "StringTestSetting"
            };
            var message = new MessageWrapper
            {
                Channel = "SettingsUpdate: MockStateful",
                Payload = JsonConvert.SerializeObject(setting)
            };

            await stateful.ReceiveMessageAsync(message);

            Assert.AreEqual("NewValue", stateful.StringTestSetting);
            Assert.AreEqual(true, stateful.EnabledTestSetting);
        }

        [TestMethod]
        public async Task ReceiveMessageAsync_NotificationReceived()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var message = new MessageWrapper
            {
                Channel = "OtherChannel",
            };

            await stateful.ReceiveMessageAsync(message);
            Assert.IsTrue(stateful.NotificationReceivedCalled);
        }

        [TestMethod]
        public async Task LogException_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            var logging = new MockLogging();
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
            mockHelper.RegisterMockService(await utilities.InitializeLogging(), logging);
            var stateful = mockHelper.CreateStateful();

            try
            {
                throw new ArgumentOutOfRangeException("Param");
            }
            catch (Exception ex)
            {
                await stateful.LogException(ex);
            }


            Assert.IsTrue(logging.ExceptionReceived);
        }

        [TestMethod]
        public async Task LogException_WhenExceptionIsThrown_DoesNotLogException()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            var logging = new MockLogging();
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
            mockHelper.RegisterMockService(await utilities.InitializeLogging(), logging);
            var stateful = mockHelper.CreateStateful();

            await stateful.LogException(new Exception());

            Assert.IsFalse(logging.ExceptionReceived);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task LogHealthState_String_String_HealthState_When1stParamIsNull_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            await stateful.LogHealthState(null, "Param", HealthState.Error);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task LogHealthState_String_String_HealthState_When2ndParamIsNull_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            await stateful.LogHealthState("MockStateful", null, HealthState.Error);
            Assert.Fail();
        }

        [TestMethod]
        public async Task LogHealthState_String_String_HealthState_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            await stateful.LogHealthState("MockStateful", "Param", HealthState.Error);

            var serviceHealth = await FabricClientProvider.FabricClient.HealthManager.GetServiceHealthAsync(stateful.Context.ServiceName);

            Assert.AreEqual(HealthState.Error, serviceHealth.AggregatedHealthState);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task LogHealthState_String_String_HealthState_TimeSpan_Boolean_When1stParamIsNull_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            await stateful.LogHealthState(null, "Param", HealthState.Error, TimeSpan.MaxValue, true);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task LogHealthState_String_String_HealthState_TimeSpan_Boolean_When2ndParamIsNull_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            await stateful.LogHealthState("MockStateful", null, HealthState.Error, TimeSpan.MaxValue, true);
            Assert.Fail();
        }

        [TestMethod]
        public async Task LogHealthState_String_String_HealthState_TimeSpan_Boolean_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            await stateful.LogHealthState("MockStateful", "Param", HealthState.Error, TimeSpan.MaxValue, true);

            var serviceHealth = await FabricClientProvider.FabricClient.HealthManager.GetServiceHealthAsync(stateful.Context.ServiceName);

            Assert.AreEqual(HealthState.Error, serviceHealth.AggregatedHealthState);
        }

        [TestMethod]
        public void ServiceName_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var expectedServiceName = stateful.Context.ServiceName.Segments[stateful.Context.ServiceName.Segments.Length - 1];
            var serviceName = stateful.ServiceName;

            Assert.AreEqual(expectedServiceName, serviceName);
        }

        [TestMethod]
        public void ServiceProxyFactory_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();

            Assert.IsNotNull(stateful.ServiceProxyFactory);
        }

        [TestMethod]
        public void ActorProxyFactory_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();

            Assert.IsNotNull(stateful.ActorProxyFactory);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Constructor_StatefulServiceContext_IReliableStateManagerReplica_IServiceProxyFactory_IActorProxyFactory_When1stParamIsNull_ThrowsException()
        {
            new MockStateful(null, new ReliableStateManager(null), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_StatefulServiceContext_IReliableStateManagerReplica_IServiceProxyFactory_IActorProxyFactory_When2ndParamIsNull_ThrowsException()
        {
            new MockStateful(MockStatefulServiceContextFactory.Default, null, null);
        }

        [TestMethod]
        public void Constructor_StatefulServiceContext_IReliableStateManagerReplica_IServiceProxyFactory_IActorProxyFactory_IsSuccessful()
        {
            FabricClientProvider.FabricClient = new MockWrappedFabricClient();
            var stateful = new MockStateful(MockStatefulServiceContextFactory.Default, new ReliableStateManager(MockStatefulServiceContextFactory.Default), new MockActorProxyFactory());
            Assert.IsNotNull(stateful);
        }

        [TestMethod]
        public async Task InitializeRetryWrapper_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var cts = new CancellationTokenSource();

            var task = stateful.InitializeRetryWrapper(cts.Token);
            await Task.Delay(TimeSpan.FromMilliseconds(1500), cts.Token);

            Assert.IsTrue(task.IsCompleted);
        }

        [TestMethod]
        public async Task InitializeRetryWrapper_OnFailure_Continues()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            stateful.InitializeMethod = () => throw new Exception();
            var cts = new CancellationTokenSource();

            var task = stateful.InitializeRetryWrapper(cts.Token);
            await Task.Delay(TimeSpan.FromMilliseconds(1500), cts.Token);
            cts.Cancel();

            var serviceHealth = await FabricClientProvider.FabricClient.HealthManager.GetServiceHealthAsync(stateful.Context.ServiceName);

            Assert.IsTrue(task.IsCanceled);
            Assert.AreEqual(HealthState.Warning, serviceHealth.AggregatedHealthState);
        }

        [TestMethod]
        public async Task RegisterSettingsChannel_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            mockHelper.RegisterMockActorService<MockPubSubBrokerActor>(new Uri("fabric:/Core.Framework/SF.Core.PubSubBrokerActor"), new ActorId("SettingsUpdate: MockStatefulService"));
            var stateful = mockHelper.CreateStateful();
            var cts = new CancellationTokenSource();

            var task = stateful.RegisterSettingsChannel(cts.Token);
            await Task.Delay(TimeSpan.FromMilliseconds(1500), cts.Token);

            Assert.IsTrue(task.IsCompleted);
        }

        [TestMethod]
        public async Task RegisterSettingsChannel_OnFailure_Continues()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var cts = new CancellationTokenSource();

            var task = stateful.RegisterSettingsChannel(cts.Token);
            await Task.Delay(TimeSpan.FromMilliseconds(1500), cts.Token);
            cts.Cancel();

            var serviceHealth = await FabricClientProvider.FabricClient.HealthManager.GetServiceHealthAsync(stateful.Context.ServiceName);

            Assert.IsTrue(task.IsCanceled);
            Assert.AreEqual(HealthState.Warning, serviceHealth.AggregatedHealthState);
        }

        [TestMethod]
        public async Task RetrieveServiceSettings_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var utilities = new MockUtilities();
            var serviceConfiguration = new MockServiceConfiguration();
            serviceConfiguration.RegisterReturnValue(() => new List<ServiceConfig>());
            mockHelper.RegisterMockActorService<MockPubSubBrokerActor>(new Uri("fabric:/Core.Framework/SF.Core.PubSubBrokerActor"), new ActorId("SettingsUpdate: MockStatefulService"));
            mockHelper.RegisterMockService(new Uri("fabric:/Core.Framework/SF.Core.Utilities"), utilities);
            mockHelper.RegisterMockService(await utilities.InitializeServiceConfiguration(), serviceConfiguration);

            var stateful = mockHelper.CreateStateful();
            var cts = new CancellationTokenSource();

            var task = stateful.RegisterSettingsChannel(cts.Token);
            await Task.Delay(TimeSpan.FromMilliseconds(1500), cts.Token);

            Assert.IsTrue(task.IsCompleted);
        }

        [TestMethod]
        public async Task RetrieveServiceSettings_OnFailure_Continues()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();
            var cts = new CancellationTokenSource();

            var task = stateful.RegisterSettingsChannel(cts.Token);
            await Task.Delay(TimeSpan.FromMilliseconds(1500), cts.Token);
            cts.Cancel();

            var serviceHealth = await FabricClientProvider.FabricClient.HealthManager.GetServiceHealthAsync(stateful.Context.ServiceName);

            Assert.IsTrue(task.IsCanceled);
            Assert.AreEqual(HealthState.Warning, serviceHealth.AggregatedHealthState);
        }

        [TestMethod]
        public async Task GetAll_When1stParamIsNull_ReturnsEmpty()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            //Expected data
            var newObject = new TestObject { Name = "NewObject" };
            var expectedCollection = new List<TestObject> { newObject };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                await dictionary.TryAddAsync(tx, Guid.NewGuid(), newObject);
                await tx.CommitAsync();
            }

            //Perform test
            var result = (await stateful.GetAll<TestObject>(null)).ToList();

            CollectionAssert.AreNotEqual(expectedCollection, result);
        }

        [TestMethod]
        public async Task GetAll_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            //Expected date
            var newObject = new TestObject { Name = "NewObject" };
            var expectedCollection = new List<TestObject> { newObject };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                await dictionary.TryAddAsync(tx, Guid.NewGuid(), newObject);
                await tx.CommitAsync();
            }

            //Perform test
            var result = (await stateful.GetAll<TestObject>("dictionary")).ToList();

            CollectionAssert.AreEqual(expectedCollection, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Get_When1stParamIsNull_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            //Expected data
            var id = Guid.NewGuid();
            var newObject = new TestObject { Name = "NewObject" };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                await dictionary.TryAddAsync(tx, id, newObject);
                await tx.CommitAsync();
            }

            //Perform test
            await stateful.Get<TestObject>(null, id);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Get_WhenGuidDoesNotExist_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            //Expected data
            var newObject = new TestObject { Name = "NewObject" };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                await dictionary.TryAddAsync(tx, Guid.NewGuid(), newObject);
                await tx.CommitAsync();
            }

            //Perform test
            await stateful.Get<TestObject>("dictionary", Guid.NewGuid());
        }

        [TestMethod]
        public async Task Get_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            //Expected data
            var id = Guid.NewGuid();
            var newObject = new TestObject { Name = "NewObject" };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                await dictionary.TryAddAsync(tx, id, newObject);
                await tx.CommitAsync();
            }

            //Perform test
            var result = await stateful.Get<TestObject>("dictionary", id);

            Assert.AreEqual(newObject, result);
        }

        private static List<TestObject> From(IReadOnlyList<TestObject> source, params int[] indexes)
        {
            return indexes.Select(index => source[index]).ToList();
        }

        [TestMethod]
        public async Task GetByFilter_WhenInternalIsOr_ReturnsFiltered()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            var objects = new List<TestObject>
            {
                new TestObject {Name = "Object1", Desc = "A"},
                new TestObject {Name = "Object2", Desc = "B"},
                new TestObject {Name = "Object3", Desc = "A"},
                new TestObject {Name = "Object4", Desc = "B"},
                new TestObject {Name = "Object1", Desc = "B"},
                new TestObject {Name = "Object2", Desc = "A"},
                new TestObject {Name = "Object3", Desc = "B"},
                new TestObject {Name = "Object4", Desc = "A"},
            };
            var filters = new List<FilterCollectionModel>
            {
                new FilterCollectionModel
                {
                    IsAnd = false,
                    InternalFilterCollection = new List<InternalFilterModel>
                    {
                        new InternalFilterModel
                        {
                            FilterProperty = "Name",
                            FilterValue = "Object1",
                            IsAnd = false
                        },
                        new InternalFilterModel
                        {
                            FilterProperty = "Name",
                            FilterValue = "Object3",
                            IsAnd = false
                        },
                    }
                }
            };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                foreach (var obj in objects)
                {
                    await dictionary.TryAddAsync(tx, Guid.NewGuid(), obj);
                }

                await tx.CommitAsync();
            }

            //Perform test
            var result = (await stateful.GetByFilter<TestObject>("dictionary", filters)).ToList();

            var expectedResult = From(objects, 0, 2, 4, 6);
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public async Task GetByFilter_WhenInternalIsAnd_ReturnsFiltered()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            var objects = new List<TestObject>
            {
                new TestObject {Name = "Object1", Desc = "A"},
                new TestObject {Name = "Object2", Desc = "B"},
                new TestObject {Name = "Object3", Desc = "A"},
                new TestObject {Name = "Object4", Desc = "B"},
                new TestObject {Name = "Object1", Desc = "B"},
                new TestObject {Name = "Object2", Desc = "A"},
                new TestObject {Name = "Object3", Desc = "B"},
                new TestObject {Name = "Object4", Desc = "A"},
            };
            var filters = new List<FilterCollectionModel>
            {
                new FilterCollectionModel
                {
                    IsAnd = false,
                    InternalFilterCollection = new List<InternalFilterModel>
                    {
                        new InternalFilterModel
                        {
                            FilterProperty = "Name",
                            FilterValue = "Object1",
                            IsAnd = false
                        },
                        new InternalFilterModel
                        {
                            FilterProperty = "Desc",
                            FilterValue = "A",
                            IsAnd = true
                        },
                    }
                }
            };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                foreach (var obj in objects)
                {
                    await dictionary.TryAddAsync(tx, Guid.NewGuid(), obj);
                }

                await tx.CommitAsync();
            }

            //Perform test
            var result = (await stateful.GetByFilter<TestObject>("dictionary", filters)).ToList();

            var expectedResult = From(objects, 0);
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public async Task GetByFilter_WhenExternalIsOr_ReturnsFiltered()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            var objects = new List<TestObject>
            {
                new TestObject {Name = "Object1", Desc = "A"},
                new TestObject {Name = "Object2", Desc = "B"},
                new TestObject {Name = "Object3", Desc = "A"},
                new TestObject {Name = "Object4", Desc = "B"},
                new TestObject {Name = "Object1", Desc = "B"},
                new TestObject {Name = "Object2", Desc = "A"},
                new TestObject {Name = "Object3", Desc = "B"},
                new TestObject {Name = "Object4", Desc = "A"},
            };
            var filters = new List<FilterCollectionModel>
            {
                new FilterCollectionModel
                {
                    IsAnd = false,
                    InternalFilterCollection = new List<InternalFilterModel>
                    {
                        new InternalFilterModel
                        {
                            FilterProperty = "Name",
                            FilterValue = "Object1",
                            IsAnd = false
                        }
                    }
                },
                new FilterCollectionModel
                {
                    IsAnd = false,
                    InternalFilterCollection = new List<InternalFilterModel>
                    {
                        new InternalFilterModel
                        {
                            FilterProperty = "Name",
                            FilterValue = "Object3",
                            IsAnd = false
                        }
                    }
                },
            };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                foreach (var obj in objects)
                {
                    await dictionary.TryAddAsync(tx, Guid.NewGuid(), obj);
                }

                await tx.CommitAsync();
            }

            //Perform test
            var result = (await stateful.GetByFilter<TestObject>("dictionary", filters)).ToList();

            var expectedResult = From(objects, 0, 2, 4, 6);
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public async Task GetByFilter_WhenExternalIsAnd_ReturnsFiltered()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            var objects = new List<TestObject>
            {
                new TestObject {Name = "Object1", Desc = "A"},
                new TestObject {Name = "Object2", Desc = "B"},
                new TestObject {Name = "Object3", Desc = "A"},
                new TestObject {Name = "Object4", Desc = "B"},
                new TestObject {Name = "Object1", Desc = "B"},
                new TestObject {Name = "Object2", Desc = "A"},
                new TestObject {Name = "Object3", Desc = "B"},
                new TestObject {Name = "Object4", Desc = "A"},
            };
            var filters = new List<FilterCollectionModel>
            {
                new FilterCollectionModel
                {
                    IsAnd = false,
                    InternalFilterCollection = new List<InternalFilterModel>
                    {
                        new InternalFilterModel
                        {
                            FilterProperty = "Name",
                            FilterValue = "Object1",
                            IsAnd = false
                        }
                    }
                },
                new FilterCollectionModel
                {
                    IsAnd = true,
                    InternalFilterCollection = new List<InternalFilterModel>
                    {
                        new InternalFilterModel
                        {
                            FilterProperty = "Desc",
                            FilterValue = "A",
                            IsAnd = false
                        }
                    }
                },
            };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                foreach (var obj in objects)
                {
                    await dictionary.TryAddAsync(tx, Guid.NewGuid(), obj);
                }

                await tx.CommitAsync();
            }

            //Perform test
            var result = (await stateful.GetByFilter<TestObject>("dictionary", filters)).ToList();

            var expectedResult = From(objects, 0);
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public async Task GetByFilter_MultipleFilters1_ReturnsFiltered()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            var objects = new List<TestObject>
            {
                new TestObject {Name = "Object1", Desc = "A"},
                new TestObject {Name = "Object2", Desc = "B"},
                new TestObject {Name = "Object3", Desc = "A"},
                new TestObject {Name = "Object4", Desc = "B"},
                new TestObject {Name = "Object1", Desc = "B"},
                new TestObject {Name = "Object2", Desc = "A"},
                new TestObject {Name = "Object3", Desc = "B"},
                new TestObject {Name = "Object4", Desc = "A"},
            };
            var filters = new List<FilterCollectionModel>
            {
                new FilterCollectionModel
                {
                    IsAnd = false,
                    InternalFilterCollection = new List<InternalFilterModel>
                    {
                        new InternalFilterModel
                        {
                            FilterProperty = "Name",
                            FilterValue = "Object1",
                            IsAnd = false
                        },
                        new InternalFilterModel
                        {
                            FilterProperty = "Desc",
                            FilterValue = "B",
                            IsAnd = false
                        },
                    }
                },
                new FilterCollectionModel
                {
                    IsAnd = false,
                    InternalFilterCollection = new List<InternalFilterModel>
                    {
                        new InternalFilterModel
                        {
                            FilterProperty = "Name",
                            FilterValue = "Object3",
                            IsAnd = false
                        },
                        new InternalFilterModel
                        {
                            FilterProperty = "Desc",
                            FilterValue = "A",
                            IsAnd = true
                        },
                    }
                },
            };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                foreach (var obj in objects)
                {
                    await dictionary.TryAddAsync(tx, Guid.NewGuid(), obj);
                }

                await tx.CommitAsync();
            }

            //Perform test
            var result = (await stateful.GetByFilter<TestObject>("dictionary", filters)).ToList();

            var expectedResult = From(objects, 0, 1, 2, 3, 4, 6);
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public async Task GetByFilter_MultipleFilters2_ReturnsFiltered()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            var objects = new List<TestObject>
            {
                new TestObject {Name = "Object1", Desc = "A"},
                new TestObject {Name = "Object2", Desc = "B"},
                new TestObject {Name = "Object3", Desc = "A"},
                new TestObject {Name = "Object4", Desc = "B"},
                new TestObject {Name = "Object1", Desc = "B"},
                new TestObject {Name = "Object2", Desc = "A"},
                new TestObject {Name = "Object3", Desc = "B"},
                new TestObject {Name = "Object4", Desc = "A"},
            };
            var filters = new List<FilterCollectionModel>
            {
                new FilterCollectionModel
                {
                    IsAnd = false,
                    InternalFilterCollection = new List<InternalFilterModel>
                    {
                        new InternalFilterModel
                        {
                            FilterProperty = "Name",
                            FilterValue = "Object1",
                            IsAnd = false
                        },
                        new InternalFilterModel
                        {
                            FilterProperty = "Desc",
                            FilterValue = "B",
                            IsAnd = true
                        },
                    }
                },
                new FilterCollectionModel
                {
                    IsAnd = true,
                    InternalFilterCollection = new List<InternalFilterModel>
                    {
                        new InternalFilterModel
                        {
                            FilterProperty = "Desc",
                            FilterValue = "A",
                            IsAnd = true
                        },
                        new InternalFilterModel
                        {
                            FilterProperty = "Name",
                            FilterValue = "Object5",
                            IsAnd = false
                        },
                    }
                },
            };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                foreach (var obj in objects)
                {
                    await dictionary.TryAddAsync(tx, Guid.NewGuid(), obj);
                }

                await tx.CommitAsync();
            }

            //Perform test
            var result = (await stateful.GetByFilter<TestObject>("dictionary", filters)).ToList();
            var expectedResult = new List<TestObject>();
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task GetByFilter_WhenInternalFilterIsNull_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            var objects = new List<TestObject>
            {
                new TestObject {Name = "Object1", Desc = "A"},
                new TestObject {Name = "Object2", Desc = "B"},
                new TestObject {Name = "Object3", Desc = "A"},
                new TestObject {Name = "Object4", Desc = "B"},
                new TestObject {Name = "Object1", Desc = "B"},
                new TestObject {Name = "Object2", Desc = "A"},
                new TestObject {Name = "Object3", Desc = "B"},
                new TestObject {Name = "Object4", Desc = "A"},
            };
            var filters = new List<FilterCollectionModel>
            {
                new FilterCollectionModel
                {
                    IsAnd = false,
                    InternalFilterCollection = null
                }
            };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                foreach (var obj in objects)
                {
                    await dictionary.TryAddAsync(tx, Guid.NewGuid(), obj);
                }

                await tx.CommitAsync();
            }

            //Perform test
            var result = (await stateful.GetByFilter<TestObject>("dictionary", filters)).ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByFilter_WhenFilterPropertyIsNull_ReturnsEmpty()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            var objects = new List<TestObject>
            {
                new TestObject {Name = "Object1", Desc = "A"},
                new TestObject {Name = "Object2", Desc = "B"},
                new TestObject {Name = "Object3", Desc = "A"},
                new TestObject {Name = "Object4", Desc = "B"},
                new TestObject {Name = "Object1", Desc = "B"},
                new TestObject {Name = "Object2", Desc = "A"},
                new TestObject {Name = "Object3", Desc = "B"},
                new TestObject {Name = "Object4", Desc = "A"},
            };
            var filters = new List<FilterCollectionModel>
            {
                new FilterCollectionModel
                {
                    IsAnd = false,
                    InternalFilterCollection = new List<InternalFilterModel>
                    {
                        new InternalFilterModel
                        {
                            FilterProperty = null,
                            FilterValue = "Object1",
                            IsAnd = false
                        }
                    }
                }
            };
            //Populate dictionary

            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                foreach (var obj in objects)
                {
                    await dictionary.TryAddAsync(tx, Guid.NewGuid(), obj);
                }

                await tx.CommitAsync();
            }

            //Perform test
            var result = (await stateful.GetByFilter<TestObject>("dictionary", filters)).ToList();
            var expectedResult = new List<TestObject>();
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public async Task GetByFilter_WhenInternalFilterValueIsNull_ReturnsEmpty()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            var objects = new List<TestObject>
            {
                new TestObject {Name = "Object1", Desc = "A"},
                new TestObject {Name = "Object2", Desc = "B"},
                new TestObject {Name = "Object3", Desc = "A"},
                new TestObject {Name = "Object4", Desc = "B"},
                new TestObject {Name = "Object1", Desc = "B"},
                new TestObject {Name = "Object2", Desc = "A"},
                new TestObject {Name = "Object3", Desc = "B"},
                new TestObject {Name = "Object4", Desc = "A"},
            };
            var filters = new List<FilterCollectionModel>
            {
                new FilterCollectionModel
                {
                    IsAnd = false,
                    InternalFilterCollection = new List<InternalFilterModel>
                    {
                        new InternalFilterModel
                        {
                            FilterProperty = "Name",
                            FilterValue = null,
                            IsAnd = false
                        }
                    }
                }
            };
            //Populate dictionary
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, TestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                foreach (var obj in objects)
                {
                    await dictionary.TryAddAsync(tx, Guid.NewGuid(), obj);
                }

                await tx.CommitAsync();
            }

            //Perform test
            var result = (await stateful.GetByFilter<TestObject>("dictionary", filters)).ToList();
            var expectedResult = new List<TestObject>();
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public async Task Process_When1stParamIsNull_AddsToDictionary()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);
            var objects = new List<BaseModelTestObject>
            {
                new BaseModelTestObject{CrudOperationType = CrudOperationType.Create},
                new BaseModelTestObject{CrudOperationType = CrudOperationType.Create},
                new BaseModelTestObject{CrudOperationType = CrudOperationType.Create},
                new BaseModelTestObject{CrudOperationType = CrudOperationType.Create},
            };


            //Perform test
            await stateful.Process(null, objects);

            //Get Dictionary
            var result = new List<BaseModelTestObject>();
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, BaseModelTestObject>>((string)null);
            using (var tx = stateManager.CreateTransaction())
            {
                var enumerator = (await dictionary.CreateEnumerableAsync(tx)).GetAsyncEnumerator();
                while (await enumerator.MoveNextAsync(CancellationToken.None))
                {
                    result.Add(enumerator.Current.Value);
                }
            }

            CollectionAssert.AreEquivalent(objects, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Process_When2ndParamIsNull_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);

            //Perform test
            await stateful.Process("dictionary", (IEnumerable<BaseModelTestObject>)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task Process_Create_WhenIdAlreadyExists_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);

            var id = Guid.NewGuid();
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, BaseModelTestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                var model = new BaseModelTestObject { Id = id };
                await dictionary.TryAddAsync(tx, model.Id, model);
                await tx.CommitAsync();
            }

            var objects = new List<BaseModelTestObject>
            {
                new BaseModelTestObject { Id = id, CrudOperationType = CrudOperationType.Create }
            };

            //Perform test
            await stateful.Process("dictionary", objects);
            Assert.Fail();
        }

        [TestMethod]
        public async Task Process_Create_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);

            var objects = new List<BaseModelTestObject>
            {
                new BaseModelTestObject { CrudOperationType = CrudOperationType.Create }
            };

            //Perform test
            await stateful.Process("dictionary", objects);

            //Get Dictionary
            var result = new List<BaseModelTestObject>();
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, BaseModelTestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                var enumerator = (await dictionary.CreateEnumerableAsync(tx)).GetAsyncEnumerator();
                while (await enumerator.MoveNextAsync(CancellationToken.None))
                {
                    result.Add(enumerator.Current.Value);
                }
            }

            CollectionAssert.AreEquivalent(objects, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task Process_Update_WhenIdDoesNotExist_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);

            var objects = new List<BaseModelTestObject>
            {
                new BaseModelTestObject { CrudOperationType = CrudOperationType.Update }
            };

            //Perform test
            await stateful.Process("dictionary", objects);
        }

        [TestMethod]
        public async Task Process_Update_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);

            //Populate Dictionary
            var id = Guid.NewGuid();
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, BaseModelTestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                var model = new BaseModelTestObject { Id = id, Name = "Cat" };
                await dictionary.TryAddAsync(tx, model.Id, model);
                await tx.CommitAsync();
            }

            //Perform test
            var objects = new List<BaseModelTestObject>
            {
                new BaseModelTestObject { Id=id, Name = "Dog", CrudOperationType = CrudOperationType.Update }
            };

            await stateful.Process("dictionary", objects);

            //Get Dictionary
            var result = new List<BaseModelTestObject>();
            using (var tx = stateManager.CreateTransaction())
            {
                var enumerator = (await dictionary.CreateEnumerableAsync(tx)).GetAsyncEnumerator();
                while (await enumerator.MoveNextAsync(CancellationToken.None))
                {
                    result.Add(enumerator.Current.Value);
                }
            }

            Assert.AreEqual("Dog", result.First().Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task Process_Delete_WhenIdDoesNotExist_ThrowsException()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);

            var objects = new List<BaseModelTestObject>
            {
                new BaseModelTestObject { CrudOperationType = CrudOperationType.Delete }
            };

            //Perform test
            await stateful.Process("dictionary", objects);
        }

        [TestMethod]
        public async Task Process_Delete_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var stateManager = new MockReliableStateManager();
            var stateful = mockHelper.CreateStateful(stateManager);

            //Populate Dictionary
            var id = Guid.NewGuid();
            var dictionary = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, BaseModelTestObject>>("dictionary");
            using (var tx = stateManager.CreateTransaction())
            {
                var model = new BaseModelTestObject { Id = id };
                await dictionary.TryAddAsync(tx, model.Id, model);
                await tx.CommitAsync();
            }

            //Perform test
            var objects = new List<BaseModelTestObject>
            {
                new BaseModelTestObject { Id=id, CrudOperationType = CrudOperationType.Delete }
            };

            await stateful.Process("dictionary", objects);

            //Get Dictionary
            var result = new List<BaseModelTestObject>();
            using (var tx = stateManager.CreateTransaction())
            {
                var enumerator = (await dictionary.CreateEnumerableAsync(tx)).GetAsyncEnumerator();
                while (await enumerator.MoveNextAsync(CancellationToken.None))
                {
                    result.Add(enumerator.Current.Value);
                }
            }

            CollectionAssert.AreEqual(new List<BaseModelTestObject>(), result);
        }

        [TestMethod]
        public void Compress_CompressesData()
        {
            var data = new List<TestObject>();
        }

        [TestMethod]
        public void Compress_CompressesData2()
        {

        }

        [TestMethod]
        public void GetPartitionRange_IsSuccessful()
        {
            var mockHelper = new MockServiceManager();
            var stateful = mockHelper.CreateStateful();

            var range = stateful.GetPartitionRange();

            Assert.AreEqual(0, range.Low);
            Assert.AreEqual(15, range.High);
        }

    }
}
