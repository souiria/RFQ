namespace Master.CQRS.Query.Project
{
    public class GetAllProjectHierarchiesQuery : IQuery<List<ProjectGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}