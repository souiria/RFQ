namespace Emacs.Data.CQRS.Specification
{
    public class GetMaterialGroupsReadOnlySpec : Specification<DbMaterialGroups>
    {
        public GetMaterialGroupsReadOnlySpec(int? position, int? take)
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
