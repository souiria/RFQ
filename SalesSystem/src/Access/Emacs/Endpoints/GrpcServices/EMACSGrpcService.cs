namespace Emacs.Endpoints.GrpcServices
{
    public class EMACSGrpcService : Emacs.EmacsBase
    {
        readonly IEMACSAccessService _EMACSAccessService;
        readonly ILogger<EMACSGrpcService> _Logger;

        public EMACSGrpcService(IEMACSAccessService eMACSAccessService, ILogger<EMACSGrpcService> logger)
        {
            _EMACSAccessService = eMACSAccessService;
            _Logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        #region CombinedParts
        public override async Task<ListCombinedPartsGrpc> GetCombinedPartsGrpc(CombinedPartsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCombinedPartsGrpc starting");
            return await _EMACSAccessService.GetAllCombinedParts(context.CancellationToken);

        }

        public override async Task<CombinedPartsCountGrpc> GetCombinedPartsGrpcCount(CombinedPartsCountGrpcRequest request, ServerCallContext context)
        {
            CombinedPartsCountGrpc combinedPartsCountGrpc = new();
            Result<int> results = await _EMACSAccessService.GetCombinedPartsGrpcCount(context.CancellationToken);
            combinedPartsCountGrpc.Count = results.Value;
            return combinedPartsCountGrpc;
        }
        #endregion

        #region PartCatogoryDetail
        public override async Task<ListPartCategoryDetailGrpc> GetPartCategoryDetailGrpc(PartCategoryDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartCategoryDetailGrpc starting");
            return await _EMACSAccessService.GetAllPartCategoryDetail(context.CancellationToken);
        }
        #endregion

        #region PartClassDetail
        public override async Task<ListPartClassDetailGrpc> GetPartClassDetailGrpc(PartClassDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartClassDetailGrpc starting");
            return await _EMACSAccessService.GetAllPartClassDetail(context.CancellationToken);
        }
        #endregion

        #region PartGroups
        public override async Task<ListPartGroupsGrpc> GetPartGroupsGrpc(PartGroupsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsGrpc starting");
            return await _EMACSAccessService.GetAllPartGroups(context.CancellationToken);
        }
        #endregion

        #region PartGroupsConst
        public override async Task<ListPartGroupsConstGrpc> GetPartGroupsConstGrpc(PartGroupsConstGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsConstGrpc starting");
            return await _EMACSAccessService.GetAllPartGroupsConst(context.CancellationToken);
        }
        #endregion

        #region CustomerData
        public override async Task<ListCustomerDataGrpc> GetCustomerDataGrpc(GetCustomerDataGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerDataGrpc starting");
            return await _EMACSAccessService.GetAllCustomerData(context.CancellationToken);
        }
        #endregion

        #region ColourCode
        public override async Task<ListColourCodeGrpc> GetColourCodeGrpc(GetColourCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetColourCode starting");
            return await _EMACSAccessService.GetAllColourCode(context.CancellationToken);
        }
        #endregion

        #region MaterialGroups
        public override async Task<ListMaterialGroupsGrpc> GetMaterialGroupsGrpc(GetMaterialGroupsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialGroups starting");
            return await _EMACSAccessService.GetAllMaterialGroups(context.CancellationToken);
        }
        #endregion

        #region MaterialTypes
        public override async Task<ListMaterialTypesGrpc> GetMaterialTypesGrpc(GetMaterialTypesGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialTypes starting");
            return await _EMACSAccessService.GetAllMaterialTypes(context.CancellationToken);
        }
        #endregion

        #region NPACustomer
        public override async Task<ListNPACustomerGrpc> GetNPACustomerGrpc(GetNPACustomerGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetNPACustomer starting");
            return await _EMACSAccessService.GetAllNPACustomer(context.CancellationToken);
        }
        #endregion

        #region NPASupplier
        public override async Task<ListNPASupplierGrpc> GetNPASupplierGrpc(GetNPASupplierGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetNPASupplier starting");
            return await _EMACSAccessService.GetAllNPASupplier(context.CancellationToken);
        }
        #endregion

        #region Suppliers
        public override async Task<ListSuppliersGrpc> GetSuppliersGrpc(GetSuppliersGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetSuppliers starting");
            return await _EMACSAccessService.GetAllSuppliers(context.CancellationToken);
        }
        #endregion

        #region EmacsRFIView
        public override async Task<ListEmacsRFIViewGrpc> GetEmacsRFIViewGrpc(GetEmacsRFIViewGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetEmacsRFIView starting");
            return await _EMACSAccessService.GetAllEmacsRFIView(context.CancellationToken);
        }
        #endregion

        #region PARTMS
        public override async Task<ListPARTMSGrpc> GetPARTMSGrpc(GetPARTMSGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSGrpcData starting");

            return await _EMACSAccessService.GetAllPARTMSGrpc(context.CancellationToken);
        }
        #endregion

        public override async Task<EmacsFilterResponseGrpc> FilterEmacsDataGrpc(EmacsFilterRequestGrpc request, ServerCallContext context)
        {
            ParsingConfig parsingConfig = new ParsingConfig();
            string filterExpressionString = request.FilterExpression;

            EmacsFilterResponseGrpc returnResponse = new EmacsFilterResponseGrpc();

            switch (request.DatabaseList)
            {
                case "CombinedPartsGrpc":
                await _EMACSAccessService.HandleFilterCase<CombinedPartsGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListCombinedPartsGrpc returnList = new ListCombinedPartsGrpc();
                    returnList.CombinedPartsGrpc.AddRange(filterList);
                    returnResponse.ListCombinedPartsGrpc = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;
                case "PartCategoryDetailGrpc":
                await _EMACSAccessService.HandleFilterCase<PartCategoryDetailGrpc>(filterExpressionString, parsingConfig,
                    filterList =>
                    {
                        ListPartCategoryDetailGrpc returnList = new ListPartCategoryDetailGrpc();
                        returnList.PartCategoryDetailGrpc.AddRange(filterList);
                        returnResponse.ListPartCategoryDetailGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "PartClassDetailGrpc":
                await _EMACSAccessService.HandleFilterCase<PartClassDetailGrpc>(filterExpressionString, parsingConfig,
                    filterList =>
                    {
                        ListPartClassDetailGrpc returnList = new ListPartClassDetailGrpc();
                        returnList.PartClassDetailGrpc.AddRange(filterList);
                        returnResponse.ListPartClassDetailGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "PartGroupsGrpc":
                await _EMACSAccessService.HandleFilterCase<PartGroupsGrpc>(filterExpressionString, parsingConfig,
                    filterList =>
                    {
                        ListPartGroupsGrpc returnList = new ListPartGroupsGrpc();
                        returnList.PartGroupsGrpc.AddRange(filterList);
                        returnResponse.ListPartGroupsGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "PartGroupsConstGrpc":
                await _EMACSAccessService.HandleFilterCase<PartGroupsConstGrpc>(filterExpressionString, parsingConfig,
                    filterList =>
                    {
                        ListPartGroupsConstGrpc returnList = new ListPartGroupsConstGrpc();
                        returnList.PartGroupsConstGrpc.AddRange(filterList);
                        returnResponse.ListPartGroupsConstGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "CustomerDataGrpc":
                await _EMACSAccessService.HandleFilterCase<CustomerDataGrpc>(filterExpressionString, parsingConfig,
                    filterList =>
                    {
                        ListCustomerDataGrpc returnList = new ListCustomerDataGrpc();
                        returnList.CustomerDataGrpc.AddRange(filterList);
                        returnResponse.ListCustomerDataGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "ColourCodeGrpc":
                await _EMACSAccessService.HandleFilterCase<ColourCodeGrpc>(filterExpressionString, parsingConfig,
                    filterList =>
                    {
                        ListColourCodeGrpc returnList = new ListColourCodeGrpc();
                        returnList.ColourCodeGrpc.AddRange(filterList);
                        returnResponse.ListColourCodeGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "MaterialGroupsGrpc":
                await _EMACSAccessService.HandleFilterCase<MaterialGroupsGrpc>(filterExpressionString, parsingConfig,
                    filterList =>
                    {
                        ListMaterialGroupsGrpc returnList = new ListMaterialGroupsGrpc();
                        returnList.MaterialGroupsGrpc.AddRange(filterList);
                        returnResponse.ListMaterialGroupsGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "MaterialTypesGrpc":
                await _EMACSAccessService.HandleFilterCase<MaterialTypesGrpc>(filterExpressionString, parsingConfig,
                    filterList =>
                    {
                        ListMaterialTypesGrpc returnList = new ListMaterialTypesGrpc();
                        returnList.MaterialTypesGrpc.AddRange(filterList);
                        returnResponse.ListMaterialTypesGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "NPACustomerGrpc":
                await _EMACSAccessService.HandleFilterCase<NPACustomerGrpc>(filterExpressionString, parsingConfig,
                    filterList =>
                    {
                        ListNPACustomerGrpc returnList = new ListNPACustomerGrpc();
                        returnList.NPACustomerGrpc.AddRange(filterList);
                        returnResponse.ListNPACustomerGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "NPASupplierGrpc":
                await _EMACSAccessService.HandleFilterCase<NPASupplierGrpc>(filterExpressionString, parsingConfig,
                    filterList =>
                    {
                        ListNPASupplierGrpc returnList = new ListNPASupplierGrpc();
                        returnList.NPASupplierGrpc.AddRange(filterList);
                        returnResponse.ListNPASupplierGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "SuppliersGrpc":
                await _EMACSAccessService.HandleFilterCase<SuppliersGrpc>(filterExpressionString, parsingConfig,
                   filterList =>
                   {
                       ListSuppliersGrpc returnList = new ListSuppliersGrpc();
                       returnList.SuppliersGrpc.AddRange(filterList);
                       returnResponse.ListSuppliersGrpc = returnList;
                       returnResponse.Success = true;
                   }, context.CancellationToken);
                break;
                case "EmacsRFIViewGrpc":
                await _EMACSAccessService.HandleFilterCase<EmacsRFIViewGrpc>(filterExpressionString, parsingConfig,
                   filterList =>
                   {
                       ListEmacsRFIViewGrpc returnList = new ListEmacsRFIViewGrpc();
                       returnList.EmacsRFIViewGrpc.AddRange(filterList);
                       returnResponse.ListEmacsRFIViewGrpc = returnList;
                       returnResponse.Success = true;
                   }, context.CancellationToken);
                break;
                case "PARTMSGrpc":
                await _EMACSAccessService.HandleFilterCase<PARTMSGrpc>(filterExpressionString, parsingConfig,
                   filterList =>
                   {
                       ListPARTMSGrpc returnList = new ListPARTMSGrpc();
                       returnList.PARTMSGrpc.AddRange(filterList);
                       returnResponse.ListPARTMSGrpc = returnList;
                       returnResponse.Success = true;
                   }, context.CancellationToken);
                break;
                default:
                _Logger.GenericLogInformation($"FilterEmacsDataGrpc: Unknown DatabaseList '{request.DatabaseList}'");
                break;
            }

            return returnResponse;
        }
    }
}
