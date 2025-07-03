namespace CPD.Endpoints.GrpcServices
{
    public class CPDGrpcService : CPD.CPDBase
    {
        readonly ICPDAccessService _CPDAccessService;
        readonly ILogger<CPDGrpcService> _Logger;

        public CPDGrpcService(ICPDAccessService cPDAccessService, ILogger<CPDGrpcService> logger)
        {
            _CPDAccessService = cPDAccessService;
            _Logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        #region MatSuppMstView
        public override async Task<ListMatSuppMstGrpc> GetAllMatSuppMstView(MatSuppMstViewGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllMatSuppMstView starting");
            return await _CPDAccessService.GetAllMatSuppMstView(context.CancellationToken);

        }
        #endregion
    }
}
