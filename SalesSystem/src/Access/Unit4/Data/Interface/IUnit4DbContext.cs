namespace Unit4.Data.Interface
{
    public interface IUnit4DbContext
    {
        DbSet<DbAlgBatchInput> AlgBatchInputs
        { get; }
        DbSet<DbAlgProductInput> AlgProductInputs
        { get; }
        DbSet<DbMinAlgArticle> MinAlgArticles
        { get; }
        DbSet<DbUnit4SalesOrdersView> Unit4SalesOrdersViewItems
        { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
