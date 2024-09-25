using Edi.Unit4DataValidator.Access.Data.Contexts;
using Edi.Unit4DataValidator.Access.Data.Interfaces;

namespace Edi.Unit4DataValidator.Access.Data.Repositories;

public class Unit4Repository<T> : RepositoryBase<T>, IUnit4ReadRepository<T>, IUnit4Repository<T> where T : class, IAggregateRoot
{
    private readonly Unit4DbContext dbContext;
    public Unit4Repository(Unit4DbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}
