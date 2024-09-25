using System;
using System.Fabric;
using Common.SF.Infrastructure.Core;

namespace Common.SF.Tests.MockHelpers
{
    //internal class MockWrappedServicePartitionInformation : IWrappedServicePartitionInformation
    //{
    //    protected readonly
    //}

    internal sealed class MockWrappedInt64RangePartitionInformation : IWrappedInt64RangePartitionInformation
    {
        public Guid Id { get; }
        public ServicePartitionKind Kind => ServicePartitionKind.Int64Range;
        public long HighKey { get; }
        public long LowKey { get; }
        internal MockWrappedInt64RangePartitionInformation(Guid id, long lowKey, long highKey)
        {
            Id = id;
            LowKey = lowKey;
            HighKey = highKey;
        }
    }
}
