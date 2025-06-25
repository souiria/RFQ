namespace Master.CQRS.Query.Project
{
    public class GetAllPlatformHierarchiesQuery : IQuery<List<PlatformData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
