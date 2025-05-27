using Grpc.Core;
using RfqManager;

namespace RfqManager.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        readonly ILogger<GreeterService> _Logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _Logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
