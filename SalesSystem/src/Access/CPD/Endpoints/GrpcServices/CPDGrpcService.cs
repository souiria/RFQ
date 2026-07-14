namespace CPD.Endpoints.GrpcServices
{
    public class CPDGrpcService : CPD.CPDBase
    {
        readonly ICPDAccessService _CPDAccessService;
        readonly ILogger<CPDGrpcService> _Logger;

        public CPDGrpcService(ICPDAccessService cPDAccessService, ILogger<CPDGrpcService> logger)
        {
            _CPDAccessService = cPDAccessService;
            _Logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        #region MatSuppMst
        public override async Task<ListMatSuppMstGrpc> GetAllMatSuppMstView(MatSuppMstViewGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllMatSuppMstView starting");
            return await _CPDAccessService.GetAllMatSuppMstView(context.CancellationToken, request.Position, request.TakeAmount);

        }
        #endregion

        #region HarnessCostingCalculationData
        public override async Task<ListHarnessCostingCalculationDataGrpc> GetAllHarnessCostingCalculationDataView(HarnessCostingCalculationDataViewGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllHarnessCostingCalculationDataView starting");
            return await _CPDAccessService.GetHarnessCostingCalculationDataView(context.CancellationToken, request.Position, request.TakeAmount);

        }
        #endregion

        public override async Task<CPDFilterResponse> FilterCPDGrpc(CPDFilterRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("FilterCPDGrpc starting");
            ParsingConfig parsingConfig = new ParsingConfig();
            CPDFilterResponse returnResponse = new CPDFilterResponse();
            await _CPDAccessService.HandleFilterCase<MatSuppMstViewGrpc>(
                request.FilterExpression, parsingConfig,
                filterlist =>
                {
                    ListMatSuppMstGrpc returnList = new ListMatSuppMstGrpc();
                    returnList.MatSuppMstViewGrpc.AddRange(filterlist);
                    returnResponse.ListMatSuppMstGrpc = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
            return returnResponse;
        }
    }
}
