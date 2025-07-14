namespace SFS.Data.Interface
{
    public interface ISFSReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot
    {
    }
}
