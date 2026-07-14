namespace Rfq.CQRS.Specification
{
    public class GetRfqReasonReadOnlySpec : Specification<DbRfqReason>
    {
        public GetRfqReasonReadOnlySpec(int? position, int? take)
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
