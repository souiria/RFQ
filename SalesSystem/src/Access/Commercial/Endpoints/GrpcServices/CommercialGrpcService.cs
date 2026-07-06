namespace Commercial.Endpoints.GrpcServices
{
    public class CommercialGrpcService : Commercial.CommercialBase
    {
        readonly ICommercialAccessService _CommercialAccessService;
        readonly ILogger<CommercialGrpcService> _Logger;

        public CommercialGrpcService(ICommercialAccessService commercialAccessService, ILogger<CommercialGrpcService> logger)
        {
            _CommercialAccessService = commercialAccessService;
            _Logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        #region Purchase Orders

        public override async Task<ListPurchaseOrderDataGrpc> GetAllPurchaseOrderDataGrpc(GetAllPurchaseOrderDataGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPurchaseOrdersGrpc starting");
            ListPurchaseOrderDataGrpc result = await _CommercialAccessService.GetAllPurchaseOrdersAsync(context.CancellationToken, request.Position, request.TakeAmount);
            return result;
        }

        #endregion

        public override async Task<CommercialFilterDataGrpcResponse> CommercialFilterDataGrpc(CommercialFilterDataGrpcRequest request, ServerCallContext context)
        {
            ParsingConfig parsingConfig = new ParsingConfig();
            string filterExpressionString = request.FilterExpression;

            CommercialFilterDataGrpcResponse returnResponse = new CommercialFilterDataGrpcResponse();

            switch (request.DatabaseList.ToUpperInvariant())
            {
                case "PURCHASEORDERDATAGRPC":
                await _CommercialAccessService.HandleFilterCase<PurchaseOrderDataGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListPurchaseOrderDataGrpc returnList = new ListPurchaseOrderDataGrpc();
                    returnList.PurchaseOrderData.AddRange(filterList);
                    returnResponse.FilteredPurchaseOrderData = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;
                default:
                _Logger.GenericLogInformation($"CommercialFilterDataGrpc: Unknown DatabaseList '{request.DatabaseList}'");
                break;
            }

            return returnResponse;
        }
    }
}
