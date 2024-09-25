namespace Edi.FileWatcher.Access.Data.Interfaces;

public interface IQuotationSystemRepository<T> : IRepository<T> where T : class, IAggregateRoot
{
}
