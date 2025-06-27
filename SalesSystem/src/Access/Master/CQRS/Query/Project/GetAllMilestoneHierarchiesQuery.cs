namespace Master.CQRS.Query.Project
{
    public class GetAllMilestoneHierarchiesQuery : IQuery<List<MilestoneGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
