namespace Emacs.Services
{
    public interface IEMACSAccessService
    {
        #region CombinedParts
        Task<ListCombinedPartsData> GetAllCombinedParts(CancellationToken cancellationToken);
        Task<Result<int>> GetCombinedPartsDataCount(CancellationToken cancellationToken);

        Task<bool> PopulateCombinedPartsAsync(CancellationToken cancellationToken);
        #endregion

        #region PartCategoryDetail

        Task<ListPartCategoryDetailData> GetAllPartCategoryDetail(CancellationToken cancellationToken);
        Task<ListPartCategoryDetailData> GetPartCategoryDetailByCategoryCode(string categoryCode, CancellationToken cancellationToken);

        Task<bool> PopulatePartCategoryDetailAsync(CancellationToken cancellationToken);
        #endregion

        #region PartClassDetail

        Task<ListPartClassDetailData> GetAllPartClassDetail(CancellationToken cancellationToken);
        Task<ListPartClassDetailData> GetPartClassDetailByClasses(string class1, double class2 ,CancellationToken cancellationToken);

        Task<bool> PopulatePartClassDetailAsync(CancellationToken cancellationToken);
        #endregion

        #region PartGroups

        Task<ListPartGroupsData> GetAllPartGroups(CancellationToken cancellationToken);
        Task<ListPartGroupsData> GetPartGroupsByPartGroup(string partGroup, CancellationToken cancellationToken);

        Task<bool> PopulatePartGroupsAsync(CancellationToken cancellationToken);
        #endregion

        #region PartGroupsConst

        Task<ListPartGroupsConstData> GetAllPartGroupsConst(CancellationToken cancellationToken);
        Task<ListPartGroupsConstData> GetAllPartGroupsConstByGroup3(string group3,CancellationToken cancellationToken);

        Task<bool> PopulatePartGroupsConstAsync(CancellationToken cancellationToken);
        #endregion

        #region CustomerData

        Task<ListCustomerDataGrpc> GetAllCustomerData(CancellationToken cancellationToken);

        Task<bool> PopulateCustomerDataAsync(CancellationToken cancellationToken);
        #endregion

        #region ColourCode

        Task<ListColourCodeData> GetAllColourCode(CancellationToken cancellationToken);
        Task<ListColourCodeData> GetColourCodeByColorCode(string colorCode, CancellationToken cancellationToken);

        Task<bool> PopulateColourCodeAsync(CancellationToken cancellationToken);
        #endregion

        #region MaterialGroups

        Task<ListMaterialGroupsData> GetAllMaterialGroups(CancellationToken cancellationToken);
        Task<ListMaterialGroupsData> GetMaterialGroupsByMaterialGroupId(string materialGroupId, CancellationToken cancellationToken);

        Task<bool> PopulateMaterialGroupsAsync(CancellationToken cancellationToken);
        #endregion

        #region MaterialTypes

        Task<ListMaterialTypesData> GetAllMaterialTypes(CancellationToken cancellationToken);
        Task<ListMaterialTypesData> GetMaterialTypesByMaterials(string materialGroup, string materialType, CancellationToken cancellationToken);

        Task<bool> PopulateMaterialTypesAsync(CancellationToken cancellationToken);
        #endregion

        #region NPACustomer

        Task<ListNPACustomerData> GetAllNPACustomer(CancellationToken cancellationToken);

        Task<bool> PopulateNPACustomerAsync(CancellationToken cancellationToken);
        #endregion

        #region NPASupplier

        Task<ListNPASupplierData> GetAllNPASupplier(CancellationToken cancellationToken);

        Task<bool> PopulateNPASupplierAsync(CancellationToken cancellationToken);
        #endregion

        #region Suppliers

        Task<ListSuppliersData> GetAllSuppliers(CancellationToken cancellationToken);

        Task<bool> PopulateSuppliersAsync(CancellationToken cancellationToken);
        #endregion

        #region EmacsRFIView

        Task<ListEmacsRFIViewData> GetAllEmacsRFIView(CancellationToken cancellationToken);

        Task<bool> PopulateEmacsRFIViewAsync(CancellationToken cancellationToken);
        #endregion

        #region PARTMS

        Task<ListPARTMSData> GetAllPARTMSData(CancellationToken cancellationToken);
        Task<ListPARTMSData> GetPARTMSDataByClass(string class1, double class2, CancellationToken cancellationToken);
        Task<ListPARTMSData> GetPARTMSDataByColorCode(string colorCode, CancellationToken cancellationToken);
        Task<ListPARTMSData> GetPARTMSDataByMaterial(string materialGroup, string materialType, CancellationToken cancellationToken);
        Task<ListPARTMSData> GetPARTMSDataByMaterialGroup(string materialGroup, CancellationToken cancellationToken);
        Task<ListPARTMSData> GetPARTMSDataByPartGroup(string partGroup, CancellationToken cancellationToken);
        Task<ListPARTMSData> GetPARTMSDataByCategoryCode(string catogoryCode, CancellationToken cancellationToken);
        Task<ListPARTMSData> GetPARTMSDataByPartGroupsConstCode(string partGroupsConstCode, CancellationToken cancellationToken);

        Task<bool> PopulatePARTMSAsync(CancellationToken cancellationToken);
        #endregion
    }
}