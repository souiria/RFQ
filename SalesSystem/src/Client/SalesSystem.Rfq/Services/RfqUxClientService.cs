namespace SalesSystem.Rfq.Services
{
    public class RfqUxClientService : IDisposable
    {
        #region Definitions
        readonly GrpcChannel _Channel;
        readonly RfqModule.RfqModule.RfqModuleClient _Client;
        readonly ILogger<RfqUxClientService>? _Logger;
        readonly TimeSpan _Timeout;
        bool _Disposed;

        // Cached Data
        List<RfqDrawingPartNumberUx?> _RfqDrawingPartNumbers;
        List<RfqProject> _RfqProjects;
        List<RfqProjectUx> _RfqProjectUxs;
        List<CustomerUx?> _Customers;
        List<RfqReasonGrpc> _Reasons;
        List<ProjectAssociationUx> _CustomerProjectAssociations;
        List<string> _QuotationNumbers;
        List<AlternativePartUxModel> _AlternativeParts;

        // Cached data accessors
        public IReadOnlyCollection<RfqDrawingPartNumberUx?> RfqDrawingPartNumbers => _RfqDrawingPartNumbers.AsReadOnly();
        public IReadOnlyCollection<RfqProject> RfqProjects => _RfqProjects.AsReadOnly();
        public IReadOnlyCollection<RfqProjectUx> RfqProjectUxs => _RfqProjectUxs.AsReadOnly(); // only active projects are here
        public IReadOnlyCollection<CustomerUx?> Customers => _Customers.AsReadOnly();
        public IReadOnlyCollection<RfqReasonGrpc> Reasons => _Reasons.AsReadOnly();
        public IReadOnlyCollection<ProjectAssociationUx> CustomerProjectAssociations => _CustomerProjectAssociations.AsReadOnly();
        public IReadOnlyCollection<string> QuotationNumbers => _QuotationNumbers.AsReadOnly();
        public IReadOnlyCollection<AlternativePartUxModel> AlternativeParts => _AlternativeParts.AsReadOnly();
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
            _RfqProjects = new();
            _RfqProjectUxs = new();
            _Logger = logger;
            _Customers = new();
            _Reasons = new();
            _CustomerProjectAssociations = new();
            _QuotationNumbers= new()
            {
                "SEWS-25-025-005678",
                "SEWS-25-025-005688",
                "SEWS-25-025-005692"
            };
            _RfqDrawingPartNumbers= new();
            _AlternativeParts= new();
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
                List<CustomerUx?> orderedCustomers = response.Customers.Select(x => x.ToUx()).OrderBy(x => x?.CustomerBusinessGroupName).ToList();
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
                _RfqProjects.Clear();
                _RfqProjects.AddRange(response.RfqProjects);
                // ux list
                _RfqProjectUxs.Clear();
                foreach (RfqProject? rfqProject in _RfqProjects)
                {
                    if(rfqProject.IsActive.HasValue && !rfqProject.IsActive.Value)
                    {
                        continue; // skip inactive projects
                    }

                    RfqProjectUx? uxModel = rfqProject.ToUx();
                    if (null != uxModel)
                    {
                        _RfqProjectUxs.Add(uxModel);
                    }
                }

                return _RfqProjects.Count;
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
        public async Task<UpdateRfqProjectGrpcResponse> UpdateRfqProjectAsync(RfqProjectUx project)
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
                    ProjectAssociationUx? projectAssociation = association.ToUx();
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
                if(null != response && 0 <= response.Parts.Count) 
                {
                    List<RfqDrawingPartNumberUx?> uxs = response.Parts.Select(x => x.ToUx()).ToList();
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
        public async Task<UpdateRfqDrawingPartNumbersGrpcResponse> UpdateRfqDrawingPartNumbersAsync(IEnumerable<RfqDrawingPartNumberUx?> parts)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            List<RfqDrawingPartNumber> partsDto = new List<RfqDrawingPartNumber>();
            foreach (RfqDrawingPartNumberUx? part in parts)
            {
                if (part != null)
                {
                    RfqDrawingPartNumber dto = part.ToDto();
                    partsDto.Add(dto);
                }
            }

            try
            {
                // Build the request
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
        public async Task<bool> UpdateRfqDrawingPartNumber(RfqDrawingPartNumberUx partNumberUx)
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
        public async Task<bool> DeleteRfqDrawingPartNumber(RfqDrawingPartNumberUx partNumberUx)
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
        #endregion

        #region Searching part numbers
        public async Task<SearchResultUx> SearchEmacsExactCustomerPn(string customerPartNumber)
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
                    SearchResultUx r = response.ToUx();
                    return r;
                }
                else
                {
                    SearchResultUx r = new SearchResultUx();
                    return r;
                }
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in SearchEmacsExactCustomerPn", ex);
                throw;
            }
        }
        public async Task<SearchResultUx> SearchEmacsContainsCustomerPn(string customerPartNumber)
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
                    SearchResultUx r = response.ToUx();
                    return r;
                }
                else
                {
                    SearchResultUx r = new SearchResultUx();
                    return r;
                }
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in SearchEmacsContainsCustomerPn", ex);
                throw;
            }
        }
        public async Task<SearchResultUx> SearchAdssSewsePn(string sewsePartNumber)
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
                    SearchResultUx r = response.ToUx();
                    return r;
                }
                else
                {
                    SearchResultUx r = new SearchResultUx();
                    return r;
                }
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in SearchAdssSewsePn", ex);
                throw;
            }
        }
        public async Task<SearchResultUx> SearchNprSewsePn(string sewsePartNumber)
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
                    SearchResultUx r = response.ToUx();
                    return r;
                }
                else
                {
                    SearchResultUx r = new SearchResultUx();
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
            if(string.IsNullOrEmpty(stringValue))
            {
                throw new ArgumentNullException(nameof(stringValue), "stringValue cannot be null or empty for this request type.");
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
        public async Task<int> GetAllAlternativePartsAsync()
        {
            //await Task.Delay(1);
            //List<AlternativePartUxModel> parts;
            //parts = AlternativePartUxModel.GenerateRandomList(); //= new List<AlternativePartUxModel>();
            //return parts;
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                GetAllAlternativePartsGrpcRequest request = new GetAllAlternativePartsGrpcRequest();
                request.Position = 0;
                request.Take = 0;

                GetAllAlternativePartsGrpcResponse response = await _Client.GetAllAlternativePartsGrpcAsync(request, cancellationToken: timeoutCts.Token);

                // ux list
                _AlternativeParts.Clear();
                foreach (RfqAlternativePartsGrpc? part in response.AlternativeParts)
                {
                    if (0.0 <= part.Price && !string.IsNullOrWhiteSpace(part.SumitomoNumber))
                    {
                        continue; // skip parts with no price or empty number
                    }

                    AlternativePartUxModel? uxModel = part.ToUx();
                    if (null != uxModel)
                    {
                        _AlternativeParts.Add(uxModel);
                    }
                }

                return _AlternativeParts.Count;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetAllAlternativePartsGrpcAsync ", ex);
                throw;
            }
        }
        public async Task<PartInfoUxModel> GetPartInfoAsync(string partNumber)
        {
            await Task.Delay(1);
            PartInfoUxModel part = new PartInfoUxModel(partNumber);
            return part;
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
    }
}