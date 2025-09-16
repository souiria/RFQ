using Grpc.Core;
using Unit4;

namespace Unit4.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        readonly ILogger<GreeterService> _Logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _Logger = logger;
        }

        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            return await Task.FromResult(reply);
        }
    }
}
