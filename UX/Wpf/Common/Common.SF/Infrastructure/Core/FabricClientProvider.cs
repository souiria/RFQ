using System;

namespace Common.SF.Infrastructure.Core
{
    public static class FabricClientProvider
    {
        public static IWrappedFabricClient FabricClient { get; set; } = new WrappedFabricClient();
    }
}
