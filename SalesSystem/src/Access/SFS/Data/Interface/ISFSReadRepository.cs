namespace SFS.Data.Interface
{
    interface ISFSReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
    
}
