namespace CDb.CQRS.Specification.Masters.WireType
{
    public class GetWireTypesSpecification : Specification<DbWireType>
    {
        public GetWireTypesSpecification(int? position, int? take)
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
