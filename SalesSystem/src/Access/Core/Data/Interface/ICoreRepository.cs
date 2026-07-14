namespace Core.Data.Interface
{
    public interface ICoreRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
    }
}
