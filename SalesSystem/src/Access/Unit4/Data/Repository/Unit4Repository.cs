namespace Unit4.Data.Repository
{
    class Unit4Repository<T> : RepositoryBase<T>, IUnit4ReadRepository<T>, IUnit4Repository<T> where T : class, IAggregateRoot
    {
        readonly Unit4DbContext _DbContext;
        public Unit4Repository(Unit4DbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
