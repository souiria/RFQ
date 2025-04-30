namespace Master.CQRS.Query.Project
{
    public class GetAllPlatformHierarchiesQuery : IRequest<List<PlatformHierarchyDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
