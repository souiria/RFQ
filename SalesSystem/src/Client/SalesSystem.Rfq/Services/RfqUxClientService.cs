using System.Collections.Generic;

namespace SalesSystem.Rfq.Services
{
    public class RfqUxClientService : IDisposable
    {
#pragma warning disable CA1002 // Do not expose generic lists

        #region Definitions
        readonly GrpcChannel _Channel;
        readonly RfqModule.RfqModule.RfqModuleClient _Client;
        readonly ILogger<RfqUxClientService>? _Logger;
        readonly TimeSpan _Timeout;
        bool _Disposed;
        static int _MAX_GRPC_RESPONSE_SIZE;
        public static int MAX_GRPC_RESPONSE_SIZE => _MAX_GRPC_RESPONSE_SIZE;
        // Cached Data
        List<RfqDrawingPartNumberUxModel?> _RfqDrawingPartNumbers;
        List<RqfProjectUxModel> _RfqProjectUxs;
        List<CustomerUxModel?> _Customers;
        List<RfqReasonGrpc> _Reasons;
        List<RqfCustomerProjectAssociationUxModel> _CustomerProjectAssociations;
        List<string> _QuotationNumbers;
        List<AlternativePartUxModel> _AlternativeParts;
        int _AlternativePartsTake;
        int _AlternativePartsPosition;
        bool _Testing;

        // NPR Request cached data
        List<RfqNprRequestUxModel> _NprRequests;
        string _NprRequestSetsFilePath;
        public string NprRequestSetsFilePath => _NprRequestSetsFilePath;
        JsonSerializerOptions _JsonOptions;
        // Cached data accessors
        public IReadOnlyCollection<RfqDrawingPartNumberUxModel?> RfqDrawingPartNumbers => _RfqDrawingPartNumbers.AsReadOnly();
        public IReadOnlyCollection<RqfProjectUxModel> RfqProjectUxs => _RfqProjectUxs.AsReadOnly(); // only active projects are here
        public IReadOnlyCollection<CustomerUxModel?> Customers => _Customers.AsReadOnly();
        public IReadOnlyCollection<RfqReasonGrpc> Reasons => _Reasons.AsReadOnly();
        public IReadOnlyCollection<RqfCustomerProjectAssociationUxModel> CustomerProjectAssociations => _CustomerProjectAssociations.AsReadOnly();
        public IReadOnlyCollection<string> QuotationNumbers => _QuotationNumbers.AsReadOnly();
        public IReadOnlyCollection<AlternativePartUxModel> AlternativeParts => _AlternativeParts.AsReadOnly();
        public IReadOnlyCollection<RfqNprRequestUxModel> NprRequestSets => _NprRequests.AsReadOnly();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public RfqUxClientService(IConfiguration configuration, ILogger<RfqUxClientService> logger, bool isTest = false)
        {
            _Logger = logger;

            string serviceUrl = configuration["GrpcService:Url"] ?? "https://localhost:7207";
            int timeoutSeconds = configuration.GetValue("GrpcService:TimeoutSeconds", 120);
            _Timeout = TimeSpan.FromSeconds(300);
            _MAX_GRPC_RESPONSE_SIZE = 64 * 1024 * 1024;

            //_Channel = GrpcChannel.ForAddress(serviceUrl);
            _Channel = GrpcChannel.ForAddress(serviceUrl, new GrpcChannelOptions
            {
                MaxReceiveMessageSize = _MAX_GRPC_RESPONSE_SIZE,
                MaxSendMessageSize = _MAX_GRPC_RESPONSE_SIZE
            });
            _Client = new RfqModule.RfqModule.RfqModuleClient(_Channel);

            _Logger?.GenericLogInformation(
                $"RfqUxClientService initialized for service URL: {serviceUrl} " +
                $"with timeout: {timeoutSeconds}s, MaxReceive: {_MAX_GRPC_RESPONSE_SIZE / 1024 / 1024}MB, MaxSend: {_MAX_GRPC_RESPONSE_SIZE / 1024 / 1024}MB");

            _Disposed = false;

            // cache initialization
            _RfqProjectUxs = new();
            _Logger = logger;
            _Customers = new();
            _Reasons = new();
            _CustomerProjectAssociations = new();
            _QuotationNumbers = new()
            {
                "SEWS-25-025-005678",
                "SEWS-25-025-005688",
                "SEWS-25-025-005692"
            };
            _RfqDrawingPartNumbers = new();
            _AlternativeParts = new();
            _AlternativePartsPosition = 0;
            _AlternativePartsTake = -1;
            _NprRequests = new();

            // storage for requests
            if(isTest)
            {
                _NprRequestSetsFilePath = Path.Combine("C:\\temp", "npr_request_sets_test.json");
                _JsonOptions = new JsonSerializerOptions();
                _JsonOptions.WriteIndented = true;
                _JsonOptions.PropertyNameCaseInsensitive = false;
                _Testing = true;
            }
            else
            {
                _NprRequestSetsFilePath = Path.Combine("C:\\temp", "npr_request_sets.json");
                _JsonOptions = new JsonSerializerOptions();
                _JsonOptions.WriteIndented = true;
                _JsonOptions.PropertyNameCaseInsensitive = false;
                _Testing = false;
            }

            _Logger.GenericLogInformation($">>> RfqUxClientService was created with test == {isTest} and storage to file {_NprRequestSetsFilePath}");
        }
        #endregion

        #region Hello Service
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
        #endregion

        #region Customer
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
                GetCustomerBusinessUnitsByUserIdRequest request = new GetCustomerBusinessUnitsByUserIdRequest();
                request.UserId = userId.ToString().ToUpperInvariant();

                GetCustomerBusinessUnitsByUserIdResponse response = await _Client.GetCustomerBusinessUnitsByUserIdGrpcAsync(request, cancellationToken: timeoutCts.Token);
                _Customers.Clear();
                List<CustomerUxModel?> orderedCustomers = response.Customers.Select(x => x.ToUx()).OrderBy(x => x?.CustomerBusinessGroupName).ToList();
                _Customers.AddRange(orderedCustomers);

                return _Customers.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetCustomersByUserId for user: {userId}", ex);
                throw;
            }
        }
        #endregion

        #region Rfq Projects
        public async Task<int> GetAllRfqProjectAsync(int position = 0, int take = 100)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                GetAllRfqProjectGrpcRequest request = new GetAllRfqProjectGrpcRequest();

                request.Position = position;
                request.Take = take;

                GetAllRfqProjectGrpcResponse response = await _Client.GetAllRfqProjectGrpcAsync(request, cancellationToken: timeoutCts.Token);

                // dto list
                //_RfqProjects.Clear();
                //_RfqProjects.AddRange(response.RfqProjects);
                // ux list
                _RfqProjectUxs.Clear();
                IOrderedEnumerable<RfqProject> rfqProjects = response.RfqProjects.OrderByDescending(x => x.RfqNumber);
                foreach (RfqProject? rfqProject in rfqProjects)
                {
                    if (rfqProject.IsActive.HasValue && !rfqProject.IsActive.Value)
                    {
                        continue; // skip inactive projects
                    }

                    RqfProjectUxModel? uxModel = rfqProject.ToUx();
                    if (null != uxModel)
                    {
                        _RfqProjectUxs.Add(uxModel);
                    }
                }

                return _RfqProjectUxs.Count;
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
        public async Task<UpdateRfqProjectGrpcResponse> UpdateRfqProjectAsync(RqfProjectUxModel project)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            RfqProject projectDto = project.ToDto();

            try
            {
                UpdateRfqProjectGrpcRequest request = new UpdateRfqProjectGrpcRequest();
                request.Project = projectDto;

                UpdateRfqProjectGrpcResponse response = await _Client.UpdateRfqProjectGrpcAsync(request, cancellationToken: timeoutCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in UpdateRfqProject for RowId: {project.RowId}", ex);
                throw;
            }
        }
        public async Task<RfqCrudResponse> DeleteRfqProjectByRowIdAsync(long rowId)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                RfqProjectRequest request = new RfqProjectRequest();

                request.RowId = rowId;

                RfqCrudResponse response = await _Client.DeleteRfqProjectByRowIdGrpcAsync(request, cancellationToken: timeoutCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in DeleteRfqProjectByRowId for RowId: {rowId}", ex);
                throw;
            }
        }
        #endregion

        #region Project Associations
        public async Task<int> GetProjectAssociationsByCustomerIdAsync(Guid customerId)
        {
            string id = customerId.ToString().ToUpperInvariant();
            return await GetProjectAssociationsByCustomerIdAsync(id);
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
                IOrderedEnumerable<ProjectAssociation> associations = response.ProjectAssociation.ToList().OrderBy(x => x.CustomerProjectName).ThenBy(x => x.CustomerLocationName);
                foreach (ProjectAssociation? association in associations)
                {
                    RqfCustomerProjectAssociationUxModel? projectAssociation = association.ToUx();
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
        #endregion

        #region PartNumbers
        public async Task<int> GetRfqDrawingPartNumbersByRfqIdAsync(long rfqId)

        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                GetRfqDrawingPartNumbersByRfqIdGrpcRequest request = new GetRfqDrawingPartNumbersByRfqIdGrpcRequest();
                request.RfqId = rfqId;

                GetRfqDrawingPartNumbersByRfqIdGrpcResponse response = await _Client.GetRfqDrawingPartNumbersByRfqIdGrpcAsync(request, cancellationToken: timeoutCts.Token);
                _RfqDrawingPartNumbers.Clear();
                if (null != response && 0 <= response.Parts.Count)
                {
                    List<RfqDrawingPartNumberUxModel?> uxs = response.Parts.Select(x => x.ToUx()).ToList();
                    _RfqDrawingPartNumbers.AddRange(uxs);
                    return _RfqDrawingPartNumbers.Count;
                }

                return 0;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetRfqDrawingPartNumbersByRfqId for RfqId: {rfqId}", ex);
                throw;
            }
        }
        public async Task<UpdateRfqDrawingPartNumbersGrpcResponse> UpdateRfqDrawingPartNumbersAsync(IEnumerable<RfqDrawingPartNumberUxModel?> parts)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            List<RfqDrawingPartNumber> partsDto = new List<RfqDrawingPartNumber>();
            foreach (RfqDrawingPartNumberUxModel? part in parts)
            {
                if (part != null)
                {
                    RfqDrawingPartNumber dto = part.ToDto();
                    partsDto.Add(dto);
                }
            }

            try
            {
                // Build the rfqRequestsForRfqNumber
                UpdateRfqDrawingPartNumbersGrpcRequest request = new UpdateRfqDrawingPartNumbersGrpcRequest();
                request.RfqDrawingPartNumbersGrpcsToUpdate.AddRange(partsDto);

                // Call the gRPC client
                UpdateRfqDrawingPartNumbersGrpcResponse response =
                    await _Client.UpdateRfqDrawingPartNumbersGrpcAsync(request, cancellationToken: timeoutCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError("Error in UpdateRfqDrawingPartNumbersAsync", ex);
                throw;
            }
        }
        public async Task<bool> UpdateRfqDrawingPartNumber(RfqDrawingPartNumberUxModel partNumberUx)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            await Task.Delay(1);
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in UpdateRfqDrawingPartNumber for PartNumber: {partNumberUx.CustomerPartNumber}/{partNumberUx.DrawingPartNumber}", ex);
                throw;
            }
        }
        public async Task<bool> DeleteRfqDrawingPartNumber(RfqDrawingPartNumberUxModel partNumberUx)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            await Task.Delay(0);
            try
            {
                // Convert to gRPC type inline
                RfqDrawingPartNumber grpcPartNumber = new RfqDrawingPartNumber();
                grpcPartNumber.RowId = partNumberUx.RowId;
                grpcPartNumber.RfqId = partNumberUx.RfqId;
                grpcPartNumber.OriginalPartNumber = partNumberUx.DrawingPartNumber ?? string.Empty;
                grpcPartNumber.OriginalPartNumberPrice = partNumberUx.DrawingPartNumberPrice.HasValue ? Convert.ToDouble(partNumberUx.DrawingPartNumberPrice.Value) : 0;
                grpcPartNumber.SwappedPartNumber = partNumberUx.SwappedPartNumber ?? string.Empty;
                grpcPartNumber.SwappedPartNumberPrice = partNumberUx.SwappedPartNumberPrice.HasValue ? Convert.ToDouble(partNumberUx.SwappedPartNumberPrice.Value) : 0;
                grpcPartNumber.PriceSource = partNumberUx.PriceSource ?? string.Empty;
                grpcPartNumber.IsExactMatch = partNumberUx.IsExactMatch ?? false;
                grpcPartNumber.IsSwapped = partNumberUx.IsSwapped ?? false;
                grpcPartNumber.Comments = partNumberUx.Comments ?? string.Empty;
                grpcPartNumber.SumitomoPartNumber = partNumberUx.CustomerPartNumber ?? string.Empty;

                // TODO: Implement delete logic once gRPC endpoint is added to RfqModule.proto
                // For now, return false to indicate deletion is not yet implemented
                _Logger?.GenericLogInformation($"Delete not yet implemented for PartNumber: {partNumberUx.CustomerPartNumber}/{partNumberUx.DrawingPartNumber}");
                return false;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in DeleteRfqDrawingPartNumber for PartNumber: {partNumberUx.CustomerPartNumber}/{partNumberUx.DrawingPartNumber}", ex);
                throw;
            }
        }
        #endregion

        #region Rfq Reasons
        public async Task<int> GetRfqReasonsAsync()
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                GetRfqReasonsGrpcRequest request = new GetRfqReasonsGrpcRequest();
                request.RequestType = 1;

                GetRfqReasonsGrpcResponse response = await _Client.GetRfqReasonsGrpcAsync(request, cancellationToken: timeoutCts.Token);

                _Reasons.Clear();
                List<RfqReasonGrpc> orderedReasons = response.RfqReasons.OrderBy(x => x.RfqReasonTitle).ToList();
                _Reasons.AddRange(orderedReasons);
                return _Reasons.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetRfqReasons with requestType 1 (read)", ex);
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

                GetVehicleByProjectCodeGrpcResponse response = await _Client.GetVehicleByProjectCodeGrpcAsync(request, cancellationToken: combinedCts.Token);

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

                request.FileData = ByteString.CopyFrom(fileData);

                UploadPartsRequestGrpcResponse response = await _Client.UploadPartsGrpcAsync(request, cancellationToken: timeoutCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in UploadParts for project: {projectId}, file: {file.Name}", ex);
                throw;
            }
        }
        public async Task<UploadPartsRequestGrpcResponse> UploadPartsAsync(string projectId,
                                                                           byte[] fileData,
                                                                           string fileName,
                                                                           long maxAllowedSize = 16_777_216)
        {
            ArgumentException.ThrowIfNullOrEmpty(projectId);
            ArgumentNullException.ThrowIfNull(fileData);
            ArgumentException.ThrowIfNullOrEmpty(fileName);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(fileData.LongLength, maxAllowedSize);

            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                UploadPartsRequestGrpcRequest request = new UploadPartsRequestGrpcRequest();
                request.ProjectId = projectId;
                request.FileName = fileName;
                request.FileData = ByteString.CopyFrom(fileData);

                UploadPartsRequestGrpcResponse response = await _Client.UploadPartsGrpcAsync(request, cancellationToken: timeoutCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in UploadParts for project: {projectId}, file: {fileName}", ex);
                throw;
            }
        }
        #endregion

        #region Searching part numbers
        public async Task<SearchResultUxModel> SearchEmacsExactCustomerPn(string customerPartNumber)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            await Task.Delay(1);
            try
            {
                // Call FilterRFQByExactCustomerPartNumber
                FilterGrpcResponse response = await FilterByRequestTypeAsync(
                    RfqManagerFilterType.FilterEmacsByExactPartNumber,
                    customerPartNumber
                );

                if (response.Success
                    && response.StringList != null
                    && 0 <= response.StringList.Count)
                {
                    SearchResultUxModel r = response.ToUx();
                    return r;
                }
                else
                {
                    SearchResultUxModel r = new SearchResultUxModel();
                    return r;
                }
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in SearchEmacsExactCustomerPn", ex);
                throw;
            }
        }
        public async Task<SearchResultUxModel> SearchEmacsContainsCustomerPn(string customerPartNumber)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            await Task.Delay(1);
            try
            {
                // Call FilterRFQBySumitomoPartNumber
                FilterGrpcResponse response = await FilterByRequestTypeAsync(
                    RfqManagerFilterType.FilterEmacsByContainingPartNumber,
                    customerPartNumber
                );

                if (response.Success
                    && response.StringList != null
                    && 0 <= response.StringList.Count)
                {
                    SearchResultUxModel r = response.ToUx();
                    return r;
                }
                else
                {
                    SearchResultUxModel r = new SearchResultUxModel();
                    return r;
                }
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in SearchEmacsContainsCustomerPn", ex);
                throw;
            }
        }
        public async Task<SearchResultUxModel> SearchAdssSewsePn(string sewsePartNumber)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            await Task.Delay(1);
            try
            {
                // Call FilterRFQBySumitomoPartNumber
                FilterGrpcResponse response = await FilterByRequestTypeAsync(
                    RfqManagerFilterType.FilterAdssBySumitomoPartNumber,
                    sewsePartNumber
                );

                if (response.Success
                    && response.StringList != null
                    && 0 <= response.StringList.Count)
                {
                    SearchResultUxModel r = response.ToUx();
                    return r;
                }
                else
                {
                    SearchResultUxModel r = new SearchResultUxModel();
                    return r;
                }
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in SearchAdssSewsePn", ex);
                throw;
            }
        }
        public async Task<SearchResultUxModel> SearchNprSewsePn(string sewsePartNumber)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            await Task.Delay(1);
            try
            {
                // Call FilterRFQBySumitomoPartNumber
                FilterGrpcResponse response = await FilterByRequestTypeAsync(
                    RfqManagerFilterType.FilterNPRBySumitomoPartNumber,
                    sewsePartNumber
                );

                if (response.Success
                    && response.StringList != null
                    && 0 <= response.StringList.Count)
                {
                    SearchResultUxModel r = response.ToUx();
                    return r;
                }
                else
                {
                    SearchResultUxModel r = new SearchResultUxModel();
                    return r;
                }
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in SearchNprSewsePn", ex);
                throw;
            }
        }
        #endregion

        #region Filtering
        // implement call to filtering service here FilterRfqGrpc
        public async Task<FilterGrpcResponse> FilterGrpcAsync(
            FilterGrpcRequest request,
            CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            try
            {
                FilterGrpcResponse response = await _Client.FilterGrpcAsync(request, cancellationToken: combinedCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in FilterGrpc", ex);
                throw;
            }
        }

        public async Task<FilterGrpcResponse> FilterByRequestTypeAsync(
            RfqManagerFilterType requestType,
            string? stringValue = null,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                throw new ArgumentNullException(nameof(stringValue), "stringValue cannot be null or empty for this rfqRequestsForRfqNumber type.");
            }

            FilterGrpcRequest request = new FilterGrpcRequest();
            request.FilterRequest = new FilterRequestType();
            request.FilterRequest.RequestType = (int)requestType;
            request.StringValue = stringValue;

            return await FilterGrpcAsync(request, cancellationToken);
        }
        #endregion

        #region FileUploads
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
                request.FileData = ByteString.CopyFrom(fileData);

                FileUploadResponse response = await _Client.UploadFileAsync(request, cancellationToken: combinedCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in UploadFile for file: {fileName}", ex);
                throw;
            }
        }
        #endregion

        #region Part alternatives
        public async Task<int> GetAllAlternativePartsAsync(int position = 0, int take = -1)
        {
            // take == -1 means get all
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                // Check if cache is valid
                bool cacheIsEmpty = _AlternativeParts.Count == 0;
                bool parametersChanged = position != _AlternativePartsPosition || take != _AlternativePartsTake;

                if (cacheIsEmpty || parametersChanged)
                {
                    _Logger?.GenericLogInformation(
                        $"RfqUxClientService.GetAllAlternativePartsAsync loading alternative parts " +
                        $"(position={position}, take={take}, reason={(cacheIsEmpty ? "cache empty" : "parameters changed")})");

                    Stopwatch stopwatch = Stopwatch.StartNew();

                    // Fetch from server
                    GetAllAlternativePartsGrpcRequest request = new GetAllAlternativePartsGrpcRequest();
                    request.Position = position;
                    request.Take = take;

                    GetAllAlternativePartsGrpcResponse response = await _Client.GetAllAlternativePartsGrpcAsync(request, cancellationToken: timeoutCts.Token);

                    stopwatch.Stop();
                    _Logger?.GenericLogInformation(
                        $"... received {response.AlternativeParts.Count} parts in {stopwatch.ElapsedMilliseconds}ms");

                    // Update cache
                    _AlternativeParts.Clear();
                    foreach (RfqAlternativePartsGrpc? part in response.AlternativeParts)
                    {
                        AlternativePartUxModel uxModel = part.ToUx();
                        if (uxModel != null)
                        {
                            _AlternativeParts.Add(uxModel);
                        }
                    }

                    // Update cached parameters
                    _AlternativePartsPosition = position;
                    _AlternativePartsTake = take;
                }
                else
                {
                    _Logger?.GenericLogInformation(
                        $"RfqUxClientService.GetAllAlternativePartsAsync using cached data " +
                        $"({_AlternativeParts.Count} parts, position={position}, take={take})");
                }

                return _AlternativeParts.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetAllAlternativePartsGrpcAsync", ex);
                throw;
            }
        }
        public void ClearAlternativePartsCache()
        {
            _AlternativeParts.Clear();
            _AlternativePartsPosition = 0;
            _AlternativePartsTake = -1;
            _Logger?.GenericLogInformation("Alternative parts cache cleared");
        }

        // Add method to check if cache is valid
        public bool IsAlternativePartsCacheValid(int position, int take)
        {
            return 0 <= _AlternativeParts.Count
                && _AlternativePartsPosition == position
                && _AlternativePartsTake == take;
        }
        public async Task<PartInfoUxModel> GetPartInfoAsync(string partNumber)
        {
            await Task.Delay(1);
            PartInfoUxModel part = new PartInfoUxModel(partNumber);
            return part;
        }
        #endregion

        #region NPR Requests (JSON file persistence - debug/test)
        // In the NPR Request Sets region of RfqUxClientService:
        #region Testing
        async Task<List<RfqNprRequestUxModel>> LoadNprRequestsFromFileAsync()
        {
            List<RfqNprRequestUxModel> list = new List<RfqNprRequestUxModel>();
            try
            {
                if (!File.Exists(_NprRequestSetsFilePath))
                {
                    _Logger?.GenericLogInformation($"NPR file not found at {_NprRequestSetsFilePath}, returning empty list");
                    return list;
                }

                string json = await File.ReadAllTextAsync(_NprRequestSetsFilePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return list;
                }

                List<RfqNprRequestUxModel>? result = JsonSerializer.Deserialize<List<RfqNprRequestUxModel>>(json, _JsonOptions);

                return result ?? list;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error loading NPR requests from file: {_NprRequestSetsFilePath}", ex);
                throw;
            }
        }

        async Task SaveNprRequestsToFileAsync(List<RfqNprRequestUxModel> requests)
        {
            try
            {
                string? directory = Path.GetDirectoryName(_NprRequestSetsFilePath);

                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    _Logger?.GenericLogInformation($"Created directory: {directory}");
                }

                // Mark all as Read (persisted) before saving
                foreach (RfqNprRequestUxModel request in requests)
                {
                    request.UxStatus = UxObjectStatus.Read;
                }

                string json = JsonSerializer.Serialize(requests, _JsonOptions);
                await File.WriteAllTextAsync(_NprRequestSetsFilePath, json);

                _Logger?.GenericLogInformation($"Saved {requests.Count} NPR requests to {_NprRequestSetsFilePath}");
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error saving NPR requests to file: {_NprRequestSetsFilePath}", ex);
                throw;
            }
        }

        async Task SyncNprCacheFromFileAsync()
        {
            List<RfqNprRequestUxModel> requests = await LoadNprRequestsFromFileAsync();

            _NprRequests.Clear();
            _NprRequests.AddRange(requests);
            foreach (RfqNprRequestUxModel request in requests)
            {
                request.UxStatus = UxObjectStatus.Read;
            }
        }

        async Task SyncNprCacheToFileAsync()
        {
            await SaveNprRequestsToFileAsync(_NprRequests);
        }
        #endregion

        async Task<bool> CreateNpr(List<RfqNprRequestUxModel> list)
        {
            CreateRfqNprRequestGrpcRequest createRequest = new CreateRfqNprRequestGrpcRequest();
            foreach (RfqNprRequestUxModel model in list)
            {
                RfqNprRequestGrpc grpc = model.ToNprGrpc();
                grpc.IsActive = true;
                createRequest.RfqNprRequestGrpc.Add(grpc);
            }

            CreateRfqNprRequestGrpcResponse response = await _Client.CreateRfqNprRequestGrpcAsync(createRequest);
            _Logger?.GenericLogInformation($"{response.Message}");
            return response.Success;
        }
        async Task<bool> UpdateNpr(List<RfqNprRequestUxModel> list)
        {
            UpdateRfqNprRequestGrpcRequest updateRequest = new UpdateRfqNprRequestGrpcRequest();
            foreach (RfqNprRequestUxModel model in list)
            {
                RfqNprRequestGrpc grpc = model.ToNprGrpc();
                grpc.IsActive = true;
                updateRequest.RfqNprRequestGrpc.Add(grpc);
            }

            UpdateRfqNprRequestGrpcResponse response = await _Client.UpdateRfqNprRequestGrpcAsync(updateRequest);
            _Logger?.GenericLogInformation($"{response.Message}");
            return response.Success;
        }
        async Task<List<RfqNprRequestUxModel>> LoadNprRequestsFromDatabaseAsync()
        {
            List<RfqNprRequestUxModel> list = new List<RfqNprRequestUxModel>();
            try
            {
                GetAllRfqNprRequestGrpcRequest request = new GetAllRfqNprRequestGrpcRequest();

                GetAllRfqNprRequestGrpcResponse response = await _Client.GetAllRfqNprRequestGrpcAsync(request);

                foreach (RfqNprRequestGrpc? nprRequest in response.RfqNprRequestGrpcs)
                {
                    RfqNprRequestUxModel model = nprRequest.ToNprUx();
                    list.Add(model);
                }

                return list;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error loading NPR requests from file: {_NprRequestSetsFilePath}", ex);
                throw;
            }
        }
        async Task SaveNprRequestsToDatabaseAsync(List<RfqNprRequestUxModel> requests)
        {
            try
            {
                List<RfqNprRequestUxModel> createList = new List<RfqNprRequestUxModel>();
                List<RfqNprRequestUxModel> updateList = new List<RfqNprRequestUxModel>();

                foreach (RfqNprRequestUxModel model in requests)
                {
                    if (_NprRequests.Contains(model))
                    {
                        updateList.Add(model);
                    }
                    else
                    {
                        createList.Add(model);
                    }
                }

                if(0 < createList.Count)
                {
                    bool success = await CreateNpr(createList);
                }

                if(0 < updateList.Count)
                {
                    bool success = await UpdateNpr(updateList);
                }
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error saving NPR requests to file: {_NprRequestSetsFilePath}", ex);
                throw;
            }
        }
        async Task SyncNprCacheFromDatabaseAsync()
        {
            List<RfqNprRequestUxModel> requests = await LoadNprRequestsFromDatabaseAsync();

            _NprRequests.Clear();
            _NprRequests.AddRange(requests);
            foreach (RfqNprRequestUxModel request in requests)
            {
                request.UxStatus = UxObjectStatus.Read;
            }
        }
        async Task SyncNprCacheToDatabaseAsync()
        {
            await SaveNprRequestsToDatabaseAsync(_NprRequests);
        }
        async Task SyncNprCacheToDataSource()
        {
            if (_Testing)
            {
                await SyncNprCacheToFileAsync();
            }
            else
            {
                await SyncNprCacheToDatabaseAsync();
            }
        }
        async Task SyncNprCacheFromDataSource()
        {
            if (_Testing)
            {
                await SyncNprCacheFromFileAsync();
            }
            else
            {
                await SyncNprCacheFromDatabaseAsync();
            }
        }

        // --- NPR Request CRUD ---

        public async Task<int> GetAllNprRequestsAsync()
        {
            try
            {
                await SyncNprCacheFromDataSource();

                return _NprRequests.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError("Error in GetAllNprRequestsAsync", ex);
                throw;
            }
        }
        public async Task<List<RfqNprRequestUxModel>?> GetNprRequestsByRfqProjectIdAsync(Guid rfqProjectId)
        {
            try
            {
                await SyncNprCacheFromDataSource();

                List<RfqNprRequestUxModel> matching = _NprRequests
                    .Where(r => r.Id == rfqProjectId)
                    .ToList();

                if (matching.Count == 0)
                {
                    _Logger?.GenericLogInformation($"No NPR requests found for RfqNumber: {rfqProjectId}");
                    return null;
                }

                return matching;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetNprRequestsByRfqProjectIdAsync for RfqNumber: {rfqProjectId}", ex);
                throw;
            }
        }
        public async Task<List<RfqNprRequestUxModel>?> GetNprRequestsByRfqNumberAsync(string? rfqNumber)
        {
            try
            {
                await SyncNprCacheFromDataSource();

                List<RfqNprRequestUxModel> matching = _NprRequests
                    .Where(r => r.RfqNumber?.ToUpperInvariant().Trim() == rfqNumber?.ToUpperInvariant().Trim())
                    .ToList();

                if (matching.Count == 0)
                {
                    _Logger?.GenericLogInformation($"No NPR requests found for RfqNumber: {rfqNumber}");
                    return null;
                }

                return matching;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetNprRequestsByRfqNumberAsync for RfqNumber: {rfqNumber}", ex);
                throw;
            }
        }
        public async Task<RfqNprRequestUxModel?> GetNprRequestByIdAsync(Guid nprRequestId)
        {
            try
            {
                await SyncNprCacheFromDataSource();

                RfqNprRequestUxModel? nprRequest = _NprRequests.FirstOrDefault(s => s.Id == nprRequestId);

                if (nprRequest == null)
                {
                    _Logger?.GenericLogInformation($"NPR rfqRequestsForRfqNumber nprRequest not found for Id: {nprRequestId}");
                    return null;
                }

                return nprRequest;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError(
                    $"Error in GetNprRequestByIdAsync for SetId: {nprRequestId}", ex);
                throw;
            }
        }
        public async Task<List<RfqNprRequestUxModel>> CreateNprRequestsAsync(List<RfqNprRequestUxModel> nprRequests)
        {
            ArgumentNullException.ThrowIfNull(nprRequests);

            try
            {
                await SyncNprCacheFromDataSource();

                DateTime created = DateTime.UtcNow;
                foreach (RfqNprRequestUxModel request in nprRequests)
                {
                    request.Created = created;
                    request.Updated = created;
                    request.UxStatus = UxObjectStatus.Created;
                }

                _NprRequests.AddRange(nprRequests);

                await SyncNprCacheToDataSource();

                _Logger?.GenericLogInformation($"Created {nprRequests.Count} NPR requests");

                return nprRequests;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in CreateNprRequestsAsync", ex);
                throw;
            }
        }

        //public async Task<List<RfqNprRequestUxModel>> UpdateNprRequestsAsync(List<RfqNprRequestUxModel> updatedRequests)
        //{
        //    ArgumentNullException.ThrowIfNull(updatedRequests);

        //    try
        //    {
        //        await SyncNprCacheFromFileAsync();

        //        foreach (RfqNprRequestUxModel updatedRequest in updatedRequests)
        //        {
        //            int index = _NprRequests.FindIndex(r => r.Id == updatedRequest.Id);

        //            if (0 < index)
        //            {
        //                updatedRequest.Updated = DateTime.UtcNow;
        //                updatedRequest.UxStatus = UxObjectStatus.Updated;
        //                _NprRequests[index] = updatedRequest;
        //            }
        //            else if (updatedRequest.UxStatus == UxObjectStatus.Created)
        //            {
        //                // New rfqRequestsForRfqNumber added in the dialog
        //                updatedRequest.Updated = DateTime.UtcNow;
        //                _NprRequests.Add(updatedRequest);
        //            }
        //        }

        //        // Remove deleted requests
        //        _NprRequests.RemoveAll(r => r.UxStatus == UxObjectStatus.Deleted);

        //        await SyncNprCacheToFileAsync();

        //        string rfqNumber = updatedRequests.FirstOrDefault()?.RfqNumber ?? "(unknown)";
        //        _Logger?.GenericLogInformation($"Updated NPR requests for RfqNumber: {rfqNumber}, count: {updatedRequests.Count}");

        //        List<RfqNprRequestUxModel> updatedNprRequests = _NprRequests.Where(r => r.RfqNumber == rfqNumber).ToList();

        //        return updatedNprRequests;
        //    }
        //    catch (Exception ex)
        //    {
        //        _Logger?.GenericLogError($"Error in UpdateNprRequestsAsync", ex);
        //        throw;
        //    }
        //}
        public async Task<List<RfqNprRequestUxModel>> UpdateNprRequestsAsync(List<RfqNprRequestUxModel> updatedRequests)
        {
            ArgumentNullException.ThrowIfNull(updatedRequests);

            try
            {
                await SyncNprCacheFromFileAsync();

                // Validate all requests exist in the cache
                foreach (RfqNprRequestUxModel request in updatedRequests)
                {
                    RfqNprRequestUxModel? existing = _NprRequests.FirstOrDefault(r => r.Id == request.Id);
                    if (existing == null)
                    {
                        throw new InvalidOperationException(
                            $"NPR request not found for Id: {request.Id}, RfqNumber: {request.RfqNumber}");
                    }
                }

                // Replace each existing request with the updated version
                DateTime now = DateTime.UtcNow;
                foreach (RfqNprRequestUxModel request in updatedRequests)
                {
                    int index = _NprRequests.FindIndex(r => r.Id == request.Id);
                    request.Updated = now;
                    request.UxStatus = UxObjectStatus.Updated;
                    _NprRequests[index] = request;
                }

                await SyncNprCacheToDataSource();

                _Logger?.GenericLogInformation(
                    $"Updated {updatedRequests.Count} NPR requests");

                return updatedRequests;
            }
            catch (InvalidOperationException)
            {
                throw; // re-throw validation errors
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in UpdateNprRequestsAsync", ex);
                throw;
            }
        }
        public async Task<bool> DeleteNprRequestAsync(Guid requestId)
        {
            try
            {
                await SyncNprCacheFromDataSource();

                RfqNprRequestUxModel? request = _NprRequests.FirstOrDefault(r => r.Id == requestId);

                if (request == null)
                {
                    _Logger?.GenericLogInformation($"NPR rfqRequestsForRfqNumber not found for deletion, Id: {requestId}");
                    return false;
                }

                _NprRequests.Remove(request);

                await SyncNprCacheToDataSource();

                _Logger?.GenericLogInformation($"Deleted NPR rfqRequestsForRfqNumber Id: {requestId}");

                return true;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in DeleteNprRequestAsync for Id: {requestId}", ex);
                throw;
            }
        }

        public async Task<bool> DeleteNprRequestsByRfqNumberAsync(string rfqNumber)
        {
            try
            {
                await SyncNprCacheFromDataSource();

                List<RfqNprRequestUxModel>? rfqRequestsForRfqNumber
                    = _NprRequests.Where(r => r.RfqNumber == rfqNumber).ToList();

                if (rfqRequestsForRfqNumber == null || rfqRequestsForRfqNumber.Count <= 0)
                {
                    _Logger?.GenericLogInformation($"NPR rfqRequestsForRfqNumber not found for deletion, Id: {rfqNumber}");
                    return false;
                }

                foreach (RfqNprRequestUxModel rfqRequest in rfqRequestsForRfqNumber)
                {
                    _NprRequests.Remove(rfqRequest);
                }

                await SyncNprCacheToDataSource();

                _Logger?.GenericLogInformation($"Deleted NPR rfqRequestsForRfqNumber Id: {rfqNumber}");

                return true;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in DeleteNprRequestsByRfqNumberAsync for Id: {rfqNumber}", ex);
                throw;
            }
        }
        public async Task<bool> DeleteAllNprRequestsAsync()
        {
            try
            {
                await SyncNprCacheFromDataSource();

                int count = _NprRequests.Count;

                if (count == 0)
                {
                    _Logger?.GenericLogInformation("No NPR requests to delete");
                    return false;
                }

                _NprRequests.Clear();

                await SyncNprCacheToDataSource();

                _Logger?.GenericLogInformation($"Deleted all {count} NPR requests");

                return true;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError("Error in DeleteAllNprRequestsAsync", ex);
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
        #endregion

#pragma warning restore CA1002 // Do not expose generic lists

    }
}