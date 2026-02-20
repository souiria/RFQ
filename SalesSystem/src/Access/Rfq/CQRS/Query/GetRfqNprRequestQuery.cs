namespace Rfq.CQRS.Query
{
    public class GetRfqNprRequestQuery : IQuery<List<RfqNprRequestGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
