namespace CPD.Data.Repository
{
    public class CPDRepository<T> : RepositoryBase<T>, ICPDDbRepository<T>, ICPDReadRepository<T> where T : class, IAggregateRoot
    {
        readonly CPDDbContext _DbContext;

        public CPDRepository(CPDDbContext dbContext) : base(dbContext) 
        {
            _DbContext = dbContext;
        }
    }
}
