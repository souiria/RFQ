namespace EDI.Data.Interface
{
    public interface IEdiReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
}
