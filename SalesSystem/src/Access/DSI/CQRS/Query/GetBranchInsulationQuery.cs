namespace DSI.CQRS.Query
{
    public class GetBranchInsulationQuery : IQuery<List<BranchInsulationGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}