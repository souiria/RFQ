namespace Rfq.CQRS.Query
{
    public class GetDsiBranchInsulationThroughNodeQuery : IQuery<List<DsiBranchInsulationThroughNodeGrpc>> 
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
