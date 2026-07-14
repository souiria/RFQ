namespace Rfq.CQRS.Specification
{
    public class GetDsiHarnessScopeScopeAssociationReadOnlySpec : Specification<DbDsiHarnessScopeScopeAssociation>
    {
        public GetDsiHarnessScopeScopeAssociationReadOnlySpec(int? position, int? take)
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