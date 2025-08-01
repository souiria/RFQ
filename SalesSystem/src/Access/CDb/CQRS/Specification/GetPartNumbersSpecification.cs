namespace CDb.CQRS.Specification
{
    public class GetPartNumbersSpecification : Specification<DbPartNumber>
    {
        public GetPartNumbersSpecification(int? position, int? take)
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
