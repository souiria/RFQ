namespace Rfq.CQRS.Specification
{
    public class GetDsiCompositeOptionReadOnlySpec : Specification<DbDsiCompositeOption>
    {
        public GetDsiCompositeOptionReadOnlySpec(int? position, int? take)
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