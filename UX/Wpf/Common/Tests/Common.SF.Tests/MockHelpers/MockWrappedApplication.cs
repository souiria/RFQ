using System;
using System.Collections.Generic;
using Common.SF.Infrastructure.Core;

namespace Common.SF.Tests.MockHelpers
{
    internal sealed class MockWrappedApplicationList : List<IWrappedApplication>, IWrappedApplicationList { }

    internal sealed class MockWrappedApplication : IWrappedApplication
    {
        public Uri ApplicationName { get; }

        public MockWrappedApplication(Uri applicationName)
        {
            ApplicationName = applicationName;
        }
    }
}
