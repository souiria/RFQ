namespace Rfq.CQRS.Specification
{
    public class GetDsiScopeReadOnlySpec : Specification<DbDsiScope>
    {
        public GetDsiScopeReadOnlySpec(int? position, int? take)
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