namespace Purchasing.CQRS.Query
{
    public class GetH1CPDQuery : IQuery<List<H1CPDGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
