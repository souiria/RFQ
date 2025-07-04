namespace CPD.Data.Interface
{
    public interface ICPDReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
}
