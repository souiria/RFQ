namespace Master.Data.Repository
{
    class MastersRepository<T> : RepositoryBase<T>, IMastersReadRepository<T>, IMastersRepository<T> where T : class, IAggregateRoot
    {
        readonly MastersDbContext _DbContext;
        public MastersRepository(MastersDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
