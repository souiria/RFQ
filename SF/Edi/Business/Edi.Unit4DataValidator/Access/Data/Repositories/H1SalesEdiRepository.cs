using Edi.Unit4DataValidator.Access.Data.Contexts;
using Edi.Unit4DataValidator.Access.Data.Interfaces;

namespace Edi.Unit4DataValidator.Access.Data.Repositories;

internal class H1SalesEdiRepository<T> : RepositoryBase<T>, ISalesEdiReadRepository<T>, ISalesEdiRepository<T> where T : class, IAggregateRoot
{
    private readonly H1SalesEdiDbContext dbContext;
    public H1SalesEdiRepository(H1SalesEdiDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

}
