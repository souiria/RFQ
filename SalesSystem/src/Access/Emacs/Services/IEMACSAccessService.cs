namespace Emacs.Services
{
    public interface IEMACSAccessService
    {
        #region CombinedParts
        Task<Result<List<CombinedPartsDto>>> GetAllCombinedParts(CancellationToken cancellationToken);
        Task<Result<int>> GetCombinedPartsDataCount(CancellationToken cancellationToken);

        Task<bool> PopulateCombinedPartsAsync(CancellationToken cancellationToken);
        #endregion

        #region PartCategoryDetail

        Task<Result<List<PartCategoryDetailDto>>> GetAllPartCategoryDetail(CancellationToken cancellationToken);

        Task<bool> PopulatePartCategoryDetailAsync(CancellationToken cancellationToken);
        #endregion

        #region PartClassDetail

        Task<Result<List<PartClassDetailDto>>> GetAllPartClassDetail(CancellationToken cancellationToken);

        Task<bool> PopulatePartClassDetailAsync(CancellationToken cancellationToken);
        #endregion

        #region PartGroups

        Task<Result<List<PartGroupsDto>>> GetAllPartGroups(CancellationToken cancellationToken);

        Task<bool> PopulatePartGroupsAsync(CancellationToken cancellationToken);
        #endregion

        #region PartGroupsConst

        Task<Result<List<PartGroupsConstDto>>> GetAllPartGroupsConst(CancellationToken cancellationToken);

        Task<bool> PopulatePartGroupsConstAsync(CancellationToken cancellationToken);
        #endregion

        #region CustomerData

        Task<Result<List<CustomerDataDto>>> GetAllCustomerData(CancellationToken cancellationToken);

        Task<bool> PopulateCustomerDataAsync(CancellationToken cancellationToken);
        #endregion
    }
}