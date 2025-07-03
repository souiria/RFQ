namespace Emacs.CQRS.Specification
{
    public class GetPartClassDetailReadOnlySpec : Specification<DbPartClassDetail>
    {
        public GetPartClassDetailReadOnlySpec(int? position, int? take)
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
