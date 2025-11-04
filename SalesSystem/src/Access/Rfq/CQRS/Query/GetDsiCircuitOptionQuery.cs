namespace Rfq.CQRS.Query
{
    public class GetDsiCircuitOptionQuery : IQuery<List<DsiCircuitOptionGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
