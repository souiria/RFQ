namespace CommercialService2.Api.Common.Interfaces;

/// <summary>
/// An abstraction for persistence, based on Ardalis.Specification
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
