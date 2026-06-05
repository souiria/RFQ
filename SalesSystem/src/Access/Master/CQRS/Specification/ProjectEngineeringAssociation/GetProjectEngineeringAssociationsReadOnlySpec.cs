namespace Master.CQRS.Specification.ProjectEngineeringAssociation
{
    public class GetProjectEngineeringAssociationsReadOnlySpec
        : Specification<DbProjectEngineeringAssociation>
    {
        public GetProjectEngineeringAssociationsReadOnlySpec(int? position, int? take)
        {
            Query.Where(x => x.IsActive == true);

            if (position != null && take != null)
            {
                Query.Skip(position.Value)
                     .Take(take.Value)
                     .AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}