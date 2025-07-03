namespace Master.Data.Interface
{
    public interface IMastersRepository<T> : IRepository<T> where T : class, IAggregateRoot;
}
