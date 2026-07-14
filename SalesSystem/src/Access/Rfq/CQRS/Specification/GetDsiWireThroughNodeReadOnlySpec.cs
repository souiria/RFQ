namespace Rfq.CQRS.Specification
{
    public class GetDsiWireThroughNodeReadOnlySpec : Specification<DbDsiWireThroughNode>
    {
        public GetDsiWireThroughNodeReadOnlySpec(int? position, int? take)
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