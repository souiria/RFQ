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

        public override async Task<EdiResponse> GetEdiDataGrpc(EdiRequest request, ServerCallContext context)
        {
            EdiResponse response = new EdiResponse();
            EdiRequestType requestType = ((EdiRequestType)request.RequestType);
            switch (requestType)
            {
                case EdiRequestType.GetEdiCustomerParameters:
                    response.ResponseType = (int)EdiResponseType.EdiCustomerParameters;
                    response.ListEdiCustomerParameterGrpc = await _EdiAccessService.GetEdiCustomerParametersGrpcAsync(context.CancellationToken);
                    break;
                case EdiRequestType.GetEdiFileDataUpload:
                    response.ResponseType = (int)EdiResponseType.EdiFileDataUpload;
                    response.ListEdiFileDataUploadGrpc = await _EdiAccessService.GetEdiFileDataUploadGrpcAsync(context.CancellationToken);
                    break;
                case EdiRequestType.GetEdiFileDataUploadDuplicates:
                    response.ResponseType = (int)EdiResponseType.EdiFileDataUploadDuplicates;
                    response.ListEdiFileDataUploadDuplicatesGrpc = await _EdiAccessService.GetEdiFileDataUploadDuplicatesGrpcAsync(context.CancellationToken);
                    break;
                case EdiRequestType.GetEdiGlobalParameters:
                    response.ResponseType = (int)EdiResponseType.EdiGlobalParameters;
                    response.ListEdiGlobalParametersGrpc = await _EdiAccessService.GetEdiGlobalParametersGrpcAsync(context.CancellationToken);
                    break;
                case EdiRequestType.GetEdiInvoiceInformation:
                    response.ResponseType = (int)EdiResponseType.EdiInvoiceInformation;
                    response.ListEdiInvoiceInformationGrpc = await _EdiAccessService.GetEdiInvoiceInformationGrpcAsync(context.CancellationToken);
                    break;
                case EdiRequestType.GetEdiInvoiceInformationDuplicates:
                    response.ResponseType = (int)EdiResponseType.EdiInvoiceInformationDuplicates;
                    response.ListEdiInvoiceInformationDuplicatesGrpc = await _EdiAccessService.GetEdiInvoiceInformationDuplicatesGrpcAsync(context.CancellationToken);
                    break;
                case EdiRequestType.GetEdiInvoiceUnit4:
                    response.ResponseType = (int)EdiResponseType.EdiInvoiceUnit4;
                    response.ListEdiInvoiceUnit4Grpc = await _EdiAccessService.GetEdiInvoiceUnit4GrpcAsync(context.CancellationToken);
                    break;
                case EdiRequestType.GetEdiZeroPriceExceptions:
                    response.ResponseType = (int)EdiResponseType.EdiZeroPriceExceptions;
                    response.ListEdiZeroPriceExceptionsGrpc = await _EdiAccessService.GetEdiZeroPriceExceptionsGrpcAsync(context.CancellationToken);
                    break;
                default:
                    _Logger.GenericLogInformation("Unknown Request Type");
                    break;
            }

            response.Success = true;
            return response;
        }

        public override async Task<EdiResponse> SaveEdiDataGrpc(EdiSaveRequest request, ServerCallContext context)
        {
            EdiResponse response = new EdiResponse();
            EdiSaveRequestType requestType = ((EdiSaveRequestType)request.RequestType);
            switch (requestType)
            {
                case EdiSaveRequestType.SaveEdiCustomerParameters:
                response.ResponseType = (int)EdiResponseType.EdiCustomerParameters;
                response.Success = await _EdiAccessService.SaveEdiCustomerParametersGrpcAsync(request.ListEdiCustomerParameterGrpc, context.CancellationToken);
                break;
                case EdiSaveRequestType.SaveEdiFileDataUpload:
                response.ResponseType = (int)EdiResponseType.EdiFileDataUpload;
                response.Success = await _EdiAccessService.SaveEdiFileDataUploadGrpcAsync(request.ListEdiFileDataUploadGrpc, context.CancellationToken);
                break;
                case EdiSaveRequestType.SaveEdiFileDataUploadDuplicates:
                response.ResponseType = (int)EdiResponseType.EdiFileDataUploadDuplicates;
                response.Success = await _EdiAccessService.SaveEdiFileDataUploadDuplicatesGrpcAsync(request.ListEdiFileDataUploadDuplicatesGrpc, context.CancellationToken);
                break;
                case EdiSaveRequestType.SaveEdiGlobalParameters:
                response.ResponseType = (int)EdiResponseType.EdiGlobalParameters;
                response.Success = await _EdiAccessService.SaveEdiGlobalParametersGrpcAsync(request.ListEdiGlobalParametersGrpc, context.CancellationToken);
                break;
                case EdiSaveRequestType.SaveEdiInvoiceInformation:
                response.ResponseType = (int)EdiResponseType.EdiInvoiceInformation;
                response.Success = await _EdiAccessService.SaveEdiInvoiceInformationGrpcAsync(request.ListEdiInvoiceInformationGrpc, context.CancellationToken);
                break;
                case EdiSaveRequestType.SaveEdiInvoiceInformationDuplicates:
                response.ResponseType = (int)EdiResponseType.EdiInvoiceInformationDuplicates;
                response.Success = await _EdiAccessService.SaveEdiInvoiceInformationDuplicatesGrpcAsync(request.ListEdiInvoiceInformationDuplicatesGrpc, context.CancellationToken);
                break;
                case EdiSaveRequestType.SaveEdiInvoiceUnit4:
                response.ResponseType = (int)EdiResponseType.EdiInvoiceUnit4;
                response.Success = await _EdiAccessService.SaveEdiInvoiceUnit4GrpcAsync(request.ListEdiInvoiceUnit4Grpc, context.CancellationToken);
                break;
                case EdiSaveRequestType.SaveEdiZeroPriceExceptions:
                response.ResponseType = (int)EdiResponseType.EdiZeroPriceExceptions;
                response.Success = await _EdiAccessService.SaveEdiZeroPriceExceptionsGrpcAsync(request.ListEdiZeroPriceExceptionsGrpc, context.CancellationToken);
                break;
                default:
                _Logger.GenericLogInformation("Unknown Request Type");
                break;
            }

            return response;
        }
    }
}
