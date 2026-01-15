namespace Purchasing.Data.Interface
{
    public interface IPurchasingRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
    }
}
