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

        public override async Task<UpdateRfqProjectGrpcResponse> UpdateRfqProjectGrpc(UpdateRfqProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateRfqProjectGrpc starting");
            UpdateRfqProjectGrpcResponse response = await _RfqManagerService.UpdateRfqProject(request);
            return response;
        }
    }
}
