using System;
using System.Fabric;
using System.Reflection;
using System.Threading.Tasks;
using Common.SF.Infrastructure.PubSub.Interfaces;
using Microsoft.ServiceFabric.Services.Runtime;
using ServiceFabric.PubSubActors;
using ServiceFabric.PubSubActors.Helpers;
using ServiceFabric.PubSubActors.Interfaces;
using BrokerServiceLocator = Common.SF.Infrastructure.PubSub.Models.BrokerServiceLocator;

namespace Common.SF.Infrastructure.PubSub.Helpers
{
    public class SubscriberServiceHelper : ISubscriberServiceHelper
    {
        private readonly IBrokerActorLocator _brokerServiceLocator;

        //public SubscriberServiceHelper()
        //{
        //    _brokerServiceLocator = new BrokerServiceLocator(ActorProxyFactory);
        //}

        public SubscriberServiceHelper(IBrokerActorLocator brokerServiceLocator)
        {
            _brokerServiceLocator = brokerServiceLocator;
        }

        #region Type Subscriptions

        /// <summary>
        /// Registers this Actor as a subscriber for messages of type <paramref name="messageType"/> with the <see cref="BrokerService"/>.
        /// </summary>
        /// <returns></returns>
        public async Task RegisterMessageTypeAsync(StatelessService service, Type messageType,
            Uri brokerServiceName = null, string listenerName = null)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (messageType == null) throw new ArgumentNullException(nameof(messageType));
            if (brokerServiceName == null)
            {
                brokerServiceName = await PublisherServiceHelper.DiscoverBrokerServiceNameAsync(_brokerServiceLocator.ActorProxyFactory);
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException(
                        "No brokerServiceName was provided or discovered in the current application.");
                }
            }
            var brokerService =
                await _brokerServiceLocator.GetBrokerServiceForMessageAsync(messageType.Name, brokerServiceName);
            var serviceReference = CreateServiceReference(service.Context, GetServicePartition(service).PartitionInfo, listenerName);
            await brokerService.RegisterServiceSubscriberAsync(serviceReference);
        }

        /// <summary>
        /// Unregisters this Actor as a subscriber for messages of type <paramref name="messageType"/> with the <see cref="BrokerService"/>.
        /// </summary>
        /// <returns></returns>
        public async Task UnregisterMessageTypeAsync(StatelessService service, Type messageType, bool flushQueue,
            Uri brokerServiceName = null)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (messageType == null) throw new ArgumentNullException(nameof(messageType));
            if (brokerServiceName == null)
            {
                brokerServiceName = await PublisherServiceHelper.DiscoverBrokerServiceNameAsync(_brokerServiceLocator.ActorProxyFactory);
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException(
                        "No brokerServiceName was provided or discovered in the current application.");
                }
            }
            var brokerService =
                await _brokerServiceLocator.GetBrokerServiceForMessageAsync(messageType.Name, brokerServiceName);
            var serviceReference = CreateServiceReference(service.Context, GetServicePartition(service).PartitionInfo);
            await brokerService.UnregisterServiceSubscriberAsync(serviceReference, flushQueue);
        }

        /// <summary>
        /// Registers this Actor as a subscriber for messages of type <paramref name="messageType"/> with the <see cref="BrokerService"/>.
        /// </summary>
        /// <returns></returns>
        public async Task RegisterMessageTypeAsync(StatefulService service, Type messageType,
            Uri brokerServiceName = null, string listenerName = null)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (messageType == null) throw new ArgumentNullException(nameof(messageType));
            if (brokerServiceName == null)
            {
                brokerServiceName = await _brokerServiceLocator.LocateAsync();
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException(
                        "No brokerServiceName was provided or discovered in the current application.");
                }
            }
            var brokerService =
            await _brokerServiceLocator.GetBrokerServiceForMessageAsync(messageType.FullName, brokerServiceName);
            var serviceReference = CreateServiceReference(service.Context, GetServicePartition(service).PartitionInfo, listenerName);
            await brokerService.RegisterServiceSubscriberAsync(serviceReference);
        }

        /// <summary>
        /// Unregisters this Actor as a subscriber for messages of type <paramref name="messageType"/> with the <see cref="BrokerService"/>.
        /// </summary>
        /// <returns></returns>
        public async Task UnregisterMessageTypeAsync(StatefulService service, Type messageType, bool flushQueue,
            Uri brokerServiceName = null)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (messageType == null) throw new ArgumentNullException(nameof(messageType));
            if (brokerServiceName == null)
            {
                brokerServiceName = await _brokerServiceLocator.LocateAsync();
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException(
                        "No brokerServiceName was provided or discovered in the current application.");
                }
            }
            var brokerService =
                await _brokerServiceLocator.GetBrokerServiceForMessageAsync(messageType.Name, brokerServiceName);
            var serviceReference = CreateServiceReference(service.Context, GetServicePartition(service).PartitionInfo);
            await brokerService.UnregisterServiceSubscriberAsync(serviceReference, flushQueue);
        }

        #endregion

        #region Channel Subscriptions

        public async Task RegisterMessageChannelAsync(StatelessService service, string channel,
            Uri brokerServiceName = null, string listenerName = null)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (channel == null || string.IsNullOrEmpty(channel)) throw new ArgumentNullException(nameof(channel));
            if (brokerServiceName == null)
            {
                brokerServiceName = await PublisherServiceHelper.DiscoverBrokerServiceNameAsync(_brokerServiceLocator.ActorProxyFactory);
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException(
                        "No brokerServiceName was provided or discovered in the current application.");
                }
            }
            var brokerService =
                await _brokerServiceLocator.GetBrokerServiceForMessageAsync(channel, brokerServiceName);
            var serviceReference = CreateServiceReference(service.Context, GetServicePartition(service).PartitionInfo, listenerName);
            await brokerService.RegisterServiceSubscriberAsync(serviceReference);
        }

        /// <summary>
        /// Unregisters this Actor as a subscriber for messages of type <paramref name="messageType"/> with the <see cref="BrokerService"/>.
        /// </summary>
        /// <returns></returns>
        public async Task UnregisterMessageChannelAsync(StatelessService service, string channel, bool flushQueue,
            Uri brokerServiceName = null)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (channel == null || string.IsNullOrEmpty(channel)) throw new ArgumentNullException(nameof(channel));
            if (brokerServiceName == null)
            {
                brokerServiceName = await PublisherServiceHelper.DiscoverBrokerServiceNameAsync(_brokerServiceLocator.ActorProxyFactory);
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException(
                        "No brokerServiceName was provided or discovered in the current application.");
                }
            }
            var brokerService =
                await _brokerServiceLocator.GetBrokerServiceForMessageAsync(channel, brokerServiceName);
            var serviceReference = CreateServiceReference(service.Context, GetServicePartition(service).PartitionInfo);
            await brokerService.UnregisterServiceSubscriberAsync(serviceReference, flushQueue);
        }

        public async Task RegisterMessageChannelAsync(StatefulService service, string channel,
             Uri brokerServiceName = null, string listenerName = null)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (channel == null || string.IsNullOrEmpty(channel)) throw new ArgumentNullException(nameof(channel));
            if (brokerServiceName == null)
            {
                brokerServiceName = await _brokerServiceLocator.LocateAsync();
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException(
                        "No brokerServiceName was provided or discovered in the current application.");
                }
            }
            var brokerService =
           await _brokerServiceLocator.GetBrokerServiceForMessageAsync(channel, brokerServiceName);
            var serviceReference = CreateServiceReference(service.Context, GetServicePartition(service).PartitionInfo, listenerName);
            await brokerService.RegisterServiceSubscriberAsync(serviceReference);
        }

        public async Task UnregisterMessageChannelAsync(StatefulService service, string channel, bool flushQueue,
            Uri brokerServiceName = null, string listenerName = null)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (channel == null || string.IsNullOrEmpty(channel)) throw new ArgumentNullException(nameof(channel));
            if (brokerServiceName == null)
            {
                brokerServiceName = await _brokerServiceLocator.LocateAsync();
                if (brokerServiceName == null)
                {
                    throw new InvalidOperationException(
                        "No brokerServiceName was provided or discovered in the current application.");
                }
            }
            var brokerService =
                await _brokerServiceLocator.GetBrokerServiceForMessageAsync(channel, brokerServiceName);
            var serviceReference = CreateServiceReference(service.Context, GetServicePartition(service).PartitionInfo);
            await brokerService.UnregisterServiceSubscriberAsync(serviceReference, flushQueue);            
        }

        #endregion

        /// <summary>
        /// Gets the Partition info for the provided StatefulServiceBase instance.
        /// </summary>
        /// <param name="serviceBase"></param>
        /// <returns></returns>
        private IStatefulServicePartition GetServicePartition(StatefulServiceBase serviceBase)
        {
            if (serviceBase == null) throw new ArgumentNullException(nameof(serviceBase));
            return (IStatefulServicePartition)serviceBase.GetType().GetProperty("Partition", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(serviceBase);
        }

        /// <summary>
        /// Gets the Partition info for the provided StatelessService instance.
        /// </summary>
        /// <param name="serviceBase"></param>
        /// <returns></returns>
        private static IStatelessServicePartition GetServicePartition(StatelessService serviceBase)
        {
            if (serviceBase == null) throw new ArgumentNullException(nameof(serviceBase));
            return (IStatelessServicePartition)serviceBase.GetType().GetProperty("Partition", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(serviceBase);
        }


        /// <summary>
        /// Creates a <see cref="ServiceReference"/> for the provided service context and partition info.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="info"></param>
        /// <param name="listenerName">(optional) The name of the listener that is used to communicate with the service</param>
        /// <returns></returns>
        private static ServiceReference CreateServiceReference(ServiceContext context, ServicePartitionInformation info, string listenerName = null)
        {
            var serviceReference = new ServiceReference
            {
                ApplicationName = context.CodePackageActivationContext.ApplicationName,
                PartitionKind = info.Kind,
                ServiceUri = context.ServiceName,
                PartitionGuid = context.PartitionId,
                ListenerName = listenerName
            };

            switch (info)
            {
                case Int64RangePartitionInformation longInfo:
                    serviceReference.PartitionID = longInfo.LowKey;
                    serviceReference.PartitionKey = longInfo.LowKey;
                    break;
                case NamedPartitionInformation stringInfo:
                    serviceReference.PartitionName = stringInfo.Name;
                    break;
            }
            return serviceReference;
        }
    }
}
