namespace Emacs.Data.Repository
{
    public class EMACSRepository<T> : RepositoryBase<T>, IEMACSReadRepository<T>, IEMACSRepository<T> where T : class, IAggregateRoot
    {
        readonly EMACSDbContext _DbContext;

        public EMACSRepository(EMACSDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
