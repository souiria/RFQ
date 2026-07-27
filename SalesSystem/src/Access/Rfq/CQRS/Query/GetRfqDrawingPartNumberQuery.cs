namespace Rfq.CQRS.Query
{
    public class GetRfqDrawingPartNumberQuery : IQuery<List<RfqDrawingPartNumberGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
