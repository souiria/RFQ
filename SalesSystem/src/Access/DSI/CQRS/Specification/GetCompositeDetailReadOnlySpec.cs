namespace DSI.CQRS.Specification
{
    public class GetCompositeDetailReadOnlySpec : Specification<DbCompositeDetail>
    {
        public GetCompositeDetailReadOnlySpec(int? position, int? take)
        {
            if (position != null && take != null)
            {
                Query.Skip(position.Value)
                     .Take(take.Value)
                     .AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}
