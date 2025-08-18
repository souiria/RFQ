namespace Unit4.Data.Interface
{
    public interface IUnit4Repository<T> : IRepository<T> where T : class, IAggregateRoot;
}
