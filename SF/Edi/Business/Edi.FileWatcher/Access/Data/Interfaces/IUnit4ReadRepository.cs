namespace Edi.FileWatcher.Access.Data.Interfaces;

public interface IUnit4ReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot
{
}
