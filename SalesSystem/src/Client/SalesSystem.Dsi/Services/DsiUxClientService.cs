namespace SalesSystem.Dsi.Services
{
    public class DsiUxClientService : IDisposable
    {
#pragma warning disable CA1002 // Do not expose generic lists

        #region Definitions
        //readonly GrpcChannel? _Channel;
        ////readonly DsiModule.DsiModule.DsiModuleClient _Client;
        //readonly ILogger<DsiUxClientService>? _Logger;
        ////readonly TimeSpan _Timeout;
        //bool _Disposed;
        //static int _MAX_GRPC_RESPONSE_SIZE;
        //public static int MAX_GRPC_RESPONSE_SIZE => _MAX_GRPC_RESPONSE_SIZE;
        #endregion
         #region Cleanup
        protected virtual void Dispose(bool disposing)
        {
            //if (!_Disposed)
            //{
            //    if (disposing)
            //    {
            //        _Channel?.Dispose();
            //        _Logger?.GenericLogInformation("DsiUxClientService disposed");
            //    }

            //    _Disposed = true;
            //}
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

#pragma warning restore CA1002 // Do not expose generic lists

    }
}