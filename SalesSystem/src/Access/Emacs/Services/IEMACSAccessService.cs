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

        Task<bool> PopulatePartCategoryDetailAsync(CancellationToken cancellationToken);
        #endregion

        #region PartClassDetail

        Task<ListPartClassDetailGrpc> GetAllPartClassDetail(CancellationToken cancellationToken);

        Task<bool> PopulatePartClassDetailAsync(CancellationToken cancellationToken);
        #endregion

        #region PartGroups

        Task<ListPartGroupsGrpc> GetAllPartGroups(CancellationToken cancellationToken);

        Task<bool> PopulatePartGroupsAsync(CancellationToken cancellationToken);
        #endregion

        #region PartGroupsConst

        Task<ListPartGroupsConstGrpc> GetAllPartGroupsConst(CancellationToken cancellationToken);

        Task<bool> PopulatePartGroupsConstAsync(CancellationToken cancellationToken);
        #endregion

        #region CustomerData

        Task<ListCustomerDataGrpc> GetAllCustomerData(CancellationToken cancellationToken);

        Task<bool> PopulateCustomerDataAsync(CancellationToken cancellationToken);
        #endregion

        #region ColourCode

        Task<ListColourCodeGrpc> GetAllColourCode(CancellationToken cancellationToken);

        Task<bool> PopulateColourCodeAsync(CancellationToken cancellationToken);
        #endregion

        #region MaterialGroups

        Task<ListMaterialGroupsGrpc> GetAllMaterialGroups(CancellationToken cancellationToken);

        Task<bool> PopulateMaterialGroupsAsync(CancellationToken cancellationToken);
        #endregion

        #region MaterialTypes

        Task<ListMaterialTypesGrpc> GetAllMaterialTypes(CancellationToken cancellationToken);

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

        Task<bool> PopulatePARTMSAsync(CancellationToken cancellationToken);
        #endregion

        #region AlternativeParts

        Task<ListAlternativePartsGrpc> GetAllAlternativePartsGrpc(CancellationToken cancellationToken);

        Task<bool> PopulateAlternativePartsAsync(CancellationToken cancellationToken);

        #endregion

        Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken);
    }
}