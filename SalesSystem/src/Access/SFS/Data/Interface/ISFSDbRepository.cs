namespace SFS.Data.Interface
{
   public interface ISFSDbRepository<T> : IRepository<T> where T : class, IAggregateRoot;
    
}
