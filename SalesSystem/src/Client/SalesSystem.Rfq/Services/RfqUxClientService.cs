using NPR;
using NprApiDataGrpc = RfqModule.NprApiDataGrpc;
using RfqNprRequestGrpc = RfqShared.RfqNprRequestGrpc;
using RFQStatusGrpc = RfqModule.RFQStatusGrpc;

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
        List<RfqProjectUxModel> _RfqProjectUxs;
        List<CustomerUxModel?> _Customers;
        List<RfqReasonGrpc> _Reasons;
        List<RfqCustomerProjectAssociationUxModel> _CustomerProjectAssociations;
        List<string> _QuotationNumbers;
        List<SupplierUxModel> _Suppliers;
        List<SupplierGroupUxModel> _SupplierGroups;
        List<UnitOfMeasureUxModel> _UnitOfMeasures;
        List<BusinessUnitUxModel> _BusinessUnits;
        // AlternativeParts
        List<AlternativePartUxModel> _AlternativeParts;
        int _AlternativePartsTake;
        int _AlternativePartsPosition;

        // NPR Request cached data
        List<RfqNprRequestUxModel> _NprRequests;
        // track changes in UX
        bool _NprRequestsHasChanges;
        List<RFQStatusGrpc> _RFQStatuses;

        public bool NprRequestsHasChanges
        {
            get
            {
                bool someUpdates = _NprRequests?.Any(r => r.UxStatus == UxObjectStatus.Updated) ?? false;
                return someUpdates || _NprRequestsHasChanges;
            }
        }

        // Cached data accessors
        public IReadOnlyCollection<RfqDrawingPartNumberUxModel?> RfqDrawingPartNumbers => _RfqDrawingPartNumbers.AsReadOnly();
        public IReadOnlyCollection<RfqProjectUxModel> RfqProjectUxs => _RfqProjectUxs.AsReadOnly(); // only active projects are here
        public IReadOnlyCollection<CustomerUxModel?> Customers => _Customers.AsReadOnly();
        public IReadOnlyCollection<RfqReasonGrpc> Reasons => _Reasons.AsReadOnly();
        public IReadOnlyCollection<RfqCustomerProjectAssociationUxModel> CustomerProjectAssociations => _CustomerProjectAssociations.AsReadOnly();
        public IReadOnlyCollection<string> QuotationNumbers => _QuotationNumbers.AsReadOnly();
        public IReadOnlyCollection<AlternativePartUxModel> AlternativeParts => _AlternativeParts.AsReadOnly();
        public IReadOnlyCollection<RfqNprRequestUxModel> NprRequests => _NprRequests.AsReadOnly();
        public IReadOnlyCollection<RFQStatusGrpc> RFQStatuses => _RFQStatuses.AsReadOnly();
        #endregion

        #region Ctor
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public RfqUxClientService(IConfiguration configuration, ILogger<RfqUxClientService> logger)
        {
            _Logger = logger;

            string serviceUrl = configuration["GrpcService:Url"] ?? "GrpcService:Core-Url is missing in configuration.";
            int timeoutSeconds = configuration.GetValue("GrpcService:TimeoutSeconds", 600);
            _Timeout = TimeSpan.FromSeconds(timeoutSeconds);
            _MAX_GRPC_RESPONSE_SIZE = 64 * 1024 * 1024;

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
            _Suppliers = new();
            _SupplierGroups = new();
            _NprRequestsHasChanges = false;
            _UnitOfMeasures = new();
            _BusinessUnits = new();
            _RFQStatuses = new();

            _Logger.GenericLogInformation($">>> RfqUxClientService was created with storage via GRPC endpoints");
        }
        #endregion

        #region Hello Service
        public async Task<CommonTypes.HelloReply> SayHelloAsync(string name, CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            try
            {
                CommonTypes.HelloRequest request = new CommonTypes.HelloRequest();
                request.Name = name;

                CommonTypes.HelloReply response = await _Client.SayHelloAsync(request, cancellationToken: combinedCts.Token);

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

                _RfqProjectUxs.Clear();
                IOrderedEnumerable<RfqProject> rfqProjects = response.RfqProjects.OrderByDescending(x => x.RfqNumber);
                foreach (RfqProject? rfqProject in rfqProjects)
                {
                    if (rfqProject.IsActive.HasValue && !rfqProject.IsActive.Value)
                    {
                        continue; // skip inactive projects
                    }

                    RfqProjectUxModel? uxModel = rfqProject.ToUx();
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
        public async Task<UpdateRfqProjectGrpcResponse> UpdateRfqProjectAsync(RfqProjectUxModel project)
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
                    RfqCustomerProjectAssociationUxModel? projectAssociation = association.ToUx();
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
                RfqDrawingPartNumbersGrpcRequest request = new RfqDrawingPartNumbersGrpcRequest();
                request.RfqId = rfqId;

                ListRfqDrawingPartNumberGrpc response = await _Client.GetRfqDrawingPartNumbersByRfqIdGrpcAsync(request, cancellationToken: timeoutCts.Token);
                _RfqDrawingPartNumbers.Clear();
                if (null != response && 0 <= response.RfqDrawingPartNumbers.Count)
                {
                    List<RfqDrawingPartNumberUxModel?> uxs = response.RfqDrawingPartNumbers.Select(x => x.ToUx()).ToList();
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
        public async Task<RfqCrudResponse> UpdateRfqDrawingPartNumbersAsync(IEnumerable<RfqDrawingPartNumberUxModel> parts)
        {
            if (parts == null || !parts.Any())
            {
                _Logger?.GenericLogInformation("EEE UpdateRfqDrawingPartNumbersAsync called with null or empty parts list");
                return new RfqCrudResponse { SaveSuccess = false, Message = "No parts to update (client side call check)!" };
            }

            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            List<RfqDrawingPartNumberGrpc> partsDto = new List<RfqDrawingPartNumberGrpc>();
            foreach (RfqDrawingPartNumberUxModel part in parts)
            {
                if (part != null)
                {
                    RfqDrawingPartNumberGrpc dto = part.ToDto();
                    partsDto.Add(dto);
                }
            }

            try
            {
                RfqDrawingPartNumbersGrpcRequest request = new RfqDrawingPartNumbersGrpcRequest();
                request.RfqDrawingPartNumbersGrpcsToUpdate.AddRange(partsDto);

                RfqCrudResponse response =
                    await _Client.UpdateRfqDrawingPartNumbersGrpcAsync(request, cancellationToken: timeoutCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError("Error in UpdateRfqDrawingPartNumbersAsync", ex);
                throw;
            }
        }
        // !!!Check this!!!
        public async Task<bool> UpdateRfqDrawingPartNumber(RfqDrawingPartNumberUxModel partNumberUx)
        {
            if (partNumberUx == null)
            {
                _Logger?.GenericLogInformation("EEE UpdateRfqDrawingPartNumber called with null partNumberUx");
                return false;
            }

            List<RfqDrawingPartNumberUxModel> partList = new List<RfqDrawingPartNumberUxModel> { partNumberUx };
            RfqCrudResponse result = await UpdateRfqDrawingPartNumbersAsync(partList);

            return result.SaveSuccess;
        }
        public async Task<bool> DeleteRfqDrawingPartNumbers(List<RfqDrawingPartNumberUxModel> partNumbers)
        {
            if (partNumbers == null || !partNumbers.Any())
            {
                _Logger?.GenericLogInformation("EEE DeleteRfqDrawingPartNumbers called with null list or empty list of parts to delete");
                return false;
            }

            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            try
            {
                List<RfqDrawingPartNumberGrpc> dtos = new();
                dtos.AddRange(partNumbers.Select(x => x.ToDto()));
                RfqDrawingPartNumbersGrpcRequest request = new RfqDrawingPartNumbersGrpcRequest();
                request.RfqDrawingPartNumbersGrpcsToDelete.AddRange(dtos);
                RfqCrudResponse result =
                    await _Client.DeleteRfqDrawingPartNumbersGrpcAsync(request, cancellationToken: timeoutCts.Token);

                _Logger?.GenericLogInformation(
                    $"Deleted {partNumbers.Count} ({result.Message}) part numbers");
                return result.SaveSuccess;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in DeleteRfqDrawingPartNumbers", ex);
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
        public async Task<UploadPartsRequestGrpcResponse> UploadBomFileAsync(string projectId,
                                                                           IBrowserFile file,
                                                                           Guid? userId,
                                                                           long maxAllowedSize = 10_000_000)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                // TBD these should be renamed, as actually they only load BOM files, not parts. But the GRPC service is called UploadPartsGrpcAsync, so we keep the name for now.
                UploadPartsRequestGrpcRequest request = new UploadPartsRequestGrpcRequest();
                request.ProjectId = projectId;
                request.FileName = file.Name;
                request.UserId = userId.ToString();

                using MemoryStream memoryStream = new MemoryStream();
                await file.OpenReadStream(maxAllowedSize: maxAllowedSize).CopyToAsync(memoryStream);
                byte[] fileData = memoryStream.ToArray();

                request.FileData = ByteString.CopyFrom(fileData);

                // TBD the same issue as above, the GRPC service is called UploadPartsGrpcAsync, but it actually uploads a BOM file.  So we keep the name for now.
                UploadPartsRequestGrpcResponse response = await _Client.UploadPartsGrpcAsync(request, cancellationToken: timeoutCts.Token);

                return response;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in UploadParts for project: {projectId}, file: {file.Name}", ex);
                throw;
            }
        }
        // never used, but kept for reference
        //public async Task<UploadPartsRequestGrpcResponse> UploadPartsAsync(string projectId,
        //                                                                   byte[] fileData,
        //                                                                   string fileName,
        //                                                                   Guid? _userId,
        //                                                                   long maxAllowedSize = 16_777_216)
        //{
        //    ArgumentException.ThrowIfNullOrEmpty(projectId);
        //    ArgumentNullException.ThrowIfNull(fileData);
        //    ArgumentException.ThrowIfNullOrEmpty(fileName);
        //    ArgumentOutOfRangeException.ThrowIfGreaterThan(fileData.LongLength, maxAllowedSize);

        //    using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

        //    try
        //    {
        //        UploadPartsRequestGrpcRequest request = new UploadPartsRequestGrpcRequest();
        //        request.ProjectId = projectId;
        //        request.FileName = fileName;
        //        request.FileData = ByteString.CopyFrom(fileData);
        //        request.UserId = _userId.ToString();

        //        UploadPartsRequestGrpcResponse response = await _Client.UploadPartsGrpcAsync(request, cancellationToken: timeoutCts.Token);

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        _Logger?.GenericLogError($"Error in UploadParts for project: {projectId}, file: {fileName}", ex);
        //        throw;
        //    }
        //}
        #endregion

        #region Searching part numbers
        public async Task<SearchResultUxModel> SearchEmacsExactCustomerPn(string customerPartNumber)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            try
            {
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
            try
            {
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
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                FilterGrpcResponse response = await FilterByRequestTypeAsync(
                    RfqManagerFilterType.FilterAdssBySumitomoPartNumber,
                    sewsePartNumber
                );
                sw.Stop();
                _Logger?.GenericLogInformation($">>> RfqUXClient.RfqUxClientService.SearchAdssSewsePn took {sw.ElapsedMilliseconds} ms to retrieve image for {sewsePartNumber}");

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
            try
            {
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
        public async Task<SearchResultUxModel> SearchNprCustomerNumber(string customerNumber)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            try
            {
                FilterGrpcResponse response = await FilterByRequestTypeAsync(
                    RfqManagerFilterType.FilterNPRByCustomerNumber,
                    customerNumber
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
                _Logger?.GenericLogError($"Error in SearchNprCustomerNumber", ex);
                throw;
            }
        }
        // unified Cpn search
        /// <summary>
        /// Calls SearchPartPricesGrpc with a batch of customer part numbers and returns
        /// the full priced result set in one round-trip.  Each <see cref="PriceResponse"/>
        /// entry contains an <c>ExactMatch</c> flag plus one <see cref="PriceInformation"/>
        /// per Sumitomo number / price source combination found.
        /// </summary>
        public async Task<SearchPartPricesGrpcResponse> SearchPartPricesAsync(
            IEnumerable<string> partNumbers,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(partNumbers);

            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
                timeoutCts.Token,
                cancellationToken);

            try
            {
                SearchPartPricesGrpcRequest request = new SearchPartPricesGrpcRequest();
                foreach (string pn in partNumbers)
                {
                    request.PartNumbers.Add(pn);
                }

                _Logger?.GenericLogInformation(
                    $"SearchPartPricesAsync - Requesting prices for {request.PartNumbers.Count} part(s)");

                SearchPartPricesGrpcResponse response = await _Client.SearchPartPricesGrpcAsync(
                    request,
                    cancellationToken: linkedCts.Token);

                _Logger?.GenericLogInformation(
                    $"SearchPartPricesAsync - Received {response.PriceResponse.Count} price response(s)");

                return response;
            }
            catch (OperationCanceledException)
            {
                _Logger?.GenericLogInformation("SearchPartPricesAsync - Operation was cancelled or timed out");
                throw;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError("Error in SearchPartPricesAsync", ex);
                throw;
            }
        }
        #endregion

        #region Filtering
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
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                bool cacheIsEmpty = _AlternativeParts.Count == 0;
                bool parametersChanged = position != _AlternativePartsPosition || take != _AlternativePartsTake;

                if (cacheIsEmpty || parametersChanged)
                {
                    _Logger?.GenericLogInformation(
                        $"RfqUxClientService.GetAllAlternativePartsAsync loading alternative parts " +
                        $"(position={position}, take={take}, reason={(cacheIsEmpty ? "cache empty" : "parameters changed")})");

                    Stopwatch stopwatch = Stopwatch.StartNew();

                    GetAllAlternativePartsGrpcRequest request = new GetAllAlternativePartsGrpcRequest();
                    request.Position = position;
                    request.Take = take;

                    GetAllAlternativePartsGrpcResponse response = await _Client.GetAllAlternativePartsGrpcAsync(request, cancellationToken: timeoutCts.Token);

                    stopwatch.Stop();
                    _Logger?.GenericLogInformation(
                        $"... received {response.AlternativeParts.Count} parts in {stopwatch.ElapsedMilliseconds}ms");

                    _AlternativeParts.Clear();
                    foreach (RfqAlternativePartsGrpc? part in response.AlternativeParts)
                    {
                        AlternativePartUxModel uxModel = part.ToUx();
                        if (uxModel != null)
                        {
                            _AlternativeParts.Add(uxModel);
                        }
                    }

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

        #region NPR Requests (GRPC Endpoints in the RfqManager)

        #region Low Level GRPC Datasource
        async Task<bool> CreateNpr(List<RfqNprRequestUxModel> list)
        {
            CreateRfqNprRequestGrpcRequest createRequest = new CreateRfqNprRequestGrpcRequest();
            foreach (RfqNprRequestUxModel model in list)
            {
                RfqNprRequestGrpc grpc = model.ToNprGrpc();
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
                _Logger?.GenericLogInformation(
                    $"UpdateNpr - Sending Id={model.Id}, RequestID='{model.RequestID}', " +
                    $"CustomerRfqNo='{model.CustomerRfqNo}', UxStatus={model.UxStatus}");

                RfqNprRequestGrpc grpc = model.ToNprGrpc();

                _Logger?.GenericLogInformation(
                    $"UpdateNpr - gRPC Id='{grpc.Id}'");

                updateRequest.RfqNprRequestGrpc.Add(grpc);
            }

            UpdateRfqNprRequestGrpcResponse response = await _Client.UpdateRfqNprRequestGrpcAsync(updateRequest);
            _Logger?.GenericLogInformation($"{response.Message}");
            return response.Success;
        }
        //async Task<bool> UpdateNpr(List<RfqNprRequestUxModel> list)
        //{
        //    UpdateRfqNprRequestGrpcRequest updateRequest = new UpdateRfqNprRequestGrpcRequest();
        //    foreach (RfqNprRequestUxModel model in list)
        //    {
        //        RfqNprRequestGrpc grpc = model.ToNprGrpc();
        //        updateRequest.RfqNprRequestGrpc.Add(grpc);
        //    }

        //    UpdateRfqNprRequestGrpcResponse response = await _Client.UpdateRfqNprRequestGrpcAsync(updateRequest);
        //    _Logger?.GenericLogInformation($"{response.Message}");
        //    return response.Success;
        //}
        async Task<bool> DeleteNpr(List<RfqNprRequestUxModel> list)
        {
            DeleteRfqNprRequestByIdGrpcRequest deleteRequest = new DeleteRfqNprRequestByIdGrpcRequest();

            foreach (RfqNprRequestUxModel model in list)
            {
                RfqNprRequestGrpc grpc = model.ToNprGrpc();
                deleteRequest.RfqNprRequestGrpc.Add(grpc);
            }

            DeleteRfqNprRequestByIdGrpcResponse response = await _Client.DeleteRfqNprRequestByIdGrpcAsync(deleteRequest);
            _Logger?.GenericLogInformation($"DeleteNpr: {response.Message}");
            return response.Success;
        }
        async Task<bool> DeleteNprById(RfqNprRequestUxModel model)
        {
            DeleteRfqNprRequestByIdGrpcRequest deleteRequest = new DeleteRfqNprRequestByIdGrpcRequest();

            RfqNprRequestGrpc grpc = model.ToNprGrpc();
            deleteRequest.RfqNprRequestGrpc.Add(grpc);

            DeleteRfqNprRequestByIdGrpcResponse response = await _Client.DeleteRfqNprRequestByIdGrpcAsync(deleteRequest);
            _Logger?.GenericLogInformation($"DeleteNprById: {response.Message}");
            return response.Success;
        }

#if DEBUG
        // DEBUG: hard-delete via DeleteRfqNprRequestByIdGrpc endpoint
        async Task SaveNprRequestsToDatabaseAsync(List<RfqNprRequestUxModel> requests)
        {
            try
            {
                List<RfqNprRequestUxModel> createList = new List<RfqNprRequestUxModel>();
                List<RfqNprRequestUxModel> updateList = new List<RfqNprRequestUxModel>();
                List<RfqNprRequestUxModel> deleteList = new List<RfqNprRequestUxModel>();

                foreach (RfqNprRequestUxModel model in requests)
                {
             
                    ////  Log values BEFORE save
                    //_Logger?.GenericLogInformation(
                    //    "---------------------------------SaveNprRequestsToDatabaseAsync\n" +
                    //    $"Id: {model.Id}\n" +
                    //    $"CustomerRfqNo: {model.CustomerRfqNo}\n" +
                    //    $"CustomerCode: {model.CustomerCode}\n" +
                    //    $"RequestID: {model.RequestID}\n" +
                    //    $"OriginatorName: {model.OriginatorName}\n" +
                    //    $"DeadlineDate: {model.DeadlineDate}\n" +
                    //    $"ReasonDescription: {model.ReasonDescription}\n" +
                    //    $"MaterialNumber: {model.MaterialNumber}\n" +
                    //    $"MaterialDescription: {model.MaterialDescription}\n" +
                    //    $"CustomerPartNumber: {model.CustomerPartNumber}\n" +
                    //    $"SupplierPartNumber: {model.SupplierPartNumber}\n" +
                    //    $"BOMUnitOfMeasurement: {model.BOMUnitOfMeasurement}\n" +
                    //    $"SupplierGroup: {model.SupplierGroup}\n" +
                    //    $"SupplierDetailComments: {model.SupplierDetailComments}\n" +
                    //    $"ProjectName: {model.ProjectName}\n" +
                    //    $"QtyPerVehicle: {model.QtyPerVehicle}\n" +
                    //    $"IsSampleDataRequired: {model.IsSampleDataRequired}\n" +
                    //    $"SampleSiteDetails Count: {model.SampleSiteDetails.Count}\n" +
                    //    $"NPRRaisedRemarks: {model.NPRRaisedRemarks}\n" +
                    //    $"ManufacturingSite: {model.ManufacturingSite}\n" +
                    //    $"IsCustomerNominatedSupplier: {model.IsCustomerNominatedSupplier}\n" +
                    //    $"IsCustomerNominatedMaterial: {model.IsCustomerNominatedMaterial}\n" +
                    //    $"SuggestedManufacturerGroup: {model.SuggestedManufacturerGroup}\n" +
                    //    $"AssociatedParts: {model.AssociatedParts}\n" +
                    //    $"NPRUploadSeqNo: {model.NPRUploadSeqNo}\n" +
                    //    $"Created: {model.Created}\n" +
                    //    $"Updated: {model.Updated}\n" +
                    //    $"Status: {model.Status}\n" +
                    //    $"UxStatus: {model.UxStatus}\n" +
                    //    $"IsActive: {model.IsActive}\n" +
                    //    $"IsValid: {model.IsValid}\n" +
                    //    $"ErrorCount: {model.ErrorCount}\n" +
                    //    $"Closed: {model.Closed}\n" +
                    //    $"Reason: {model.Reason}\n" +
                    //    "---------------------------------");
                    // Defensive: any malformed Id is an in-memory cache bug — skip & log
                    if (model.Id == Guid.Empty && model.UxStatus != UxObjectStatus.Created)
                    {
                                               _Logger?.GenericLogInformation(
                            $"SaveNprRequestsToDatabaseAsync - Skipping item with empty Id: " +
                            $"RequestID='{model.RequestID}', CustomerRfqNo='{model.CustomerRfqNo}', " +
                            $"UxStatus={model.UxStatus}");
                       continue;
                    }

                    switch (model.UxStatus)
                    {
                        case UxObjectStatus.Created:
                            createList.Add(model);
                            break;
                        case UxObjectStatus.Updated:
                            updateList.Add(model);
                            break;
                        case UxObjectStatus.Deleted:
                            deleteList.Add(model);
                            break;
                        case UxObjectStatus.Read:
                            break;
                    }
                }

                if (0 < createList.Count)
                {
                    bool success = await CreateNpr(createList);
                    _Logger?.GenericLogInformation($"Created {createList.Count} NPR requests, success: {success}");
                }

                if (0 < updateList.Count)
                {
                    bool success = await UpdateNpr(updateList);
                    _Logger?.GenericLogInformation($"Updated {updateList.Count} NPR requests, success: {success}");
                }

                if (0 < deleteList.Count)
                {
                    bool success = await DeleteNpr(deleteList);
                    _Logger?.GenericLogInformation($"Deleted {deleteList.Count} NPR requests, success: {success}");
                }
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error saving NPR requests to database", ex);
                throw;
            }
        }
#else
        // RELEASE: soft-delete via IsActive = false through the Update endpoint
        async Task SaveNprRequestsToDatabaseAsync(List<RfqNprRequestUxModel> requests)
        {
            try
            {
                List<RfqNprRequestUxModel> createList = new List<RfqNprRequestUxModel>();
                List<RfqNprRequestUxModel> updateList = new List<RfqNprRequestUxModel>();

                foreach (RfqNprRequestUxModel model in requests)
                {
                    // Defensive: any malformed Id is an in-memory cache bug — skip & log
                    if (model.Id == Guid.Empty && model.UxStatus != UxObjectStatus.Created)
                    {
                        _Logger?.GenericLogInformation(
                            $"SaveNprRequestsToDatabaseAsync - Skipping item with empty Id: " +
                            $"RequestID='{model.RequestID}', CustomerRfqNo='{model.CustomerRfqNo}', " +
                            $"UxStatus={model.UxStatus}");
                        continue;
                    }

                    switch (model.UxStatus)
                    {
                        case UxObjectStatus.Created:
                            createList.Add(model);
                            break;

                        case UxObjectStatus.Updated:
                            updateList.Add(model);
                            break;

                        case UxObjectStatus.Deleted:
                            // Deleted items go through the update path –
                            // ToNprGrpc() already sets IsActive = false when UxStatus == Deleted
                            updateList.Add(model);
                            break;

                        case UxObjectStatus.Read:
                            // No changes – skip
                            break;
                    }
                }

                if (0 < createList.Count)
                {
                    bool success = await CreateNpr(createList);
                    _Logger?.GenericLogInformation($"Created {createList.Count} NPR requests, success: {success}");
                }

                if (0 < updateList.Count)
                {
                    bool success = await UpdateNpr(updateList);
                    _Logger?.GenericLogInformation($"Updated {updateList.Count} NPR requests (includes soft-deletes), success: {success}");
                }
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error saving NPR requests to database", ex);
                throw;
            }
        }
#endif

        async Task SyncNprCacheFromDatabaseAsync()
        {
            List<RfqNprRequestUxModel> requests = new List<RfqNprRequestUxModel>();
            try
            {
                GetAllRfqNprRequestGrpcRequest request = new GetAllRfqNprRequestGrpcRequest();

                GetAllRfqNprRequestGrpcResponse response = await _Client.GetAllRfqNprRequestGrpcAsync(request);

                foreach (RfqNprRequestGrpc? nprRequest in response.RfqNprRequestGrpcs)
                {
                    RfqNprRequestUxModel model = nprRequest.ToNprUx();
                    requests.Add(model);
                }

                _NprRequests.Clear();
                _NprRequests.AddRange(requests);

                // load once
                if(RFQStatuses.Count == 0)
                {
                    await GetAllRFQStatusAsync();
                }
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error loading NPR requests from database", ex);
                throw;
            }
        }
        async Task SyncNprCacheToDatabaseAsync()
        {
            await SaveNprRequestsToDatabaseAsync(_NprRequests);
        }
        #endregion

        // --- NPR Request CRUD ---
        // on cached list
        public bool DeleteNprRequest(RfqNprRequestUxModel nprRequest)
        {
            RfqNprRequestUxModel? request = _NprRequests.FirstOrDefault(x => x.Id == nprRequest.Id);
            if (request != null)
            {
                if (request.UxStatus == UxObjectStatus.Created)
                {
                    // Never persisted – safe to remove entirely
                    _NprRequests.Remove(request);
                }
                else
                {
                    request.UxStatus = UxObjectStatus.Deleted;
                }

                _NprRequestsHasChanges = true;
                return true;
            }

            return false;
        }

        public bool UnDeleteNprRequest(RfqNprRequestUxModel nprRequest)
        {
            RfqNprRequestUxModel? request = _NprRequests.FirstOrDefault(x => x.Id == nprRequest.Id);
            if (request != null)
            {
                request.UxStatus = UxObjectStatus.Updated;
                _NprRequestsHasChanges = true;
                return true;
            }

            return false;
        }
        public async Task GetAllRFQStatusAsync()
        {
            GetAllRFQStatusGrpcRequest request = new GetAllRFQStatusGrpcRequest();
            RfqModule.ListRFQStatusGrpc response = await _Client.GetAllRFQStatusGrpcAsync(request);
            if(response != null && response.RFQStatusGrpc != null)
            {
                _RFQStatuses.Clear();
                foreach (RFQStatusGrpc status in response.RFQStatusGrpc.ToList())
                {
                    _RFQStatuses.Add(status);
                }
            }
        }
        public async Task<int> GetAllNprRequestsAsync()
        {
            try
            {
                await SyncNprCacheFromDatabaseAsync();
                _NprRequestsHasChanges = false;
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
                await SyncNprCacheFromDatabaseAsync();
                _NprRequestsHasChanges = false;
                List<RfqNprRequestUxModel> matching = _NprRequests
                    .Where(r => r.Id == rfqProjectId)
                    .ToList();

                if (matching.Count == 0)
                {
                    _Logger?.GenericLogInformation($"No NPR requests found for RfqProjectID: {rfqProjectId}");
                    return null;
                }

                return matching;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetNprRequestsByRfqProjectIdAsync for RfqProjectId: {rfqProjectId}", ex);
                throw;
            }
        }
        public async Task<List<RfqNprRequestUxModel>?> GetNprRequestsByRfqNumberAsync(string? rfqNumber)
        {
            try
            {
                await SyncNprCacheFromDatabaseAsync();
                _NprRequestsHasChanges = false;
                List<RfqNprRequestUxModel> matching = _NprRequests
                    .Where(r => r.CustomerRfqNo?.ToUpperInvariant().Trim() == rfqNumber?.ToUpperInvariant().Trim())
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
                if (!_NprRequestsHasChanges && _NprRequests.Count <= 0)
                {
                    await SyncNprCacheFromDatabaseAsync();
                    _NprRequestsHasChanges = false;
                }

                RfqNprRequestUxModel? nprRequest = _NprRequests.FirstOrDefault(s => s.Id == nprRequestId);

                if (nprRequest == null)
                {
                    _Logger?.GenericLogInformation($"NPR request not found for Id: {nprRequestId}");
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
                if (!_NprRequestsHasChanges && _NprRequests.Count <= 0)
                {
                    await SyncNprCacheFromDatabaseAsync();
                    _NprRequestsHasChanges = false;
                }

                DateTime created = DateTime.UtcNow;
                foreach (RfqNprRequestUxModel request in nprRequests)
                {
                    request.Created = created;
                    request.Updated = created;
                    request.UxStatus = UxObjectStatus.Created;
                }

                _NprRequests.AddRange(nprRequests);

                // sync
                await SyncNprCacheToDatabaseAsync();
                await SyncNprCacheFromDatabaseAsync();

                _NprRequestsHasChanges = false;

                _Logger?.GenericLogInformation($"Created {nprRequests.Count} NPR requests");

                return nprRequests;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in CreateNprRequestsAsync", ex);
                throw;
            }
        }
        public async Task<List<RfqNprRequestUxModel>> UpdateNprRequestsAsync(List<RfqNprRequestUxModel>? updatedRequests)
        {
            // full sync (only from AdminTool) — null means "push all cached changes"
            if (NprRequestsHasChanges && updatedRequests == null)
            {
                try
                {
                    await SyncNprCacheToDatabaseAsync();
                    await SyncNprCacheFromDatabaseAsync();
                    _NprRequestsHasChanges = false;
                }
                catch (InvalidOperationException) 
                { 
                    throw; 
                }
                catch (Exception ex)
                {
                    _Logger?.GenericLogError($"Error in UpdateNprRequestsAsync", ex);
                    throw;
                }

                return _NprRequests;
            }

            // null without pending changes is a caller error
            ArgumentNullException.ThrowIfNull(updatedRequests);

            // partial update — always validate and persist
            try
            {
                if (_NprRequests.Count <= 0)
                {
                    await SyncNprCacheFromDatabaseAsync();
                    _NprRequestsHasChanges = false;
                }

                // Validate all requests exist in the cache
                foreach (RfqNprRequestUxModel request in updatedRequests)
                {
                    RfqNprRequestUxModel? existing = _NprRequests.FirstOrDefault(r => r.Id == request.Id);
                    if (existing == null)
                    {
                        throw new InvalidOperationException(
                            $"NPR request not found for Id: {request.Id}, CustomerRfqNo: {request.CustomerRfqNo}");
                    }
                }

                // Replace each existing request with the updated version
                DateTime now = DateTime.UtcNow;
                foreach (RfqNprRequestUxModel request in updatedRequests)
                {
                    int index = _NprRequests.FindIndex(r => r.Id == request.Id);
                    request.Updated = now;
                    _NprRequests[index] = request;
                }

                await SyncNprCacheToDatabaseAsync();

                _Logger?.GenericLogInformation(
                    $"Updated {updatedRequests.Count} NPR requests");

                return updatedRequests;
            }
            catch (InvalidOperationException ex)
            {
                _Logger?.GenericLogError($"InvalidOperationException in UpdateNprRequestsAsync", ex);
                throw;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in UpdateNprRequestsAsync", ex);
                throw;
            }
        }

        public async Task<bool> UpdateRfqNprRequestStatusAsync()
        {
            UpdateRfqNprRequestStatusGrpcRequest request = new UpdateRfqNprRequestStatusGrpcRequest();
            UpdateRfqNprRequestStatusGrpcResponse response = await _Client.UpdateRfqNprRequestStatusGrpcAsync(request);
            _Logger?.GenericLogInformation(
                   $"UpdateRfqNprRequestStatusAsync message: {response.Message}");
            return response.Success;
        }

#if DEBUG
        public async Task<bool> DeleteNprRequestAsync(Guid requestId)
        {
            // DEBUG only: hard-delete from the backend table
            try
            {
                if (!_NprRequestsHasChanges && _NprRequests.Count <= 0)
                {
                    await SyncNprCacheFromDatabaseAsync();
                    _NprRequestsHasChanges = false;
                }

                RfqNprRequestUxModel? request = _NprRequests.FirstOrDefault(r => r.Id == requestId);

                if (request == null)
                {
                    _Logger?.GenericLogInformation($"NPR request not found for deletion, Id: {requestId}");
                    return false;
                }

                _NprRequests.Remove(request);

                bool result = await DeleteNprById(request);

                // reload cache from DB to stay in sync
                await SyncNprCacheFromDatabaseAsync();

                _NprRequestsHasChanges = false;

                _Logger?.GenericLogInformation($"Deleted NPR request Id: {requestId}");

                return result;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in DeleteNprRequestAsync for Id: {requestId}", ex);
                throw;
            }
        }
#else
        public async Task<bool> DeleteNprRequestAsync(Guid requestId)
        {
            // RELEASE: no hard-delete in production
            await Task.Delay(1);
            return false;
        }
#endif
        public async Task<bool> DeleteNprRequestsByRfqNumberAsync(string rfqNumber)
        {
            try
            {
                if (!_NprRequestsHasChanges && _NprRequests.Count <= 0)
                {
                    await SyncNprCacheFromDatabaseAsync();
                    _NprRequestsHasChanges = false;
                }

                List<RfqNprRequestUxModel>? rfqRequestsForRfqNumber
                    = _NprRequests.Where(r => r.CustomerRfqNo == rfqNumber).ToList();

                if (rfqRequestsForRfqNumber == null || rfqRequestsForRfqNumber.Count <= 0)
                {
                    _Logger?.GenericLogInformation($"NPR requests not found for deletion, CustomerRfqNo: {rfqNumber}");
                    return false;
                }

                foreach (RfqNprRequestUxModel rfqRequest in rfqRequestsForRfqNumber)
                {
                    _NprRequests.Remove(rfqRequest);
                }

                // sync
                await SyncNprCacheToDatabaseAsync();
                await SyncNprCacheFromDatabaseAsync();
                _NprRequestsHasChanges = false;
                _NprRequestsHasChanges = false;

                _Logger?.GenericLogInformation($"Deleted NPR requests for RfqNumber: {rfqNumber}");

                return true;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in DeleteNprRequestsByRfqNumberAsync for RfqNumber: {rfqNumber}", ex);
                throw;
            }
        }
        public async Task<bool> DeleteAllNprRequestsAsync()
        {
            try
            {
                if (!_NprRequestsHasChanges && _NprRequests.Count <= 0)
                {
                    await SyncNprCacheFromDatabaseAsync();
                }

                int count = _NprRequests.Count;

                if (count == 0)
                {
                    _Logger?.GenericLogInformation("No NPR requests to delete");
                    return false;
                }

                _NprRequests.Clear();

                // sync
                await SyncNprCacheToDatabaseAsync();
                await SyncNprCacheFromDatabaseAsync();

                _NprRequestsHasChanges = false;

                _Logger?.GenericLogInformation($"Deleted all {count} NPR requests");

                return true;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError("Error in DeleteAllNprRequestsAsync", ex);
                throw;
            }
        }

        /// <summary>
        /// Submits a batch of NPR requests to the NPR API via the manager's
        /// CreateNprGrpc endpoint (which internally calls _RfqManagerService.CreateNprGrpc).
        /// </summary>
        /// <param name="nprRequests">UX models to submit.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>The raw <see cref="CreateNprGrpcResponse"/> from the manager service.</returns>
        public async Task<CreateNprGrpcResponse> CreateNprGrpcAsync(
            List<RfqNprRequestUxModel> nprRequests,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(nprRequests);

            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);
            using CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
                timeoutCts.Token,
                cancellationToken);

            try
            {
                CreateNprGrpcRequest request = new CreateNprGrpcRequest();
                foreach (RfqNprRequestUxModel model in nprRequests)
                {
                    NprApiDataGrpc apiData = new NprApiDataGrpc();
                    apiData.RfqNprRequest = model.ToNprGrpc();
                    request.NprApiData.Add(apiData);
                }

                _Logger?.GenericLogInformation(
                    $"CreateNprGrpcAsync - Sending {request.NprApiData.Count} NPR API request(s) to manager");

                CreateNprGrpcResponse response = await _Client.CreateNprGrpcAsync(
                    request,
                    cancellationToken: linkedCts.Token);

                _Logger?.GenericLogInformation(
                    $"CreateNprGrpcAsync - Manager response: HttpStatusCode='{response.HttpStatusCode}', " +
                    $"Message='{response.Message}', returned {response.NprApiData.Count} entry(ies)");

                return response;
            }
            catch (OperationCanceledException)
            {
                _Logger?.GenericLogInformation("CreateNprGrpcAsync - Operation was cancelled or timed out");
                throw;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError("Error in CreateNprGrpcAsync", ex);
                throw;
            }
        }

        #endregion

        #region Supplier and Supplier Group
        public async Task<List<SupplierUxModel>> GetAllSuppliersAsync(int position = 0, int take = 100)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                GetAllSuppliersGrpcRequest request = new GetAllSuppliersGrpcRequest();

                request.Position = position;
                request.Take = take;

                GetAllSuppliersGrpcResponse response = await _Client.GetAllSuppliersGrpcAsync(request, cancellationToken: timeoutCts.Token);

                _Suppliers.Clear();
                IOrderedEnumerable<SupplierGrpc> rpcSuppliers = response.SupplierGrpc.OrderByDescending(x => x.SupplierName);
                foreach (SupplierGrpc? supplier in rpcSuppliers)
                {
                    if (supplier.IsActive.HasValue && !supplier.IsActive.Value)
                    {
                        continue; // skip inactive projects
                    }

                    SupplierUxModel? uxModel = supplier.ToUx();
                    if (null != uxModel)
                    {
                        _Suppliers.Add(uxModel);
                    }
                }

                return _Suppliers;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetAllSuppliersAsync with position {position} and take {take}", ex);
                throw;
            }
        }
        public async Task<List<SupplierGroupUxModel>> GetAllSupplierGroupsAsync(int position = 0, int take = 100)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                GetAllSupplierGroupsGrpcRequest request = new GetAllSupplierGroupsGrpcRequest();

                request.Position = position;
                request.Take = take;

                GetAllSupplierGroupsGrpcResponse response = await _Client.GetAllSupplierGroupsGrpcAsync(request, cancellationToken: timeoutCts.Token);

                _SupplierGroups.Clear();
                IOrderedEnumerable<SupplierGroupGrpc> rpcSupplierGroups = response.SupplierGroupGrpc.OrderByDescending(x => x.SupplierGroupName);
                foreach (SupplierGroupGrpc? supplierGroup in rpcSupplierGroups)
                {
                    if (supplierGroup.IsActive.HasValue && !supplierGroup.IsActive.Value)
                    {
                        continue; // skip inactive projects
                    }

                    SupplierGroupUxModel? uxModel = supplierGroup.ToUx();
                    if (null != uxModel)
                    {
                        _SupplierGroups.Add(uxModel);
                    }
                }

                return _SupplierGroups;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetAllSupplierGroupsAsync with position {position} and take {take}", ex);
                throw;
            }
        }
        #endregion

        #region UnitOfMeasures
        public async Task<List<UnitOfMeasureUxModel>> GetAllUnitOfMeasuresAsync(int position = 0, int take = 100)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                GetAllUnitOfMeasuresRequest request = new GetAllUnitOfMeasuresRequest();
                request.Position = position;
                request.Take = take;

                GetAllUnitOfMeasuresResponse response = await _Client.GetAllUnitOfMeasuresGrpcAsync(request, cancellationToken: timeoutCts.Token);

                _UnitOfMeasures.Clear();
                IOrderedEnumerable<UnitOfMeasureGrpc> rpcUnits = response.UnitOfMeasureGrpc.OrderByDescending(x => x.Code);
                foreach (UnitOfMeasureGrpc? unit in rpcUnits)
                {
                    if (unit.IsActive.HasValue && !unit.IsActive.Value)
                    {
                        continue; // skip inactive projects
                    }

                    UnitOfMeasureUxModel? uxModel = unit.ToUx();
                    if (null != uxModel)
                    {
                        _UnitOfMeasures.Add(uxModel);
                    }
                }

                return _UnitOfMeasures;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetAllUnitOfMeasuresAsync with position {position} and take {take}", ex);
                throw;
            }
        }

        #endregion

        #region BusinessUnits

        public async Task<List<BusinessUnitUxModel>> GetAllBusinessunitsAsync(int position = 0, int take = 100)
        {
            using CancellationTokenSource timeoutCts = new CancellationTokenSource(_Timeout);

            try
            {
                GetAllBusinessUnitsGrpcRequest request = new GetAllBusinessUnitsGrpcRequest();
                request.Position = position;
                request.Take = take;

                GetAllBusinessUnitsGrpcResponse response = await _Client.GetAllBuisnessUnitsGrpcAsync(request, cancellationToken: timeoutCts.Token);

                _BusinessUnits.Clear();
                IOrderedEnumerable<BusinessUnitGrpc> rpcUnits = response.BusinessUnitGrpc.OrderByDescending(x => x.LegacyBusinessUnitCode);
                foreach (BusinessUnitGrpc? unit in rpcUnits)
                {
                    if (unit.IsActive.HasValue && !unit.IsActive.Value)
                    {
                        continue; // skip inactive projects
                    }

                    BusinessUnitUxModel? uxModel = unit.ToUx();
                    if (null != uxModel)
                    {
                        _BusinessUnits.Add(uxModel);
                    }
                }

                return _BusinessUnits;
            }
            catch (Exception ex)
            {
                _Logger?.GenericLogError($"Error in GetAllUnitOfMeasuresAsync with position {position} and take {take}", ex);
                throw;
            }
        }

        #endregion

        //#region BusinessUnits
        //public async Task<List<Bus>>
        //#endregion

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