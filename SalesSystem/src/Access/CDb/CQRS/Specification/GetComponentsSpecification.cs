namespace CDb.CQRS.Specification
{
    public class GetComponentsSpecification : Specification<DbComponent>
    {
        public GetComponentsSpecification(int? position, int? take)
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
