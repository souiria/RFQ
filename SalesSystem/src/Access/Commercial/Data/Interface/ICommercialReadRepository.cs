namespace Commercial.Data.Interface
{
    public interface ICommercialReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
}
