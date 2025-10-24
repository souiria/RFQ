namespace Rfq.CQRS.Specification
{
    public class GetDsiWireSpecificationReadOnlySpec : Specification<DbDsiWireSpecification>
    {
        public GetDsiWireSpecificationReadOnlySpec(int? position, int? take)
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