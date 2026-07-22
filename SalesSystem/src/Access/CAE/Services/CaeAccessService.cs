
namespace Cae.Services
{
    public class CaeAccessService : CaeService.CaeServiceBase
    {
        readonly ILogger<CaeAccessService> _Logger;
        public CaeAccessService(ILogger<CaeAccessService> logger)
        {
            _Logger = logger;
        }

        public override Task<CommonTypes.HelloReply> SayHello(CommonTypes.HelloRequest request, ServerCallContext context)
        {
            CommonTypes.HelloReply reply = new CommonTypes.HelloReply();
            reply.Message = "Hello " ;

            Task<CommonTypes.HelloReply> result = Task.FromResult(reply);
            return result;
        }
    }
}
