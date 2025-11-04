namespace Rfq.CQRS.Specification
{
    public class GetDsiBranchConfigurationBendAssociationReadOnlySpec : Specification<DbDsiBranchConfigurationBendAssociation>
    {
        public GetDsiBranchConfigurationBendAssociationReadOnlySpec(int? position, int? take)
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
