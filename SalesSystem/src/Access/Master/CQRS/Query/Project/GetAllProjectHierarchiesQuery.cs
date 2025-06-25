namespace Master.CQRS.Query.Project
{
    public class GetAllProjectHierarchiesQuery : IQuery<List<ProjectData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}