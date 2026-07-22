namespace EdiModule.Services
{
    public class EdiModuleService : EdiModule.EdiModuleBase
    {
        readonly ILogger<EdiModuleService> _Logger;
        public EdiModuleService(ILogger<EdiModuleService> logger)
        {
            _Logger = logger;
        }

        public override Task<CommonTypes.HelloReply> SayHello(CommonTypes.HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new CommonTypes.HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
