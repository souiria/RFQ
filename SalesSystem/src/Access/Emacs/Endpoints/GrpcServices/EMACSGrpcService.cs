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
        public override async Task<ListCombinedPartsData> GetCombinedPartsData(CombinedPartsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCombinedPartsData starting");
            return await _EMACSAccessService.GetAllCombinedParts(context.CancellationToken);

        }

        public override async Task<CombinedPartsCountData> GetCombinedPartsDataCount(CombinedPartsCountGrpcRequest request, ServerCallContext context)
        {
            CombinedPartsCountData combinedPartsCountData = new();
            Result<int> results = await _EMACSAccessService.GetCombinedPartsDataCount(context.CancellationToken);
            combinedPartsCountData.Count = results.Value;
            return combinedPartsCountData;
        }
        #endregion

        #region PartCatogoryDetail
        public override async Task<ListPartCategoryDetailData> GetPartCategoryDetailData(PartCategoryDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartCategoryDetailData starting");
            return await _EMACSAccessService.GetAllPartCategoryDetail(context.CancellationToken);
        }

        public override async Task<ListPartCategoryDetailData> GetPartCategoryDetailDataByCategoryCode(PartCategoryDetailByCategoryCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartCategoryDetailDataByCategoryCode starting");
            return await _EMACSAccessService.GetPartCategoryDetailByCategoryCode(request.CategoryCode ,context.CancellationToken);
        }
        #endregion

        #region PartClassDetail
        public override async Task<ListPartClassDetailData> GetPartClassDetailData(PartClassDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartClassDetailData starting");
            return await _EMACSAccessService.GetAllPartClassDetail(context.CancellationToken);
        }
        public override async Task<ListPartClassDetailData> GetPartClassDetailDataByClasses(PartClassDetailByClassesGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartClassDetailDataByClasses starting");
            return await _EMACSAccessService.GetPartClassDetailByClasses(request.Class1, request.Class2 ,context.CancellationToken);
        }
        #endregion

        #region PartGroups
        public override async Task<ListPartGroupsData> GetPartGroupsData(PartGroupsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsData starting");
            return await _EMACSAccessService.GetAllPartGroups(context.CancellationToken);
        }
        public override async Task<ListPartGroupsData> GetPartGroupsDataByPartGroup(PartGroupsByPartGroupGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsDataByPartGroup starting");
            return await _EMACSAccessService.GetPartGroupsByPartGroup(request.PartGroup, context.CancellationToken);
        }
        #endregion

        #region PartGroupsConst
        public override async Task<ListPartGroupsConstData> GetPartGroupsConstData(PartGroupsConstGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsConstData starting");
            return await _EMACSAccessService.GetAllPartGroupsConst(context.CancellationToken);
        }
        public override async Task<ListPartGroupsConstData> GetPartGroupsConstDataByGroup3(PartGroupsConstByGroup3GrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsConstData starting");
            return await _EMACSAccessService.GetAllPartGroupsConstByGroup3(request.Group3,context.CancellationToken);
        }
        #endregion

        #region CustomerData
        public override async Task<ListCustomerDataGrpc> GetCustomerData(GetCustomerDataGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerData starting");
            return await _EMACSAccessService.GetAllCustomerData(context.CancellationToken);
        }
        #endregion

        #region ColourCode
        public override async Task<ListColourCodeData> GetColourCodeData(GetColourCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetColourCode starting");
            return await _EMACSAccessService.GetAllColourCode(context.CancellationToken);
        }
        public override async Task<ListColourCodeData> GetColourCodeDataByColorCode(GetColourCodeByColorCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetColourCodeDataByColorCode starting");
            return await _EMACSAccessService.GetColourCodeByColorCode(request.ColorCode ,context.CancellationToken);
        }
        #endregion

        #region MaterialGroups
        public override async Task<ListMaterialGroupsData> GetMaterialGroupsData(GetMaterialGroupsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialGroups starting");
            return await _EMACSAccessService.GetAllMaterialGroups(context.CancellationToken);
        }
        public override async Task<ListMaterialGroupsData> GetMaterialGroupsDataByMaterialGroupId(GetMaterialGroupsByMaterialGroupIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialGroupsDataByMaterialGroupId starting");
            return await _EMACSAccessService.GetMaterialGroupsByMaterialGroupId(request.MaterialGroup, context.CancellationToken);
        }
        #endregion

        #region MaterialTypes
        public override async Task<ListMaterialTypesData> GetMaterialTypesData(GetMaterialTypesGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialTypes starting");
            return await _EMACSAccessService.GetAllMaterialTypes(context.CancellationToken);
        }
        public override async Task<ListMaterialTypesData> GetMaterialTypesDataByMaterials(GetMaterialTypesByMaterialsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialTypesDataByMaterials starting");
            return await _EMACSAccessService.GetMaterialTypesByMaterials(request.MaterialGroup, request.MaterialType,context.CancellationToken);
        }
        #endregion

        #region NPACustomer
        public override async Task<ListNPACustomerData> GetNPACustomerData(GetNPACustomerGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetNPACustomer starting");
            return await _EMACSAccessService.GetAllNPACustomer(context.CancellationToken);
        }
        #endregion

        #region NPASupplier
        public override async Task<ListNPASupplierData> GetNPASupplierData(GetNPASupplierGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetNPASupplier starting");
            return await _EMACSAccessService.GetAllNPASupplier(context.CancellationToken);
        }
        #endregion

        #region Suppliers
        public override async Task<ListSuppliersData> GetSuppliersData(GetSuppliersGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetSuppliers starting");
            return await _EMACSAccessService.GetAllSuppliers(context.CancellationToken);
        }
        #endregion

        #region EmacsRFIView
        public override async Task<ListEmacsRFIViewData> GetEmacsRFIViewData(GetEmacsRFIViewGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetEmacsRFIView starting");
            return await _EMACSAccessService.GetAllEmacsRFIView(context.CancellationToken);
        }
        #endregion

        #region PARTMS
        public override async Task<ListPARTMSData> GetPARTMSData(GetPARTMSDataGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSDataData starting");

            return await _EMACSAccessService.GetAllPARTMSData(context.CancellationToken);
        }

        public override async Task<ListPARTMSData> GetPARTMSDataByClass(GetPARTMSDataByClassGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSDataByClass starting");
            
            return await _EMACSAccessService.GetPARTMSDataByClass(request.Class1, request.Class2, context.CancellationToken);
        }
        public override async Task<ListPARTMSData> GetPARTMSDataByColorCode(GetPARTMSDataByColorCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSDataByColorCode starting");
            
            return await _EMACSAccessService.GetPARTMSDataByColorCode(request.ColorCode, context.CancellationToken);
        }
        public override async Task<ListPARTMSData> GetPARTMSDataByMaterial(GetPARTMSDataByMaterialGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSDataByMaterial starting");
            
            return await _EMACSAccessService.GetPARTMSDataByMaterial(request.MaterialGroup, request.MaterialType, context.CancellationToken);
        }
        public override async Task<ListPARTMSData> GetPARTMSDataByMaterialGroup(GetPARTMSDataByMaterialGroupGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSDataByMaterialGroup starting");

            return await _EMACSAccessService.GetPARTMSDataByMaterialGroup(request.MaterialGroup, context.CancellationToken);
        }
        public override async Task<ListPARTMSData> GetPARTMSDataByPartGroup(GetPARTMSDataByPartGroupGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSDataByPartGroup starting");

            return await _EMACSAccessService.GetPARTMSDataByPartGroup(request.PartGroup, context.CancellationToken);
        }
        public override async Task<ListPARTMSData> GetPARTMSDataByCategoryCode(GetPARTMSDataByCategoryCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSDataByCatogoryCode starting");

            return await _EMACSAccessService.GetPARTMSDataByCategoryCode(request.CatogoryCode, context.CancellationToken);
        }
        public override async Task<ListPARTMSData> GetPARTMSDataByPartGroupsConstCode(GetPARTMSDataByPartGroupsConstCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSDataByPartGroupsConstCode starting");

            return await _EMACSAccessService.GetPARTMSDataByPartGroupsConstCode(request.PartGroupsConstCode, context.CancellationToken);
        }
        #endregion
    }
}
