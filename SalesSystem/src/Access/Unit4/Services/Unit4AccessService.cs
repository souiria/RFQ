namespace Unit4.Services
{
    public class Unit4AccessService : Greeter.GreeterBase
    {
        readonly ILogger<Unit4AccessService> _Logger;
        public Unit4AccessService(ILogger<Unit4AccessService> logger)
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
