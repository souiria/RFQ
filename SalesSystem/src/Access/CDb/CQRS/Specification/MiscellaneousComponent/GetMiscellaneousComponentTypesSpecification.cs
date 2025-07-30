namespace CDb.CQRS.Specification.MiscellaneousComponentType
{
    public class GetMiscellaneousComponentTypesSpecification : Specification<DbMiscellaneousComponentType>
    {
        public GetMiscellaneousComponentTypesSpecification(int? position, int? take)
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
