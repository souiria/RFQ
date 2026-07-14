namespace Rfq.Data.Repository
{
    public class RfqRepository<T> : RepositoryBase<T>, IRfqReadRepository<T>, IRfqRepository<T> where T : class, IAggregateRoot
    {
        readonly RfqDbContext _DbContext;
        public RfqRepository(RfqDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
