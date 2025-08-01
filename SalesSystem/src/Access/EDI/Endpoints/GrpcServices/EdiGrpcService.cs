namespace EDI.Endpoints.GrpcServices
{
    public class EdiGrpcService : Edi.EdiBase
    {
        readonly IEdiAccessService _EdiAccessService;
        readonly ILogger<EdiGrpcService> _Logger;

        public EdiGrpcService(IEdiAccessService ediAccessService, ILogger<EdiGrpcService> logger)
        {
            _EdiAccessService = ediAccessService;
            _Logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name + ", I am the EdiGrpcService";
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        public override async Task<ListEdiCustomerParameterGrpc> GetEdiCustomerParametersGrpc(Empty request, ServerCallContext context)
        {
            return await _EdiAccessService.GetEdiCustomerParametersGrpcAsync(context.CancellationToken);
        }

        public override async Task<ListEdiFileDataUploadDuplicatesGrpc> GetEdiFileDataUploadDuplicatesGrpc(Empty request, ServerCallContext context)
        {
            return await _EdiAccessService.GetEdiFileDataUploadDuplicatesGrpcAsync(context.CancellationToken);
        }

        public override async Task<ListEdiFileDataUploadGrpc> GetEdiFileDataUploadGrpc(Empty request, ServerCallContext context)
        {
            return await _EdiAccessService.GetEdiFileDataUploadGrpcAsync(context.CancellationToken);
        }

        public override async Task<ListEdiGlobalParametersGrpc> GetEdiGlobalParametersGrpc(Empty request, ServerCallContext context)
        {
            return await _EdiAccessService.GetEdiGlobalParametersGrpcAsync(context.CancellationToken);
        }

        public override async Task<ListEdiInvoiceInformationDuplicatesGrpc> GetEdiInvoiceInformationDuplicatesGrpc(Empty request, ServerCallContext context)
        {
            return await _EdiAccessService.GetEdiInvoiceInformationDuplicatesGrpcAsync(context.CancellationToken);
        }

        public override async Task<ListEdiInvoiceInformationGrpc> GetEdiInvoiceInformationGrpc(Empty request, ServerCallContext context)
        {
            return await _EdiAccessService.GetEdiInvoiceInformationGrpcAsync(context.CancellationToken);
        }

        public override async Task<ListEdiInvoiceUnit4Grpc> GetEdiInvoiceUnit4Grpc(Empty request, ServerCallContext context)
        {
            return await _EdiAccessService.GetEdiInvoiceUnit4GrpcAsync(context.CancellationToken);
        }

        public override async Task<ListEdiZeroPriceExceptionsGrpc> GetEdiZeroPriceExceptionsGrpc(Empty request, ServerCallContext context)
        {
            return await _EdiAccessService.GetEdiZeroPriceExceptionsGrpcAsync(context.CancellationToken);
        }
    }
}
