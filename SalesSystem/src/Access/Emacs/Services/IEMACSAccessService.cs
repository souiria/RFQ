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
        Task<ListPartCategoryDetailData> GetPartCategoryDetailByPARTMS(string categoryCode, CancellationToken cancellationToken);

        Task<bool> PopulatePartCategoryDetailAsync(CancellationToken cancellationToken);
        #endregion

        #region PartClassDetail

        Task<ListPartClassDetailData> GetAllPartClassDetail(CancellationToken cancellationToken);
        Task<ListPartClassDetailData> GetPartClassDetailByPARTMS(string class1, double class2 ,CancellationToken cancellationToken);

        Task<bool> PopulatePartClassDetailAsync(CancellationToken cancellationToken);
        #endregion

        #region PartGroups

        Task<ListPartGroupsData> GetAllPartGroups(CancellationToken cancellationToken);
        Task<ListPartGroupsData> GetPartGroupsByPARTMS(string partGroup, CancellationToken cancellationToken);

        Task<bool> PopulatePartGroupsAsync(CancellationToken cancellationToken);
        #endregion

        #region PartGroupsConst

        Task<ListPartGroupsConstData> GetAllPartGroupsConst(CancellationToken cancellationToken);
        Task<ListPartGroupsConstData> GetAllPartGroupsConstByPARTMS(string group3,CancellationToken cancellationToken);

        Task<bool> PopulatePartGroupsConstAsync(CancellationToken cancellationToken);
        #endregion

        #region CustomerData

        Task<ListCustomerDataGrpc> GetAllCustomerData(CancellationToken cancellationToken);

        Task<bool> PopulateCustomerDataAsync(CancellationToken cancellationToken);
        #endregion

        #region ColourCode

        Task<ListColourCodeData> GetAllColourCode(CancellationToken cancellationToken);
        Task<ListColourCodeData> GetColourCodeByPARTMS(string colorCode, CancellationToken cancellationToken);

        Task<bool> PopulateColourCodeAsync(CancellationToken cancellationToken);
        #endregion

        #region MaterialGroups

        Task<ListMaterialGroupsData> GetAllMaterialGroups(CancellationToken cancellationToken);
        Task<ListMaterialGroupsData> GetMaterialGroupsByPARTMS(string materialGroupId, CancellationToken cancellationToken);

        Task<bool> PopulateMaterialGroupsAsync(CancellationToken cancellationToken);
        #endregion

        #region MaterialTypes

        Task<ListMaterialTypesData> GetAllMaterialTypes(CancellationToken cancellationToken);
        Task<ListMaterialTypesData> GetMaterialTypesByPARTMS(string materialGroup, string materialType, CancellationToken cancellationToken);

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

        Task<ListPARTMS> GetAllPARTMS(CancellationToken cancellationToken);
        Task<ListPARTMS> GetPARTMSByClass(string class1, double class2, CancellationToken cancellationToken);
        Task<ListPARTMS> GetPARTMSByColorCode(string colorCode, CancellationToken cancellationToken);
        Task<ListPARTMS> GetPARTMSByMaterial(string materialGroup, string materialType, CancellationToken cancellationToken);
        Task<ListPARTMS> GetPARTMSByMaterialGroup(string materialGroup, CancellationToken cancellationToken);
        Task<ListPARTMS> GetPARTMSByPartGroup(string partGroup, CancellationToken cancellationToken);
        Task<ListPARTMS> GetPARTMSByCatogoryCode(string catogoryCode, CancellationToken cancellationToken);
        Task<ListPARTMS> GetPARTMSByPartGroupsConstCode(string partGroupsConstCode, CancellationToken cancellationToken);

        Task<bool> PopulatePARTMSAsync(CancellationToken cancellationToken);
        #endregion
    }
}