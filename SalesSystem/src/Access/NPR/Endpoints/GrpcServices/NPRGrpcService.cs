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
            return await _NPRAccessService.GetAllH1NPRView(context.CancellationToken);
        }
        #endregion
    }
}
