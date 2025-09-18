namespace Rfq.CQRS.Query
{
    public class GetRfqDrawingPartNumberQuery : IQuery<List<RfqDrawingPartNumbersGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
