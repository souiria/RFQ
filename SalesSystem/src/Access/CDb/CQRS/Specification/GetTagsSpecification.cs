namespace CDb.CQRS.Specification
{
    public class GetTagsSpecification : Specification<DbTag>
    {
        public GetTagsSpecification(int? position, int? take)
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
