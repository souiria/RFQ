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

        public override async Task<ListPartCategoryDetailGrpc> GetPartCategoryDetailGrpcByCategoryCode(PartCategoryDetailByCategoryCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartCategoryDetailGrpcByCategoryCode starting");
            return await _EMACSAccessService.GetPartCategoryDetailByCategoryCode(request.CategoryCode ,context.CancellationToken);
        }
        #endregion

        #region PartClassDetail
        public override async Task<ListPartClassDetailGrpc> GetPartClassDetailGrpc(PartClassDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartClassDetailGrpc starting");
            return await _EMACSAccessService.GetAllPartClassDetail(context.CancellationToken);
        }
        public override async Task<ListPartClassDetailGrpc> GetPartClassDetailGrpcByClasses(PartClassDetailByClassesGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartClassDetailGrpcByClasses starting");
            return await _EMACSAccessService.GetPartClassDetailByClasses(request.Class1, request.Class2 ,context.CancellationToken);
        }
        #endregion

        #region PartGroups
        public override async Task<ListPartGroupsGrpc> GetPartGroupsGrpc(PartGroupsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsGrpc starting");
            return await _EMACSAccessService.GetAllPartGroups(context.CancellationToken);
        }
        public override async Task<ListPartGroupsGrpc> GetPartGroupsGrpcByPartGroup(PartGroupsByPartGroupGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsGrpcByPartGroup starting");
            return await _EMACSAccessService.GetPartGroupsByPartGroup(request.PartGroup, context.CancellationToken);
        }
        #endregion

        #region PartGroupsConst
        public override async Task<ListPartGroupsConstGrpc> GetPartGroupsConstGrpc(PartGroupsConstGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsConstGrpc starting");
            return await _EMACSAccessService.GetAllPartGroupsConst(context.CancellationToken);
        }
        public override async Task<ListPartGroupsConstGrpc> GetPartGroupsConstGrpcByGroup3(PartGroupsConstByGroup3GrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsConstGrpc starting");
            return await _EMACSAccessService.GetAllPartGroupsConstByGroup3(request.Group3,context.CancellationToken);
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
        public override async Task<ListColourCodeGrpc> GetColourCodeGrpcByColorCode(GetColourCodeByColorCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetColourCodeGrpcByColorCode starting");
            return await _EMACSAccessService.GetColourCodeByColorCode(request.ColorCode ,context.CancellationToken);
        }
        #endregion

        #region MaterialGroups
        public override async Task<ListMaterialGroupsGrpc> GetMaterialGroupsGrpc(GetMaterialGroupsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialGroups starting");
            return await _EMACSAccessService.GetAllMaterialGroups(context.CancellationToken);
        }
        public override async Task<ListMaterialGroupsGrpc> GetMaterialGroupsGrpcByMaterialGroupId(GetMaterialGroupsByMaterialGroupIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialGroupsGrpcByMaterialGroupId starting");
            return await _EMACSAccessService.GetMaterialGroupsByMaterialGroupId(request.MaterialGroup, context.CancellationToken);
        }
        #endregion

        #region MaterialTypes
        public override async Task<ListMaterialTypesGrpc> GetMaterialTypesGrpc(GetMaterialTypesGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialTypes starting");
            return await _EMACSAccessService.GetAllMaterialTypes(context.CancellationToken);
        }
        public override async Task<ListMaterialTypesGrpc> GetMaterialTypesGrpcByMaterials(GetMaterialTypesByMaterialsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialTypesGrpcByMaterials starting");
            return await _EMACSAccessService.GetMaterialTypesByMaterials(request.MaterialGroup, request.MaterialType,context.CancellationToken);
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

        public override async Task<ListPARTMSGrpc> GetPARTMSGrpcByClass(GetPARTMSGrpcByClassGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSGrpcByClass starting");
            
            return await _EMACSAccessService.GetPARTMSGrpcByClass(request.Class1, request.Class2, context.CancellationToken);
        }
        public override async Task<ListPARTMSGrpc> GetPARTMSGrpcByColorCode(GetPARTMSGrpcByColorCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSGrpcByColorCode starting");
            
            return await _EMACSAccessService.GetPARTMSGrpcByColorCode(request.ColorCode, context.CancellationToken);
        }
        public override async Task<ListPARTMSGrpc> GetPARTMSGrpcByMaterial(GetPARTMSGrpcByMaterialGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSGrpcByMaterial starting");
            
            return await _EMACSAccessService.GetPARTMSGrpcByMaterial(request.MaterialGroup, request.MaterialType, context.CancellationToken);
        }
        public override async Task<ListPARTMSGrpc> GetPARTMSGrpcByMaterialGroup(GetPARTMSGrpcByMaterialGroupGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSGrpcByMaterialGroup starting");

            return await _EMACSAccessService.GetPARTMSGrpcByMaterialGroup(request.MaterialGroup, context.CancellationToken);
        }
        public override async Task<ListPARTMSGrpc> GetPARTMSGrpcByPartGroup(GetPARTMSGrpcByPartGroupGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSGrpcByPartGroup starting");

            return await _EMACSAccessService.GetPARTMSGrpcByPartGroup(request.PartGroup, context.CancellationToken);
        }
        public override async Task<ListPARTMSGrpc> GetPARTMSGrpcByCategoryCode(GetPARTMSGrpcByCategoryCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSGrpcByCatogoryCode starting");

            return await _EMACSAccessService.GetPARTMSGrpcByCategoryCode(request.CatogoryCode, context.CancellationToken);
        }
        public override async Task<ListPARTMSGrpc> GetPARTMSGrpcByPartGroupsConstCode(GetPARTMSGrpcByPartGroupsConstCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSGrpcByPartGroupsConstCode starting");

            return await _EMACSAccessService.GetPARTMSGrpcByPartGroupsConstCode(request.PartGroupsConstCode, context.CancellationToken);
        }
        #endregion

        public override async Task<EmacsFilterResponse> FilterEmacsDataGrpc(EmacsFilterRequest request, ServerCallContext context)
        {
            ParsingConfig parsingConfig = new ParsingConfig();
            string filterExpressionString = request.FilterExpression.ToUpperInvariant();
            EmacsFilterResponse returnResponse = new EmacsFilterResponse();

            switch (request.DatabaseList)
            {
                case "CombinedPartsGrpc":
                    await HandleFilterCase<CombinedPartsGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filterList => {
                            ListCombinedPartsGrpc returnList = new ListCombinedPartsGrpc();
                            returnList.CombinedPartsGrpc.AddRange(filterList);
                            returnResponse.ListCombinedPartsGrpc = returnList;
                        }, context.CancellationToken);
                    break;
                case "PartCategoryDetailGrpc":
                    await HandleFilterCase<PartCategoryDetailGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filterList => {
                            ListPartCategoryDetailGrpc returnList = new ListPartCategoryDetailGrpc();
                            returnList.PartCategoryDetailGrpc.AddRange(filterList);
                            returnResponse.ListPartCategoryDetailGrpc = returnList;
                        }, context.CancellationToken);
                    break;
                case "PartClassDetailGrpc":
                    await HandleFilterCase<PartClassDetailGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filterList => {
                            ListPartClassDetailGrpc returnList = new ListPartClassDetailGrpc();
                            returnList.PartClassDetailGrpc.AddRange(filterList);
                            returnResponse.ListPartClassDetailGrpc = returnList;
                        }, context.CancellationToken);
                    break;
                case "PartGroupsGrpc":
                    await HandleFilterCase<PartGroupsGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filterList => {
                            ListPartGroupsGrpc returnList = new ListPartGroupsGrpc();
                            returnList.PartGroupsGrpc.AddRange(filterList);
                            returnResponse.ListPartGroupsGrpc = returnList;
                        }, context.CancellationToken);
                    break;
                case "PartGroupsConstGrpc":
                    await HandleFilterCase<PartGroupsConstGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filterList => {
                            ListPartGroupsConstGrpc returnList = new ListPartGroupsConstGrpc();
                            returnList.PartGroupsConstGrpc.AddRange(filterList);
                            returnResponse.ListPartGroupsConstGrpc = returnList;
                        }, context.CancellationToken);
                    break;
                case "CustomerDataGrpc":
                    await HandleFilterCase<CustomerDataGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filterList => {
                            ListCustomerDataGrpc returnList = new ListCustomerDataGrpc();
                            returnList.CustomerDataGrpc.AddRange(filterList);
                            returnResponse.ListCustomerDataGrpc = returnList;
                        }, context.CancellationToken);
                    break;
                case "ColourCodeGrpc":
                    await HandleFilterCase<ColourCodeGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filterList => {
                            ListColourCodeGrpc returnList = new ListColourCodeGrpc();
                            returnList.ColourCodeGrpc.AddRange(filterList);
                            returnResponse.ListColourCodeGrpc = returnList;
                        }, context.CancellationToken);
                    break;
                case "MaterialGroupsGrpc":
                    await HandleFilterCase<MaterialGroupsGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filterList => {
                            ListMaterialGroupsGrpc returnList = new ListMaterialGroupsGrpc();
                            returnList.MaterialGroupsGrpc.AddRange(filterList);
                            returnResponse.ListMaterialGroupsGrpc = returnList;
                        }, context.CancellationToken);
                    break;
                case "MaterialTypesGrpc":
                    await HandleFilterCase<MaterialTypesGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filterList => {
                            ListMaterialTypesGrpc returnList = new ListMaterialTypesGrpc();
                            returnList.MaterialTypesGrpc.AddRange(filterList);
                            returnResponse.ListMaterialTypesGrpc = returnList;
                        }, context.CancellationToken);
                    break;
                case "NPACustomerGrpc":
                    await HandleFilterCase<NPACustomerGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filterList => {
                            ListNPACustomerGrpc returnList = new ListNPACustomerGrpc();
                            returnList.NPACustomerGrpc.AddRange(filterList);
                            returnResponse.ListNPACustomerGrpc = returnList;
                        }, context.CancellationToken);
                    break;
                case "NPASupplierGrpc":
                    await HandleFilterCase<NPASupplierGrpc>(filterExpressionString, parsingConfig, returnResponse,
                        filterList => {
                            ListNPASupplierGrpc returnList = new ListNPASupplierGrpc();
                            returnList.NPASupplierGrpc.AddRange(filterList);
                            returnResponse.ListNPASupplierGrpc = returnList;
                        }, context.CancellationToken);
                    break;
                case "SuppliersGrpc":
                    await HandleFilterCase<SuppliersGrpc>(filterExpressionString, parsingConfig, returnResponse,
                       filterList => {
                           ListSuppliersGrpc returnList = new ListSuppliersGrpc();
                           returnList.SuppliersGrpc.AddRange(filterList);
                           returnResponse.ListSuppliersGrpc = returnList;
                       }, context.CancellationToken);
                    break;
                case "EmacsRFIViewGrpc":
                    await HandleFilterCase<EmacsRFIViewGrpc>(filterExpressionString, parsingConfig, returnResponse,
                       filterList => {
                           ListEmacsRFIViewGrpc returnList = new ListEmacsRFIViewGrpc();
                           returnList.EmacsRFIViewGrpc.AddRange(filterList);
                           returnResponse.ListEmacsRFIViewGrpc = returnList;
                       }, context.CancellationToken);
                    break;
                case "PartMSGrpc":
                    await HandleFilterCase<PARTMSGrpc>(filterExpressionString, parsingConfig, returnResponse,
                       filterList => {
                           ListPARTMSGrpc returnList = new ListPARTMSGrpc();
                           returnList.PARTMSGrpc.AddRange(filterList);
                           returnResponse.ListPARTMSGrpc = returnList;
                       }, context.CancellationToken);
                    break;
                default:
                    _Logger.GenericLogInformation($"FilterEmacsDataGrpc: Unknown DatabaseList '{request.DatabaseList}'");
                    break;
            }

            return returnResponse;
        }

        async Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            EmacsFilterResponse returnResponse, Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken)
        {
            Expression<Func<T, bool>> filterExpression = DynamicExpressionParser.ParseLambda<T, bool>(parsingConfig, false, filterExpressionString);
            Func<T, bool> compiledExpression = filterExpression.Compile();
            IEnumerable<T> filteredList = await _EMACSAccessService.Filter(compiledExpression, cancellationToken);

            if (filteredList.Any())
            {
                setResponseCollection(filteredList);
                returnResponse.Success = true;
            }
        }
    }
}
