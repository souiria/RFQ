namespace DSI.Endpoints.GrpcServices
{
    public class DSIGrpcService : DSI.DSIBase
    {
        readonly IDSIAccessService _DSIAccessService;
        readonly ILogger<DSIGrpcService> _Logger;

        public DSIGrpcService(
            IDSIAccessService dsiAccessService,
            ILogger<DSIGrpcService> logger)
        {
            _DSIAccessService = dsiAccessService;
            _Logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        //////////////////////////////////////////////////////
        //  READ APIs
        //////////////////////////////////////////////////////

        public override async Task<ListComponentGrpc> GetAllComponent(GetAllRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllComponent starting");
            return await _DSIAccessService.GetAllComponent(
                context.CancellationToken,
                request.Position,
                request.Take);
        }

        public override async Task<ListBranchInsulationGrpc> GetAllBranchInsulation(GetAllRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllBranchInsulation starting");
            return await _DSIAccessService.GetAllBranchInsulation(
                context.CancellationToken,
                request.Position,
                request.Take);
        }

        public override async Task<ListWireSpecificationGrpc> GetAllWireSpecification(GetAllRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllWireSpecification starting");
            return await _DSIAccessService.GetAllWireSpecification(
                context.CancellationToken,
                request.Position,
                request.Take);
        }

        public override async Task<ListCompositeDetailGrpc> GetAllCompositeDetail(GetAllRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllCompositeDetail starting");
            return await _DSIAccessService.GetAllCompositeDetail(
                context.CancellationToken,
                request.Position,
                request.Take);
        }

        public override async Task<ListHarnessGrpc> GetAllHarness(GetAllRequest request, ServerCallContext context)
        {
            return await _DSIAccessService.GetAllHarness(
                context.CancellationToken,
                request.Position,
                request.Take);
        }
        public override async Task<ListCompositeDetailGrpc>GetCompositeDetailByHarnessName( GetHarnessByNameRequest request,  ServerCallContext context)        {
            return await _DSIAccessService
                .GetCompositeDetailByHarnessName(
                    request.HarnessName,
                    context.CancellationToken);
        }
        public override async Task<ListComponentGrpc>GetComponentsByHarnessAndOptions(GetComponentByHarnessRequest request,ServerCallContext context)     
        {
            return await _DSIAccessService.GetComponentsByHarnessAndOptions(
                request.HarnessName,
                [.. request.CompositeOptions],
                context.CancellationToken);
        }
        public override async Task<DSIFilterResponse> FilterDSIGrpc(DSIFilterRequest request,ServerCallContext context)
        {
            _Logger.GenericLogInformation("FilterDSIGrpc starting");

            ParsingConfig parsingConfig = new ParsingConfig();
            DSIFilterResponse response = new DSIFilterResponse();

            switch (request.DatabaseList.ToUpperInvariant())
            {
                case "COMPONENTGRPC":
                await _DSIAccessService.HandleFilterCase<ComponentGrpc>(
                    request.FilterExpression,
                    parsingConfig,
                    list =>
                    {
                        ListComponentGrpc result = new();
                        result.ComponentList.AddRange(list);
                        response.ComponentList = result;
                        response.Success = true;
                    },
                    context.CancellationToken);
                break;

                case "BRANCHINSULATIONGRPC":
                await _DSIAccessService.HandleFilterCase<BranchInsulationGrpc>(
                    request.FilterExpression,
                    parsingConfig,
                    list =>
                    {
                        ListBranchInsulationGrpc result = new();
                        result.BranchInsulationList.AddRange(list);
                        response.BranchInsulationList = result;
                        response.Success = true;
                    },
                    context.CancellationToken);
                break;

                case "WIRESPECIFICATIONGRPC":
                await _DSIAccessService.HandleFilterCase<WireSpecificationGrpc>(
                    request.FilterExpression,
                    parsingConfig,
                    list =>
                    {
                        ListWireSpecificationGrpc result = new();
                        result.WireSpecificationList.AddRange(list);
                        response.WireSpecificationList = result;
                        response.Success = true;
                    },
                    context.CancellationToken);
                break;

                case "COMPOSITEDETAILGRPC":
                await _DSIAccessService.HandleFilterCase<CompositeDetailGrpc>(
                    request.FilterExpression,
                    parsingConfig,
                    list =>
                    {
                        ListCompositeDetailGrpc result = new();
                        result.CompositeDetailList.AddRange(list);
                        response.CompositeDetailList = result;
                        response.Success = true;
                    },
                    context.CancellationToken);
                break;

                case "HARNESSGRPC":
                await _DSIAccessService.HandleFilterCase<HarnessGrpc>(
                    request.FilterExpression,
                    parsingConfig,
                    list =>
                    {
                        ListHarnessGrpc result = new();
                        result.HarnessList.AddRange(list);
                        response.HarnessList = result;
                        response.Success = true;
                    },
                    context.CancellationToken);
                break;

                default:
             _Logger.GenericLogInformation($"FilterRfqGrpc: Unknown DatabaseList '{request.DatabaseList}'");
                break;
            }

            return response;
        }
    }
}