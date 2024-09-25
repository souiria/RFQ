using System.Collections.Generic;
using System.Fabric.Query;

namespace Common.SF.Infrastructure.Core
{
    public interface IWrappedServiceList : IList<IWrappedService> { }

    internal class WrappedServiceList : PagedList<IWrappedService>, IWrappedServiceList
    {
        internal WrappedServiceList(ServiceList serviceList)
        {
            foreach (var service in serviceList)
                Add(new WrappedService(service));
        }
    }
}
