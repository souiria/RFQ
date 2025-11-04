namespace Rfq.CQRS.Query
{
    public class GetDsiBranchInsulationQuery : IQuery<List<DsiBranchInsulationGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
