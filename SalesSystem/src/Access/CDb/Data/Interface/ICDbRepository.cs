namespace CDb.Data.Interface
{
    public interface ICDbRepository<T> : IRepository<T> where T : class, IAggregateRoot;
}
