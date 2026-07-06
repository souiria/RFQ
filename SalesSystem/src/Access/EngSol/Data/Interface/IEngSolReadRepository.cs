namespace EngSol.Data.Interface
{
    public interface IEngSolReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
}
