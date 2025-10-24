namespace SalesSystem.Rfq.Services
{
    public class RfqUxClientService : IDisposable
    {
        readonly GrpcChannel _Channel;
        readonly RfqModule.RfqModule.RfqModuleClient _Client;
        readonly ILogger<RfqUxClientService>? _Logger;
        readonly TimeSpan _Timeout;
        bool _Disposed;

        // Cached Data
        List<CustomerGrpc> _Customers;
        List<RfqReasonGrpc> _Reasons;
        List<CustomerProjectUx> _CustomerProjectAssociations;
        // Cached data accessors
        public IReadOnlyCollection<CustomerGrpc> Customers => _Customers.AsReadOnly();
        public IReadOnlyCollection<RfqReasonGrpc> Reasons => _Reasons.AsReadOnly();
        public IReadOnlyCollection<CustomerProjectUx> CustomerProjectAssociations => _CustomerProjectAssociations.AsReadOnly();

        public RfqUxClientService(IConfiguration configuration, ILogger<RfqUxClientService>? logger = null)
        {
            _Logger = logger;

            string serviceUrl = configuration["GrpcService:Url"] ?? "https://localhost:7207";
            int timeoutSeconds = configuration.GetValue("GrpcService:TimeoutSeconds", 30);
            _Timeout = TimeSpan.FromSeconds(timeoutSeconds);

            _Channel = GrpcChannel.ForAddress(serviceUrl);
            _Client = new RfqModule.RfqModule.RfqModuleClient(_Channel);

            _Logger?.GenericLogInformation($"RfqUxClientService initialized for service URL: {serviceUrl} with timeout: {timeoutSeconds}s");
            _Disposed = false;

            // cache initialization
            _Logger = logger;
            _Customers = new();
            _Reasons = new();
            _CustomerProjectAssociations = new();
        }

        public async Task<HelloReply> SayHelloAsync(string name, CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            try
            {
                HelloRequest request = new HelloRequest();
                request.Name = name;

                HelloReply response = await _Client.SayHelloAsync(request, cancellationToken: combinedCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in SayHello for name: {name}", ex);
                throw;
            }
        }

        public async Task<GetAllCustomersGrpcResponse> GetAllCustomersAsync(
            int position = 0,
            int take = 100,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            try
            {
                GetAllCustomersGrpcRequest request = new GetAllCustomersGrpcRequest();
                request.Position = position;
                request.Take = take;

                GetAllCustomersGrpcResponse response = await _Client.GetAllCustomersGrpcAsync(request, cancellationToken: combinedCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetAllCustomers with position: {position}, take: {take}", ex);
                throw;
            }
        }

        public async Task<int> GetCustomersByUserIdAsync(Guid userId)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                GetCustomersByUserIdGrpcRequest request = new GetCustomersByUserIdGrpcRequest();
                request.UserId = userId.ToString().ToUpperInvariant();

                GetCustomersByUserIdGrpcResponse response = await _Client.GetCustomersByUserIdGrpcAsync(request, cancellationToken: timeoutCts.Token);
                _Customers.Clear();
                _Customers.AddRange(response.Customers);
                return _Customers.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetCustomersByUserId for user: {userId}", ex);
                throw;
            }
        }

        public async Task<int> GetProjectAssociationsByCustomerIdAsync(string customerId)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                GetProjectAssociationsByCustomerIdRequest request = new GetProjectAssociationsByCustomerIdRequest();
                request.CustomerId = customerId;

                GetProjectAssociationsByCustomerIdResponse response = await _Client.GetProjectAssociationsByCustomerIdAsync(request, cancellationToken: timeoutCts.Token);

                _CustomerProjectAssociations.Clear();
                foreach (ProjectAssociation? association in response.ProjectAssociation)
                {
                    CustomerProjectUx? projectAssociation = association.ToCustomerProjectUx();
                    if (null == projectAssociation)
                    {
                        continue;
                    }

                    _CustomerProjectAssociations.Add(projectAssociation);
                }

                return _CustomerProjectAssociations.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetProjectAssociationsByCustomerId for customer: {customerId}", ex);
                throw;
            }
        }

        public async Task<int> GetRfqReasonsAsync()
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                GetRfqReasonsGrpcRequest request = new GetRfqReasonsGrpcRequest();
                request.RequestType = 1;

                GetRfqReasonsGrpcResponse response = await _Client.GetRfqReasonsGrpcAsync(request, cancellationToken: timeoutCts.Token);

                _Reasons.Clear();
                _Reasons.AddRange(response.RfqReasons);
                return _Reasons.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetRfqReasons with requestType 1 (read)", ex);
                throw;
            }
        }

        public async Task<GetVehicleByProjectCodeGrpcResponse> GetVehiclesByProjectCodeAsync(
            string projectCode,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            try
            {
                GetVehicleByProjectCodeGrpcRequest request = new GetVehicleByProjectCodeGrpcRequest();
                request.ProjectCode = projectCode;

                GetVehicleByProjectCodeGrpcResponse response = await _Client.GetVehicleByProjectCodeGrpcAsync(request, cancellationToken: combinedCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetVehiclesByProjectCode for project code: {projectCode}", ex);
                throw;
            }
        }

        public async Task<UploadPartsRequestGrpcResponse> UploadPartsAsync(string projectId,
                                                                           IBrowserFile file,
                                                                           long maxAllowedSize = 10_000_000)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                UploadPartsRequestGrpcRequest request = new UploadPartsRequestGrpcRequest();
                request.ProjectId = projectId;
                request.FileName = file.Name;

                using MemoryStream memoryStream = new MemoryStream();
                await file.OpenReadStream(maxAllowedSize: maxAllowedSize).CopyToAsync(memoryStream);
                byte[] fileData = memoryStream.ToArray();

                request.FileData = Google.Protobuf.ByteString.CopyFrom(fileData);

                UploadPartsRequestGrpcResponse response = await _Client.UploadPartsGrpcAsync(request, cancellationToken: timeoutCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in UploadParts for project: {projectId}, file: {file.Name}", ex);
                throw;
            }
        }

        public async Task<CreateRfqProjectGrpcResponse> CreateRfqProjectAsync(RfqProject project)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                CreateRfqProjectGrpcRequest request = new CreateRfqProjectGrpcRequest();
                request.Project = project;

                CreateRfqProjectGrpcResponse response = await _Client.CreateRfqProjectGrpcAsync(request, cancellationToken: timeoutCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in CreateRfqProject", ex);
                throw;
            }
        }

        public async Task<FileUploadResponse> UploadFileAsync(
            byte[] fileData,
            string fileName,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            try
            {
                FileUploadRequest request = new FileUploadRequest();
                request.FileName = fileName;
                request.FileData = Google.Protobuf.ByteString.CopyFrom(fileData);

                FileUploadResponse response = await _Client.UploadFileAsync(request, cancellationToken: combinedCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in UploadFile for file: {fileName}", ex);
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_Disposed)
            {
                if (disposing)
                {
                    _Channel?.Dispose();
                    _Logger?.GenericLogInformation("RfqUxClientService disposed");
                }

                _Disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}