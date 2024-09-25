using System;
using System.Fabric.Query;

namespace Common.SF.Infrastructure.Core
{
    public interface IWrappedService
    {
        Uri ServiceName { get; }
    }

    internal class WrappedService : Wrapped<Service>, IWrappedService
    {
        internal WrappedService(Service service): base(service) { }
        public Uri ServiceName => Value.ServiceName;
    }
}
