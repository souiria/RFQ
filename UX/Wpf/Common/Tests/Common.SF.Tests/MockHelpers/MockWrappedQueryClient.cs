using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading.Tasks;
using Common.SF.Infrastructure.Core;

namespace Common.SF.Tests.MockHelpers
{
    internal sealed class MockWrappedQueryClient : IWrappedQueryClient
    {
        private readonly Dictionary<Uri, MockWrappedServicePartitionList> _servicePartitionList = new Dictionary<Uri, MockWrappedServicePartitionList>();
        private readonly HashSet<Uri> _applicationList = new HashSet<Uri>();

        internal void RegisterService(Uri applicationName, Uri serviceName, MockWrappedServicePartitionList partitionList)
        {
            _servicePartitionList.Add(serviceName, partitionList);
            _applicationList.Add(applicationName);
        }

        public Task<IWrappedServicePartitionList> GetPartitionListAsync(Uri serviceName)
        {
            if (_servicePartitionList.ContainsKey(serviceName))
                return Task.FromResult((IWrappedServicePartitionList)_servicePartitionList[serviceName]);

            throw new NullReferenceException($"No service with the uri {serviceName} has been registered.");
        }

        public Task<IWrappedApplicationList> GetApplicationListAsync()
        {
            var applicationList = new MockWrappedApplicationList();
            foreach (var application in _applicationList)
                applicationList.Add(new MockWrappedApplication(application));
            return Task.FromResult((IWrappedApplicationList)applicationList);
        }

        public Task<IWrappedServiceList> GetServiceListAsync(Uri applicationName)
        {
            var serviceList = new MockWrappedServiceList();
            foreach (var key in _servicePartitionList.Keys)
                serviceList.Add(new MockWrappedService(key));
            return Task.FromResult((IWrappedServiceList)serviceList);
        }

        internal bool Contains(Uri uri)
        {
            return _servicePartitionList.ContainsKey(uri);
        }
    }
}
