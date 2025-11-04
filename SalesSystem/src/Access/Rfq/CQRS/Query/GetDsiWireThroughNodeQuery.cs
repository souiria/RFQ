namespace Rfq.CQRS.Query
{
    public class GetDsiWireThroughNodeQuery : IQuery<List<DsiWireThroughNodeGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount 
        { get; set; }
    }
}
