using System;
using System.Threading.Tasks;
using Common.SF.Infrastructure.Core;
using Common.SF.Infrastructure.PubSub.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace Common.SF.Infrastructure.PubSub.Models
{
    public class BrokerServiceLocator : IBrokerActorLocator
    {
        private static IWrappedServicePartitionList _cachedPartitions;
        private readonly IWrappedFabricClient _fabricClient;
        public IActorProxyFactory ActorProxyFactory { get; }

        /// <summary>
        /// Creates a new default instance.
        /// </summary>
        public BrokerServiceLocator(IActorProxyFactory actorProxyFactory)
        {
            _fabricClient = FabricClientProvider.FabricClient;
            ActorProxyFactory = actorProxyFactory;
        }
        
        //public async Task RegisterAsync(Uri brokerServiceName)
        //{
        //    var activationContext = FabricRuntime.GetActivationContext();
        //    var fc = FabricClientProvider.FabricClient;
        //    await fc.PropertyManager.PutPropertyAsync(new Uri(activationContext.ApplicationName), nameof(BrokerService), brokerServiceName.ToString());
        //}

        /// <inheritdoc />
        public async Task<Uri> LocateAsync()
        {
            //FabricRuntime.GetActivationContext();
            var list = await _fabricClient.QueryManager.GetApplicationListAsync();
            foreach (var item in list)
            {
                try
                {
                    var serviceList = await _fabricClient.QueryManager.GetServiceListAsync(item.ApplicationName);
                    foreach (var service in serviceList)
                    {
                        if (service.ServiceName.ToString().Contains("SF.Core.PubSubBrokerActor"))
                        {
                            return service.ServiceName;
                        }
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return null;
        }
        
        //public async Task<ServicePartitionKey> GetPartitionForMessageAsync(object message, Uri brokerServiceName)
        //{
        //    if (message == null) throw new ArgumentNullException(nameof(message));
        //    if (brokerServiceName == null) throw new ArgumentNullException(nameof(brokerServiceName));

        //    string messageTypeName = (message.GetType().FullName);

        //    if (_cachedPartitions == null)
        //    {
        //        _cachedPartitions = await _fabricClient.QueryManager.GetPartitionListAsync(brokerServiceName);
        //    }
        //    int index = Math.Abs(messageTypeName.GetHashCode() % _cachedPartitions.Count);
        //    var partition = _cachedPartitions[index];
        //    if (partition.PartitionInformation.Kind != ServicePartitionKind.Int64Range)
        //    {
        //        throw new InvalidOperationException("Sorry, only Int64 Range Partitions are supported.");
        //    }

        //    var info = (IWrappedInt64RangePartitionInformation)partition.PartitionInformation;
        //    var resolvedPartition = new ServicePartitionKey(info.LowKey);

        //    return resolvedPartition;
        //}

        //public Task<IBrokerActor> GetBrokerServiceForMessageAsync(object message, Uri brokerServiceName)
        //{
        //    return GetBrokerServiceForMessageAsync(message.GetType().FullName, brokerServiceName);
        //}

        /// <inheritdoc />
        public async Task<IBrokerActor> GetBrokerServiceForMessageAsync(string messageTypeName, Uri brokerServiceName)
        {
            //var resolvedPartition = await GetPartitionForMessageAsync(messageTypeName, brokerServiceName);
            var brokerService = ActorProxyFactory.CreateActorProxy<IBrokerActor>(brokerServiceName, new ActorId(messageTypeName));
            return brokerService;
        }
    }
}