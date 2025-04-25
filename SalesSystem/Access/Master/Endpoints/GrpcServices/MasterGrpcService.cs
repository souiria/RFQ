using Grpc.Core;

namespace Master.Endpoints.GrpcServices
{
    public class MasterGrpcService : Master.MasterBase
    {
        readonly ILogger<MasterGrpcService> _Logger;
        public MasterGrpcService(ILogger<MasterGrpcService> logger)
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

        public override Task<ListCurrencyData> GetCurrencyData(CurrencyGrpcRequest request, ServerCallContext context)
        {
            return base.GetCurrencyData(request, context);
        }

        public override Task GetCurrencyDataStream(CurrencyGrpcRequest request, IServerStreamWriter<CurrencyData> responseStream, ServerCallContext context)
        {
            return base.GetCurrencyDataStream(request, responseStream, context);
        }
    }
}
