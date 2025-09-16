namespace Rfq.CQRS.Specification
{
    public class GetRfqProjectReadOnlySpec : Specification<DbRfqProject>
    {
        public GetRfqProjectReadOnlySpec(int? position, int? take)
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
