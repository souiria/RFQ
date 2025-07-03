namespace CPD.Data.Interface
{
    public interface ICPDDbRepository<T> : IRepository<T> where T : class, IAggregateRoot;
}
