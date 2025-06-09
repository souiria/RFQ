namespace Emacs.Data.CQRS.Specification
{
    public class GetPartGroupsReadOnlySpec : Specification<DbPartGroups>
    {
        public GetPartGroupsReadOnlySpec(int? position, int? take)
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
