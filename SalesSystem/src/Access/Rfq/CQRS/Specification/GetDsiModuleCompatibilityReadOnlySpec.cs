namespace Rfq.CQRS.Specification
{
    public class GetDsiModuleCompatibilityReadOnlySpec : Specification<DbDsiModuleCompatibility>
    {
        public GetDsiModuleCompatibilityReadOnlySpec(int? position, int? take)
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