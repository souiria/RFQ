namespace NPR.Data.Repository
{
    class NPRRepository<T> : RepositoryBase<T>, INPRReadRepository<T>, INPRDbRepository<T> where T : class, IAggregateRoot
    {
        readonly NPRDbContext _DbContext;

        public NPRRepository(NPRDbContext context) : base(context)
        {
            _DbContext = context;
        }
    }
}
