namespace EngSol.Endpoints.GrpcServices
{
    public class EngSolGrpcService : EngSol.EngSolBase
    {
        readonly IEngSolAccessService _EngSolAccessService;
        readonly ILogger<EngSolGrpcService> _Logger;

        public EngSolGrpcService(IEngSolAccessService engSolAccessService, ILogger<EngSolGrpcService> logger)
        {
            _EngSolAccessService = engSolAccessService;
            _Logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        public override async Task<ListDerivativeWiresGrpc> GetDerivativeWiresGrpc(GetDerivativeWiresGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetDerivativeWiresGrpc starting");
            ListDerivativeWiresGrpc result = await _EngSolAccessService.GetAllDerivativeWires(context.CancellationToken, request.Position, request.TakeAmount);
            return result;
        }

        public override async Task<DerivativeWiresGrpc> GetDerivativeWireByIdGrpc(GetDerivativeWireByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetDerivativeWireByIdGrpc starting");
            DerivativeWiresGrpc result = await _EngSolAccessService.GetDerivativeWireById(request.DerivativeId, context.CancellationToken);

            return result;
        }
    }
}
