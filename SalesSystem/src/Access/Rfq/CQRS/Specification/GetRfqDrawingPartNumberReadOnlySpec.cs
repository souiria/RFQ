namespace Rfq.CQRS.Specification
{
    public class GetRfqDrawingPartNumberReadOnlySpec : Specification<DbRfqDrawingPartNumber>
    {
        public GetRfqDrawingPartNumberReadOnlySpec(int? position, int? take)
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
