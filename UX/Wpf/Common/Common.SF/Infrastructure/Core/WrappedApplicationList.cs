using System.Collections.Generic;
using System.Fabric.Query;

namespace Common.SF.Infrastructure.Core
{
    public interface IWrappedApplicationList : IList<IWrappedApplication> { }

    internal class WrappedApplicationList : PagedList<IWrappedApplication>, IWrappedApplicationList
    {
        internal WrappedApplicationList(ApplicationList applicationList)
        {
            foreach (var application in applicationList)
                Add(new WrappedApplication(application));
        }
    }
}
