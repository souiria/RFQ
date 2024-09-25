using System;
using System.Collections;
using System.Collections.Generic;
using System.Fabric;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.SF.Contracts.Interfaces.Administration.Security.DataFilter;
using Common.SF.Contracts.Interfaces.Core;
using Common.SF.Contracts.Interfaces.Core.Logging;
using Common.SF.Contracts.Interfaces.Core.Notifications;
using Common.SF.Contracts.Interfaces.Core.Settings;
using Common.SF.Contracts.Models.Core.Proxy;
using Common.SF.Contracts.Models.Core.Proxy.Commercial;
using Common.SF.Infrastructure.Base.Commercial;
using Common.SF.Infrastructure.Core;
using Common.SF.Infrastructure.PubSub.Helpers;
using Common.SF.Infrastructure.PubSub.Wrappers;
using Common.SF.Tests.MockHelpers;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using ServiceFabric.Mocks;

namespace Common.SF.Tests.MockServices.Base
{
    internal class MockStateful : StatefulServiceBase
    {
        internal new IUtilities UtilityProxy => base.UtilityProxy;
        internal new ILogging Logging => base.Logging;
        internal new Proxy<IServiceConfiguration> ServiceConfiguration => base.ServiceConfiguration;
        internal new PublisherServiceHelper PublisherServiceHelper => base.PublisherServiceHelper;
        internal new SubscriberServiceHelper SubscriberServiceHelper => base.SubscriberServiceHelper;
        internal new string ServiceName => base.ServiceName;
        internal new IServiceProxyFactory ServiceProxyFactory => base.ServiceProxyFactory;
        internal new IActorProxyFactory ActorProxyFactory => base.ActorProxyFactory;

        internal Action InitializeMethod { get; set; } = () => { };
        internal bool InitializeCalled { get; private set; }

        internal string FieldStringTestSetting = "Default";
        private string PrivateStringTestSetting { get; set; }
        internal string GetPrivateStringSetting => PrivateStringTestSetting;
        internal string StringTestSetting { get; set; } = "Default";
        internal string StringWithoutSetterTestSetting { get; } = "Default";

        internal int NumberTestSetting { get; set; } = 2;
        internal bool EnabledTestSetting { get; set; } = false;
        internal bool NotificationReceivedCalled { get; private set; }

        internal MockStateful(StatefulServiceContext context, IReliableStateManagerReplica2 stateManagerReplica,
            MockActorProxyFactory proxyFactory) : base(context, stateManagerReplica, proxyFactory, proxyFactory)
        {
            ((MockWrappedHealthClient)FabricClientProvider.FabricClient.HealthManager).AddService(Context.ServiceName);

        }

        internal new async Task InitializeRetryWrapper(CancellationToken cancellationToken)
        {
            await base.InitializeRetryWrapper(cancellationToken);
        }

        internal new async Task RegisterSettingsChannel(CancellationToken cancellationToken)
        {
            await base.RegisterSettingsChannel(cancellationToken);
        }

        internal new async Task<IEnumerable<TModel>> GetAll<TModel>(string dictionaryName)
        {
            return await base.GetAll<TModel>(dictionaryName);
        }

        internal new async Task<TModel> Get<TModel>(string dictionaryName, Guid id)
        {
            return await base.Get<TModel>(dictionaryName, id);
        }

        internal new async Task<IEnumerable<TModel>> GetByFilter<TModel>(string dictionaryName, IEnumerable<FilterCollectionModel> filters)
        {
            return await base.GetByFilter<TModel>(dictionaryName, filters);
        }

        internal new async Task Process<TModel>(string dictionaryName, IEnumerable<TModel> models) where TModel : BaseModel<Guid>
        {
            await base.Process(dictionaryName, models);
        }


        protected override Task Initialize()
        {
            InitializeCalled = true;
            InitializeMethod();
            return Task.FromResult(0);
        }

        internal new Range GetPartitionRange()
        {
            return base.GetPartitionRange();
        }

        protected override async Task NotificationReceived(MessageWrapper message)
        {
            NotificationReceivedCalled = true;
        }
    }

    internal class MockStateful<T> : StatefulServiceBase<T> where T : BaseModel<Guid>
    {
        internal new ISubscriptions Subscriptions => base.Subscriptions;
        internal new Proxy<IDataFilter> ServiceDataFilter => base.ServiceDataFilter;
        internal new static string _notificationQueue => StatefulServiceBase<T>._notificationQueue;
        internal new static string _auditQueue => StatefulServiceBase<T>._auditQueue;
        internal new static string _cacheName => StatefulServiceBase<T>._cacheName;
        internal new bool IsAuditLoggingEnabled
        {
            get => base.IsAuditLoggingEnabled;
            set => base.IsAuditLoggingEnabled = value;
        }

        internal MockStateful(StatefulServiceContext context, IReliableStateManagerReplica stateManagerReplica,
            MockActorProxyFactory proxyFactory) : base(context, stateManagerReplica, proxyFactory, proxyFactory)
        {
            ((MockWrappedHealthClient)FabricClientProvider.FabricClient.HealthManager).AddService(Context.ServiceName);
        }

        internal async Task RegisterCRUDChannels(bool create)
        {
            await base.RegisterCRUDChannels(create);
        }

        internal byte[] Compress(object obj)
        {
            return base.Compress(obj);
        }

        internal T Decompress<T>(byte[] objData)
        {
            return base.Decompress<T>(objData);
        }

        internal List<T> Decompress<T>(byte[][] objData)
        {
            return base.Decompress<T>(objData);
        }

        internal List<T> DecompressFromSingle<T>(byte[][] objData)
        {
            return base.DecompressFromSingle<T>(objData);
        }
    }
}
