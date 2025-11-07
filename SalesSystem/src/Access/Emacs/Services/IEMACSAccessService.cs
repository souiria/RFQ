namespace Emacs.Services
{
    public interface IEMACSAccessService
    {
        #region CombinedParts
        Task<ListCombinedPartsGrpc> GetAllCombinedParts(CancellationToken cancellationToken);
        Task<Result<int>> GetCombinedPartsGrpcCount(CancellationToken cancellationToken);

        Task<bool> PopulateCombinedPartsAsync(CancellationToken cancellationToken);
        #endregion

        #region PartCategoryDetail

        Task<ListPartCategoryDetailGrpc> GetAllPartCategoryDetail(CancellationToken cancellationToken);
        Task<ListPartCategoryDetailGrpc> GetPartCategoryDetailByCategoryCode(string categoryCode, CancellationToken cancellationToken);

        Task<bool> PopulatePartCategoryDetailAsync(CancellationToken cancellationToken);
        #endregion

        #region PartClassDetail

        Task<ListPartClassDetailGrpc> GetAllPartClassDetail(CancellationToken cancellationToken);
        Task<ListPartClassDetailGrpc> GetPartClassDetailByClasses(string class1, double class2 ,CancellationToken cancellationToken);

        Task<bool> PopulatePartClassDetailAsync(CancellationToken cancellationToken);
        #endregion

        #region PartGroups

        Task<ListPartGroupsGrpc> GetAllPartGroups(CancellationToken cancellationToken);
        Task<ListPartGroupsGrpc> GetPartGroupsByPartGroup(string partGroup, CancellationToken cancellationToken);

        Task<bool> PopulatePartGroupsAsync(CancellationToken cancellationToken);
        #endregion

        #region PartGroupsConst

        Task<ListPartGroupsConstGrpc> GetAllPartGroupsConst(CancellationToken cancellationToken);
        Task<ListPartGroupsConstGrpc> GetAllPartGroupsConstByGroup3(string group3,CancellationToken cancellationToken);

        Task<bool> PopulatePartGroupsConstAsync(CancellationToken cancellationToken);
        #endregion

        #region CustomerData

        Task<ListCustomerDataGrpc> GetAllCustomerData(CancellationToken cancellationToken);

        Task<bool> PopulateCustomerDataAsync(CancellationToken cancellationToken);
        #endregion

        #region ColourCode

        Task<ListColourCodeGrpc> GetAllColourCode(CancellationToken cancellationToken);
        Task<ListColourCodeGrpc> GetColourCodeByColorCode(string colorCode, CancellationToken cancellationToken);

        Task<bool> PopulateColourCodeAsync(CancellationToken cancellationToken);
        #endregion

        #region MaterialGroups

        Task<ListMaterialGroupsGrpc> GetAllMaterialGroups(CancellationToken cancellationToken);
        Task<ListMaterialGroupsGrpc> GetMaterialGroupsByMaterialGroupId(string materialGroupId, CancellationToken cancellationToken);

        Task<bool> PopulateMaterialGroupsAsync(CancellationToken cancellationToken);
        #endregion

        #region MaterialTypes

        Task<ListMaterialTypesGrpc> GetAllMaterialTypes(CancellationToken cancellationToken);
        Task<ListMaterialTypesGrpc> GetMaterialTypesByMaterials(string materialGroup, string materialType, CancellationToken cancellationToken);

        Task<bool> PopulateMaterialTypesAsync(CancellationToken cancellationToken);
        #endregion

        #region NPACustomer

        Task<ListNPACustomerGrpc> GetAllNPACustomer(CancellationToken cancellationToken);

        Task<bool> PopulateNPACustomerAsync(CancellationToken cancellationToken);
        #endregion

        #region NPASupplier

        Task<ListNPASupplierGrpc> GetAllNPASupplier(CancellationToken cancellationToken);

        Task<bool> PopulateNPASupplierAsync(CancellationToken cancellationToken);
        #endregion

        #region Suppliers

        Task<ListSuppliersGrpc> GetAllSuppliers(CancellationToken cancellationToken);

        Task<bool> PopulateSuppliersAsync(CancellationToken cancellationToken);
        #endregion

        #region EmacsRFIView

        Task<ListEmacsRFIViewGrpc> GetAllEmacsRFIView(CancellationToken cancellationToken);

        Task<bool> PopulateEmacsRFIViewAsync(CancellationToken cancellationToken);
        #endregion

        #region PARTMS

        Task<ListPARTMSGrpc> GetAllPARTMSGrpc(CancellationToken cancellationToken);
        Task<ListPARTMSGrpc> GetPARTMSGrpcByClass(string class1, double class2, CancellationToken cancellationToken);
        Task<ListPARTMSGrpc> GetPARTMSGrpcByColorCode(string colorCode, CancellationToken cancellationToken);
        Task<ListPARTMSGrpc> GetPARTMSGrpcByMaterial(string materialGroup, string materialType, CancellationToken cancellationToken);
        Task<ListPARTMSGrpc> GetPARTMSGrpcByMaterialGroup(string materialGroup, CancellationToken cancellationToken);
        Task<ListPARTMSGrpc> GetPARTMSGrpcByPartGroup(string partGroup, CancellationToken cancellationToken);
        Task<ListPARTMSGrpc> GetPARTMSGrpcByCategoryCode(string catogoryCode, CancellationToken cancellationToken);
        Task<ListPARTMSGrpc> GetPARTMSGrpcByPartGroupsConstCode(string partGroupsConstCode, CancellationToken cancellationToken);

        Task<bool> PopulatePARTMSAsync(CancellationToken cancellationToken);
        #endregion

        Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken);
    }
}