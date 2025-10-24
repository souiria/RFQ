namespace Core.Data.Interface
{
    public interface ICoreReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
}
