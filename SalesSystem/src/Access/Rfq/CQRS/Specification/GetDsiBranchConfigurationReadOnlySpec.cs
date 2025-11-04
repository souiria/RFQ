namespace Rfq.CQRS.Specification
{
    public class GetDsiBranchConfigurationReadOnlySpec : Specification<DbDsiBranchConfiguration>
    {
        public GetDsiBranchConfigurationReadOnlySpec(int? position, int? take)
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
