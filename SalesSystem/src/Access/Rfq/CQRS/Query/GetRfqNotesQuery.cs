namespace Rfq.CQRS.Query
{
    public class GetRfqNotesQuery : IQuery<List<RfqNotesGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
