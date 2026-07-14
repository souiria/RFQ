namespace NPR.Data.Interface
{
    public interface INPRReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
}
