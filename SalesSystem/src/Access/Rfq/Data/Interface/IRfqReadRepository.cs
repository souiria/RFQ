namespace Rfq.Data.Interface
{
    public interface IRfqReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
}
