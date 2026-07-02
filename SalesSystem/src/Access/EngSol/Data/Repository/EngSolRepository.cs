namespace EngSol.Data.Repository
{
    public class EngSolRepository<T> : RepositoryBase<T>, IEngSolReadRepository<T>, IEngSolRepository<T> where T : class, IAggregateRoot
    {
        readonly EngSolDbContext _DbContext;

        public EngSolRepository(EngSolDbContext context) : base(context)
        {
            _DbContext = context;
        }
    }
}
