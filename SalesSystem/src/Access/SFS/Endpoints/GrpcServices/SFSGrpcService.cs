namespace SFS.Endpoints.GrpcServices
{
    public class SFSGrpcService :SFSService.SFSServiceBase
    {
      readonly ISFSAccessService _SFSAccessService;
      readonly ILogger<SFSGrpcService> _Logger;
    public SFSGrpcService(ISFSAccessService sFSAccessService, ILogger<SFSGrpcService> logger)
    {
        _SFSAccessService = sFSAccessService;
        _Logger = logger;
    }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        public override async Task<CarModelListViewGrpc> GetAllCarModels(Empty request, ServerCallContext context)
        {
            return await _SFSAccessService.GetAllCarModel(context.CancellationToken);
        }
    }
}
