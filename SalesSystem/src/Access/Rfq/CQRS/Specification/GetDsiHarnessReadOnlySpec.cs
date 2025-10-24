namespace Rfq.CQRS.Specification
{
    public class GetDsiHarnessReadOnlySpec : Specification<DbDsiHarness>
    {
        public GetDsiHarnessReadOnlySpec(int? position, int? take)
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