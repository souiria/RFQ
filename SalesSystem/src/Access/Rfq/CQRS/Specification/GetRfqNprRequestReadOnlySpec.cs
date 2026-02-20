namespace Rfq.CQRS.Specification
{
    public class GetRfqNprRequestReadOnlySpec : Specification<DbRfqNprRequestModel>
    {
        public GetRfqNprRequestReadOnlySpec(int? position, int? take)
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
