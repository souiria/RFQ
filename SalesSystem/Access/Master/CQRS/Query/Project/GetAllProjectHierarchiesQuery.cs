namespace Master.CQRS.Query.Project
{
    public class GetAllProjectHierarchiesQuery : IRequest<List<ProjectHierarchyDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}