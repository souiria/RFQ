namespace Rfq.CQRS.Specification
{
    public class GetDsiTransformedModuleChildDetailReadOnlySpec : Specification<DbDsiTransformedModuleChildDetail>
    {
        public GetDsiTransformedModuleChildDetailReadOnlySpec(int? position, int? take)
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