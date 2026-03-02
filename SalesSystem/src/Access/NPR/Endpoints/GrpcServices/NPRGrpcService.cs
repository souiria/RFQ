namespace NPR.Endpoints.GrpcServices
{
    public class NPRGrpcService : NPR.NPRBase
    {
        readonly INPRAccessService _NPRAccessService;
        readonly ILogger<NPRGrpcService> _Logger;

        public NPRGrpcService(INPRAccessService nPRAccessService, ILogger<NPRGrpcService> logger)
        {
            _NPRAccessService = nPRAccessService;
            _Logger = logger;
        }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        #region H1NPRView
        public override async Task<ListH1NPRViewGrpc> GetAllH1NPRViewGrpc(H1NPRViewRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetH1NPRViewGrpc starting");
            return await _NPRAccessService.GetAllH1NPRView(context.CancellationToken, request.Position, request.Takeamount);
        }
        #endregion

        #region RFQStatus
        public override async Task<ListRFQStatusGrpc> GetAllRFQStatusGrpc(RFQStatusRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllRFQStatusGrpc starting");
            return await _NPRAccessService.GetAllRFQStatus(context.CancellationToken, request.Position, request.Takeamount);
        }
        #endregion

        public override async Task<NPRFilterResponse> FilterNPRGrpc(NPRFilterRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("FilterNPRGrpc starting");
            ParsingConfig parsingConfig = new ParsingConfig();
            NPRFilterResponse returnResponse = new NPRFilterResponse();
            await _NPRAccessService.HandleFilterCase<H1NPRViewGrpc>(
                request.FilterExpression, parsingConfig,
                filterlist =>
                {
                    ListH1NPRViewGrpc returnList = new ListH1NPRViewGrpc();
                    returnList.H1NPRViewGrpc.AddRange(filterlist);
                    returnResponse.ListH1NPRViewGrpc = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
            return returnResponse;
        }
          }
}
