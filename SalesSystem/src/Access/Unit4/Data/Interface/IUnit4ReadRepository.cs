namespace EDI.Data.Interface
{
    public interface IUnit4ReadRepository<T> : IReadRepository<T> where T : class, IAggregateRoot;
}
