namespace Purchasing.Data.Repository
{
    public class PurchasingRepository<T> : RepositoryBase<T>, IPurchasingReadRepository<T>, IPurchasingRepository<T> where T : class, IAggregateRoot
    {
        readonly PurchasingDbContext _DbContext;

        public PurchasingRepository(PurchasingDbContext dbContext): base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
