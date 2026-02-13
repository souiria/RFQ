namespace NPR.CQRS.Specification.RFQStatus
{
    public class GetRFQStatusReadOnlySpec : Specification<DbRFQStatus> 
    {
        public GetRFQStatusReadOnlySpec(int? position, int? take)
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
