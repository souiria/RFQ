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

        public override async Task<GetCustomersGrpcResponse> GetCustomersGrpc(GetCustomersGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomersGrpc starting");
            GetCustomersGrpcResponse response = await _RfqManagerService.GetCustomersGrpc(request);
            return response;
        }

        public override async Task<GetLocationsByCustomerIdGrpcResponse> GetLocationsByCustomerIdGrpc(GetLocationsByCustomerIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetLocationsByCustomerIdGrpc starting");
            GetLocationsByCustomerIdGrpcResponse response = await _RfqManagerService.GetLocationsByCustomerIdGrpc(request);
            return response;
        }
        public override async Task<GetProjectsByLocationIdGrpcResponse> GetProjectsByLocationIdGrpc(GetProjectsByLocationIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProjectsByLocationIdGrpc starting");
            GetProjectsByLocationIdGrpcResponse response = await _RfqManagerService.GetProjectsByLocationIdGrpc(request);
            return response;
        }
        public override async Task<GetVehicleByProjectCodeGrpcResponse> GetVehiclesByProjectCodeGrpc(GetVehicleByProjectCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehiclesByProjectCodeGrpc starting");
            GetVehicleByProjectCodeGrpcResponse response = await _RfqManagerService.GetVehiclesByProjectCodeGrpc(request);
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
                default:
                    _Logger.GenericLogInformation($"FilterGrpc received unknown filter type: {filterType}");
                    break;
            }

            return response;
        }
    }
}
