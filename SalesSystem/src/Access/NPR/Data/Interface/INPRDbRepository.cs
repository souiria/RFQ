namespace NPR.Data.Interface
{
    public interface INPRDbRepository<T> : IRepository<T> where T : class, IAggregateRoot;
}
