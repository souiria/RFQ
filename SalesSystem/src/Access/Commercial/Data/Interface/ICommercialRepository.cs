namespace Commercial.Data.Interface
{
    public interface ICommercialRepository<T> : IRepository<T> where T : class, IAggregateRoot;
}
