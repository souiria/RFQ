namespace Edi.Api.Access.Data.Interfaces;

public interface ISalesEdiReadRepository<T> :  IReadRepository<T> where T : class, IAggregateRoot;
