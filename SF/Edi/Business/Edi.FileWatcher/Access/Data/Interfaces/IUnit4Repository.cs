namespace Edi.FileWatcher.Access.Data.Interfaces;

public interface IUnit4Repository<T> : IRepository<T> where T : class, IAggregateRoot
{
}
