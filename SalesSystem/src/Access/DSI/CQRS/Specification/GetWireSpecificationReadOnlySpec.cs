namespace DSI.CQRS.Specification
{
    public class GetWireSpecificationReadOnlySpec : Specification<DbWireSpecification>
    {
        public GetWireSpecificationReadOnlySpec(int? position, int? take)
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
