using RfqModule;

namespace SalesSystem.Dsi.Services
{
    public class DsiUxClientService : IDisposable
    {
#pragma warning disable CA1002 // Do not expose generic lists

        #region Definitions

        readonly GrpcChannel _Channel;
        readonly RfqModule.RfqModule.RfqModuleClient _Client;
        readonly ILogger<DsiUxClientService>? _Logger;
        readonly TimeSpan _Timeout;
        bool _Disposed;

        static int _MAX_GRPC_RESPONSE_SIZE;
        public static int MAX_GRPC_RESPONSE_SIZE => _MAX_GRPC_RESPONSE_SIZE;

        // Cached Data
        readonly List<DSIHarnessGrpc> _Harnesses;
        readonly List<DSICompositeDetailGrpc> _CompositeDetails;
        readonly List<DSIWireSpecificationGrpc> _WireSpecifications;
        readonly List<DSIComponentGrpc> _Components;

        // Cached data accessors
        public IReadOnlyCollection<DSIHarnessGrpc> Harnesses => _Harnesses.AsReadOnly();
        public IReadOnlyCollection<DSICompositeDetailGrpc> CompositeDetails => _CompositeDetails.AsReadOnly();
        public IReadOnlyCollection<DSIWireSpecificationGrpc> WireSpecifications => _WireSpecifications.AsReadOnly();
        public IReadOnlyCollection<DSIComponentGrpc> Components => _Components.AsReadOnly();

        #endregion

        #region Ctor

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public DsiUxClientService(IConfiguration configuration, ILogger<DsiUxClientService> logger)
        {
            _Logger = logger;

            string serviceUrl =
                configuration["GrpcService:Url"]
                ?? "GrpcService:Core-Url is missing in configuration.";

            int timeoutSeconds =
                configuration.GetValue("GrpcService:TimeoutSeconds", 120);

            _Timeout = TimeSpan.FromSeconds(300);
            _MAX_GRPC_RESPONSE_SIZE = 64 * 1024 * 1024;

            _Channel = GrpcChannel.ForAddress(
                serviceUrl,
                new GrpcChannelOptions
                {
                    MaxReceiveMessageSize = _MAX_GRPC_RESPONSE_SIZE,
                    MaxSendMessageSize = _MAX_GRPC_RESPONSE_SIZE
                });

            _Client = new RfqModule.RfqModule.RfqModuleClient(_Channel);

            _Disposed = false;

            _Harnesses = new List<DSIHarnessGrpc>();
            _CompositeDetails = new List<DSICompositeDetailGrpc>();
            _WireSpecifications = new List<DSIWireSpecificationGrpc>();
            _Components = new List<DSIComponentGrpc>();

            _Logger?.GenericLogInformation(
                $"DsiUxClientService initialized for service URL: {serviceUrl} " +
                $"with timeout: {timeoutSeconds}s, MaxReceive: {_MAX_GRPC_RESPONSE_SIZE / 1024 / 1024}MB, " +
                $"MaxSend: {_MAX_GRPC_RESPONSE_SIZE / 1024 / 1024}MB");
        }

        #endregion

        #region Hello Service

        public async Task<HelloReply> SayHelloAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts =
                CancellationTokenSource.CreateLinkedTokenSource(
                    cancellationToken,
                    timeoutCts.Token);

            try
            {
                HelloRequest request = new HelloRequest();
                request.Name = name;

                HelloReply response =
                    await _Client.SayHelloAsync(
                        request,
                        cancellationToken: combinedCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in SayHelloAsync for name: {name}", ex);
                throw;
            }
        }

        #endregion

        #region Harness

        public async Task<int> GetAllHarnessAsync(
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts =
                CancellationTokenSource.CreateLinkedTokenSource(
                    cancellationToken,
                    timeoutCts.Token);

            try
            {
                GetAllHarnessModuleRequest request = new GetAllHarnessModuleRequest();

                GetAllHarnessModuleResponse response =
                    await _Client.GetAllHarnessGrpcAsync(
                        request,
                        cancellationToken: combinedCts.Token);

                _Harnesses.Clear();

                List<DSIHarnessGrpc> ordered = response.HarnessList
                    .OrderBy(x => x.HarnessName1)
                    .ToList();

                _Harnesses.AddRange(ordered);

                return _Harnesses.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError("Error in GetAllHarnessAsync", ex);
                throw;
            }
        }

        #endregion

        #region CompositeDetail

        public async Task<int> GetCompositeDetailByHarnessIdAsync(
            string harnessId,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts =
                CancellationTokenSource.CreateLinkedTokenSource(
                    cancellationToken,
                    timeoutCts.Token);

            try
            {
                GetCompositeDetailByHarnessRequest request =
                    new GetCompositeDetailByHarnessRequest();

                request.HarnessId = harnessId;

                GetCompositeDetailByHarnessResponse response =
                    await _Client.GetCompositeDetailByHarnessGrpcAsync(
                        request,
                        cancellationToken: combinedCts.Token);

                _CompositeDetails.Clear();

                List<DSICompositeDetailGrpc> ordered = response.CompositeDetails
                    .OrderBy(x => x.HarnessName1)
                    .ThenBy(x => x.CircuitOption)
                    .ToList();

                _CompositeDetails.AddRange(ordered);

                return _CompositeDetails.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError(
                    $"Error in GetCompositeDetailByHarnessIdAsync for HarnessId: {harnessId}",
                    ex);

                throw;
            }
        }

        public async Task<int> GetCompositeDetailByHarnessNameAsync(
            string harnessName1,
            string harnessId,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts =
                CancellationTokenSource.CreateLinkedTokenSource(
                    cancellationToken,
                    timeoutCts.Token);

            try
            {
                GetCompositeDetailByHarnessNameRequest request =
                    new GetCompositeDetailByHarnessNameRequest();

                request.HarnessName1 = harnessName1;
                request.HarnessId = harnessId;

                GetCompositeDetailByHarnessNameResponse response =
                    await _Client.GetCompositeDetailByHarnessNameGrpcAsync(
                        request,
                        cancellationToken: combinedCts.Token);

                _CompositeDetails.Clear();

                List<DSICompositeDetailGrpc> ordered = response.CompositeDetails
                    .OrderBy(x => x.HarnessName1)
                    .ThenBy(x => x.CircuitOption)
                    .ToList();

                _CompositeDetails.AddRange(ordered);

                return _CompositeDetails.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError(
                    $"Error in GetCompositeDetailByHarnessNameAsync for HarnessName1: {harnessName1}, HarnessId: {harnessId}",
                    ex);

                throw;
            }
        }

        #endregion

        #region WireSpecification

        public async Task<int> GetWireSpecificationByCompositeOptionAsync(
            string compositeOptionString,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts =
                CancellationTokenSource.CreateLinkedTokenSource(
                    cancellationToken,
                    timeoutCts.Token);

            try
            {
                GetWireSpecificationByCompositeOptionRequest request =
                    new GetWireSpecificationByCompositeOptionRequest();

                request.CompositeOptionString = compositeOptionString;

                GetWireSpecificationByCompositeOptionResponse response =
                    await _Client.GetWireSpecificationByCompositeOptionGrpcAsync(
                        request,
                        cancellationToken: combinedCts.Token);

                _WireSpecifications.Clear();

                List<DSIWireSpecificationGrpc> ordered = response.WireSpecifications
                    .OrderBy(x => x.Compositeoptionstring)
                    .ThenBy(x => x.WireName)
                    .ToList();

                _WireSpecifications.AddRange(ordered);

                return _WireSpecifications.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError(
                    $"Error in GetWireSpecificationByCompositeOptionAsync for CompositeOptionString: {compositeOptionString}",
                    ex);

                throw;
            }
        }

        #endregion

        #region Components

        public async Task<int> GetComponentsByHarnessAndOptionsAsync(
            string harnessName,
            IEnumerable<string> compositeOptions,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts =
                CancellationTokenSource.CreateLinkedTokenSource(
                    cancellationToken,
                    timeoutCts.Token);

            try
            {
                GetComponentsByHarnessAndOptionsRequest request =
                    new GetComponentsByHarnessAndOptionsRequest();

                request.HarnessName = harnessName;

                if (compositeOptions != null)
                {
                    request.CompositeOptions.AddRange(
                        compositeOptions.Where(x => !string.IsNullOrWhiteSpace(x)));
                }

                ListComponentGrpc response =
                    await _Client.GetComponentsByHarnessAndOptionsGrpcAsync(
                        request,
                        cancellationToken: combinedCts.Token);

                _Components.Clear();

                List<DSIComponentGrpc> ordered = response.ComponentList
                    .OrderBy(x => x.PartNumber1)
                    .ThenBy(x => x.PartNumber2)
                    .ThenBy(x => x.PartNumber3)
                    .ToList();

                _Components.AddRange(ordered);

                return _Components.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError(
                    $"Error in GetComponentsByHarnessAndOptionsAsync for HarnessName: {harnessName}",
                    ex);

                throw;
            }
        }

        #endregion

        #region Cleanup

        protected virtual void Dispose(bool disposing)
        {
            if (!_Disposed)
            {
                if (disposing)
                {
                    _Channel?.Dispose();
                    _Logger?.GenericLogInformation("DsiUxClientService disposed");
                }

                _Disposed = true;
            }
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