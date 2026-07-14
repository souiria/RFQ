namespace Rfq.CQRS.Query
{
    public class GetDsiBendQuery : IQuery<List<DsiBendGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
