namespace DSI.Data.Repository
{
    public class DSIRepository<T> : RepositoryBase<T>, IDSIReadRepository<T>, IDSIRepository<T> where T : class, IAggregateRoot
    {
        readonly DSIDbContext _DbContext;
        public DSIRepository(DSIDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
