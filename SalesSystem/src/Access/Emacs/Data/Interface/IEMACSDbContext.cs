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
        DbSet<DbPartGroups> PartGroups
        { get; }
        DbSet<DbPartGroupsConst> PartGroupsConst
        { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
