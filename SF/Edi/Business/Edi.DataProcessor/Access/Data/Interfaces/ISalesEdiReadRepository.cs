namespace Edi.DataProcessor.Access.Data.Interfaces;

public interface ISalesEdiReadRepository<T> :  IReadRepository<T> where T : class, IAggregateRoot;
