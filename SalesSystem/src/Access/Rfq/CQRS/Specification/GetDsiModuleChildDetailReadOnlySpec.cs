namespace Rfq.CQRS.Specification
{
    public class GetDsiModuleChildDetailReadOnlySpec : Specification<DbDsiModuleChildDetail>
    {
        public GetDsiModuleChildDetailReadOnlySpec(int? position, int? take)
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