namespace Master.CQRS.Query.Project
{
    public class GetAllPlatformHierarchiesQuery : IQuery<List<PlatformGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
