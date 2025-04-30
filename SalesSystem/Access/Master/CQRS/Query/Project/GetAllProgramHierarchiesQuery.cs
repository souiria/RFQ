namespace Master.CQRS.Query.Project
{
    public class GetAllProgramHierarchiesQuery : IRequest<List<ProgramHierarchyDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
