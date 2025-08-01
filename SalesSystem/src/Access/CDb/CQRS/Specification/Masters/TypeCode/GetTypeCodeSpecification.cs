namespace CDb.CQRS.Specification.Masters.TypeCode
{
    public class GetTypeCodesSpecification : Specification<DbTypeCode>
    {
        public GetTypeCodesSpecification(int? position, int? take)
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
