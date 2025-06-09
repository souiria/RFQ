namespace Emacs.Data.Interface
{
    public interface IEMACSDbContext
    {
        DbSet<DbCombinedParts> CombinedParts 
        { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
