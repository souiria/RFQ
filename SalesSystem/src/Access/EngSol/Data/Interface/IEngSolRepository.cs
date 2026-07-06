namespace EngSol.Data.Interface
{
    public interface IEngSolRepository<T> : IRepository<T> where T : class, IAggregateRoot;
}
