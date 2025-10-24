namespace Master.CQRS.Specification.Project
{
    public class GetMilestoneHierarchyReadOnlySpec : Specification<DbMilestoneHierarchy>
    {
        public GetMilestoneHierarchyReadOnlySpec(int? position, int? take)
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
