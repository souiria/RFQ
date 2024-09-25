namespace Edi.Unit4DataProcessor.Access.Data.Interfaces;

public interface IQuotationSystemRepository<T> : IRepository<T> where T : class, IAggregateRoot
{
}
