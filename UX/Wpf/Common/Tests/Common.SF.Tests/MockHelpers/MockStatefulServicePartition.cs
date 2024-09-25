using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Health;
using Common.SF.Infrastructure.Core;

namespace Common.SF.Tests.MockHelpers
{
    internal class MockStatefulServicePartition : IStatefulServicePartition, IServicePartition
    {
        private Uri ServiceName { get; }
        public MockStatefulServicePartition(Uri serviceName)
        {
            ServiceName = serviceName;
        }

        public FabricReplicator CreateReplicator(IStateProvider stateProvider, ReplicatorSettings replicatorSettings)
        {
            throw new NotImplementedException();
        }

        public void ReportReplicaHealth(HealthInformation healthInfo)
        {
            (FabricClientProvider.FabricClient.HealthManager as MockWrappedHealthClient)?.SetHealthState(ServiceName, healthInfo.HealthState);
        }

        public void ReportReplicaHealth(HealthInformation healthInfo, HealthReportSendOptions sendOptions)
        {
            throw new NotImplementedException();
        }

        public PartitionAccessStatus ReadStatus { get; }
        public PartitionAccessStatus WriteStatus { get; }

        public void ReportLoad(IEnumerable<LoadMetric> metrics)
        {
            throw new NotImplementedException();
        }

        public void ReportFault(FaultType faultType)
        {
            throw new NotImplementedException();
        }

        public void ReportMoveCost(MoveCost moveCost)
        {
            throw new NotImplementedException();
        }

        public void ReportPartitionHealth(HealthInformation healthInfo)
        {
            throw new NotImplementedException();
        }

        public void ReportPartitionHealth(HealthInformation healthInfo, HealthReportSendOptions sendOptions)
        {
            throw new NotImplementedException();
        }

        public ServicePartitionInformation PartitionInfo { get; set; }
    }
}
