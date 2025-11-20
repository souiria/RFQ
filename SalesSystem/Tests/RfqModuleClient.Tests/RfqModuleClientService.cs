using System.Diagnostics;
using Grpc.Net.Client;
using Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RfqModule;

namespace RfqModuleClient.Tests.Services
{
    /// gRPC client service that only uses the RfqModule.proto definitions
    public class RfqModuleClientService : IDisposable
    {
        readonly GrpcChannel _Channel;
        readonly RfqModule.RfqModule.RfqModuleClient _Client;
        readonly ILogger<RfqModuleClientService>? _Logger;
        readonly TimeSpan _Timeout;
        bool _Disposed;

        public RfqModuleClientService(IConfiguration configuration, ILogger<RfqModuleClientService>? logger = null)
        {
            _Logger = logger;
            
            string serviceUrl = configuration["GrpcService:Url"] ?? "https://localhost:7207";
            int timeoutSeconds = configuration.GetValue("GrpcService:TimeoutSeconds", 30);
            _Timeout = TimeSpan.FromSeconds(timeoutSeconds);
            
            _Channel = GrpcChannel.ForAddress(serviceUrl);
            _Client = new RfqModule.RfqModule.RfqModuleClient(_Channel);

            _Logger?.GenericLogInformation($"RfqModuleClientService initialized for service URL: {serviceUrl} with timeout: {timeoutSeconds}s");
            _Disposed = false;
        }
        #region HelloService

        public async Task<HelloReply> SayHelloAsync(string name, CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);
            
            try
            {
                HelloRequest request = new HelloRequest();
                request.Name = name;
                Stopwatch stopwatch = Stopwatch.StartNew();

                HelloReply response = await _Client.SayHelloAsync(request, cancellationToken: combinedCts.Token);
                stopwatch.Stop();
                
                _Logger?.GenericLogInformation($"SayHello completed in {stopwatch.ElapsedMilliseconds}ms for name: {name}");
                
                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in SayHello for name: {name}", ex);
                throw;
            }
        }
        #endregion

        #region Rfq Projects
        public async Task<CreateRfqProjectGrpcResponse> CreateRfqProjectAsync(
            RfqProject project,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            try
            {
                CreateRfqProjectGrpcRequest request = new CreateRfqProjectGrpcRequest();
                request.Project = project;

                Stopwatch stopwatch = Stopwatch.StartNew();
                CreateRfqProjectGrpcResponse response = await _Client.CreateRfqProjectGrpcAsync(request, cancellationToken: combinedCts.Token);
                stopwatch.Stop();

                _Logger?.GenericLogInformation($"CreateRfqProject completed in {stopwatch.ElapsedMilliseconds}ms. Success: {response.Success}, Created ID: {response.CreatedProjectId}");

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in CreateRfqProject", ex);
                throw;
            }
        }
        public async Task<int> GetAllRfqProjectAsync(int position = 0,
                                                     int take = 100,
                                                     CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            try
            {
                GetAllRfqProjectGrpcRequest request = new GetAllRfqProjectGrpcRequest();

                request.Position = position;
                request.Take = take;

                Stopwatch stopwatch = Stopwatch.StartNew();
                GetAllRfqProjectGrpcResponse response = await _Client.GetAllRfqProjectGrpcAsync(request, cancellationToken: combinedCts.Token);
                stopwatch.Stop();

                _Logger?.GenericLogInformation($"GetAllRfqProject completed in {stopwatch.ElapsedMilliseconds}ms. Success: {response.RfqProjects != null}");

                List<RfqProject> projects = new List<RfqProject>();
                if(response.RfqProjects != null && 0 < response.RfqProjects.Count)
                {
                    projects.AddRange(response.RfqProjects);
                }

                return projects.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetAllRfqProjectGrpc with position {position} and take {take}", ex);
                throw;
            }
        }
        public async Task<RfqProject?> GetRfqProjectByIdAsync(long rowId)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                GetRfqProjectByIdGrpcRequest request = new GetRfqProjectByIdGrpcRequest();
                request.RowId = rowId;

                GetRfqProjectByIdGrpcResponse response = await _Client.GetRfqProjectByIdGrpcAsync(request, cancellationToken: timeoutCts.Token);

                return response.Project;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetRfqProjectById for RowId: {rowId}", ex);
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

                Stopwatch stopwatch = Stopwatch.StartNew();
                FileUploadResponse response = await _Client.UploadFileAsync(request, cancellationToken: combinedCts.Token);
                stopwatch.Stop();

                _Logger?.GenericLogInformation($"UploadFile completed in {stopwatch.ElapsedMilliseconds}ms for file: {fileName}. Success: {response.Success}");

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in UploadFile for file: {fileName}", ex);
                throw;
            }
        }
        #endregion

        #region Customers and Related Data
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

                Stopwatch stopwatch = Stopwatch.StartNew();
                GetAllCustomersGrpcResponse response = await _Client.GetAllCustomersGrpcAsync(request, cancellationToken: combinedCts.Token);
                stopwatch.Stop();

                _Logger?.GenericLogInformation($"GetAllCustomers completed in {stopwatch.ElapsedMilliseconds}ms. Retrieved {response.Customers.Count}/{response.TotalCount} customers");

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetAllCustomers with position: {position}, take: {take}", ex);
                throw;
            }
        }
        public async Task<GetCustomersByUserIdGrpcResponse> GetCustomersByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            try
            {
                GetCustomersByUserIdGrpcRequest request = new GetCustomersByUserIdGrpcRequest();
                request.UserId = userId.ToString().ToUpperInvariant();

                Stopwatch stopwatch = Stopwatch.StartNew();
                GetCustomersByUserIdGrpcResponse response = await _Client.GetCustomersByUserIdGrpcAsync(request, cancellationToken: combinedCts.Token);
                stopwatch.Stop();

                _Logger?.GenericLogInformation($"GetCustomersByUserId completed in {stopwatch.ElapsedMilliseconds}ms for user: {userId}. Retrieved {response.Customers.Count}/{response.TotalCount} customers");

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetCustomersByUserId for user: {userId}", ex);
                throw;
            }
        }
        public async Task<GetProjectAssociationsByCustomerIdResponse> GetProjectAssociationsByCustomerIdAsync(
            string customerId,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            try
            {
                GetProjectAssociationsByCustomerIdRequest request = new GetProjectAssociationsByCustomerIdRequest();
                request.CustomerId = customerId;

                Stopwatch stopwatch = Stopwatch.StartNew();
                GetProjectAssociationsByCustomerIdResponse response = await _Client.GetProjectAssociationsByCustomerIdAsync(request, cancellationToken: combinedCts.Token);
                stopwatch.Stop();

                _Logger?.GenericLogInformation($"GetProjectAssociationsByCustomerId completed in {stopwatch.ElapsedMilliseconds}ms for customer: {customerId}. Retrieved {response.ProjectAssociation.Count} associations. Success: {response.Success}");

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetProjectAssociationsByCustomerId for customer: {customerId}", ex);
                throw;
            }
        }
        #endregion

        #region Reasons
        public async Task<GetRfqReasonsGrpcResponse> GetRfqReasonsAsync(
            int requestType = 1,
            int position = 0,
            int take = 100,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            try
            {
                GetRfqReasonsGrpcRequest request = new GetRfqReasonsGrpcRequest();
                request.RequestType = requestType;
                request.Position = position;
                request.Take = take;

                Stopwatch stopwatch = Stopwatch.StartNew();
                GetRfqReasonsGrpcResponse response = await _Client.GetRfqReasonsGrpcAsync(request, cancellationToken: combinedCts.Token);
                stopwatch.Stop();

                _Logger?.GenericLogInformation($"GetRfqReasons completed in {stopwatch.ElapsedMilliseconds}ms. Retrieved {response.RfqReasons.Count} reasons");

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetRfqReasons with requestType: {requestType}", ex);
                throw;
            }
        }
        #endregion

        #region Vehicles
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

                Stopwatch stopwatch = Stopwatch.StartNew();
                GetVehicleByProjectCodeGrpcResponse response = await _Client.GetVehicleByProjectCodeGrpcAsync(request, cancellationToken: combinedCts.Token);
                stopwatch.Stop();

                _Logger?.GenericLogInformation($"GetVehiclesByProjectCode completed in {stopwatch.ElapsedMilliseconds}ms for project code: {projectCode}. Retrieved {response.Vehicles.Count} vehicles");

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetVehiclesByProjectCode for project code: {projectCode}", ex);
                throw;
            }
        }
        #endregion

        #region Parts
        public async Task<UploadPartsRequestGrpcResponse> UploadPartsAsync(
            string projectId,
            byte[] fileData,
            string fileName,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            try
            {
                UploadPartsRequestGrpcRequest request = new UploadPartsRequestGrpcRequest();
                request.ProjectId = projectId;
                request.FileName = fileName;
                request.FileData = Google.Protobuf.ByteString.CopyFrom(fileData);

                Stopwatch stopwatch = Stopwatch.StartNew();
                UploadPartsRequestGrpcResponse response = await _Client.UploadPartsGrpcAsync(request, cancellationToken: combinedCts.Token);
                stopwatch.Stop();

                _Logger?.GenericLogInformation($"UploadParts completed in {stopwatch.ElapsedMilliseconds}ms for project: {projectId}, file: {fileName}. Success: {response.Success}");

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in UploadParts for project: {projectId}, file: {fileName}", ex);
                throw;
            }
        }
        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (!_Disposed)
            {
                if (disposing)
                {
                    _Channel?.Dispose();
                    _Logger?.GenericLogInformation("RfqModuleClientService disposed");
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