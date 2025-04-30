namespace Master.CQRS.Query.Project
{
    public class GetAllMilestoneHierarchiesQuery : IRequest<List<MilestoneHierarchyDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
