namespace Rfq.CQRS.Specification
{
    public class GetDsiMulticoreSpecificationReadOnlySpec : Specification<DbDsiMulticoreSpecification>
    {
        public GetDsiMulticoreSpecificationReadOnlySpec(int? position, int? take)
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