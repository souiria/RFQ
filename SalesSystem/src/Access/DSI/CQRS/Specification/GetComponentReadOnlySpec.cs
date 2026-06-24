namespace DSI.CQRS.Specification
{
    public class GetComponentReadOnlySpec : Specification<DbComponent>
    {
        public GetComponentReadOnlySpec(int? position, int? take)
        {
            if (position != null && take != null)
            {
                Query.Skip(position.Value).Take(take.Value).AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}
