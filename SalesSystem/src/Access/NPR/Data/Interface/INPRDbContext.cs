namespace NPR.Data.Interface
{
    public interface INPRDbContext
    {
        DbSet<DbH1NPRView> H1NPRItems
        { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
