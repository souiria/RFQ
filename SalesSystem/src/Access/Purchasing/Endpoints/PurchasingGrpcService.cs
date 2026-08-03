namespace Purchasing.Endpoints
{
    public class PurchasingGrpcService : Purchasing.PurchasingBase
    {
        readonly IPurchasingAccessService _PurchasingAccessService;
        readonly ILogger<PurchasingGrpcService> _Logger;

        public PurchasingGrpcService(IPurchasingAccessService purchasingAccessService, ILogger<PurchasingGrpcService> logger)
        {
            _PurchasingAccessService = purchasingAccessService;
            _Logger = logger;
        }

        public override Task<CommonTypes.HelloReply> SayHello(CommonTypes.HelloRequest request, ServerCallContext context)
        {
            CommonTypes.HelloReply reply = new CommonTypes.HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<CommonTypes.HelloReply> result = Task.FromResult(reply);
            return result;
        }

        #region H1CPD
        public override async Task<ListH1CPDGrpc> ReadH1CPDGrpc(H1CPDGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadH1CPDGrpc starting");
            if (request == null || request.PurchasingGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;

            if (Enum.IsDefined(typeof(RequestType), request.PurchasingGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.PurchasingGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _PurchasingAccessService.GetAllH1CPD(context.CancellationToken, request.PurchasingGrpcRequestParameter.Position, request.PurchasingGrpcRequestParameter.Take);
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                    throw new RpcException(status);
                }
            }
        }
        #endregion

        public override async Task<PurchasingFilterResponse> FilterPurchasingGrpc(PurchasingFilterRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("FilterPurchasingGrpc starting");
            ParsingConfig parsingConfig = new ParsingConfig();
            PurchasingFilterResponse returnResponse = new PurchasingFilterResponse();
            switch (request.DatabaseList.ToUpperInvariant())
            {
                case "H1CPDGRPC":
                await _PurchasingAccessService.HandleFilterCase<H1CPDGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListH1CPDGrpc returnList = new ListH1CPDGrpc();
                        returnList.H1CPD.AddRange(filterlist);
                        returnResponse.ListH1CPDGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                default:
                _Logger.GenericLogInformation($"FilterRfqGrpc: Unknown DatabaseList '{request.DatabaseList}'");
                break;
            }

            return returnResponse;
        }
    }
}
