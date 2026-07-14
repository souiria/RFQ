
namespace CAE.Services
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
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " ;

            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }
    }
}
