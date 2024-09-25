namespace Edi.DataProcessor.Access.Data.Interfaces;

public interface IUnit4ReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
