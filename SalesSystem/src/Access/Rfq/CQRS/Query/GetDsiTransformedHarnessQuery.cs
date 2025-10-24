namespace Rfq.CQRS.Query
{
    public class GetDsiTransformedHarnessQuery : IQuery<List<DsiTransformedHarnessGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
