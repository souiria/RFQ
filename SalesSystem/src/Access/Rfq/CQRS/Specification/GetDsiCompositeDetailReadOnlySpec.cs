namespace Rfq.CQRS.Specification
{
    public class GetDsiCompositeDetailReadOnlySpec : Specification<DbDsiCompositeDetail>
    {
        public GetDsiCompositeDetailReadOnlySpec(int? position, int? take)
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