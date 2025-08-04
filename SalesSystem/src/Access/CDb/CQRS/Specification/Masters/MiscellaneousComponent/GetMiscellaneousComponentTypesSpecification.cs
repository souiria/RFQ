namespace CDb.CQRS.Specification.Masters.MiscellaneousComponent
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
