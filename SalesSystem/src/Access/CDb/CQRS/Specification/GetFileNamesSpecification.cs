namespace CDb.CQRS.Specification
{
    public class GetFileNamesSpecification : Specification<DbFileName>
    {
        public GetFileNamesSpecification(int? position, int? take)
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
