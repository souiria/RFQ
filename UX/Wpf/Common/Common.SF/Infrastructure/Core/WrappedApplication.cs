using System;
using System.Fabric.Query;

namespace Common.SF.Infrastructure.Core
{
    public interface IWrappedApplication
    {
        Uri ApplicationName { get; }
    }

    internal sealed class WrappedApplication : Wrapped<Application>, IWrappedApplication
    {
        public Uri ApplicationName => Value.ApplicationName;
        internal WrappedApplication(Application application) : base(application) { }
    }
}
