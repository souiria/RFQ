namespace Filtering.Interfaces
{
    public interface IFilter
    {
        TResult FilterExpression<T, TResult>(IEnumerable<T> collection, Expression<Func<T, bool>> expression);
        TResult FilterExpression<T, TResult>(Func<T, bool> function, AccessServices accessService);
    }
}
