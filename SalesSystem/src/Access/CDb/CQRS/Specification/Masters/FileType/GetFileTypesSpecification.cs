namespace CDb.CQRS.Specification.Masters.FileType
{
    public class GetFileTypesSpecification : Specification<DbFileType>
    {
        public GetFileTypesSpecification(int? position, int? take)
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
