namespace Rfq.CQRS.Query
{
    public class GetRfqReasonQuery : IQuery<List<RfqReasonGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
