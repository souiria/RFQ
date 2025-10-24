namespace Rfq.CQRS.Query
{
    public class GetDsiCentreStripQuery : IQuery<List<DsiCentreStripGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
