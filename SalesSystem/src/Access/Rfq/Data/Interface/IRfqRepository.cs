namespace Rfq.Data.Interface
{
    public interface IRfqRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
    }
}
