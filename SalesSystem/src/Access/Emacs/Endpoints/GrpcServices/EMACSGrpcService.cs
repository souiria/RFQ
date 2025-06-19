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

        public override async Task<ListPartCategoryDetailData> GetPartCategoryDetailDataByPARTMS(PartCategoryDetailByPARTMSGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartCategoryDetailDataByPARTMS starting");
            return await _EMACSAccessService.GetPartCategoryDetailByPARTMS(request.CategoryCode ,context.CancellationToken);
        }
        #endregion

        #region PartClassDetail
        public override async Task<ListPartClassDetailData> GetPartClassDetailData(PartClassDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartClassDetailData starting");
            return await _EMACSAccessService.GetAllPartClassDetail(context.CancellationToken);
        }
        public override async Task<ListPartClassDetailData> GetPartClassDetailDataByPARTMS(PartClassDetailByPARTMSGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartClassDetailDataByPARTMS starting");
            return await _EMACSAccessService.GetPartClassDetailByPARTMS(request.Class1, request.Class2 ,context.CancellationToken);
        }
        #endregion

        #region PartGroups
        public override async Task<ListPartGroupsData> GetPartGroupsData(PartGroupsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsData starting");
            return await _EMACSAccessService.GetAllPartGroups(context.CancellationToken);
        }
        public override async Task<ListPartGroupsData> GetPartGroupsDataByPARTMS(PartGroupsByPARTMSGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsData starting");
            return await _EMACSAccessService.GetPartGroupsByPARTMS(request.PartGroup, context.CancellationToken);
        }
        #endregion

        #region PartGroupsConst
        public override async Task<ListPartGroupsConstData> GetPartGroupsConstData(PartGroupsConstGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsConstData starting");
            return await _EMACSAccessService.GetAllPartGroupsConst(context.CancellationToken);
        }
        public override async Task<ListPartGroupsConstData> GetPartGroupsConstDataByPARTMS(PartGroupsConstByPARTMSGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsConstData starting");
            return await _EMACSAccessService.GetAllPartGroupsConstByPARTMS(request.Group3,context.CancellationToken);
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
        public override async Task<ListColourCodeData> GetColourCodeDataByPARTMS(GetColourCodeByPARTMSGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetColourCodeDataByPARTMS starting");
            return await _EMACSAccessService.GetColourCodeByPARTMS(request.ColorCode ,context.CancellationToken);
        }
        #endregion

        #region MaterialGroups
        public override async Task<ListMaterialGroupsData> GetMaterialGroupsData(GetMaterialGroupsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialGroups starting");
            return await _EMACSAccessService.GetAllMaterialGroups(context.CancellationToken);
        }
        public override async Task<ListMaterialGroupsData> GetMaterialGroupsDataByPARTMS(GetMaterialGroupsByPARTMSGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialGroupsDataByPARTMS starting");
            return await _EMACSAccessService.GetMaterialGroupsByPARTMS(request.MaterialGroup, context.CancellationToken);
        }
        #endregion

        #region MaterialTypes
        public override async Task<ListMaterialTypesData> GetMaterialTypesData(GetMaterialTypesGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialTypes starting");
            return await _EMACSAccessService.GetAllMaterialTypes(context.CancellationToken);
        }
        public override async Task<ListMaterialTypesData> GetMaterialTypesDataByPARTMS(GetMaterialTypesByPARTMSGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMaterialTypesByPARTMSData starting");
            return await _EMACSAccessService.GetMaterialTypesByPARTMS(request.MaterialGroup, request.MaterialType,context.CancellationToken);
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
        public override async Task<ListPARTMS> GetPARTMS(GetPARTMSGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMS starting");

            return await _EMACSAccessService.GetAllPARTMS(context.CancellationToken);
        }

        public override async Task<ListPARTMS> GetPARTMSByClass(GetPARTMSByClassGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSByClass starting");
            
            return await _EMACSAccessService.GetPARTMSByClass(request.Class1, request.Class2, context.CancellationToken);
        }
        public override async Task<ListPARTMS> GetPARTMSByColorCode(GetPARTMSByColorCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSByColorCode starting");
            
            return await _EMACSAccessService.GetPARTMSByColorCode(request.ColorCode, context.CancellationToken);
        }
        public override async Task<ListPARTMS> GetPARTMSByMaterial(GetPARTMSByMaterialGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSByMaterial starting");
            
            return await _EMACSAccessService.GetPARTMSByMaterial(request.MaterialGroup, request.MaterialType, context.CancellationToken);
        }
        public override async Task<ListPARTMS> GetPARTMSByMaterialGroup(GetPARTMSByMaterialGroupGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSByMaterialGroup starting");

            return await _EMACSAccessService.GetPARTMSByMaterialGroup(request.MaterialGroup, context.CancellationToken);
        }
        public override async Task<ListPARTMS> GetPARTMSByPartGroup(GetPARTMSByPartGroupGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSByPartGroup starting");

            return await _EMACSAccessService.GetPARTMSByPartGroup(request.PartGroup, context.CancellationToken);
        }
        public override async Task<ListPARTMS> GetPARTMSByCatogoryCode(GetPARTMSByCatogoryCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSByCatogoryCode starting");

            return await _EMACSAccessService.GetPARTMSByCatogoryCode(request.CatogoryCode, context.CancellationToken);
        }
        public override async Task<ListPARTMS> GetPARTMSByPartGroupsConstCode(GetPARTMSByPartGroupsConstCodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPARTMSByPartGroupsConstCode starting");

            return await _EMACSAccessService.GetPARTMSByPartGroupsConstCode(request.PartGroupsConstCode, context.CancellationToken);
        }
        #endregion
    }
}
