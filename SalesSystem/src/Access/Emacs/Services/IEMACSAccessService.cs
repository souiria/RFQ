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
    }
}