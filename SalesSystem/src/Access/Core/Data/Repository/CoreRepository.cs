namespace Core.Data.Repository
{
    public class CoreRepository<T> : RepositoryBase<T>, ICoreReadRepository<T>, ICoreRepository<T> where T : class, IAggregateRoot
    {
        CoreDbContext _DbContext;
        public CoreRepository(CoreDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
