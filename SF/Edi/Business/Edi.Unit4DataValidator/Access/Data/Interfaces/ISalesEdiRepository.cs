namespace Edi.Unit4DataValidator.Access.Data.Interfaces;

public interface ISalesEdiRepository<T> : IRepository<T> where T : class, IAggregateRoot
{
}
