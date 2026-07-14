namespace Purchasing.Data.Interface
{
    public interface IPurchasingReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
}
