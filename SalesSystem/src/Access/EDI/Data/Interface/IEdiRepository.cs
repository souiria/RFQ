namespace EDI.Data.Interface
{
    public interface IEdiRepository<T> : IRepository<T> where T : class, IAggregateRoot;
}
