namespace Purchasing.CQRS.Specification
{
    public class GetH1CPDReadOnlySpec : Specification<DbH1CPD>
    {
        public GetH1CPDReadOnlySpec(int? position, int? take)
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
