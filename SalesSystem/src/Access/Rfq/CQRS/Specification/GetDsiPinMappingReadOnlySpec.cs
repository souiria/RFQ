namespace Rfq.CQRS.Specification
{
    public class GetDsiPinMappingReadOnlySpec : Specification<DbDsiPinMapping>
    {
        public GetDsiPinMappingReadOnlySpec(int? position, int? take)
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