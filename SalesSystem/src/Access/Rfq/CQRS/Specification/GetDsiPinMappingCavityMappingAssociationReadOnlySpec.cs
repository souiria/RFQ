namespace Rfq.CQRS.Specification
{
    public class GetDsiPinMappingCavityMappingAssociationReadOnlySpec : Specification<DbDsiPinMappingCavityMappingAssociation>
    {
        public GetDsiPinMappingCavityMappingAssociationReadOnlySpec(int? position, int? take)
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