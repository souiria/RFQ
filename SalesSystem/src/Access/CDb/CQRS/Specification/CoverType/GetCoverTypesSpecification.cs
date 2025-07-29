namespace CDb.CQRS.Specification.CoverType
{
    public class GetCoverTypesSpecification : Specification<DbCoverType>
    {
        public GetCoverTypesSpecification(int? position, int? take)
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
