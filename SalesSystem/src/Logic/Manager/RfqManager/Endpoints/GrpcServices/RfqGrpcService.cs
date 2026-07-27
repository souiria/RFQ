namespace RfqModule.Endpoints.GrpcServices
{
    public class RfqGrpcService : RfqModule.RfqModuleBase
    {
        readonly ILogger<RfqGrpcService> _Logger;
        readonly IRfqManagerService _RfqManagerService;

        public RfqGrpcService(ILogger<RfqGrpcService> logger, IRfqManagerService rfqManagerService)
        {
            _Logger = logger;
            _RfqManagerService = rfqManagerService;
        }

        public override Task<CommonTypes.HelloReply> SayHello(CommonTypes.HelloRequest request, ServerCallContext context)
        {
            CommonTypes.HelloReply reply = new CommonTypes.HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<CommonTypes.HelloReply> result = Task.FromResult(reply);
            return result;
        }
        public override async Task<GetAllCustomersGrpcResponse> GetAllCustomersGrpc(GetAllCustomersGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllCustomersGrpc starting");
            GetAllCustomersGrpcResponse response = await _RfqManagerService.GetAllCustomersGrpc(request);
            return response;
        }
        //public override async Task<GetCustomersByUserIdGrpcResponse> 
        //    GetCustomersByUserIdGrpc(GetCustomersByUserIdGrpcRequest request, ServerCallContext context)
        //{
        //    _Logger.GenericLogInformation("GetCustomersByUserIdGrpc starting");
        //    GetCustomersByUserIdGrpcResponse response = await _RfqManagerService.GetCustomersByUserIdGrpc(request);
        //    return response;
        //}

        public override async Task<GetProjectAssociationsByCustomerIdResponse> GetProjectAssociationsByCustomerId(GetProjectAssociationsByCustomerIdRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomersByUserIdGrpc starting");
            GetProjectAssociationsByCustomerIdResponse response = await _RfqManagerService.GetProjectAssociationsByCustomerId(request);
            return response;
        }

        public override async Task<GetRfqReasonsGrpcResponse> GetRfqReasonsGrpc(GetRfqReasonsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($">>> GetRfqReasonsGrpc starting");
            GetRfqReasonsGrpcResponse response = await _RfqManagerService.GetRfqReasonsGrpc(request);
            return response;
        }
        public override async Task<UploadPartsRequestGrpcResponse> UploadPartsGrpc(UploadPartsRequestGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($">>> UploadPartsGrpc starting for {request.FileName} BOM");
            UploadPartsRequestGrpcResponse response = await _RfqManagerService.UploadPartsGrpc(request);
            return response;
        }

        public override async Task<CreateRfqProjectGrpcResponse> CreateRfqProjectGrpc(CreateRfqProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($">>> CreateRfqProjectGrpc starting for RfqNumber: {request.Project.RfqNumber}");
            CreateRfqProjectGrpcResponse response = await _RfqManagerService.CreateRfqProject(request);
            return response;
        }

        public override async Task<GetAllRfqProjectGrpcResponse> GetAllRfqProjectGrpc(GetAllRfqProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($">>> GetAllRfqProjectGrpc starting");
            GetAllRfqProjectGrpcResponse response = await _RfqManagerService.GetAllRfqProjectGrpc(request);
            return response;
        }
        public override async Task<GetRfqProjectByIdGrpcResponse> GetRfqProjectByIdGrpc(GetRfqProjectByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($">>> GetRfqProjectByIdGrpc starting for RFQ RowId: {request.RowId}");
            GetRfqProjectByIdGrpcResponse response = await _RfqManagerService.GetRfqProjectByIdGrpc(request);
            return response;
        }
        public override async Task<ListRfqDrawingPartNumberGrpc> GetRfqDrawingPartNumbersByRfqIdGrpc(RfqDrawingPartNumbersGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($">>> GetRfqDrawingPartNumbersByRfqIdGrpc starting for RFQ ID: {request.RfqId}");
            RfqDrawingPartNumbersGrpcRequest accessRequest = new RfqDrawingPartNumbersGrpcRequest();
            accessRequest.RfqId = request.RfqId;
            ListRfqDrawingPartNumberGrpc response = await _RfqManagerService.GetRfqDrawingPartNumbersByRfqIdGrpc(accessRequest);
            return response;
        }
        public override async Task<RfqCrudResponse> UpdateRfqDrawingPartNumbersGrpc(
            RfqDrawingPartNumbersGrpcRequest request,
            ServerCallContext context)
        {
            _Logger.GenericLogInformation($">>> UpdateRfqDrawingPartNumbersGrpc starting for {request.RfqDrawingPartNumbersGrpcsToUpdate.Count} items");
            RfqCrudResponse response = await _RfqManagerService.UpdateRfqDrawingPartNumbers(request);
            return response;
        }
        public override async Task<RfqCrudResponse> DeleteRfqDrawingPartNumbersGrpc(
            RfqDrawingPartNumbersGrpcRequest request,
            ServerCallContext context)
        {
            _Logger.GenericLogInformation($">>> DeleteRfqDrawingPartNumbersGrpc starting for {request.RfqDrawingPartNumbersGrpcsToDelete.Count} items");
            RfqCrudResponse response =
                await _RfqManagerService.DeleteRfqDrawingPartNumbersGrpc(request);
            return response;
        }
        public override async Task<UpdateRfqProjectGrpcResponse> UpdateRfqProjectGrpc(UpdateRfqProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateRfqProjectGrpc starting");
            UpdateRfqProjectGrpcResponse response = await _RfqManagerService.UpdateRfqProject(request);
            return response;
        }
        public override async Task<RfqCrudResponse> DeleteRfqProjectByRowIdGrpc(RfqProjectRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("DeleteRfqProjectByRowIdGrpc starting");
            return await _RfqManagerService.DeleteRfqProjectByRowIdGrpc(request);
        }

        public override async Task<GetCustomerLocationsByUserIdResponse> GetCustomerLocationsByUserIdGrpc(GetCustomerLocationsByUserIdRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationsByUserId starting");
            GetCustomerLocationsByUserIdResponse response = await _RfqManagerService.GetCustomerLocationsByUserId(request.UserId);
            return response;
        }

        public override async Task<GetCustomerBusinessUnitsByUserIdResponse> GetCustomerBusinessUnitsByUserIdGrpc(GetCustomerBusinessUnitsByUserIdRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerBusinessUnitsByUserId starting");
            GetCustomerBusinessUnitsByUserIdResponse response = await _RfqManagerService.GetCustomerBusinessUnitsByUserId(request.UserId);
            return response;
        }

        public override async Task<GetAlternativePartInfoBySumitomoNumberResponse> GetAlternativePartInfoBySumitomoNumberGrpc(GetAlternativePartInfoBySumitomoNumberRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAlternativePartInfoBySumitomoNumberGrpc starting");
            GetAlternativePartInfoBySumitomoNumberResponse response = await _RfqManagerService.GetAlternativePartInfoBySumitomoNumberResponse(request.SumitomoPartNumber);
            return response;
        }

        public override async Task<GetAllSuppliersGrpcResponse> GetAllSuppliersGrpc(GetAllSuppliersGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllSuppliersGrpc starting");
            GetAllSuppliersGrpcResponse response = await _RfqManagerService.GetAllSuppliersGrpc(request);
            return response;
        }

        public override async Task<GetAllSupplierGroupsGrpcResponse> GetAllSupplierGroupsGrpc(GetAllSupplierGroupsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllSupplierGroupsGrpc starting");
            GetAllSupplierGroupsGrpcResponse response = await _RfqManagerService.GetAllSupplierGroupsGrpc(request);
            return response;
        }

        public override async Task<CreateNprGrpcResponse> CreateNprGrpc(CreateNprGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateNprGrpc starting");
            CreateNprGrpcResponse response = await _RfqManagerService.CreateNprGrpc(request);
            return response;
        }

        public override async Task<SearchPartPricesGrpcResponse> SearchPartPricesGrpc(SearchPartPricesGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("SearchPartPricesGrpc starting");
            SearchPartPricesGrpcResponse response = await _RfqManagerService.SearchPartPricesGrpc(request);
            return response;
        }

        public override async Task<FilterGrpcResponse> FilterGrpc(FilterGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("FilterGrpc starting");
            FilterGrpcResponse response = new FilterGrpcResponse();
            RfqManagerFilterType filterType = (RfqManagerFilterType)request.FilterRequest.RequestType;
            switch (filterType)
            {
                case RfqManagerFilterType.FilterByCustomerId:
                    response = await _RfqManagerService.FilterByCustomerId(request);
                    break;
                case RfqManagerFilterType.FilterByLocationId:
                    response = await _RfqManagerService.FilterByLocationId(request);
                    break;
                case RfqManagerFilterType.FilterByProjectCode:
                    response = await _RfqManagerService.FilterByProjectCode(request);
                    break;
                case RfqManagerFilterType.FilterEmacsByExactPartNumber:
                    response = await _RfqManagerService.FilterEmacsByExactPartNumber(request);
                    break;
                case RfqManagerFilterType.FilterEmacsByContainingPartNumber:
                    response = await _RfqManagerService.FilterEmacsByContainingPartNumber(request);
                    break;
                case RfqManagerFilterType.FilterAdssBySumitomoPartNumber:
                    response = await _RfqManagerService.FilterAdssBySumitomoPartNumber(request);
                    break;
                case RfqManagerFilterType.FilterNPRBySumitomoPartNumber:
                    response = await _RfqManagerService.FilterNPRBySumitomoPartNumber(request);
                    break;
                case RfqManagerFilterType.FilterCPDBySumitomoPartNumber:
                    response = await _RfqManagerService.FilterCPDBySumitomoPartNumber(request);
                    break;
                case RfqManagerFilterType.FilterRFQBySumitomoPartNumber:
                    response = await _RfqManagerService.FilterRFQBySumitomoPartNumber(request);
                    break;
                default:
                    _Logger.GenericLogInformation($"FilterGrpc received unknown filter type: {filterType}");
                    break;
            }

            return response;
        }

        public override async Task<GetAllAlternativePartsGrpcResponse> GetAllAlternativePartsGrpc(GetAllAlternativePartsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"GetAlternativePartsGrpc starting at position {request.Position} taking {request.Take} - 120s timeout");
            TimeSpan ts = TimeSpan.FromSeconds(120);
            using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(context.CancellationToken))
            {
                // Use cts.Token here
                //cts.CancelAfter(ts);
                GetAllAlternativePartsGrpcResponse response = await _RfqManagerService.GetAllAlternativePartsGrpc(request, cts.Token);
                return response;
            }
        }
       
        public override async Task<GetRfqNprRequestByRfqNumberGrpcResponse> GetRfqNprRequestByRfqNumberGrpc(GetRfqNprRequestByRfqNumberGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"GetRfqNprRequestByRfqNumberGrpc starting");
            GetRfqNprRequestByRfqNumberGrpcResponse response = await _RfqManagerService.GetRfqNprRequestByRfqNumberGrpc(request);
            return response;
        }
        public override async Task<GetRfqNprRequestByRfqProjectIdGrpcResponse> GetRfqNprRequestByRfqProjectIdGrpc(GetRfqNprRequestByRfqProjectIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"GetRfqNprRequestByRfqProjectIdGrpc starting");
            GetRfqNprRequestByRfqProjectIdGrpcResponse response = await _RfqManagerService.GetRfqNprRequestByRfqProjectIdGrpc(request);
            return response;
        }
        public override async Task<GetRfqNprRequestByIdGrpcResponse> GetRfqNprRequestByIdGrpc(GetRfqNprRequestByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"GetRfqNprRequestByIdGrpc starting");
            GetRfqNprRequestByIdGrpcResponse response = await _RfqManagerService.GetRfqNprRequestByIdGrpc(request);
            return response;
        }
        public override async Task<GetAllRfqNprRequestGrpcResponse> GetAllRfqNprRequestGrpc(GetAllRfqNprRequestGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"GetAllRfqNprRequestGrpc starting");
            GetAllRfqNprRequestGrpcResponse response = await _RfqManagerService.GetAllRfqNprRequestGrpc(request);
            return response;
        }
        public override async Task<CreateRfqNprRequestGrpcResponse> CreateRfqNprRequestGrpc(CreateRfqNprRequestGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"CreateRfqNprRequestGrpc starting");
            CreateRfqNprRequestGrpcResponse response = await _RfqManagerService.CreateRfqNprRequestGrpc(request);
            return response;
        }
        public override async Task<UpdateRfqNprRequestGrpcResponse> UpdateRfqNprRequestGrpc(UpdateRfqNprRequestGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"UpdateRfqNprRequestGrpc starting");
            UpdateRfqNprRequestGrpcResponse response = await _RfqManagerService.UpdateRfqNprRequestGrpc(request);
            return response;
        }
        public override async Task<UpdateRfqNprRequestStatusGrpcResponse> UpdateRfqNprRequestStatusGrpc(UpdateRfqNprRequestStatusGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"UpdateRfqNprRequestStatusGrpc starting");
            UpdateRfqNprRequestStatusGrpcResponse response = await _RfqManagerService.UpdateRfqNprRequestStatusGrpc(request);
            return response;
        }
        public override async Task<DeleteRfqNprRequestByIdGrpcResponse> DeleteRfqNprRequestByIdGrpc(DeleteRfqNprRequestByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"DeleteRfqNprRequestByIdGrpc starting");
            DeleteRfqNprRequestByIdGrpcResponse response = await _RfqManagerService.DeleteRfqNprRequestByIdGrpc(request);
            return response;
        }
        public override async Task<GetAllUnitOfMeasuresResponse> GetAllUnitOfMeasuresGrpc(GetAllUnitOfMeasuresRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"GetAllUnitOfMeasuresGrpc starting");
            GetAllUnitOfMeasuresResponse response = await _RfqManagerService.GetAllUnitOfMeasuresGrpc(request);
            return response;
        }
        public override async Task<GetAllBusinessUnitsGrpcResponse> GetAllBuisnessUnitsGrpc(GetAllBusinessUnitsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"GetAllBuisnessUnitsGrpc starting");
            GetAllBusinessUnitsGrpcResponse response = await _RfqManagerService.GetAllBusinessUnitsGrpc(request);
            return response;
        }
        public override Task<WhoAmIResponse> WhoAmI(Empty request, ServerCallContext context)
        {
            string user = Environment.UserName;
            string domain = Environment.UserDomainName;

            WhoAmIResponse response = new WhoAmIResponse();
            response.User = domain + "\\" + user;

            Task<WhoAmIResponse> result = Task.FromResult(response);

            return result;
        }
        public override async Task<GetAllHarnessModuleResponse> GetAllHarnessGrpc(GetAllHarnessModuleRequest request,  ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetAllHarnessGrpc starting");
              GetAllHarnessModuleResponse response =
                await _RfqManagerService.GetAllHarnessGrpc(request);

            return response;
        }
        public override async Task<GetHarnessByIdGrpcResponse> GetHarnessByIdGrpc(GetHarnessByIdGrpcRequest request,ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetHarnessByIdGrpc starting");

            GetHarnessByIdGrpcResponse response =
                await _RfqManagerService.GetHarnessByIdGrpc(request);

            return response;
        }

        public override async Task<GetCompositeDetailByHarnessResponse> GetCompositeDetailByHarnessGrpc(GetCompositeDetailByHarnessRequest request,
    ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCompositeDetailByHarnessGrpc starting");

            GetCompositeDetailByHarnessResponse response =
                await _RfqManagerService.GetCompositeDetailByHarnessGrpc(request);

            return response;
        }
        public override async Task<GetCompositeDetailByHarnessNameResponse> GetCompositeDetailByHarnessNameGrpc(
    GetCompositeDetailByHarnessNameRequest request,
    ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCompositeDetailByHarnessNameGrpc starting");

            GetCompositeDetailByHarnessNameResponse response =
              await _RfqManagerService.GetCompositeDetailByHarnessNameGrpc(request);

            return response;
        }
        public override async Task<GetWireSpecificationByCompositeOptionResponse> GetWireSpecificationByCompositeOptionGrpc(
            GetWireSpecificationByCompositeOptionRequest request,
            ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetWireSpecificationByCompositeOptionGrpc starting");

            GetWireSpecificationByCompositeOptionResponse response =
                await _RfqManagerService.GetWireSpecificationByCompositeOptionGrpc(request);

            return response;
        }
        public override async Task<ListComponentGrpc> GetComponentsByHarnessAndOptionsGrpc(
       GetComponentsByHarnessAndOptionsRequest request,
       ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetComponentsByHarnessAndOptionsGrpc starting");

            ListComponentGrpc response =
                await _RfqManagerService.GetComponentsByHarnessAndOptionsGrpc(request);

            return response;
        }
     }
}
