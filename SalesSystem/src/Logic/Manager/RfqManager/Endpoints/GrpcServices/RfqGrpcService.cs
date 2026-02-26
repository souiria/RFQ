namespace RfqModule.Endpoints.GrpcServices
{
    public class RfqGrpcService : RfqModule.RfqModuleBase
    {
        readonly ILogger<RfqGrpcService> _Logger;
        readonly IRfqManagerService _RfqManagerService;

        public RfqGrpcService(ILogger<RfqGrpcService> logger, IRfqManagerService rfqManagerService)
        {
            _Logger = logger;
            _RfqManagerService = rfqManagerService;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }
        public override async Task<GetAllCustomersGrpcResponse> GetAllCustomersGrpc(GetAllCustomersGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllCustomersGrpc starting");
            GetAllCustomersGrpcResponse response = await _RfqManagerService.GetAllCustomersGrpc(request);
            return response;
        }
        //public override async Task<GetCustomersByUserIdGrpcResponse> 
        //    GetCustomersByUserIdGrpc(GetCustomersByUserIdGrpcRequest request, ServerCallContext context)
        //{
        //    _Logger.GenericLogInformation("GetCustomersByUserIdGrpc starting");
        //    GetCustomersByUserIdGrpcResponse response = await _RfqManagerService.GetCustomersByUserIdGrpc(request);
        //    return response;
        //}

        public override async Task<GetProjectAssociationsByCustomerIdResponse> GetProjectAssociationsByCustomerId(GetProjectAssociationsByCustomerIdRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomersByUserIdGrpc starting");
            GetProjectAssociationsByCustomerIdResponse response = await _RfqManagerService.GetProjectAssociationsByCustomerId(request);
            return response;
        }

        public override async Task<GetRfqReasonsGrpcResponse> GetRfqReasonsGrpc(GetRfqReasonsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetRfqReasonsGrpc starting");
            GetRfqReasonsGrpcResponse response = await _RfqManagerService.GetRfqReasonsGrpc(request);
            return response;
        }
        public override async Task<UploadPartsRequestGrpcResponse> UploadPartsGrpc(UploadPartsRequestGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UploadPartsGrpc starting");
            UploadPartsRequestGrpcResponse response = await _RfqManagerService.UploadPartsGrpc(request);
            return response;
        }

        public override async Task<CreateRfqProjectGrpcResponse> CreateRfqProjectGrpc(CreateRfqProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateRfqProjectGrpc starting");
            CreateRfqProjectGrpcResponse response = await _RfqManagerService.CreateRfqProject(request);
            return response;
        }

        public override async Task<GetAllRfqProjectGrpcResponse> GetAllRfqProjectGrpc(GetAllRfqProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllRfqProjectGrpc starting");
            GetAllRfqProjectGrpcResponse response = await _RfqManagerService.GetAllRfqProjectGrpc(request);
            return response;
        }
        public override async Task<GetRfqProjectByIdGrpcResponse> GetRfqProjectByIdGrpc(GetRfqProjectByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetRfqProjectByIdGrpc starting");
            GetRfqProjectByIdGrpcResponse response = await _RfqManagerService.GetRfqProjectByIdGrpc(request);
            return response;
        }
        public override async Task<GetRfqDrawingPartNumbersByRfqIdGrpcResponse> GetRfqDrawingPartNumbersByRfqIdGrpc(GetRfqDrawingPartNumbersByRfqIdGrpcRequest request,  ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetRfqDrawingPartNumbersByRfqIdGrpc starting");
            return await _RfqManagerService.GetRfqDrawingPartNumbersByRfqIdGrpc(request);
        }
        public override async Task<UpdateRfqProjectGrpcResponse> UpdateRfqProjectGrpc(UpdateRfqProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateRfqProjectGrpc starting");
            UpdateRfqProjectGrpcResponse response = await _RfqManagerService.UpdateRfqProject(request);
            return response;
        }
        public override async Task<RfqCrudResponse> DeleteRfqProjectByRowIdGrpc(RfqProjectRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("DeleteRfqProjectByRowIdGrpc starting");
            return await _RfqManagerService.DeleteRfqProjectByRowIdGrpc(request);
        }

        public override async Task<GetCustomerLocationsByUserIdResponse> GetCustomerLocationsByUserIdGrpc(GetCustomerLocationsByUserIdRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationsByUserId starting");
            GetCustomerLocationsByUserIdResponse response = await _RfqManagerService.GetCustomerLocationsByUserId(request.UserId);
            return response;
        }

        public override async Task<GetCustomerBusinessUnitsByUserIdResponse> GetCustomerBusinessUnitsByUserIdGrpc(GetCustomerBusinessUnitsByUserIdRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerBusinessUnitsByUserId starting");
            GetCustomerBusinessUnitsByUserIdResponse response = await _RfqManagerService.GetCustomerBusinessUnitsByUserId(request.UserId);
            return response;
        }

        public override async Task<GetAlternativePartInfoBySumitomoNumberResponse> GetAlternativePartInfoBySumitomoNumberGrpc(GetAlternativePartInfoBySumitomoNumberRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAlternativePartInfoBySumitomoNumberGrpc starting");
            GetAlternativePartInfoBySumitomoNumberResponse response = await _RfqManagerService.GetAlternativePartInfoBySumitomoNumberResponse(request.SumitomoPartNumber);
            return response;
        }

        public override async Task<FilterGrpcResponse> FilterGrpc(FilterGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("FilterGrpc starting");
            FilterGrpcResponse response = new FilterGrpcResponse();
            RfqManagerFilterType filterType = (RfqManagerFilterType)request.FilterRequest.RequestType;
            switch (filterType)
            {
                case RfqManagerFilterType.FilterByCustomerId:
                    response = await _RfqManagerService.FilterByCustomerId(request);
                    break;
                case RfqManagerFilterType.FilterByLocationId:
                    response = await _RfqManagerService.FilterByLocationId(request);
                    break;
                case RfqManagerFilterType.FilterByProjectCode:
                    response = await _RfqManagerService.FilterByProjectCode(request);
                    break;
                case RfqManagerFilterType.FilterEmacsByExactPartNumber:
                    response = await _RfqManagerService.FilterEmacsByExactPartNumber(request);
                    break;
                case RfqManagerFilterType.FilterEmacsByContainingPartNumber:
                    response = await _RfqManagerService.FilterEmacsByContainingPartNumber(request);
                    break;
                case RfqManagerFilterType.FilterAdssBySumitomoPartNumber:
                    response = await _RfqManagerService.FilterAdssBySumitomoPartNumber(request);
                    break;
                case RfqManagerFilterType.FilterNPRBySumitomoPartNumber:
                    response = await _RfqManagerService.FilterNPRBySumitomoPartNumber(request);
                    break;
                case RfqManagerFilterType.FilterCPDBySumitomoPartNumber:
                    response = await _RfqManagerService.FilterCPDBySumitomoPartNumber(request);
                    break;
                case RfqManagerFilterType.FilterRFQBySumitomoPartNumber:
                    response = await _RfqManagerService.FilterRFQBySumitomoPartNumber(request);
                    break;
                default:
                    _Logger.GenericLogInformation($"FilterGrpc received unknown filter type: {filterType}");
                    break;
            }

            return response;
        }
        public override async Task<UpdateRfqDrawingPartNumbersGrpcResponse> UpdateRfqDrawingPartNumbersGrpc(
            UpdateRfqDrawingPartNumbersGrpcRequest request,
            ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateRfqDrawingPartNumbersGrpc starting");
            UpdateRfqDrawingPartNumbersGrpcResponse response = await _RfqManagerService.UpdateRfqDrawingPartNumbers(request);
            return response;
        }
        public override async Task<GetAllAlternativePartsGrpcResponse> GetAllAlternativePartsGrpc(GetAllAlternativePartsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"GetAlternativePartsGrpc starting at position {request.Position} taking {request.Take} - 120s timeout");
            TimeSpan ts = TimeSpan.FromSeconds(120);
            using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(context.CancellationToken))
            {
                // Use cts.Token here
                //cts.CancelAfter(ts);
                GetAllAlternativePartsGrpcResponse response = await _RfqManagerService.GetAllAlternativePartsGrpc(request, cts.Token);
                return response;
            }
        }
        public override async Task<GetRfqNprRequestByRfqNumberGrpcResponse> GetRfqNprRequestByRfqNumberGrpc(GetRfqNprRequestByRfqNumberGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"GetRfqNprRequestByRfqNumberGrpc starting");
            GetRfqNprRequestByRfqNumberGrpcResponse response = await _RfqManagerService.GetRfqNprRequestByRfqNumberGrpc(request);
            return response;
        }
        public override async Task<GetAllRfqNprRequestGrpcResponse> GetAllRfqNprRequestGrpc(GetAllRfqNprRequestGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"GetAllRfqNprRequestGrpc starting");
            GetAllRfqNprRequestGrpcResponse response = await _RfqManagerService.GetAllRfqNprRequestGrpc(request);
            return response;
        }
        public override async Task<CreateRfqNprRequestGrpcResponse> CreateRfqNprRequestGrpc(CreateRfqNprRequestGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"CreateRfqNprRequestGrpc starting");
            CreateRfqNprRequestGrpcResponse response = await _RfqManagerService.CreateRfqNprRequestGrpc(request);
            return response;
        }
        public override async Task<UpdateRfqNprRequestGrpcResponse> UploadRfqNprRequestGrpc(UpdateRfqNprRequestGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"UploadRfqNprRequestGrpc starting");
            UpdateRfqNprRequestGrpcResponse response = await _RfqManagerService.UpdateRfqNprRequestGrpc(request);
            return response;
        }
    }
}
