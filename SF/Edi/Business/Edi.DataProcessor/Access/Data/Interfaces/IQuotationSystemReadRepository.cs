namespace Edi.DataProcessor.Access.Data.Interfaces;

public interface IQuotationSystemReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
