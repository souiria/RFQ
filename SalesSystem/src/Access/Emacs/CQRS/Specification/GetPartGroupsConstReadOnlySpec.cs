namespace Emacs.CQRS.Specification
{
    public class GetPartGroupsConstReadOnlySpec : Specification<DbPartGroupsConst>
    {
        public GetPartGroupsConstReadOnlySpec(int? position, int? take)
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
