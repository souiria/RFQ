using System;
using System.Collections.Generic;
using System.Fabric.Query;
using Common.Core.Contracts.Models.Base;
using Common.SF.Infrastructure.Core;
using Common.SF.Tests.MockServices.Base;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Services.Remoting;
using ServiceFabric.Mocks;

namespace Common.SF.Tests.MockHelpers
{
    internal class MockServiceManager
    {
        private MockActorProxyFactory MockActorProxyFactory { get; }
        private readonly Dictionary<Uri, object> _services = new Dictionary<Uri, object>();

        public MockServiceManager()
        {
            FabricClientProvider.FabricClient = new MockWrappedFabricClient();
            MockActorProxyFactory = new MockActorProxyFactory();
        }

        public void RegisterMockService(Uri serviceName, IService service, MockWrappedServicePartitionList partitions = null)
        {
            MockActorProxyFactory.RegisterService(serviceName, service);
            _services.Add(serviceName, service);

            if (FabricClientProvider.FabricClient.QueryManager is MockWrappedQueryClient client)
            {
                var applicationName = RemoveLastSegment(serviceName);
                client.RegisterService(applicationName, serviceName, partitions ?? DefaultPartitions());
            }
            else throw new ArgumentException("The FabricClientProvider did not return a client of type MockWrappedFabricClient.");
        }

        private Uri RemoveLastSegment(Uri uri)
        {
            var noLastSegment = uri.AbsoluteUri;
            return new Uri(noLastSegment.Substring(0, noLastSegment.LastIndexOf('/')));
        }

        private static MockWrappedServicePartitionList DefaultPartitions()
        {
            return new MockWrappedServicePartitionList
            {
                new MockWrappedPartition(new MockWrappedInt64RangePartitionInformation(Guid.NewGuid(), 0, 15))
            };
        }

        public T RegisterMockActorService<T>(Uri actorAddress, ActorId id) where T : Actor, IActor
        {
            MockActorService<T> mockActorService;
            if (_services.ContainsKey(actorAddress))
            {
                mockActorService = (MockActorService<T>)_services[actorAddress];
            }
            else
            {
                ActorBase ActorFactory(ActorService service, ActorId actorId) =>
                    (T)Activator.CreateInstance(typeof(T), service, actorId);

                mockActorService = MockActorServiceFactory.CreateActorServiceForActor<T>(ActorFactory);
            }

            var actor = mockActorService.Activate(id);
            MockActorProxyFactory.RegisterActor(actor);

            RegisterMockService(actorAddress, mockActorService);
            return actor;
        }


        public MockActor CreateActor(ActorId id)
        {
            ActorBase ActorFactory(ActorService service, ActorId actorId) => new MockActor(service, id, MockActorProxyFactory);
            var svc = MockActorServiceFactory.CreateActorServiceForActor<MockActor>(ActorFactory);
            var actor = svc.Activate(id);
            return actor;
        }

        public MockStateful CreateStateful(MockReliableStateManager stateManager = null)
        {
            var context = MockStatefulServiceContextFactory.Default;

            var service = new MockStateful(context, stateManager ?? new MockReliableStateManager(), MockActorProxyFactory);
            var partition = new MockStatefulServicePartition(service.Context.ServiceName)
            {
                PartitionInfo = MockQueryPartitionFactory.CreateIntPartitonInfo(0, 15)
            };
            service.SetPartition(partition);

            return service;
        }

        public MockStateful<T> CreateStateful<T>(MockReliableStateManager stateManager = null) where T : BaseModel<Guid>
        {
            var context = MockStatefulServiceContextFactory.Default;

            var service = new MockStateful<T>(context, stateManager ?? new MockReliableStateManager(), MockActorProxyFactory);
            var partition = new MockStatefulServicePartition(service.Context.ServiceName)
            {
                PartitionInfo = MockQueryPartitionFactory.CreateIntPartitonInfo(0, 15)
            };
            service.SetPartition(partition);

            return service;
        }
    }
}
