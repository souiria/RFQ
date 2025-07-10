namespace SFS.Data.Repository
{
    public class SFSRepository<T> : RepositoryBase<T>, ISFSDbRepository<T>, ISFSReadRepository<T> where T : class, IAggregateRoot
    {
        readonly SFSDbContext _DbContext;
        public SFSRepository(SFSDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
