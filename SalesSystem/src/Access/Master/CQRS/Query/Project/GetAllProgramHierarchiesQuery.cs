namespace Master.CQRS.Query.Project
{
    public class GetAllProgramHierarchiesQuery : IQuery<List<ProgramData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
