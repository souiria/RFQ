namespace Master.CQRS.Specification.Project
{
    public class GetProjectHierarchyReadOnlySpec : Specification<DbProjectHierarchy>
    {
        public GetProjectHierarchyReadOnlySpec(int? position, int? take)
        {
            Query.Where(x => x.IsActive == true);
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
