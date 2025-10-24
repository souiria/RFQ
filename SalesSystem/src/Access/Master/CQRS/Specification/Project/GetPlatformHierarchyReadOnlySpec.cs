namespace Master.CQRS.Specification.Project
{
    public class GetPlatformHierarchyReadOnlySpec : Specification<DbPlatformHierarchy>
    {
        public GetPlatformHierarchyReadOnlySpec(int? position, int? take)
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
