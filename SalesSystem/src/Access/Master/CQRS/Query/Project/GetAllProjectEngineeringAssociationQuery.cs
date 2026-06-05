namespace Master.CQRS.Query.Project
{
    public class GetAllProjectEngineeringAssociationQuery : IQuery<List<ProjectEngineeringAssociationGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
