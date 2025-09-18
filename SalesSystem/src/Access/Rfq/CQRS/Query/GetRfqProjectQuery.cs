namespace Rfq.CQRS.Query
{
    public class GetRfqProjectQuery : IQuery<List<RfqProjectGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
