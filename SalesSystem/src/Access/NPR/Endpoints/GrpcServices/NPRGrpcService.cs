using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
namespace NPR.Endpoints.GrpcServices
{
    public class NPRGrpcService : NPR.NPRBase
    {
        readonly INPRAccessService _NPRAccessService;
        readonly ILogger<NPRGrpcService> _Logger;

        public NPRGrpcService(INPRAccessService nPRAccessService, ILogger<NPRGrpcService> logger)
        {
            _NPRAccessService = nPRAccessService;
            _Logger = logger;
        }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        #region H1NPRView
        public override async Task<ListH1NPRViewGrpc> GetAllH1NPRViewGrpc(H1NPRViewRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetH1NPRViewGrpc starting");
            return await _NPRAccessService.GetAllH1NPRView(context.CancellationToken, request.Position, request.Takeamount);
        }
        #endregion

        #region RFQStatus
        public override async Task<ListRFQStatusGrpc> GetAllRFQStatusGrpc(RFQStatusRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllRFQStatusGrpc starting");
            return await _NPRAccessService.GetAllRFQStatus(context.CancellationToken, request.Position, request.Takeamount);
        }
        #endregion

        public override async Task<NPRFilterResponse> FilterNPRGrpc(NPRFilterRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("FilterNPRGrpc starting");
            ParsingConfig parsingConfig = new ParsingConfig();
            NPRFilterResponse returnResponse = new NPRFilterResponse();
            await _NPRAccessService.HandleFilterCase<H1NPRViewGrpc>(
                request.FilterExpression, parsingConfig,
                filterlist =>
                {
                    ListH1NPRViewGrpc returnList = new ListH1NPRViewGrpc();
                    returnList.H1NPRViewGrpc.AddRange(filterlist);
                    returnResponse.ListH1NPRViewGrpc = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
            return returnResponse;
        }

        // ------------------------------------------------------------
        // NEW: NPR Request Sets
        // ------------------------------------------------------------

        public override async Task<ListRfqNprRequestSetGrpc> GetAllNprRequestSets(
            Empty request,
            ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllNprRequestSets starting");

            ListRfqNprRequestSetGrpc response = new ListRfqNprRequestSetGrpc();

            List<RfqNprRequestSetModel> loadedSets = await _NPRAccessService
                .LoadNprRequestSetsFromBackendAsync(context.CancellationToken)
                ?? new List<RfqNprRequestSetModel>();

            if (loadedSets.Count < 1)
            {
                return response;
            }

            foreach (RfqNprRequestSetModel setModel in loadedSets)
            {
                RfqNprRequestSetGrpc? mapped = setModel.MapToGrpc();
                if (mapped is not null)
                {
                    response.Items.Add(mapped);
                }
            }

            return response;
        }
         public override async Task<Empty> SaveAllNprRequestSets(
            ListRfqNprRequestSetGrpc request,
            ServerCallContext context)
        {
            _Logger.GenericLogInformation("SaveAllNprRequestSets starting");

            List<RfqNprRequestSetModel> dtoSets = new List<RfqNprRequestSetModel>();

            // Normalize request + items
            List<RfqNprRequestSetGrpc> items = request?.Items?.ToList()
                        ?? new List<RfqNprRequestSetGrpc>();

            foreach (RfqNprRequestSetGrpc? g in items)
            {
                RfqNprRequestSetModel? model = g.MapToModel();
                if (model is not null)
                {
                    dtoSets.Add(model);
                }
            }

            ReadOnlyCollection<RfqNprRequestSetModel> readOnlySets = new ReadOnlyCollection<RfqNprRequestSetModel>(dtoSets);

            await _NPRAccessService.SaveNprRequestSetsToBackendAsync(
                readOnlySets,
                context.CancellationToken);

            Empty result;
            result = new Empty();

            return result;
        }
    }
}
