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
        public override async Task<GetCustomersByUserIdGrpcResponse> GetCustomersByUserIdGrpc(GetCustomersByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomersByUserIdGrpc starting");
            GetCustomersByUserIdGrpcResponse response = await _RfqManagerService.GetCustomersByUserIdGrpc(request);
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
    }
}
