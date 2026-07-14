namespace Rfq.CQRS.Specification
{
    public class GetDsiCompositeDetailCircuitOptionAssociationReadOnlySpec : Specification<DbDsiCompositeDetailCircuitOptionAssociation>
    {
        public GetDsiCompositeDetailCircuitOptionAssociationReadOnlySpec(int? position, int? take)
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