namespace Unit4.Data.Interface
{
    public interface IUnit4DbContext
    {
        DbSet<DbEdiFileDataUpload> EdiFileDataUploads
        { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
