namespace CDb.CQRS.Specification.Masters.FuseType
{
    public class GetFuseTypesSpecification : Specification<DbFuseType>
    {
        public GetFuseTypesSpecification(int? position, int? take)
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
