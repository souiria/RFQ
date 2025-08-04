namespace CDb.CQRS.Specification.Masters.ClipType
{
    public class GetClipTypesSpecification : Specification<DbClipType>
    {
        public GetClipTypesSpecification(int? position, int? take)
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
