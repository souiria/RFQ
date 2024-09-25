using System;
using System.Fabric;
using System.Fabric.Query;

namespace Common.SF.Infrastructure.Core
{
    public interface IWrappedPartition
    {
        IWrappedServicePartitionInformation PartitionInformation { get; }
    }
    public class WrappedPartition : IWrappedPartition
    {
        private readonly Partition _partition;
        public IWrappedServicePartitionInformation PartitionInformation => GenerateWrappedPartitionInformation(_partition.PartitionInformation);

        public WrappedPartition(Partition partition)
        {
            _partition = partition;
        }

        private WrappedServicePartitionInformation GenerateWrappedPartitionInformation(
            ServicePartitionInformation servicePartitionInformation)
        {
            switch (servicePartitionInformation)
            {
                case Int64RangePartitionInformation int64Range:
                    return new WrappedInt64RangePartitionInformation(int64Range);

                case SingletonPartitionInformation singleton:
                    return new WrappedSingletonPartitionInformation(singleton);

                default:
                    throw new ArgumentOutOfRangeException(nameof(servicePartitionInformation));
            }
        }
    }
}
