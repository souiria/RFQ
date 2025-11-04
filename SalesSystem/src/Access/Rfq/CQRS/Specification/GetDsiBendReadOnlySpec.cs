namespace Rfq.CQRS.Specification
{
    public class GetDsiBendReadOnlySpec : Specification<DbDsiBend>
    {
        public GetDsiBendReadOnlySpec(int? position, int? take)
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
