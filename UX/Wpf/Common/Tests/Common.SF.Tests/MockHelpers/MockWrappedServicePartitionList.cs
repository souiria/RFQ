using System.Fabric.Query;
using Common.SF.Infrastructure.Core;

namespace Common.SF.Tests.MockHelpers
{
    internal sealed class MockWrappedServicePartitionList : PagedList<IWrappedPartition>,
        IWrappedServicePartitionList
    {
    }
}
