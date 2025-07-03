namespace Master.Data.Interface
{
    public interface IMastersReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
}
