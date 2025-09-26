namespace Core.Data.Interface
{
    public interface ICoreDbContext
    {
        DbSet<DbUserList> UserListItems
        { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
