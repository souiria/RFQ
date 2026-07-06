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

        #region Derivative Wires

        public override async Task<ListDerivativeWiresGrpc> GetDerivativeWireByIdGrpc(GetDerivativeWireByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetDerivativeWireByIdGrpc starting");
            List<DerivativeWiresGrpc> result = await _EngSolAccessService.GetDerivativeWiresByDerivativeId(request.DerivativeId, context.CancellationToken);
            ListDerivativeWiresGrpc response = new ListDerivativeWiresGrpc();
            response.DerivativeWiresGrpc.AddRange(result);

            return response;
        }

        #endregion

        #region Derivative Parts

        public override async Task<ListDerivativePartsGrpc> GetDerivativePartByIdGrpc(GetDerivativePartByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetDerivativePartByIdGrpc starting");
            List<DerivativePartsGrpc> result = await _EngSolAccessService.GetDerivativePartsByDerivativeId(request.DerivativeId, context.CancellationToken);
            ListDerivativePartsGrpc response = new ListDerivativePartsGrpc();
            response.DerivativePartsGrpc.Add(result);
            return response;
        }

        //take derivative last 12 months dont save any parts/wires in mem just do the filter
        #endregion

        #region Derivatives

        public override async Task<ListDerivatives> GetDerivativesGrpc(GetDerivativesGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetDerivativesGrpc starting");
            ListDerivatives result = await _EngSolAccessService.GetAllDerivatives(context.CancellationToken, request.Position, request.TakeAmount);
            return result;
        }

        public override Task<DerivativeGrpc> GetDerivativeByDerivativeId(GetDerivativeByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetDerivativeByDerivativeId starting");
            Task<DerivativeGrpc> result = _EngSolAccessService.GetDerivativeByDerivativeId(request.DerivativeId, context.CancellationToken);
            return result;
        }

        #endregion

        public override async Task<EngSolFilterDataGrpcResponse> EngSolFilterDataGrpc(EngSolFilterDataGrpcRequest request, ServerCallContext context)
        {
            ParsingConfig parsingConfig = new ParsingConfig();
            string filterExpressionString = request.FilterExpression;

            EngSolFilterDataGrpcResponse returnResponse = new EngSolFilterDataGrpcResponse();

            switch (request.DatabaseList.ToUpperInvariant())
            {
                case "DERIVATIVESGRPC":
                await _EngSolAccessService.HandleFilterCase<DerivativeGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListDerivatives returnList = new ListDerivatives();
                    returnList.DerivativeGrpc.AddRange(filterList);
                    returnResponse.DerivativeGrpc = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;
                default:
                _Logger.GenericLogInformation($"EngSolFilterDataGrpc: Unknown DatabaseList '{request.DatabaseList}'");
                break;
            }

            return returnResponse;
        }
    }
}
