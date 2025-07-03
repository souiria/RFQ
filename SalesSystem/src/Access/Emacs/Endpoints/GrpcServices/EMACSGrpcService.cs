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
    }
}
