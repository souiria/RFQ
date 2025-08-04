namespace CDb.Endpoints.GrpcServices
{
    public partial class CDbGrpcService : CDbService.CDbServiceBase
    {
        readonly ICDbAccessService _CDbAccessService;
        readonly ILogger<CDbGrpcService> _Logger;

        public CDbGrpcService(ICDbAccessService cDbAccessService, ILogger<CDbGrpcService> logger)
        {
            _CDbAccessService = cDbAccessService;
            _Logger = logger;
        }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }
    }
}
