namespace Master.CQRS.Query.ProjectEngineeringAssociation
{
    public class GetProjectEngineeringAssociationsQuery : IQuery<List<ProjectEngineeringAssociationGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}