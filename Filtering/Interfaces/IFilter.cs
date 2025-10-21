namespace Filtering.Interfaces
{
    public interface IFilter<T> where T : class
    {
        Collection<T> FilterExpression(IEnumerable<T> collection, Expression<Func<T, bool>> expression);
        Collection<T> FilterExpression(Func<T, bool> function, AccessServices accessService);
    }
}
