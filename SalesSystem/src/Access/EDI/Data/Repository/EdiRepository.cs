namespace EDI.Data.Repository
{
    class EdiRepository<T> : RepositoryBase<T>, IEdiReadRepository<T>, IEdiRepository<T> where T : class, IAggregateRoot
    {
        readonly EdiDbContext _DbContext;
        public EdiRepository(EdiDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
