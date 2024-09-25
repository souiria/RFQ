using Common.SF.Infrastructure.Core;

namespace Common.SF.Tests.MockHelpers
{
    internal sealed class MockWrappedPartition : IWrappedPartition
    {
        public IWrappedServicePartitionInformation PartitionInformation { get; }
        internal MockWrappedPartition(IWrappedServicePartitionInformation servicePartitionInformation)
        {
            PartitionInformation = servicePartitionInformation;
        }
    }
}
