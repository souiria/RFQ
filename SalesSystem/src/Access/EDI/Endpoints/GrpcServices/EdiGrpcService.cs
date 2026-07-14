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

        public override async Task<EdiResponse> FilterEdiDataGrpc(EdiFilterRequest request, ServerCallContext context)
        {
            ParsingConfig parsingConfig = new ParsingConfig();
            string filterExpressionString = request.FilterExpression.ToUpperInvariant();
            EdiResponse returnResponse = new EdiResponse();

            switch (request.DatabaseList)
            {
                case "EdiCustomerParameterGrpc":
                    await HandleFilterCase<EdiCustomerParameterGrpc>(filterExpressionString, parsingConfig, returnResponse, 
                        filteredList => {
                            ListEdiCustomerParameterGrpc returnCollection = new ListEdiCustomerParameterGrpc();
                            returnCollection.EdiCustomerParameterGrpc.AddRange(filteredList);
                            returnResponse.ListEdiCustomerParameterGrpc = returnCollection;
                        }, context.CancellationToken);
                    break;
                case "EdiFileDataUploadGrpc":
                    await HandleFilterCase<EdiFileDataUploadGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filteredList => {
                            ListEdiFileDataUploadGrpc returnCollection = new ListEdiFileDataUploadGrpc();
                            returnCollection.EdiFileDataUploadGrpc.AddRange(filteredList);
                            returnResponse.ListEdiFileDataUploadGrpc = returnCollection;
                        }, context.CancellationToken);
                    break;
                case "EdiFileDataUploadDuplicatesGrpc":
                    await HandleFilterCase<EdiFileDataUploadDuplicatesGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filteredList => {
                            ListEdiFileDataUploadDuplicatesGrpc returnCollection = new ListEdiFileDataUploadDuplicatesGrpc();
                            returnCollection.EdiFileDataUploadDuplicatesGrpc.AddRange(filteredList);
                            returnResponse.ListEdiFileDataUploadDuplicatesGrpc = returnCollection;
                        }, context.CancellationToken);
                    break;
                case "EdiGlobalParametersGrpc":
                    await HandleFilterCase<EdiGlobalParametersGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filteredList => {
                            ListEdiGlobalParametersGrpc returnCollection = new ListEdiGlobalParametersGrpc();
                            returnCollection.EdiGlobalParametersGrpc.AddRange(filteredList);
                            returnResponse.ListEdiGlobalParametersGrpc = returnCollection;
                        }, context.CancellationToken);
                    break;
                case "EdiInvoiceInformationGrpc":
                    await HandleFilterCase<EdiInvoiceInformationGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filteredList => {
                            ListEdiInvoiceInformationGrpc returnCollection = new ListEdiInvoiceInformationGrpc();
                            returnCollection.EdiInvoiceInformationGrpc.AddRange(filteredList);
                            returnResponse.ListEdiInvoiceInformationGrpc = returnCollection;
                        }, context.CancellationToken);
                    break;
                case "EdiInvoiceInformationDuplicatesGrpc":
                    await HandleFilterCase<EdiInvoiceInformationDuplicateGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filteredList => {
                            ListEdiInvoiceInformationDuplicatesGrpc returnCollection = new ListEdiInvoiceInformationDuplicatesGrpc();
                            returnCollection.EdiInvoiceInformationDuplicateGrpc.AddRange(filteredList);
                            returnResponse.ListEdiInvoiceInformationDuplicatesGrpc = returnCollection;
                        }, context.CancellationToken);
                    break;
                case "EdiInvoiceUnit4Grpc":
                    await HandleFilterCase<EdiInvoiceUnit4Grpc>(filterExpressionString, parsingConfig, returnResponse,
                        filteredList => {
                            ListEdiInvoiceUnit4Grpc returnCollection = new ListEdiInvoiceUnit4Grpc();
                            returnCollection.EdiInvoiceUnit4Grpc.AddRange(filteredList);
                            returnResponse.ListEdiInvoiceUnit4Grpc = returnCollection;
                        }, context.CancellationToken);
                    break;
                case "EdiZeroPriceExceptionsGrpc":
                    await HandleFilterCase<EdiZeroPriceExceptionsGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filteredList => {
                            ListEdiZeroPriceExceptionsGrpc returnCollection = new ListEdiZeroPriceExceptionsGrpc();
                            returnCollection.EdiZeroPriceExceptionsGrpc.AddRange(filteredList);
                            returnResponse.ListEdiZeroPriceExceptionsGrpc = returnCollection;
                        }, context.CancellationToken);
                    break;
                default:
                    _Logger.GenericLogInformation("Unknown Filter Type");
                    break;
            }

            returnResponse.ResponseType = (int)EdiResponseType.EdiFilter;
            return returnResponse;
        }

        async Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig, 
            EdiResponse returnResponse, Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken)
        {
            Expression<Func<T, bool>> filterExpression = DynamicExpressionParser.ParseLambda<T, bool>(parsingConfig, false, filterExpressionString);
            Func<T, bool> compiledExpression = filterExpression.Compile();
            IEnumerable<T> filteredList = await _EdiAccessService.Filter(compiledExpression, cancellationToken);
            
            if (filteredList.Any())
            {
                setResponseCollection(filteredList);
                returnResponse.Success = true;
            }
        }
    }
}
