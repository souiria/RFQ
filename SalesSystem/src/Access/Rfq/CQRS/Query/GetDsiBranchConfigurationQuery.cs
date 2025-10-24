namespace Rfq.CQRS.Query
{
    public class GetDsiBranchConfigurationQuery : IQuery<List<DsiBranchConfigurationGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
