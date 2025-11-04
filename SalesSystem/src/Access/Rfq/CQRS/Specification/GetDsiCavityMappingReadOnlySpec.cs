namespace Rfq.CQRS.Specification
{
    public class GetDsiCavityMappingReadOnlySpec : Specification<DbDsiCavityMapping>
    {
        public GetDsiCavityMappingReadOnlySpec(int? position, int? take)
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
