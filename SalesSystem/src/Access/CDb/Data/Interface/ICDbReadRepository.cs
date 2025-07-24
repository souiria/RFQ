namespace CDb.Data.Interface
{
    public interface ICDbReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
}
