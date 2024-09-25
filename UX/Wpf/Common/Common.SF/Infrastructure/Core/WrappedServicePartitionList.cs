using System.Collections.Generic;
using System.Fabric.Query;

namespace Common.SF.Infrastructure.Core
{
    public interface IWrappedServicePartitionList : IList<IWrappedPartition> { }

    public class WrappedServicePartitionList : PagedList<IWrappedPartition>, IWrappedServicePartitionList
    {
        public WrappedServicePartitionList(ServicePartitionList servicePartitionList)
        {
            foreach (var partition in servicePartitionList)
                Add(new WrappedPartition(partition));
        }
    }
}
