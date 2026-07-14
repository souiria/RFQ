namespace Emacs.Data.Interface
{
    public interface IEMACSRepository<T> : IRepository<T> where T : class, IAggregateRoot;
}
