namespace Rfq.CQRS.Specification
{
    public class GetDsiWireMulticoreMarkerReadOnlySpec : Specification<DbDsiWireMulticoreMarker>
    {
        public GetDsiWireMulticoreMarkerReadOnlySpec(int? position, int? take)
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