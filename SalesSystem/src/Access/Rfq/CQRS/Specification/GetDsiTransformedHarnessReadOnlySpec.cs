namespace Rfq.CQRS.Specification
{
    public class GetDsiTransformedHarnessReadOnlySpec : Specification<DbDsiTransformedHarness>
    {
        public GetDsiTransformedHarnessReadOnlySpec(int? position, int? take)
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
