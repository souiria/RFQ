namespace Emacs.Data.Interface
{
    public interface IEMACSDbContext
    {
        DbSet<DbCombinedParts> CombinedParts 
        { get; }
        DbSet<DbPartCategoryDetail> PartCategoryDetails
        { get; }
        DbSet<DbPartClassDetail> PartClassDetail
        { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
