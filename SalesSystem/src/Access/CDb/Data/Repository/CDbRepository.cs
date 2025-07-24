namespace CDb.Data.Repository
{
    class CDbRepository<T> : RepositoryBase<T>, ICDbReadRepository<T>, ICDbRepository<T> where T : class, IAggregateRoot
    {
        readonly CDbContext _DbContext;

        public CDbRepository(CDbContext context) : base(context)
        {
            _DbContext = context;
        }
    }
}
