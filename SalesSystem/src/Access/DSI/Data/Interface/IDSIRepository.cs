namespace DSI.Data.Interface
{
    public interface IDSIRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
    }
}
