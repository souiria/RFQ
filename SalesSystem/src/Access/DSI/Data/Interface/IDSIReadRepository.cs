namespace DSI.Data.Interface
{
    public interface IDSIReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
}
