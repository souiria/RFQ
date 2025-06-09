namespace Emacs.Data.Interface
{
    public interface IEMACSReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;

}
