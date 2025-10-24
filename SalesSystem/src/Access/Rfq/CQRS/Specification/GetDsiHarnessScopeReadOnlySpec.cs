namespace Rfq.CQRS.Specification
{
    public class GetDsiHarnessScopeReadOnlySpec : Specification<DbDsiHarnessScope>
    {
        public GetDsiHarnessScopeReadOnlySpec(int? position, int? take)
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