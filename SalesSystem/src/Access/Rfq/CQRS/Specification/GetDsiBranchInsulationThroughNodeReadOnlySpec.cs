namespace Rfq.CQRS.Specification
{
    public class GetDsiBranchInsulationThroughNodeReadOnlySpec : Specification<DbDsiBranchInsulationThroughNode>
    {
        public GetDsiBranchInsulationThroughNodeReadOnlySpec(int? position, int? take)
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
