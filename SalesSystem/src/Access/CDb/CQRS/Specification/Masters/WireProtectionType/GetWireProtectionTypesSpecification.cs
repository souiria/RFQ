namespace CDb.CQRS.Specification.Masters.WireProtectionType
{
    public class GetWireProtectionTypesSpecification : Specification<DbWireProtectionType>
    {
        public GetWireProtectionTypesSpecification(int? position, int? take)
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
