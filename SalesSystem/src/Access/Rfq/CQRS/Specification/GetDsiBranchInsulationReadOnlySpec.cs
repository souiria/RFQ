namespace Rfq.CQRS.Specification
{
    public class GetDsiBranchInsulationReadOnlySpec : Specification<DbDsiBranchInsulation>
    {
        public GetDsiBranchInsulationReadOnlySpec(int? position, int? take)
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
