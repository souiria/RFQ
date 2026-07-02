namespace Commercial.Data.Repository
{
    public class CommercialRepository<T> : RepositoryBase<T>, ICommercialReadRepository<T>, ICommercialRepository<T> where T : class, IAggregateRoot
    {
        readonly CommercialDbContext _DbContext;
        public CommercialRepository(CommercialDbContext context) : base(context)
        {
            _DbContext = context;
        }
    }
}
