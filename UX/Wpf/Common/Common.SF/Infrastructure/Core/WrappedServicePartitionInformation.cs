using System;
using System.Fabric;

namespace Common.SF.Infrastructure.Core
{
    public interface IWrappedServicePartitionInformation
    {
        Guid Id { get; }
        ServicePartitionKind Kind { get; }
    }

    internal abstract class WrappedServicePartitionInformation : IWrappedServicePartitionInformation
    {
        protected readonly ServicePartitionInformation ServicePartitionInformation;
        public Guid Id => ServicePartitionInformation.Id;
        public ServicePartitionKind Kind => ServicePartitionInformation.Kind;
        protected internal WrappedServicePartitionInformation(ServicePartitionInformation servicePartitionInformation)
        {
            ServicePartitionInformation = servicePartitionInformation;
        }
    }

    public interface IWrappedInt64RangePartitionInformation : IWrappedServicePartitionInformation
    {
        long LowKey { get; }
        long HighKey { get; }
    }

    internal sealed class WrappedInt64RangePartitionInformation : WrappedServicePartitionInformation, IWrappedInt64RangePartitionInformation
    {
        internal WrappedInt64RangePartitionInformation(Int64RangePartitionInformation int64RangePartitionInformation) :
            base(int64RangePartitionInformation)
        { }

        public long HighKey => ((Int64RangePartitionInformation)ServicePartitionInformation).HighKey;
        public long LowKey => ((Int64RangePartitionInformation)ServicePartitionInformation).LowKey;
    }

    public interface IWrappedSingletonPartitionInformation : IWrappedServicePartitionInformation
    { }

    internal sealed class WrappedSingletonPartitionInformation : WrappedServicePartitionInformation, IWrappedSingletonPartitionInformation
    {
        internal WrappedSingletonPartitionInformation(SingletonPartitionInformation singletonPartitionInformation) :
            base(singletonPartitionInformation)
        { }
    }

}
