namespace Emacs.CQRS.Specification
{
    public class GetPartCatogoryDetailReadOnlySpec : Specification<DbPartCategoryDetail>
    {
        public GetPartCatogoryDetailReadOnlySpec(int? position, int? take)
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
