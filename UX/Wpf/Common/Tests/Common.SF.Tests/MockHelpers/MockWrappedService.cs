using System;
using System.Collections.Generic;
using Common.SF.Infrastructure.Core;

namespace Common.SF.Tests.MockHelpers
{
    internal sealed class MockWrappedServiceList : List<IWrappedService>, IWrappedServiceList { }

    internal sealed class MockWrappedService : IWrappedService
    {
        public Uri ServiceName { get; }

        public MockWrappedService(Uri serviceName)
        {
            ServiceName = serviceName;
        }
    }
}
