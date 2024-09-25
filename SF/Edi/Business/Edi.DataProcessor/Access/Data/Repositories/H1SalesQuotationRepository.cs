namespace Edi.DataProcessor.Access.Data.Repositories;

public class H1SalesQuotationRepository<T> : RepositoryBase<T>, IQuotationSystemReadRepository<T>, IQuotationSystemRepository<T> where T : class, IAggregateRoot
{
    private readonly H1SalesQuotationDbContext dbContext;
    public H1SalesQuotationRepository(H1SalesQuotationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}
